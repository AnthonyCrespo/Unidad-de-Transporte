# Unidad-de-Transporte
El siguiente software fue diseñado para ser utilizado en la Unidad de Transporte del Hospital General San Vicente de Paúl, en Ibarra-Ecuador. La implementación consta de 2 partes bien diferenciadas:

1. Inspección de las ambulancias.
2. Orden de movilización, Autorización de Salida, e Informes y Hojas de Ruta.

## Dependencias
1. Visual Studio 2019/2022 (C#)
2. PostgreSQL 13.4

## Ejecución

### 1. Creación de la base de datos.
Es necesario crear la base de datos con el nombre unidad_transporte. Los archivos db1.sql y db2.sql contienen el código sql necesario para la generación de tablas para la Inspección de Ambulancias, y las Órdenes de movilización, Autorización de Salida, e Informes y Hojas de Ruta, respectivamente.

Posteriormente se requiere editar el archivo main.cs, ubicado en el directorio Unidad-de-Transporte, para configurar el servidor, puerto, nombre, usuario, y contraseña de la base de datos.


### 2. Ejecución y edición del programa con Visual Studio 2019/2022.

El archivo Unidad de Transporte.sln se ejecuta con Visual Studio. Este permite acceder a la edición de cada una de las ventanas, controles, y funciones del software. 

