using GestionMascotas.Models;

namespace GestionMascotas;

public partial class RegistroMascotasPage : ContentPage
{
    public RegistroMascotasPage()
    {
        InitializeComponent();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entNombre.Text) || string.IsNullOrWhiteSpace(entEspecie.Text))
        {
            await DisplayAlert("Error", "Complete los campos", "OK");
            return;
        }

        int.TryParse(entEdad.Text, out int edad);

        var nuevaMascota = new Mascota
        {
            Nombre = entNombre.Text,
            Especie = entEspecie.Text,
            Edad = edad
        };

        await App.Database.InsertAsync(nuevaMascota);
        await DisplayAlert("Éxito", "Mascota registrada", "OK");
        await Navigation.PopAsync(); // Volver al menú
    }
}