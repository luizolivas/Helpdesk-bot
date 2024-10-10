using HelpdeskBot.Context;
using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Repositories;
using HelpdeskBot.Repositories.contracts;
using HelpdeskBot.Services;
using HelpdeskBot.Services.contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using RabbitMQ.Client;
using HelpdeskBot.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

var connectionStringCliente = builder.Configuration.GetConnectionString("ConnectionLift");
builder.Services.AddDbContext<ClienteDbContext>(options => options.UseSqlServer(connectionStringCliente));

var rabbitMqSettings = builder.Configuration.GetSection("RabbitMQ").Get<RabbitMqSettings>();
builder.Services.AddSingleton(rabbitMqSettings);

var factory = new ConnectionFactory()
{
    HostName = rabbitMqSettings.HostName,
    UserName = rabbitMqSettings.UserName,
    Password = rabbitMqSettings.Password
};
builder.Services.AddSingleton(factory);

builder.Services.AddSingleton<IChatbotService, ChatbotService>();
builder.Services.AddSingleton<IMLService, MLService>();
builder.Services.AddSingleton<IOptionsMessage, OptionsMessage>();
builder.Services.AddScoped<IChamadoService, ChamadoService>();
builder.Services.AddScoped<IChamadoRepository, ChamadoRepository>();
builder.Services.AddScoped<IImageChamadoService, ImageChamadoService>();
builder.Services.AddScoped<IImageChamadoRepository, ImageChamadoRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IRabbitService, RabbitService>();
builder.Services.AddScoped<IRedirectService, RedirectService>();
builder.Services.AddScoped<IUsuarioResponsavelService, UsuarioResponsavelService>();
builder.Services.AddScoped<IUsuarioInternoRepository, UsuarioInternoRepository>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
    RequestPath = "/uploads"
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
//app.UseMiddleware<SessionCheckMiddleware>();

app.MapControllers();

app.Run();
