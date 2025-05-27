using System.ComponentModel.DataAnnotations;

namespace PetFormation_APIS.Models
{
    public class caluproduct
    {
        [Key]
        public int ID_CALUPRODUCT { get; set; }
        public string NOMBRE_CALUPRODUCT { get; set; }
        public string TAMANO_CALUPRODUCT { get; set; }
        public string CARACTERISTICA_CALUPRODUCT { get; set; }
        public DateTime TIMESTAMP { get; set; }
        public int PRECIO_CALUPRODUCT { get; set; }
    }
}
