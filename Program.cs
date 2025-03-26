using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SistemaVenda;

// Cria o builder da aplica��o
var builder = WebApplication.CreateBuilder(args);

// Cria a configura��o (opcional, se precisar de configura��es adicionais)
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

// Instancia a classe Startup
var startup = new Startup(configuration);

// Configura os servi�os
startup.ConfigureServices(builder.Services);

// Constr�i a aplica��o
var app = builder.Build();

// Configura o pipeline HTTP
startup.Configure(app, app.Environment);

// Executa a aplica��o
app.Run();