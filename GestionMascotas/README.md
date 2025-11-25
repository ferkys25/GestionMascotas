# GestionMascotas - Aplicación .NET MAUI

**GestionMascotas** es una aplicación móvil desarrollada en **.NET MAUI** diseñada para administrar la información básica de una clínica veterinaria. Permite el control de usuarios, registro de mascotas, inventario de medicinas y agenda de citas veterinarias mediante una base de datos local.

## Funcionalidad General

La aplicación cuenta con un sistema de autenticación y cuatro módulos principales de gestión:

1.  **Inicio de Sesión (Login):**
    * Validación de credenciales contra base de datos.
    * Creación automática de un usuario administrador por defecto (`admin` / `123`).
2.  **Registro de Mascotas:** Formulario para ingresar nombre, especie y edad.
3.  **Listado de Mascotas:** Visualización de registros y opción para eliminar mascotas de la base de datos.
4.  **Inventario de Medicinas:** Gestión rápida (agregar/eliminar) de medicamentos y dosis.
5.  **Citas Veterinarias:** Agenda de citas vinculando una mascota, un motivo y una fecha.

Toda la información persiste localmente utilizando **SQLite**.

---

## Arquitectura y Layout

El proyecto ha sido diseñado priorizando la simplicidad y la funcionalidad directa, sin el uso de capas complejas ni patrones como MVVM.

### 1. Estructura de Navegación
Se utiliza **`NavigationPage`** como contenedor principal. Esto permite una navegación jerárquica basada en una pila (Stack Navigation):
* **PushAsync:** Para entrar a los módulos (agrega páginas a la pila).
* **PopAsync:** Para regresar al menú principal (elimina la página actual de la pila).
* **Manipulación de `MainPage`:** En el Login, se reemplaza la raíz de la navegación para evitar que el usuario regrese a la pantalla de acceso con el botón "atrás".

### 2. Contenedores de Diseño (Layouts)
Para la interfaz de usuario (XAML) se utilizaron los siguientes controles de distribución:

* **VerticalStackLayout:** Utilizado en los formularios (Login, Registro) para apilar elementos verticalmente de forma sencilla y ordenada con espaciado uniforme (`Spacing`).
* **Grid:** Implementado en las celdas de las listas (`ViewCell`) y en páginas compuestas para dividir el espacio en filas y columnas proporcionales (ej. botón de eliminar alineado a la derecha, texto a la izquierda).
* **ListView:** Componente principal para visualizar las colecciones de datos (Mascotas, Medicinas, Citas). Permite el reciclaje de celdas y la actualización de datos mediante `ItemsSource`.

### 3. Lógica de Datos
* **Patrón:** Code-Behind. Toda la lógica de interacción y acceso a datos se encuentra en los archivos `.xaml.cs` correspondientes a cada vista.
* **Persistencia:** `sqlite-net-pcl` con conexión asíncrona (`SQLiteAsyncConnection`).

---

## Cómo ejecutar el proyecto

1.  **Requisitos:** Visual Studio 2022 con la carga de trabajo ".NET Multi-platform App UI development" instalada.
2.  Clonar el repositorio o descargar el código fuente.
3.  Abrir la solución `GestionMascotas.sln`.
4.  Compilar y ejecutar en un Emulador Android o Windows Machine.

### Credenciales de Acceso
Al iniciar la aplicación por primera vez, use:
* **Usuario:** `admin`
* **Contraseña:** `123`

---