using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2.Models
{
    public class AnimalesClase
    {
        public int Id { get; set; }
        public string NombreAni { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Observaciones { get; set; }


    }
}
