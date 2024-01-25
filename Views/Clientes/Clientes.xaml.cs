using ProyectoP2.ViewModels;

namespace ProyectoP2;

public partial class Clientes : ContentPage
{
    private ClientesViewModel viewModel;

    public Clientes()
    {
        InitializeComponent();
        viewModel = new ClientesViewModel();
        BindingContext = viewModel;
    }

    private async void botonRegistrarClientes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrarClientes());
    }

    private async void botonVerClientes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VerClientes());
    }
}