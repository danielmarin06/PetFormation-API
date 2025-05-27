using System.ComponentModel.DataAnnotations;

namespace PetFormation_APIS.Models
{
    public class login
    {
        [Key]
        public int idlogin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
