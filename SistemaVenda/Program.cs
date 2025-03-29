using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SistemaVenda;

// Cria o builder da aplicação
var builder = WebApplication.CreateBuilder(args);

// Cria a configuração (opcional, se precisar de configurações adicionais)
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

// Instancia a classe Startup
var startup = new Startup(configuration);

// Configura os serviços
startup.ConfigureServices(builder.Services);

// Constrói a aplicação
var app = builder.Build();

// Configura o pipeline HTTP
startup.Configure(app, app.Environment);

// Executa a aplicação
app.Run();