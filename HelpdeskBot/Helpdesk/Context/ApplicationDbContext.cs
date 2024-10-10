using ChamadoDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskBot.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<ImageChamado> ImageChamado { get; set; }
        public DbSet<UsuarioInterno> UsuarioInterno { get; set; }

    }
}
