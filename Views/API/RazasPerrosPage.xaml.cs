using ProyectoP2.ViewModels;
using ProyectoP2.Models;

namespace ProyectoP2
{
    public partial class RazasPerrosPage : ContentPage
    {
        private readonly RazasPerrosViewModel _viewModel;

        public RazasPerrosPage()
        {
            InitializeComponent();
            _viewModel = new RazasPerrosViewModel();
            BindingContext = _viewModel;
        }

        private async void OnMostrarSiguienteImagenClicked(object sender, EventArgs e)
        {
              var randomImageApiResponse = await _viewModel.GetRandomImagen();
              var Raza = await _viewModel.GetListaRaza();

            if (randomImageApiResponse.Status == "success")
            {
                ImagenPerro.Source = randomImageApiResponse.Message;
                ImagenPerro.Source = randomImageApiResponse.Message;
            }
            else
            {
            }
        }
    }
}