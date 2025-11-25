using GestionMascotas.Models;

namespace GestionMascotas;

public partial class ListaMascotasPage : ContentPage
{
    public ListaMascotasPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarMascotas(null, null);
    }

    private async void CargarMascotas(object sender, EventArgs e)
    {
        var lista = await App.Database.Table<Mascota>().ToListAsync();
        lstMascotas.ItemsSource = lista;
    }

    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        int id = (int)button.CommandParameter;

        bool confirmar = await DisplayAlert("Eliminar", "¿Seguro que desea eliminar?", "Sí", "No");
        if (confirmar)
        {
            var mascota = await App.Database.Table<Mascota>().Where(m => m.Id == id).FirstOrDefaultAsync();
            if (mascota != null)
            {
                await App.Database.DeleteAsync(mascota);
                CargarMascotas(null, null);
            }
        }
    }
}