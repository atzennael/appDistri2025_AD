from django.http import JsonResponse
from django.views.decorators.csrf import csrf_exempt
import psycopg2

@csrf_exempt
def get_facturas_postgres(request):
    if request.method not in ['GET', 'POST']:
        return JsonResponse({'error': 'Método no permitido'}, status=405)
    try:
        conn = psycopg2.connect(
            dbname='BDDFACTURA',
            user='postgres',
            password='admin',
            host='database-postgres',
            port=5432
        )
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