using ProyectoP2.ViewModels;

namespace ProyectoP2;

public partial class Citas : ContentPage
{
    private readonly CitasViewModel viewModel;

    public Citas()
    {
        InitializeComponent();
        viewModel = new CitasViewModel();
        BindingContext = viewModel;
    }

    private async void botonRegistrarCitas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrarCitas());
    }

    private async void botonVerCitas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VerCitas());
    }

}

