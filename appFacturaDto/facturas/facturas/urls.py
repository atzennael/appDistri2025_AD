
from django.contrib import admin
from django.urls import path
from facturas.views import get_facturas_postgres  # importa la vista

urlpatterns = [
    path('admin/', admin.site.urls),
    path('api/cola-facturas', get_facturas_postgres),  # la ruta que te interesa
]
