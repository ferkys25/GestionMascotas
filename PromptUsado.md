🧩 Estructura General del Prompt para Aplicación .NET MAUI (XAML + C#, sin capas, con SQLite)

Crea una aplicación funcional en **.NET MAUI** con las siguientes características:

1. **Nombre de la aplicación:** `GestionMascotas`

2. **Pantalla de Login** (`LoginPage.xaml` + `LoginPage.xaml.cs`):
   * Controles: Entry para usuario, Entry para contraseña (con `IsPassword="True"`), botón "Iniciar sesión"
   * Validación contra base de datos SQLite local (tabla `Usuarios`)
   * Si la validación es exitosa, navegar a la pantalla principal

3. **Pantalla Principal** (`MainPage.xaml` + `MainPage.xaml.cs`):
   * Mostrar saludo al usuario autenticado
   * Lista de botones para acceder a módulos

4. **Módulos** (cada módulo con su propio `.xaml` y `.xaml.cs`):
   * Módulos a incluir: `RegistroMascotas`, `ListaMascotas`, `Medicinas`, `CitasVeterinarias`
   * Funcionalidad básica para cada módulo:
     - Listar registros desde SQLite
     - Agregar nuevos registros
     - Eliminar registros

5. **Base de datos SQLite**:
   * Usar `sqlite-net-pcl`
   * Crear base de datos y tablas al iniciar la app si no existen
   * Ejecutar las operaciones CRUD dentro de los archivos `.xaml.cs`

6. **Navegación**:
   * Usar `Navigation.PushAsync()` para cambiar entre páginas
   * Configurar `NavigationPage` en `App.xaml.cs` para habilitar navegación

7. **Código completo**:
   * Incluir todos los archivos `.xaml` y `.xaml.cs` necesarios:
     - `App.xaml` y `App.xaml.cs`
     - `LoginPage.xaml` y `LoginPage.xaml.cs`
     - `MainPage.xaml` y `MainPage.xaml.cs`
     - Cada módulo: `RegistroMascotasPage.xaml` y `RegistroMascotasPage.xaml.cs`
     - Cada módulo: `ListaMascotasPage.xaml` y `ListaMascotasPage.xaml.cs`
     - Cada módulo: `MedicinasPage.xaml` y `MedicinasPage.xaml.cs`
     - Cada módulo: `CitasVeterinariasPage.xaml` y `CitasVeterinariasPage.xaml.cs`
   * Código funcional listo para compilar y ejecutar en Visual Studio

8. **Restricciones**:
   * No usar MVVM, capas ni inyección de dependencias
   * Toda la lógica en los archivos `.xaml.cs`
   * Sin usar Shell ni patrones complejos

**Nota:** Proporciona el código completo y funcional para cada archivo, incluyendo la estructura de tablas SQLite para cada módulo y todas las operaciones CRUD necesarias.