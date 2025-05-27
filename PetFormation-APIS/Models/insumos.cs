using System.ComponentModel.DataAnnotations;

namespace PetFormation_APIS.Models
{
    public class insumos
    {
        [Key]
        public int ID_INSUMO { get; set; }
        public string NOMBRE_INSUMO { get; set; }
        public int PRECIO_INSUMO { get; set; }
        public int ID_PROVEEDOR { get; set; }
    }
}
