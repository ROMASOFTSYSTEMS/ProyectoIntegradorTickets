using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorApi.Models;
//

namespace ProyectoIntegradorApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(): base()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil_Opcion> Perfil_Opcion { get; set; }
        public DbSet<Sistema> Sistema { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
    }
}
