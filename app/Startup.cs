using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using desafio_docker.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;

namespace desafio_docker
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            SeedDatabase();
        }

        public async void SeedDatabase()
        {
            
            
            using (var connection = Connection.GetConnection())
            {
                await CreateDatabase(connection);
                await SeedModules(connection);
            }
        }

        private async Task SeedModules(MySqlConnection connection)
        {
            var id = await connection.QueryFirstOrDefaultAsync<int?>("select id from modules limit 1");

            if (!id.HasValue)
            {
                var modules = new List<Module> {
                     new Module("Docker","https://portal.code.education/lms/#/180/163/110/conteudos"),
                     new Module("Fundamentos de Arquitetura de Software","https://portal.code.education/lms/#/180/163/112/conteudos"),
                     new Module("Comunicação","https://portal.code.education/lms/#/180/163/116/conteudos"),
                     new Module("RabbitMQ","https://portal.code.education/lms/#/180/163/102/conteudos"),
                     new Module("Autenticação e Keycloak","https://portal.code.education/lms/#/180/163/108/conteudos"),
                     new Module("DDD e Arquitetura hexagonal","https://portal.code.education/lms/#/180/163/123/conteudos"),
                     new Module("Arquitetura do projeto prático - Codeflix","https://portal.code.education/lms/#/180/163/124/conteudos"),
                };

                await connection.InsertAsync(modules);
            }
        }

        private async Task CreateDatabase(MySqlConnection connection)
        {
            var createtablequery = @"create table IF NOT EXISTS modules(
    id int not null auto_increment,
    name nvarchar(256) collate utf8_unicode_ci,
    url nvarchar(500),
    primary key(id)
);";
            await connection.ExecuteAsync(createtablequery);

        }
    }
}
