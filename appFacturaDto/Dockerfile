# Etapa de build
FROM python:3.11-slim AS build-env

# Establecer el directorio de trabajo en el contenedor
WORKDIR /app

# Copiar solo el contenido necesario al contenedor
COPY facturas/ /app/facturas/

# Crear un entorno virtual para el contenedor
RUN python -m venv /app/venv

# Instalar dependencias en el entorno virtual
RUN /app/venv/bin/pip install --upgrade pip && /app/venv/bin/pip install -r /app/facturas/requirements.txt

# Etapa de runtime
FROM python:3.11-slim

# Establecer el directorio de trabajo
WORKDIR /app/facturas

# Copiar los archivos del build, incluyendo el entorno virtual
COPY --from=build-env /app/facturas /app/facturas
COPY --from=build-env /app/venv /app/venv

# Establecer el entorno virtual como el predeterminado para ejecutar comandos
ENV PATH="/app/venv/bin:$PATH"

# Exponer el puerto 8000 (o el puerto que uses)
EXPOSE 8000

# Comando para ejecutar el contenedor usando el entorno virtual
CMD ["python", "manage.py", "runserver", "0.0.0.0:8000"]

