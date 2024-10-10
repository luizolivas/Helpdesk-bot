

using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Services.contracts;

namespace HelpdeskBot.Services
{
    public class ChatbotService : IChatbotService
    {
        

        private readonly IMLService _mlService;
        private readonly IOptionsMessage _optionsMessage;

        public ChatbotService(IMLService mlService, IOptionsMessage optionsMessage)
        {
            _mlService = mlService;
            _optionsMessage = optionsMessage;
        }

        public async Task<string> GetResponse(Message userMessage)
        {
            if (userMessage == null) 
            { 
                
            }

            string message = userMessage.Content;
            string result = "";

            string typeMessage = TypeMessage(message);
            if (typeMessage == "opcao")
            {
                result = _optionsMessage.GetBotResponse(message);
            }
            else
            {
                result = _mlService.PredictIntent(message);
            }

            return result;
        }

        public string TypeMessage(string message)
        {
            string handledMessage = message.Trim();

            if (handledMessage.Length == 1)
            {
                return "opcao";
            }
            else
            {
                return "pergunta";
            }

        }


    }


}
