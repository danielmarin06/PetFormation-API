using System.ComponentModel.DataAnnotations;

namespace PetFormation_APIS.Models
{
    public class ventas
    {
        [Key]
        public int ID_VENTA { get; set; }
        public DateTime TIMESTAMP_VENTA { get; set; }
        public int ID_CLIENTE { get; set; }
        public int GRAN_TOTAL { get; set; }
    }
}
