using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Ws.Financeiro.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Ws.Financeiro.Domain.Intefaces.Repository;
using Ws.Financeiro.Infra.Repository;
using Ws.Financeiro.Domain.Intefaces;
using Ws.Financeiro.Domain.Notificacoes;
using Ws.Financeiro.Domain.Services;
using Ws.Financeiro.Domain.Intefaces.Service;
using Ws.Financeiro.API.Configuration;
using Ws.Financeiro.API.Extensions;

namespace Ws.Financeiro.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EntityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddIdentityConfiguration(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            //app.UseAuthorization();
            //app.UseHttpsRedirection();


            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGastoRepository, GastoRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ITipoPagamentoRepository, TipoPagamentoRepository>();

            services.AddScoped<IGastoService, GastoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ITipoPagamentoService, TipoPagamentoService>();

            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
