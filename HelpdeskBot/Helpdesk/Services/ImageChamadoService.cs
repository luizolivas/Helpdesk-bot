using Azure.Core;
using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Repositories.contracts;
using HelpdeskBot.Services.contracts;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace HelpdeskBot.Services
{
    public class ImageChamadoService : IImageChamadoService
    {

        private readonly IImageChamadoRepository _repository;
        private readonly IRabbitService _rabbitService;


        public ImageChamadoService(IImageChamadoRepository repository, IRabbitService rabbitService)
        {
            _repository = repository;
            _rabbitService = rabbitService;
        }

        public async Task AddImagesChamado(int chamadoId, List<IFormFile> files)
        {

            var imageChamados = new List<ImageChamado>();

            foreach (var file in files)
            {
                // Processa a imagem temporariamente, salva em algum local ou converte em byte[]
                var imageChamado = new ImageChamado
                {
                    ChamadoId = chamadoId,
                    Nome = file.FileName,
                    Tipo = file.ContentType,
                    // Aqui, você pode salvar o caminho ou a própria imagem em base64, por exemplo
                    Caminho = ConvertToBase64(file),
                    DataUpload = DateTime.UtcNow
                };
                imageChamados.Add(imageChamado);
            }



            var mensagem = JsonConvert.SerializeObject(imageChamados);


            _rabbitService.EnviarMensagem(mensagem);
        }

        private string ConvertToBase64(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return Convert.ToBase64String(fileBytes);
            }
        }

        public async Task<IEnumerable<ImageChamado>> GetImagesChamadoById(int id)
        {
            IEnumerable<ImageChamado> listImages = await _repository.GetById(id);
            return listImages;
        }

        public Task UpdateImagesChamado(int id, ImageChamado imgChamado)
        {
            throw new NotImplementedException();
        }
      

    }
}
