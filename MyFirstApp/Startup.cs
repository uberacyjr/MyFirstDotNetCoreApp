﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFirstApp.Domain;
using MyFirstApp.Infrastructure;
using MyFirstApp.Service;

namespace MyFirstApp
{
    public class Startup
    {
        //How to read connection string inside .NET Standard Class librahttps://www.google.com.br/webhp?hl=pt-BR&ictx=2&sa=X&ved=0ahUKEwiUj6-qrO7eAhXDI5AKHUPRBKsQPQgHry project from ASP.NET Core
        //https://stackoverflow.com/questions/51304432/how-to-read-connection-string-inside-net-standard-class-library-project-from-as
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Para usar o mvc precisa desse método AddMvc do services
            services.AddMvc();
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.1
            //Forma correta de passar connections string para class librarys
            services.Configure<ConnectionHelper>(_config.GetSection("ConnectionStrings"));
            //Para fazer injeção de depêndencia de classe concreta
            services.AddTransient<PersonListService, PersonListService>();
            services.AddTransient<SqlQuery<Person>, SqlQuery<Person>>();
            //Enteder melhor esse comando. O padrão singleton serve para garantir que uma classe só vai ter uma instância.
            //Nesse caso acredito que a instância é única durante o ciclo de vida da requisição.
            //Consegui com essa chamada acessar a configuração do projeto na class lirary MyFistApp.Service e usar a connection string contida no appsettings
            //https://stackoverflow.com/questions/46574521/is-services-addsingletoniconfiguration-really-needed-in-net-core-2-api
            //https://weblog.west-wind.com/posts/2018/Feb/18/Accessing-Configuration-in-NET-Core-Test-Projects
            //AddSingleton é feito pelo .net core
            // services.AddSingleton(_config);
            // Configuração de Injeção de Depêndencia Interface/Implementação
            //services.AddTransient<interface, implementation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Para usar o mvc precisa adicionar na pipeline o UseMvc
            app.UseMvc(mvc=> {
                mvc.MapRoute("default", "{controller=Default}/{action=Index}/{id?}");
            });
        }
    }
}
