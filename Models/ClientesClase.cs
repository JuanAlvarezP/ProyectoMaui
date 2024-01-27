using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2.Models
{
    public class ClientesClase
    {
        public int Id { get; set; }
        public string NombreCli { get; set; }
        public string ApellidoCli { get; set; }
        public string CorreoElectronicoCli { get; set; }
        public string NumeroTelefonoCli { get; set; }
        public DateTime FechaRegistroCli { get; set; }
        public string Direccion { get; set; }
    }


}
