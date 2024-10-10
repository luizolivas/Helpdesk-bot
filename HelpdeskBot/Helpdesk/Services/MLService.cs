using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Services.contracts;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelpdeskBot.Services
{
    public class MLService : IMLService
    {
        private static PredictionEngine<MessageInput, MessagePrediction> _predictionEngine;

        static MLService()
        {
            var context = new MLContext();

            var data = new Dictionary<string, List<string>>()
            {
                { "financeiro", new List<string> { "Contas a pagar", "Contas a receber", "fluxo de caixa", "Meio de pagamento", "banco", "conta", "grupos financeiros", "dre", "integração" } },
                { "cadastro", new List<string> { "cadastra", "quero cadastrar", "Como cadastro", "cadastrar um", "cadastrar uma" } },
                { "relatorio", new List<string> { "fazer um relatorio", "relatorio", "emitir um relatorio" } },
                { "estoque", new List<string> { "como transferencia de estoque?", "adicionar um produto", "adicionar um item", "baixa no estoque" } },
                { "assistencia", new List<string> { "abrir assistencia", "encerrar assistencia", "receber meu pedido" } },
                { "suporte", new List<string> { "entrar em contato com o suporte", "suporte", "suporte técnico", "minha duvida não foi resolvida" } }
            };

            var synonyms = new Dictionary<string, List<string>>()
            {
                { "finalizar", new List<string> { "finalizo", "concluir", "terminar" } },
                { "cancelamento", new List<string> { "cancelar", "desistir do pedido", "anular pedido" } },
                { "suporte", new List<string> { "ajuda", "atendimento ao cliente", "suporte técnico" } },
                { "fazer", new List<string> { "faço" } },
                { "cadastrar", new List<string> { "cadastra", "quero cadastrar", "como cadastro", "alterar dados de um", "registrar um", "inscrever um" } }
            };

            var questions = new List<MessageInput>();
            foreach (var intent in data.Keys)
            {
                foreach (var text in data[intent])
                {
                    var preprocessedText = PreprocessText(text);
                    questions.Add(new MessageInput { Text = preprocessedText, Intent = intent });

                    // Expandir perguntas com sinônimos
                    foreach (var key in synonyms.Keys)
                    {
                        if (text.ToLower().Contains(key.ToLower()))
                        {
                            foreach (var syn in synonyms[key])
                            {
                                var expandedText = text.Replace(key, syn);
                                preprocessedText = PreprocessText(expandedText);
                                questions.Add(new MessageInput { Text = preprocessedText, Intent = intent });
                            }
                        }
                    }

                    // Adicionar exemplos negativos
                    foreach (var otherIntent in data.Keys)
                    {
                        if (otherIntent != intent)
                        {
                            foreach (var otherText in data[otherIntent])
                            {
                                preprocessedText = PreprocessText(otherText);
                                questions.Add(new MessageInput { Text = preprocessedText, Intent = otherIntent });
                            }
                        }
                    }
                }
            }

            // Carregar os dados para o modelo
            var trainingData = context.Data.LoadFromEnumerable(questions);

            // Definir o pipeline de aprendizado de máquina
            var pipeline = context.Transforms.Conversion.MapValueToKey("Label", nameof(MessageInput.Intent)) // Mapear rótulo
                .Append(context.Transforms.Text.FeaturizeText("Features", nameof(MessageInput.Text)))
                .Append(context.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(context.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // Treinar o modelo
            var model = pipeline.Fit(trainingData);

            // Inicializar o PredictionEngine
            _predictionEngine = context.Model.CreatePredictionEngine<MessageInput, MessagePrediction>(model);
        }

        public string PredictIntent(string message)
        {
            var preprocessedMessage = PreprocessText(message);
            var prediction = _predictionEngine.Predict(new MessageInput { Text = preprocessedMessage });
            return prediction.PredictedIntent;
        }

        private static string PreprocessText(string text)
        {
            text = text.ToLower();
            text = Regex.Replace(text, @"\p{P}", ""); // Remover pontuação
            text = Regex.Replace(text, @"\s+", " ").Trim(); // Remover espaços extras
            return text;
        }
    }
}
