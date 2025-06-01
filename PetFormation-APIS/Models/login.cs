using System.ComponentModel.DataAnnotations;

namespace PetFormation_APIS.Models
{
    public class Login
    {
        [Key]
        public int idlogin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool logged { get; set; }
    }
}
