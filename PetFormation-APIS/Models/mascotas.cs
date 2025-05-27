using System.ComponentModel.DataAnnotations;

namespace PetFormation_APIS.Models
{
    public class mascotas
    {
        [Key]
        public int ID_MASCOTA { get; set; }
        public string NOMBRE_MASCOTA { get; set; }
        public DateTime FECHA_NACIMIENTO_MASCOTA { get; set; }
        public string TIPO_MASCOTA { get; set; }
        public string RAZA_MASCOTA { get; set; }
        public string TAMANO_MASCOTA { get; set; }
        public string GENERO_MASCOTA { get; set; }
        public string ID_CLIENTE { get; set; }
    }
}
