using Alura.ListaLeitura.App.Logica;
using Alura.ListaLeitura.App.Mvc;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //usando servico de roteamento automatico do Asp.Net Core
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);

            //builder.MapRoute("Livros/ParaLer", LivrosLogica.ParaLer);
            //builder.MapRoute("Livros/Lendo", LivrosLogica.Lendo);
            //builder.MapRoute("Livros/Lidos", LivrosLogica.Lidos);
            //builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.Detalhes); // somente inteiro no template id
            //builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivro);            
            //builder.MapRoute("Cadastro/ExibeFormulario", CadastroLogica.ExibeFormulario);
            //builder.MapRoute("Cadastro/Incluir", CadastroLogica.Incluir);

            var rotas = builder.Build();

            app.UseRouter(rotas);

            //app.Run(Roteamento);
        }

        /*public Task Roteamento(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();

            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                { "/Livros/ParaLer",  LivrosParaLer },
                { "/Livros/Lendo", LivrosLendo },
                { "/Livros/Lidos", LivrosLidos }
            };


            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];

                return metodo.Invoke(context);
            }

            context.Response.StatusCode = 404;

            return context.Response.WriteAsync("Caminho inexistente!");
        }*/


    }
}