using ChamadoDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;

namespace ImageProcessingService.Services
{
    public class FileStorageService : IFileStorageService
    {

        public async Task<List<ImageChamado>> SaveImagesToDisk(int chamadoId, List<ImageChamado> listChamado)
        {
            var imageChamados = new List<ImageChamado>();


            var uploadsDirectory = Path.Combine("C:\\Users\\luizo\\Source\\Repos\\LiftChatbot\\HelpdeskBot\\HelpdeskBot", "uploads");
            CreateDirectory(uploadsDirectory);
            string pathChamado = Path.Combine(uploadsDirectory, "Chamado_" + chamadoId);
            CreateDirectory(pathChamado);

            int indiceAux = 1;
            foreach (ImageChamado item in listChamado)
            {
                if (listChamado.Count > 0)
                {

                    string nameFile = indiceAux + "_" + RemoveSpecialCharacters(item.Nome);

                    var filePath = Path.Combine(pathChamado, nameFile);

                    var imageBytes = Convert.FromBase64String(item.Caminho);

                    // Salva o arquivo no disco
                    await File.WriteAllBytesAsync(filePath, imageBytes);

                    var publicUrl = $"https://localhost:44358/uploads/Chamado_{chamadoId}/{nameFile}";

                    var imageChamado = new ImageChamado
                    {
                        Nome = nameFile,
                        Caminho = publicUrl,
                        Tipo = item.Tipo,
                        DataUpload = DateTime.UtcNow,
                        ChamadoId = chamadoId
                    };


                    imageChamados.Add(imageChamado);
                    indiceAux++;
                }
            }

            return imageChamados;
        }

        public void CreateDirectory(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }

        public string RemoveSpecialCharacters(string fileName)
        {
            return string.Concat(fileName.Where(c => !Path.GetInvalidFileNameChars().Contains(c) && !char.IsWhiteSpace(c)))
                          .Replace("'", "")
                          .Replace("®", "")
                          .Replace(" ", "_");
        }
    }
}
