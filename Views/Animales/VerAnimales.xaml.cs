using ProyectoP2.Models;
using ProyectoP2.ViewModels;
using System.Collections.ObjectModel;

namespace ProyectoP2
{
    public partial class VerAnimales : ContentPage
    {

        private readonly AnimalesViewModel viewModel;

        public VerAnimales(ObservableCollection<AnimalesClase> animales)
        {
            InitializeComponent();

            // Inicializa la lista de animales en el ViewModel
            var viewModel = new AnimalesViewModel();
            viewModel.Animales = animales;

            // Establece el ViewModel como contexto de enlace
            BindingContext = viewModel;
        }


        private async void EliminarAnimalClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is AnimalesClase animal)
            {
                bool answer = await DisplayAlert("Confirmar", "¿Está seguro de que desea eliminar este animal?", "Sí", "No");

                if (answer)
                {
                    if (listViewAnimales.ItemsSource is IList<AnimalesClase> animales)
                    {
                        animales.Remove(animal);
                        var serializedAnimales = System.Text.Json.JsonSerializer.Serialize(animales);
                        Preferences.Set("Animales", serializedAnimales);
                        listViewAnimales.ItemsSource = null;
                        listViewAnimales.ItemsSource = animales;
                    }
                }
            }
        }

        private async void DetalleAnimalClicked(object sender, EventArgs e)
        {
            var animalSeleccionado = (AnimalesClase)((Button)sender).CommandParameter;

            // Pasa tanto el viewModel como el objeto AnimalesClase al constructor de DetalleAnimal
            await Navigation.PushAsync(new DetalleAnimal(viewModel, animalSeleccionado));
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Actualizar la lista de animales cada vez que la página se muestre
            if (Preferences.ContainsKey("Animales"))
            {
                string animalesString = Preferences.Get("Animales", string.Empty);
                List<AnimalesClase> animalesGuardados = System.Text.Json.JsonSerializer.Deserialize<List<AnimalesClase>>(animalesString);
                listViewAnimales.ItemsSource = null; // Limpiar la lista existente
                listViewAnimales.ItemsSource = animalesGuardados;
                BindingContext = this;
            }
        }



    }
}
