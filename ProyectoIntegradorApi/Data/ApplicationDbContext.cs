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
        // Mantenimientos
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Sistema> Sistema { get; set; }
        public DbSet<Modulo> Modulo { get; set; }

        // Seguridad
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario_Empresa> Usuario_Empresa { get; set; }
        public DbSet<Usuario_Perfil> Usuario_Perfil { get; set; }

        // Autorizaciones
        public DbSet<Perfil_Opcion> Perfil_Opcion { get; set; }
        
        // Tickets
        public DbSet<Estado_Ticket> Estado_Ticket { get; set; }
        public DbSet<Tipo_Ticket> Tipo_Ticket { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}
