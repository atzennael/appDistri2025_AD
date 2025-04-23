import sys
from django.conf import settings
from django.core.management import execute_from_command_line
from django.http import JsonResponse
from django.urls import path
from django.views.decorators.csrf import csrf_exempt
import django
import psycopg2

# Configuración mínima de Django
settings.configure(
    DEBUG=True,
    SECRET_KEY='dev',
    ROOT_URLCONF=__name__,  # 👈 Esto es clave
    ALLOWED_HOSTS=['*'],
    MIDDLEWARE=[
        'django.middleware.common.CommonMiddleware',
    ],
)

# Configuración de PostgreSQL
POSTGRES_CONFIG = {
    'dbname': 'BDDFACTURA',
    'user': 'postgres',
    'password': 'admin',
    'host': 'database-postgres',
    'port': 5432,
}

print("¡Conectado!")

# Vista
@csrf_exempt
def get_facturas_postgres(request):
    if request.method not in ['GET', 'POST']:
        return JsonResponse({'error': 'Método no permitido'}, status=405)
    try:
        conn = psycopg2.connect(**POSTGRES_CONFIG)
        cursor = conn.cursor()
        cursor.execute('SELECT * FROM "VentaDetalles"')
        rows = cursor.fetchall()
        columns = [desc[0] for desc in cursor.description]
        data = [dict(zip(columns, row)) for row in rows]
        cursor.close()
        conn.close()
        return JsonResponse(data, safe=False)
    except Exception as e:
        return JsonResponse({'error': str(e)}, status=500)

# Rutas
urlpatterns = [
    path('api/cola-facturas', get_facturas_postgres),
]

# Inicializar Django
django.setup()

if __name__ == '__main__':
    print("🔗 URL patterns activos:")
    for u in urlpatterns:
        print(" -", u.pattern)
    execute_from_command_line(sys.argv)
