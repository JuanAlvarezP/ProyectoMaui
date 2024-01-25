using ProyectoP2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2.ViewModels
{
    public class CitasViewModel : BindableObject
    {
        private ObservableCollection<CitasClase> citas;

        public ObservableCollection<CitasClase> Citas
        {
            get => citas;
            set
            {
                citas = value;
                OnPropertyChanged(nameof(Citas));
            }
        }

        public CitasViewModel()
        {
            LoadCitas();
        }

        private void LoadCitas()
        {
            if (Preferences.ContainsKey("Citas"))
            {
                string citasString = Preferences.Get("Citas", string.Empty);
                Citas = new ObservableCollection<CitasClase>(System.Text.Json.JsonSerializer.Deserialize<List<CitasClase>>(citasString));
            }
            else
            {
                Citas = new ObservableCollection<CitasClase>();
            }
        }
    }
}
