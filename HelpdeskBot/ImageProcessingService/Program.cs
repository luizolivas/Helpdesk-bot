using ImageProcessingService;
using ImageProcessingService.Context;
using ImageProcessingService.Repository;
using ImageProcessingService.Services;
using Microsoft.EntityFrameworkCore;



var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppWorkerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSingleton<IFileStorageService, FileStorageService>();
builder.Services.AddSingleton<IManageChamadoService, ManageChamadoService>();
builder.Services.AddSingleton<IManageChamadoRepository, ManageChamadoRepository>();

var host = builder.Build();
host.Run();
