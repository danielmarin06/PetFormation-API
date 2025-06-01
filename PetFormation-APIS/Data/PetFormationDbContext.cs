using Microsoft.EntityFrameworkCore;
using PetFormation_APIS.Models;

namespace PetFormation_APIS.Data
{
    public class PetFormationDbContext : DbContext
    {

        public PetFormationDbContext(DbContextOptions options) : base(options) 
        {
        
        }

        public DbSet<clientes> Clientes { get; set; }
        public DbSet<detalles> Detalles { get; set; }
        public DbSet<insumos> Insumos { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<mascotas> Mascotas { get; set;}
        public DbSet<productos> Productos { get; set; }
        public DbSet<proveedores> Proveedores { get; set; }
        public DbSet<ventas> Ventas { get; set; }
        public DbSet<caluproduct> Caluproduct { get; set; }

    }
}
