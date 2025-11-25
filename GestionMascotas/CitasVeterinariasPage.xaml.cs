using GestionMascotas.Models;

namespace GestionMascotas;

public partial class CitasVeterinariasPage : ContentPage
{
    public CitasVeterinariasPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarCitas();
    }

    private async void CargarCitas()
    {
        lstCitas.ItemsSource = await App.Database.Table<CitaVeterinaria>()
                                            .OrderByDescending(c => c.Fecha)
                                            .ToListAsync();
    }

    private async void OnAgendarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entMascotaCita.Text)) return;

        var cita = new CitaVeterinaria
        {
            NombreMascota = entMascotaCita.Text,
            Motivo = entMotivo.Text,
            Fecha = dpFecha.Date
        };

        await App.Database.InsertAsync(cita);

        entMascotaCita.Text = string.Empty;
        entMotivo.Text = string.Empty;
        CargarCitas();
    }

    private async void OnEliminarCitaClicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        int id = (int)btn.CommandParameter;

        var item = await App.Database.Table<CitaVeterinaria>().Where(x => x.Id == id).FirstOrDefaultAsync();
        if (item != null)
        {
            await App.Database.DeleteAsync(item);
            CargarCitas();
        }
    }
}