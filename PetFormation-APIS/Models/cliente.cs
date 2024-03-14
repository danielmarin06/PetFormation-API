using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetFormation_APIS.Models
{
    public class cliente
    {
        [Key]
        public int ID_CLIENTE { get; set; }
        public string CEDULA_CLIENTE { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string TELEFONO_CLIENTE { get; set; }
        public string DIRECCION_CLIENTE { get; set; }
        public string CORREO_CLIENTE { get; set; }

    }
}
