using System.Collections.Generic;
using ProyectoP2.Models;
using ProyectoP2.Services;

namespace ProyectoP2.ViewModels
{
    public class RazasPerrosViewModel : BaseViewModel
    {
        private readonly RazasPerrosApiService apiService;

        private List<RazaPerro> razasPerros;
        public List<RazaPerro> RazasPerros
        {
            get { return razasPerros; }
            set
            {
                if (razasPerros != value)
                {
                    razasPerros = value;
                    OnPropertyChanged();
                }
            }
        }

        public RazasPerrosViewModel()
        {
            apiService = new RazasPerrosApiService();
            CargarRazasPerros();
        }

        private async void CargarRazasPerros()
        {
            RazasPerros = await apiService.ObtenerRazasPerros();
        }
    }
}
