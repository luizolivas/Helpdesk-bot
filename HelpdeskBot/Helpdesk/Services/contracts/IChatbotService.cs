using ChamadoDataAccessLibrary.Models;

namespace HelpdeskBot.Services.contracts
{
    public interface IChatbotService
    {
        Task<string> GetResponse(Message userMessagev);
        public string TypeMessage(string message);
    }
}
