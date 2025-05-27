using System.ComponentModel.DataAnnotations;

namespace PetFormation_APIS.Models
{
    public class proveedores
    {
        [Key]
        public int ID_PROVEEDOR { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
        public string CONTACTO_PROVEEDOR { get; set; }
        public string TELEFONO_PROVEEDOR { get; set; }
        public string CORREO_PROVEEDOR { get; set; }
        public string DIRECCION_PROVEEDOR { get; set; }
        public int ID_PRODUCTO {  get; set; }
    }
}
