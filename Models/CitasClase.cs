using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2.Models
{
    public class CitasClase
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }
        public string NombreAnimal { get; set; }
        public string NombrePropietario { get; set; }
        public string NumeroTelefonoPropietario { get; set; }
        public string Observaciones { get; set; }
        public string FechaHoraString
        {
            get { return FechaHora.ToString("dd/MM/yyyy HH:mm"); }
            set { FechaHora = DateTime.ParseExact(value, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture); }
        }
    }
}
