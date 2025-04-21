@echo off
echo Deteniendo y eliminando contenedores y volúmenes existentes...
docker-compose down -v

echo Levantando el contenedor de MariaDB...
docker-compose up -d

echo El contenedor se ha levantado nuevamente con la inicialización actualizada.
pause
