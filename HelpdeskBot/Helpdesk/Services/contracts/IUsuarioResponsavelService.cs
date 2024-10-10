using ChamadoDataAccessLibrary.Models;

namespace HelpdeskBot.Services.contracts
{
    public interface IUsuarioResponsavelService
    {
        Task CreateUsuario(UsuarioInterno usuario);
        Task<List<UsuarioInterno>> GetAllUsuario();
        Task<UsuarioInterno> GetUsuarioById(int id);
        Task UpdateUsuario(UsuarioInterno usuario);
        Task DeleteUsuarioById(UsuarioInterno usuario);
        
    }
}
