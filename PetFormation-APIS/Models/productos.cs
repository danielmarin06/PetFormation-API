using System.ComponentModel.DataAnnotations;

namespace PetFormation_APIS.Models
{
    public class productos
    {
        [Key]
        public int ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string TAMANO_PRODUCTO { get; set; }
        public string COLOR_PRODUCTO { get; set; }
        public string CONTENIDO_PRODUCTO { get; set; }
        public string CATEGORIA_PRODUCTO { get; set; }
    }
}
