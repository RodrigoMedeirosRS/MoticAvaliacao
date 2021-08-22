using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;

using DAO;
using BLL;
using DAL;
using API.Interface;
using DAL.Interface;
using BLL.Interface;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AdicionarControladores(services);
            AdicionarDataContext(services, Configuration.GetConnectionString("motic_avaliacao"));
            RealizarInjecaoDeDependenciasBLL(services);
            RealizarInjecaoDeDependeciasDAL(services);
            DefinirConfiguracaoSwagger(services);
        }

        public static void RealizarInjecaoDeDependenciasBLL(IServiceCollection services)
        {
            services.AddScoped<IRequisicao, Requisicao>();
            services.AddScoped<ICadastroBLL, CadastroBLL>();
            services.AddScoped<IAvaliacaoBLL, AvaliacaoBLL>();
        }

        public static void RealizarInjecaoDeDependeciasDAL(IServiceCollection services)
        {
            services.AddScoped<ICadastroDAL, CadastroDAL>();
            services.AddScoped<IAvaliacaoDAL, AvaliacaoDAL>();
        }

        private static void AdicionarDataContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<motic_avaliacaoContext>(options => options.UseNpgsql(connectionString));
        }

        private static void AdicionarControladores(IServiceCollection services)
        {
            services.AddControllers();
        }

        private static void DefinirConfiguracaoSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Motic Avaliação Digital", Version = "v1" });
                options.CustomOperationIds(d => (d.ActionDescriptor as ControllerActionDescriptor)?.ActionName);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { 
                option.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(option => {
                option.RoutePrefix = swaggerOptions.RoutePrefix;
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
