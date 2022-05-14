# Unidad-de-Transporte
El siguiente software fue diseñado para ser utilizado en la Unidad de Transporte del Hospital General San Vicente de Paúl, en Ibarra-Ecuador. La implementación consta de 2 partes bien diferenciadas:

1. Inspección de las ambulancias.
2. Orden de movilización, Autorización de Salida, e Informes y Hojas de Ruta.

## Dependencias
1. Visual Studio 2019/2022 (C#)
2. PostgreSQL 13.4

## Ejecución

### 1. Creación de la base de datos
Es necesario crear la base de datos con el nombre unidad_transporte. Los archivos db1.sql y db2.sql contienen el código sql necesario para la generación de tablas para la Inspección de Ambulancias, y las Órdenes de movilización, Autorización de Salida, e Informes y Hojas de Ruta, respectivamente.

Posteriormente se requiere editar el archivo main.cs, ubicado en el directorio Unidad-de-Transporte, para configurar el servidor, puerto, nombre, usuario, y contraseña de la base de datos.


### 2. Ejecución y edición del programa con Visual Studio 2019/2022

El archivo Unidad de Transporte.sln se ejecuta con Visual Studio. Este permite acceder a la edición de cada una de las ventanas, controles, y funciones del software. 

## Inspección de ambulancias
En esta parte del software se desarrolló un programa que permita el llenado del formulario de Inspección Diaria de Ambulancias. Además de ello, una ventana que permite la búsqueda de reportes por No. de Reporte y Fecha, así como la visualización de dichos documentos.

### Archivos útiles
El directorio Inspección de Ambulancia contiene:

1. El formulario del hospital que fue implementado en el software en formato DOC y PDF.
2. Un diagrama de la base de datos.
3. Imágenes del llenado del formulario en el hospital.

**NOTA** 

Las tablas limpieza, cabina_exterior, cabina_interior, documentos heredan la estructura de la tabla preguntas.

### Repositorio 
Para proporcionar acceso al repositorio original únicamente destinado al software Inspección de ambulancias, contactarse al correo brian.crespo@yachaytech.edu.ec.

### Generación aleatoria de datos
Para realizar pruebas con el software y generar reportes con datos aleatorios, se hizo uso del archivo data_random.py. Las librerias necesarias se pueden instalar mediante el comando: 

~~~
pip install -r requirements.txt
~~~

Se requiere además editar el archivo data_random.py para configurar las credenciales de la base de datos.

## Trabajo Futuro
Las futuras implementaciones que podrían realizarse consistirían en la implementación de una función para imprimir un reporte determinado, cuando este es generado.


##    Transporte
En esta parte del software se desarrolló un programa el cual se divide en tres partes. En la primera parte, se llena el formulario de Orden de Movilización con todos los campos requeridos. En la segunda parte, se llena el formulario de Autorización de Salida. Cabe mencionar que en esta parte se vuelve a tomar ciertos datos de la primera parte y además se llenan los nuevos campos requeridos. Finalmente tenemos la tercera parte, donde se prodrá realizar la busqueda tanto de la Hoja de Ruta como del Informe de Movilización ya sea con el No. de Reporte, Fecha, No. de Vehículo o el Conductor.

### Archivos útiles
El directorio Transporte Documentos contiene:

1. El formulario tanto de la Orden de Movilización, Autorización de Salida, Hoja de Ruta e Informe de Movilización en formato PDF.
2. Imágenes del llenado de los formularios en el hospital a exepción del formulario de Informe de Movilización el cual no fue puesto a disposición.
3. Un archivo en formato DOC de las Unidades de traslado.

**NOTA**

La tabla destino_no_bd fue creada ya que que existen destinos de traslados que no estan registrados en la BD (tabla destino) por lo que se creo esta nueva tabla para poder guardar los nuevos destinos. Por otra parte, la tabla solicitante_sin_destino fue creada ya que puede existir la posiblidad de que la movilización no incluya a un paciente por lo que se necesita conocer el destino de movilización. Dicho destino es guarado en la tabla en mención.

### Repositorio 
Para más información únicamente destinado al software Orden de movilización, Autorización de Salida, e Informes y Hojas de Ruta, contactarse al correo santiago.ajala@yachaytech.edu.ec.
