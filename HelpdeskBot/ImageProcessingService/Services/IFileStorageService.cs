using ChamadoDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;

namespace ImageProcessingService.Services
{
    public interface IFileStorageService
    {
        Task<List<ImageChamado>> SaveImagesToDisk(int chamadoId, List<ImageChamado> listChamado);
        public void CreateDirectory(string filePath);
        public string RemoveSpecialCharacters(string fileName);
    }


}
