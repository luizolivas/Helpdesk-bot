using ChamadoDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingService.Repository
{
    public interface IManageChamadoRepository
    {
        Task UpdateStatusChamado(int idChamado);
        Task SaveImagesChamado(List<ImageChamado> listImageChamado);
    }
}
