
using ChamadoDataAccessLibrary.Models;

namespace HelpdeskBot.Repositories.contracts
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetClienteById(int id);

    }
}
