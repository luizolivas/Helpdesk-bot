using ChamadoDataAccessLibrary.Models;
using ImageProcessingService.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageProcessingService.Repository
{
    public class ManageChamadoRepository : IManageChamadoRepository
    {
        private readonly IServiceProvider _serviceProvider;

        public ManageChamadoRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task UpdateStatusChamado(int idChamado)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppWorkerDbContext>();

                Chamado chamado = await dbContext.Chamados.FindAsync(idChamado);
                if (chamado == null)
                {
                    return;
                }
                chamado.Status = ChamadoDataAccessLibrary.Models.Enum.StatusChamado.Aberto;
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }

        public async Task SaveImagesChamado(List<ImageChamado> listImageChamado)
        {
            if (listImageChamado == null || listImageChamado.Count == 0)
            {
                // Lidar com lista vazia ou nula
                return;
            }

            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppWorkerDbContext>();

            try
            {
                await dbContext.ImageChamado.AddRangeAsync(listImageChamado);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Tratar exceção (logar ou lançar)
            }
        }
    }
}
