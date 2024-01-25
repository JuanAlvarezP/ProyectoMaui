using ProyectoP2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoP2.ViewModels
{
    public class ClientesViewModel : INotifyPropertyChanged
    {
        private List<ClientesClase> _clientesList;
        public List<ClientesClase> ClientesList
        {
            get { return _clientesList; }
            set
            {
                if (_clientesList != value)
                {
                    _clientesList = value;
                    OnPropertyChanged(nameof(ClientesList));
                }
            }
        }

        private ClientesClase _selectedCliente;
        public ClientesClase SelectedCliente
        {
            get { return _selectedCliente; }
            set
            {
                if (_selectedCliente != value)
                {
                    _selectedCliente = value;
                    OnPropertyChanged(nameof(SelectedCliente));
                }
            }
        }

        // Otros miembros de tu ViewModel

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Método SetProperty para facilitar la notificación de cambios
        protected bool SetProperty<T>(ref T backingStore, T value,
                                      [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "",
                                      System.Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
