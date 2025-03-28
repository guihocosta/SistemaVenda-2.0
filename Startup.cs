using Microsoft.EntityFrameworkCore;
using SistemaVenda.DAL;
using Microsoft.Extensions.Configuration;
using Aplicacao.Servico.Interfaces;
using Aplicacao.Servico;
using Dominio.Interfaces;
using Dominio.Servicos;
using Dominio.Interfaces.Repositorio;
using Repositorio.Entidades;

namespace SistemaVenda
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // Adicione o construtor para injetar a configuração
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do DbContext com a connection string
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("MyStock")));

            services.AddDbContext<Repositorio.Contexto.ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyStock")));

            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddControllersWithViews();

            //Serviço Aplicação
            services.AddScoped<IServicoAplicacaoCategoria, ServicoAplicacaoCategoria>();

            // Domínio
            services.AddScoped<IServicoCategoria, ServicoCategoria>();

            // Repositório
            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}