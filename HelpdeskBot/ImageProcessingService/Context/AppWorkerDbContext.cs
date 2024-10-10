using ChamadoDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace ImageProcessingService.Context
{
    public class AppWorkerDbContext : DbContext
    {
        public AppWorkerDbContext(DbContextOptions<AppWorkerDbContext> options) : base(options) { }

        public DbSet<ImageChamado> ImageChamado { get; set; }
        public DbSet<Chamado> Chamados { get; set; }

    }
}
