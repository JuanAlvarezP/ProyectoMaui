using ProyectoP2.ViewModels;

namespace ProyectoP2
{
    public partial class Animales : ContentPage
    {
        private readonly AnimalesViewModel viewModel;

        public Animales()
        {
            InitializeComponent();
            viewModel = new AnimalesViewModel();
            BindingContext = viewModel;
        }

        private async void botonRegistrarAnimales(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarAnimales(viewModel.Animales));
        }


        private async void botonVerAnimales(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerAnimales(viewModel.Animales));
        }
    }
}

