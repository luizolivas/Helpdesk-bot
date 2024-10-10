using HelpdeskBot.Services.contracts;
using System.Collections.Generic;

namespace HelpdeskBot.Services
{
    public class OptionsMessage : IOptionsMessage
    {
        // Definimos estados (layers) com enum
        private enum Layer
        {
            Initial = 0,
            Error = 1,
            BeijaFlor = 3,
            Other = 4,
            Exit = 5
        }

        private Layer _currentLayer = Layer.Initial;
        private static bool _executed = false;

        private static readonly string _mensagemInicial =
            "Em que posso te ajudar? (digite o número)<br />" +
            "1. Erro no sistema<br />" +
            "2. Dúvidas<br />" +
            "3. Dúvidas do Beija-flor<br />" +
            "4. Outros";

        // Usamos dicionários para mapear as opções
        private static readonly Dictionary<Layer, string> MenuOptions = new Dictionary<Layer, string>
        {
            { Layer.Error, "Por gentileza, nos envie um print da tela do erro (se possível) pelo WhatsApp..." },
            { Layer.BeijaFlor, "Qual seria sua dúvida sobre o Beija-flor?" },
            { Layer.Other, "Certo, como posso ajudar? <br /> 0. Para Voltar" },
        };

        public string GetBotResponse(string userMessage)
        {
            switch (_currentLayer)
            {
                case Layer.Initial:
                    return HandleInitialLayer(userMessage);
                case Layer.Error:
                    return HandleErrorLayer(userMessage);
                case Layer.BeijaFlor:
                    return HandleBeijaFlorLayer(userMessage);
                case Layer.Other:
                    return HandleOtherLayer(userMessage);
                case Layer.Exit:
                    return HandleExitLayer(userMessage);
                default:
                    return "Erro desconhecido.";
            }
        }

        private string HandleInitialLayer(string userMessage)
        {
            if (userMessage.ToLower().Contains("inicio"))
                return _mensagemInicial;

            if (userMessage == "1")
                _currentLayer = Layer.Error;
            else if (userMessage == "3")
                _currentLayer = Layer.BeijaFlor;
            else if (userMessage == "4")
                _currentLayer = Layer.Other;
            else
                return "Desculpe, não entendi. Selecione uma opção válida.";

            return GetResponseForLayer(_currentLayer);
        }

        private string HandleErrorLayer(string userMessage)
        {
            if (userMessage == "0")
            {
                _currentLayer = Layer.Initial;
                return _mensagemInicial;
            }
            return GetResponseForLayer(_currentLayer);
        }

        private string HandleBeijaFlorLayer(string userMessage)
        {
            if (userMessage == "0")
            {
                _currentLayer = Layer.Initial;
                return _mensagemInicial;
            }
            return GetResponseForLayer(_currentLayer);
        }

        private string HandleOtherLayer(string userMessage)
        {
            if (userMessage == "0")
            {
                _currentLayer = Layer.Initial;
                return _mensagemInicial;
            }
            return GetResponseForLayer(_currentLayer);
        }

        private string HandleExitLayer(string userMessage)
        {
            if (userMessage == "1")
            {
                _currentLayer = Layer.Initial;
                return "Ótimo! Caso ainda tenha dúvidas, estamos à disposição. Tenha um ótimo dia!";
            }
            else if (userMessage == "2")
            {
                _currentLayer = Layer.Initial;
                return "Posso te ajudar de outra forma?";
            }
            return "Desculpe, não entendi. Selecione uma opção válida.";
        }

        private string GetResponseForLayer(Layer layer)
        {
            if (MenuOptions.TryGetValue(layer, out var response))
                return response;

            return "Desculpe, não entendi. Selecione uma opção válida.";
        }
    }
}
