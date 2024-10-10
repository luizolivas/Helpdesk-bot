using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Context;
using HelpdeskBot.Repositories.contracts;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskBot.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _context;

        public ClienteRepository(ClienteDbContext context)
        {
            _context = context;
        }

        public Task<Cliente> GetClienteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = await _context.Cliente.ToListAsync();
            return clientes;
        }
    }
}
