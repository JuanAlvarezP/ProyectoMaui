using ProyectoP2.Models;
using ProyectoP2.ViewModels;

namespace ProyectoP2
{
    public partial class DetalleCliente : ContentPage
    {
        private ClientesClase cliente;
        private ClientesViewModel viewModel;

        public DetalleCliente(ClientesClase cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            viewModel = new ClientesViewModel();
            viewModel.SelectedCliente = cliente;
            BindingContext = viewModel;
        }

        private async void ActualizarClienteClicked(object sender, EventArgs e)
        {
            // Aquí obtienes los nuevos datos ingresados por el usuario y actualizas el cliente existente
            cliente.NombreCli = NombreEntry.Text;
            cliente.ApellidoCli = ApellidoEntry.Text;
            cliente.CorreoElectronicoCli = CorreoElectronicoEntry.Text;
            cliente.NumeroTelefonoCli = NumeroTelefonoEntry.Text;
            cliente.Direccion = DireccionEntry.Text;

            // Guarda los datos actualizados en MauiPreferences
            var clientesGuardadosString = Preferences.Get("Clientes", string.Empty);

            // Deserializa la cadena JSON a una lista de ClientesClase
            var clientesGuardados = string.IsNullOrWhiteSpace(clientesGuardadosString)
                ? new List<ClientesClase>()
                : System.Text.Json.JsonSerializer.Deserialize<List<ClientesClase>>(clientesGuardadosString);
            var clienteAActualizar = clientesGuardados.Find(c => c.Id == cliente.Id);
            if (clienteAActualizar != null)
            {
                clienteAActualizar.NombreCli = cliente.NombreCli;
                clienteAActualizar.ApellidoCli = cliente.ApellidoCli;
                clienteAActualizar.CorreoElectronicoCli = cliente.CorreoElectronicoCli;
                clienteAActualizar.NumeroTelefonoCli = cliente.NumeroTelefonoCli;
                clienteAActualizar.Direccion = cliente.Direccion;

                // Serializa la lista actualizada a una cadena JSON
                var serializedClientes = System.Text.Json.JsonSerializer.Serialize(clientesGuardados);

                // Almacena la cadena JSON en las preferencias
                Preferences.Set("Clientes", serializedClientes);
            }
            await DisplayAlert("Éxito", "El cliente se actualizó correctamente", "OK");

            // Regresa a la página anterior (VerClientes)
            await Navigation.PopAsync();
        }
    }
}
