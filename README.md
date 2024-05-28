# Mini proyecto: Itla Tv+

## Índice

1. [Objetivo general](#objetivo-general)
2. [Funcionalidades generales](#funcionalidades-generales)
    - [Home](#home)
    - [Mantenimiento de series](#mantenimiento-de-series)
    - [Mantenimiento de productora](#mantenimiento-de-productora)
    - [Mantenimientos de géneros](#mantenimientos-de-géneros)
3. [Requerimientos técnicos](#requerimientos-técnicos)

---

## Objetivo general

Crear una app de streaming de video usando ASP.NET Core MVC 6, 7 o 8.

---

## Funcionalidades generales

### Home

El sistema en su pantalla inicial tendrá un menú que debe tener las siguientes opciones:

- Una opción para ir al home
- Una opción con el nombre de Series (Debe llevar el mantenimiento de Series)
- Una opción con el nombre de Productora (Debe llevar el mantenimiento de productoras)
- Una opción con el nombre de géneros (Debe llevar el mantenimiento de géneros)

**Ejemplo:**

En esta pantalla de home tendrá un listado con todas las series creadas en el sistema, de las series se debe mostrar el nombre de la serie, la imagen de portada, los géneros a los que pertenece y la productora a la cual pertenece. También, debajo de esta información, tendrá un botón que permitirá ir al detalle de la serie.

Al hacer click sobre el botón de detalle se debe enviar al usuario a una pantalla nueva donde se visualizará el título de la serie y debajo de este título un reproductor de video para poder visualizar la serie según el enlace guardado (para esto usaremos videos de YouTube).

Además del listado en la pantalla del home debemos tener la posibilidad de realizar los siguientes filtros o búsqueda:

- Se debe poder realizar búsqueda por el nombre de la serie, para esto debe haber un formulario con un input de texto donde el usuario coloque el nombre de la serie y un botón para realizar la búsqueda.
- Se debe tener un formulario para poder filtrar las series por las productoras. Para esto debe haber un listado con todas las productoras creadas en el sistema de manera que podamos seleccionar una de ellas y al pulsar sobre un botón de filtrar se muestren solo las series de esa productora (ejemplo: si seleccionan la productora de Sony solo saldrán las series de esa productora).

**Ejemplo de filtro:**

Finalmente, se debe tener un formulario para poder filtrar las series por los géneros. Para esto debe haber un listado con todos los géneros creados en el sistema de manera que podamos seleccionar uno de ellos y al pulsar sobre un botón de filtrar se muestren solo las series de ese género, ya sea esa serie lo tenga como género primario o secundario (ejemplo: si selecciona el género comedia solo saldrán las series de ese género, ya sea una serie que sea romántica como género principal y comedia como secundario o comedia como principal y acción como secundario).

---

### Mantenimiento de series

Al ingresar a la opción de series desde el menú principal de la app, esta nos enviará al mantenimiento de series.

En la pantalla inicial de este mantenimiento debemos tener un listado con todas las series creadas en el sistema. De las series se debe mostrar el nombre de la serie, la imagen de portada, los géneros que tiene y la productora a la cual pertenece. Aparte de mostrar esta información, cada serie debe tener un botón para editar la serie y otro para eliminarla.

Arriba del listado de las series debe haber un botón para crear una serie nueva. Al hacer clic sobre este botón de crear se enviará al usuario a una pantalla nueva donde habrá un formulario con los siguientes campos:

- Nombre de la serie (input text)
- Imagen de portada (input text)
- Enlace del video de YouTube (input text)
- Productora a la que pertenece la serie (select con las productoras creadas en el sistema)
- Género primario (select con todos los géneros creados en el sistema)
- Género secundario (select con los géneros creados en el sistema)

Este formulario debe tener las siguientes validaciones: tanto el nombre, como la productora, la imagen de portada, el enlace del video y el género primario son campos requeridos.

Al final del formulario de creación debe haber dos botones: un botón para volver atrás que devuelve a la pantalla inicial del mantenimiento donde están listadas las series y otro botón para crear la serie. Al hacer clic en el botón se envía la información y se crea la serie. Una vez creada la serie se debe redirigir a la pantalla inicial de mantenimiento de series.

En el listado de series del mantenimiento, cada serie tiene su botón para editarla o borrarla. Al presionar sobre el botón editar se debe enviar al usuario a una pantalla con un formulario con los siguientes campos:

- Nombre de la serie (input text)
- Imagen de portada (input text)
- Enlace del video de YouTube (input text)
- Productora a la que pertenece la serie (select con las productoras creadas en el sistema)
- Género primario (select con todos los géneros creados en el sistema)
- Género secundario (select con los géneros creados en el sistema)

Como es una edición, estos campos deben venir con los valores guardados para la serie que estamos editando.

Este formulario debe tener las siguientes validaciones: tanto el nombre, como la productora, la imagen de portada, el enlace del video y el género primario son campos requeridos.

Al final del formulario de edición debe haber dos botones: un botón para volver atrás que devuelve a la pantalla inicial del mantenimiento donde están listadas las series y otro botón para guardar la serie. Al hacer clic en el botón se envía la información y se edita la serie con los valores nuevos. Una vez editada la serie se debe redirigir a la pantalla inicial de mantenimiento de series.

Finalmente, al presionar sobre el botón de eliminar se envía al usuario a una pantalla con un mensaje que debe decir: "¿Está seguro que desea eliminar esta serie?" Debajo de este mensaje, dos botones: uno de cancelar y otro de aceptar. Si se pulsa sobre cancelar se envía a la pantalla inicial del mantenimiento de serie (El listado), pero al presionar sobre el aceptar se elimina la serie y se redirecciona a la pantalla inicial del mantenimiento de series (El listado).

---

### Mantenimiento de productora

Al ingresar a la opción de productoras desde el menú principal de la app, esta nos enviará al mantenimiento de productoras.

En la pantalla inicial de este mantenimiento debemos tener un listado con todas las productoras creadas en el sistema. De las productoras se debe mostrar el nombre de la productora. Aparte de mostrar esta información, cada productora debe tener un botón para editar la productora y otro para eliminarla.

Arriba del listado de productoras debe haber un botón para crear una productora nueva. Al hacer clic sobre este botón de crear se enviará al usuario a una pantalla nueva donde habrá un formulario con los siguientes campos:

- Nombre de la productora

Este formulario debe tener las siguientes validaciones para que el nombre de la productora sea un campo requerido.

Al final del formulario de creación debe haber dos botones: un botón para volver atrás que devuelve a la pantalla inicial del mantenimiento donde están listadas las productoras y otro botón para crear la productora. Al hacer clic en el botón se envía la información y se crea la productora. Una vez creada la productora se debe redirigir a la pantalla inicial de mantenimiento de productoras.

En el listado de productoras del mantenimiento, cada productora tiene su botón para editarla o borrarla. Al presionar sobre el botón de editar se debe enviar al usuario a una pantalla con un formulario con los siguientes campos:

- Nombre de la productora

Como es una edición, estos campos deben venir con los valores guardados para la productora que estamos editando.

Este formulario debe tener las siguientes validaciones para que el nombre de la productora sea un campo requerido.

Al final del formulario de edición debe haber dos botones: un botón para volver atrás que devuelve a la pantalla inicial del mantenimiento donde están listadas las productoras y otro botón para guardar la productora. Al hacer clic en el botón se envía la información y se edita la productora con los valores nuevos. Una vez editada la productora se debe redirigir a la pantalla inicial de mantenimiento de productoras.

Finalmente, al presionar sobre el botón de eliminar se envía al usuario a una pantalla con un mensaje que debe decir: "¿Está seguro que desea eliminar esta productora?" Debajo de este mensaje, dos botones: uno de cancelar y otro de aceptar. Si se pulsa sobre cancelar se envía a la pantalla inicial del mantenimiento de productoras (El listado), pero al presionar sobre el aceptar se elimina la productora y se redirecciona a la pantalla inicial del mantenimiento de productoras (El listado).

---

### Mantenimientos de géneros

Al ingresar a la opción de géneros desde el menú principal de la app, esta nos enviará al mantenimiento de géneros.

En la pantalla inicial de este mantenimiento debemos tener un listado con todos los géneros creados en el sistema. De los géneros se debe mostrar el nombre del género. Aparte de mostrar esta información, cada género debe tener un botón para editar el género y otro para eliminarlo.

Arriba del listado de géneros debe haber un botón para crear un género nuevo. Al hacer clic sobre este botón de crear se enviará al usuario a una pantalla nueva donde habrá un formulario con los siguientes campos:

- Nombre del género

Este formulario debe tener las siguientes validaciones para que el nombre del género sea un campo requerido.

Al final del formulario de creación debe haber dos botones: un botón para volver atrás que devuelve a la pantalla inicial del mantenimiento donde están listados los géneros y otro botón para crear el género. Al hacer clic en el botón se envía la información y se crea el género. Una vez creado el género se debe redirigir a la pantalla inicial de mantenimiento de géneros.

En el listado de géneros del mantenimiento, cada género tiene su botón para editarlo o borrarlo. Al presionar sobre el botón de editar se debe enviar al usuario a una pantalla con un formulario con los siguientes campos:

- Nombre del género

Como es una edición, estos campos deben venir con los valores guardados para el género que estamos editando.

Este formulario debe tener las siguientes validaciones para que el nombre del género sea un campo requerido.

Al final del formulario de edición debe haber dos botones: un botón para volver atrás que devuelve a la pantalla inicial del mantenimiento donde están listados los géneros y otro botón para guardar el género. Al hacer clic en el botón se envía la información y se edita el género con los valores nuevos. Una vez editado el género se debe redirigir a la pantalla inicial de mantenimiento de géneros.

Finalmente, al presionar sobre el botón de eliminar se envía al usuario a una pantalla con un mensaje que debe decir: "¿Está seguro que desea eliminar este género?" Debajo de este mensaje, dos botones: uno de cancelar y otro de aceptar. Si se pulsa sobre cancelar se envía a la pantalla inicial del mantenimiento de géneros (El listado), pero al presionar sobre el aceptar se elimina el género y se redirecciona a la pantalla inicial del mantenimiento de géneros (El listado).

---

## Requerimientos técnicos

Para este proyecto se requiere el uso de:

- ASP.NET Core MVC (versiones 6, 7 o 8)
- Base de datos SQL Server o MySQL
- Entity Framework Core para acceso a datos
- Bootstrap para el diseño responsivo
- Control de versiones con Git

---

