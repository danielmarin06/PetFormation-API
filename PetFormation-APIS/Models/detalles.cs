using System.ComponentModel.DataAnnotations;

namespace PetFormation_APIS.Models
{
    public class detalles
    {
        [Key]
        public int ID_DETALLE { get; set; }
        public DateTime TIMESTAMP_DETALLE { get; set; }
        public int ID_VENTA { get; set; }
        public int CANTIDAD_DETALLE { get; set; }
        public int ID_CALUPRODUCT { get; set; }
        public int TOTAL_DETALLE { get; set; }
    }
}
