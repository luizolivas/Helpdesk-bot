using ChamadoDataAccessLibrary.Models;

namespace HelpdeskBot.Services.contracts
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetClientes();
    }
}
