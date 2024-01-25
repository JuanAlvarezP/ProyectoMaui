using ProyectoP2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2.ViewModels
{
    public class AnimalesViewModel : BaseViewModel
    {
        private ObservableCollection<AnimalesClase> _animales;

        public ObservableCollection<AnimalesClase> Animales
        {
            get { return _animales; }
            set
            {
                if (_animales != value)
                {
                    _animales = value;
                    OnPropertyChanged(nameof(Animales));
                }
            }
        }

        public AnimalesViewModel()
        {
            
            Animales = new ObservableCollection<AnimalesClase>();
        }
    }
}
