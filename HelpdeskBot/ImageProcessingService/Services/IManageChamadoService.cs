using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingService.Services
{
    public interface IManageChamadoService
    {
        Task ProcessMessage(string message);
    }
}
