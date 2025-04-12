import os
import json
import pika
import django
from django.conf import settings
from django.http import JsonResponse
from django.views.decorators.csrf import csrf_exempt
from django.urls import path
from django.core.management import execute_from_command_line

# Configuración básica de Django
settings.configure(
    DEBUG=True,
    SECRET_KEY='factura_secret_key',
    ROOT_URLCONF=__name__,
    ALLOWED_HOSTS=["*"],
    MIDDLEWARE=[],
    INSTALLED_APPS=[],
)

django.setup()

# Configuración RabbitMQ (ajusta según sea necesario)
RABBITMQ_CONFIG = {
    "username": "admin",
    "password": "admin",
    "virtualHost": "/",
    "port": 5672,
    "hostname": "localhost"
}

def get_rabbitmq_connection():
    credentials = pika.PlainCredentials(
        username=RABBITMQ_CONFIG["username"],
        password=RABBITMQ_CONFIG["password"]
    )
    parameters = pika.ConnectionParameters(
        host=RABBITMQ_CONFIG["hostname"],
        port=RABBITMQ_CONFIG["port"],
        virtual_host=RABBITMQ_CONFIG["virtualHost"],
        credentials=credentials
    )
    return pika.BlockingConnection(parameters)

@csrf_exempt
def factura_view(request):
    if request.method != 'POST':
        return JsonResponse({'error': 'Método no permitido'}, status=405)

    try:
        data = json.loads(request.body)
        required_fields = ['nombre', 'apellido', 'telefono', 'correo']
        if not all(field in data for field in required_fields):
            return JsonResponse({'error': 'Faltan campos requeridos'}, status=400)

        connection = get_rabbitmq_connection()
        channel = connection.channel()
        channel.queue_declare(queue='facturaMensaje', durable=True)

        channel.basic_publish(
            exchange='',
            routing_key='facturaMensaje',
            body=json.dumps(data),
            properties=pika.BasicProperties(delivery_mode=2)
        )

        connection.close()
        return JsonResponse({'mensaje': 'Factura enviada correctamente'})

    except Exception as e:
        print("🔥 Error en el backend:", str(e))
        return JsonResponse({'error': str(e)}, status=500)

# Rutas Django
urlpatterns = [
    path('api/factura', factura_view),
]

# Ejecutar servidor Django
if __name__ == '__main__':
    os.environ.setdefault('DJANGO_SETTINGS_MODULE', '__main__')
    execute_from_command_line(['manage.py', 'runserver', '8000'])