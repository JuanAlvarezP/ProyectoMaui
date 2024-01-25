using ProyectoP2.Models;
using ProyectoP2.ViewModels;
using System.Collections.ObjectModel;

namespace ProyectoP2;

public partial class RegistrarAnimales : ContentPage
{
    private readonly AnimalesViewModel viewModel;

    public RegistrarAnimales(ObservableCollection<AnimalesClase> animales)
    {
        InitializeComponent();
        viewModel = new AnimalesViewModel();
        viewModel.Animales = animales; // Asigna la lista de animales al viewModel
        BindingContext = new AnimalesClase(); // Nuevo animal para la entrada de datos
    }


    private async void RegistrarClicked(object sender, EventArgs e)
    {
        // Obtener los valores de las entradas
        string nombre = entryNombre.Text;
        string especie = entryEspecie.Text;
        string raza = entryRaza.Text;
        DateTime fechaNacimiento = datePickerFechaNacimiento.Date;
        string genero = pickerGenero.SelectedItem?.ToString();
        string observaciones = entryObservaciones.Text;

        // Validar los datos ingresados
        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(especie) ||
            string.IsNullOrWhiteSpace(raza) ||
            string.IsNullOrWhiteSpace(genero) ||
            fechaNacimiento == DateTime.MinValue)
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos obligatorios.", "OK");
            return;
        }

        // Crear una nueva instancia de la clase AnimalesClase con los datos ingresados
        AnimalesClase nuevoAnimal = new AnimalesClase()
        {
            NombreAni = nombre,
            Especie = especie,
            Raza = raza,
            FechaNacimiento = fechaNacimiento,
            Genero = genero,
            Observaciones = observaciones
        };

        // Agregar el nuevo animal al ViewModel
        viewModel.Animales.Add(nuevoAnimal);

        // Serializar la lista actualizada de animales a formato JSON
        string serializedAnimales = System.Text.Json.JsonSerializer.Serialize(viewModel.Animales);

        // Guardar la lista de animales en las preferencias
        Preferences.Set("Animales", serializedAnimales);

        // Mostrar un mensaje de éxito
        await DisplayAlert("Éxito", "Se ha registrado el animal correctamente", "Aceptar");

        // Puedes agregar aquí la navegación a otra página si es necesario
    }
}
