using ChamadoDataAccessLibrary.Models;
using ImageProcessingService.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingService.Services
{
    public class ManageChamadoService : IManageChamadoService
    {
        private readonly IManageChamadoRepository _repository;
        private readonly IFileStorageService _fileStorageService;


        public ManageChamadoService(IManageChamadoRepository repository, IFileStorageService fileStorageService)
        {
            _repository = repository;
            _fileStorageService = fileStorageService;
        }

        public async Task ProcessMessage(string message)
        {

            List<ImageChamado> resultImageChamados = JsonConvert.DeserializeObject<List<ImageChamado>>(message);
            if(resultImageChamados != null)
            {
                try
                {
                    List<ImageChamado> imageChamados = await _fileStorageService.SaveImagesToDisk(resultImageChamados[0].ChamadoId, resultImageChamados);
                    await _repository.SaveImagesChamado(imageChamados);
                    await _repository.UpdateStatusChamado(resultImageChamados[0].ChamadoId);
                }
                catch (Exception ex)
                {

                }

            }
            


        }
    }
}
