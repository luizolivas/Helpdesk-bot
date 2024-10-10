using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Repositories.contracts;
using HelpdeskBot.Services.contracts;

namespace HelpdeskBot.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = await _clienteRepository.GetClientes();
            return clientes;
        }
    }
}
