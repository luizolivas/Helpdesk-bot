using ChamadoDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskBot.Context
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
