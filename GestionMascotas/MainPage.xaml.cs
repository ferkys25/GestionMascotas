using GestionMascotas.Models;

namespace GestionMascotas;

public partial class MainPage : ContentPage
{
    // Solo debe haber UN constructor: public MainPage()
    public MainPage()
    {
        InitializeComponent();
    }

    private async void IrRegistroMascotas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistroMascotasPage());
    }

    private async void IrListaMascotas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaMascotasPage());
    }

    private async void IrMedicinas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MedicinasPage());
    }

    private async void IrCitas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CitasVeterinariasPage());
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }
}