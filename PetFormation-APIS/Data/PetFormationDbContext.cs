using Microsoft.EntityFrameworkCore;
using PetFormation_APIS.Models;

namespace PetFormation_APIS.Data
{
    public class PetFormationDbContext : DbContext
    {

        public PetFormationDbContext(DbContextOptions options) : base(options) 
        {
        
        }

        public DbSet<cliente> Clientes { get; set; }

    }
}
