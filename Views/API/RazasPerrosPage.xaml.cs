using ProyectoP2.Models;
using ProyectoP2.ViewModels;
using ProyectoP2.Services;
using ProyectoP2.Views;
using System.Collections.Generic;

namespace ProyectoP2;

    public partial class RazasPerrosPage : ContentPage
    {
        private readonly RazasPerrosApiService apiService;
        private List<RazaPerro> razasPerros;

        public RazasPerrosPage()
        {
            InitializeComponent();
            apiService = new RazasPerrosApiService();
            CargarRazasPerros();
        }

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

        private async void CargarRazasPerros()
        {
            RazasPerros = await apiService.ObtenerRazasPerros();
        }

    }