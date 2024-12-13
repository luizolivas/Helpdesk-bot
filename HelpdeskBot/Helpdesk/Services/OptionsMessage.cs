using HelpdeskBot.Services.contracts;
using System.Collections.Generic;

namespace HelpdeskBot.Services
{
    public class OptionsMessage : IOptionsMessage
    {
        private static string _currentLayer = "0"; // Estado atual do menu
        private static string _previousLayer = "0"; // Para navegar para o estado anterior
        private static readonly string _mensagemInicial = "Em que posso te ajudar? (digite o número)<br />1. Erro no sistema<br />2. Dúvidas do Sistema<br />3. Outros<br />";

        private static readonly Dictionary<string, (string, Dictionary<string, string>)> _menu = new()
        {
            {
                "0",
                (_mensagemInicial, new Dictionary<string, string>
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" },
                    { "4", "4" }
                })
            },
            {
                "1",
                ("Por gentileza, nos envie um print da tela do erro pelo WhatsApp.<br />0. Para Voltar<br />",
                new Dictionary<string, string> { { "0", "0" } })
            },
            {
                "2",
                (@"Qual seria sua dúvida? (digite o número)<br />
                1. Cadastros do sistema<br />
                2. Financeiro<br />
                3. Orçamentos e pedidos<br />
                0. Para Voltar<br />",
                new Dictionary<string, string>
                {
                    { "1", "2.1" },
                    { "2", "2.2" },
                    { "3", "2.3" },
                    { "0", "0" }
                })
            },
            {
                "2.1",
                ("Qual sua dúvida sobre cadastros?<br />1. Usuário<br />2. Funcionário<br />0. Para Voltar<br />",
                new Dictionary<string, string>
                {
                    { "1", "Resposta sobre cadastro de usuário" },
                    { "2", "Resposta sobre cadastro de funcionário" },
                    { "0", "2" }
                })
            },
            {
                "2.2",
                ("Qual sua dúvida sobre financeiro?<br />1. Pagamentos<br />2. Recebimentos<br />0. Para Voltar<br />",
                new Dictionary<string, string>
                {
                    { "1", "Resposta sobre pagamentos" },
                    { "2", "Resposta sobre recebimentos" },
                    { "0", "2" }
                })
            },
            {
                "3",
                ("Qual seria sua dúvida sobre Beija-flor?<br />0. Para Voltar<br />",
                new Dictionary<string, string>
                {
                    { "0", "0" }
                })
            },
            {
                "4",
                ("Certo, como posso ajudar?<br />0. Para Voltar<br />",
                new Dictionary<string, string>
                {
                    { "0", "0" }
                })
            }
        };

        public string GetBotResponse(string userMessage)
        {
            if (_menu.ContainsKey(_currentLayer))
            {
                var (message, options) = _menu[_currentLayer];

                if (options.ContainsKey(userMessage))
                {
                    var nextLayer = options[userMessage];

                    if (_menu.ContainsKey(nextLayer))
                    {
                        _previousLayer = _currentLayer;
                        _currentLayer = nextLayer;
                        return _menu[nextLayer].Item1; // Retorna a mensagem da próxima camada
                    }

                    return nextLayer; // Retorna uma resposta direta (por exemplo, "Resposta sobre pagamentos")
                }

                return "Desculpe, não entendi. Selecione uma opção válida.";
            }

            _currentLayer = "0"; // Redefine para o menu inicial em caso de erro
            return _mensagemInicial;
        }
    }
}
