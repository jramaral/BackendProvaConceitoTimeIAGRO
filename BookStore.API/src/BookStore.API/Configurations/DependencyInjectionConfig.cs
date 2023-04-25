using BookStore.API.Domain;
using BookStore.API.Domain.Models;
using BookStore.API.FreteCerto;
using BookStore.API.FreteCerto.CalcularFrete;
using BookStore.API.FreteCerto.Frete;
using BookStore.API.Interfaces.Services;
using BookStore.API.Services;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFrete, FreteVintePorcento>();

            services.AddSingleton<IEnumerable<Book>>(serviceProvider =>
            {
                var arquivoJson = configuration.GetSection("FileJson:CatalogoJson").Value;
               
                var json = File.ReadAllText(arquivoJson);

                var _book = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;

                FreteCerto.FreteCerto calculadora = new FreteCerto.FreteCerto(new FreteVintePorcento());

                List<Book> result = new List<Book>();

                foreach (Book book in _book)
                {
                    book.ValorFrete = calculadora.CalcularFrete(book.Price);
                    book.Specifications.IllustratorContent = book.WriteArrayOrString(book.Specifications.Illustrator!);

                    book.Specifications.GeneresContent = book.WriteArrayOrString(book.Specifications.Genres!);

                    result.Add(book);

                }
                return result;
  

            });

            #region Services
            services.AddTransient<ICatalogoService, CatalogoService>();
          
            #endregion

            return services;
        }
    }
}
