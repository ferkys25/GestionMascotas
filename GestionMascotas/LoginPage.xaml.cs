using GestionMascotas.Models;

namespace GestionMascotas;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string user = txtUsuario.Text;
        string pass = txtPassword.Text;

        if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
        {
            await DisplayAlert("Error", "Ingrese usuario y contraseña", "OK");
            return;
        }

        // Validación directa contra SQLite
        var usuarioEncontrado = await App.Database.Table<Usuario>()
            .Where(u => u.Username == user && u.Password == pass)
            .FirstOrDefaultAsync();

        if (usuarioEncontrado != null)
        {
            // Navegar a MainPage y borrar la pila de navegación anterior
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "Credenciales incorrectas", "OK");
        }
    }
}