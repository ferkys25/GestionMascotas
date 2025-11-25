using GestionMascotas.Models;

namespace GestionMascotas;

public partial class MedicinasPage : ContentPage
{
    public MedicinasPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarMedicinas();
    }

    private async void CargarMedicinas()
    {
        lstMedicinas.ItemsSource = await App.Database.Table<Medicina>().ToListAsync();
    }

    private async void OnAgregarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entNombreMed.Text)) return;

        var med = new Medicina
        {
            NombreMedicina = entNombreMed.Text,
            Dosis = entDosis.Text
        };

        await App.Database.InsertAsync(med);

        // Limpiar campos y recargar
        entNombreMed.Text = string.Empty;
        entDosis.Text = string.Empty;
        CargarMedicinas();
    }

    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        int id = (int)btn.CommandParameter;

        var item = await App.Database.Table<Medicina>().Where(x => x.Id == id).FirstOrDefaultAsync();
        if (item != null)
        {
            await App.Database.DeleteAsync(item);
            CargarMedicinas();
        }
    }
}