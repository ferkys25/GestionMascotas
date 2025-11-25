using GestionMascotas.Models;
using SQLite;

namespace GestionMascotas;

public partial class App : Application
{
    // Conexión estática para acceso global simple (sin inyección de dependencias)
    public static SQLiteAsyncConnection Database;

    public App()
    {
        InitializeComponent();

        // Configurar base de datos
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "GestionMascotas.db3");
        Database = new SQLiteAsyncConnection(dbPath);

        // Crear tablas
        Database.CreateTableAsync<Usuario>().Wait();
        Database.CreateTableAsync<Mascota>().Wait();
        Database.CreateTableAsync<Medicina>().Wait();
        Database.CreateTableAsync<CitaVeterinaria>().Wait();

        // Crear usuario admin por defecto si no existe
        CrearUsuarioPorDefecto();

        // Configurar NavigationPage
        MainPage = new NavigationPage(new LoginPage());
    }

    private async void CrearUsuarioPorDefecto()
    {
        var usuario = await Database.Table<Usuario>().FirstOrDefaultAsync();
        if (usuario == null)
        {
            await Database.InsertAsync(new Usuario { Username = "admin", Password = "123" });
        }
    }
}