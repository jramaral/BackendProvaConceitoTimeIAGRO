using Bogus;
using BookStore.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookStore.API.Tests.Configuracao
{
    public class BaseTest
    {
        protected readonly Faker _faker;
        public BaseTest()
        {
            _faker = new Faker();
        }


        public IEnumerable<Book> CreateCatalog() 
        {
            JsonDocument elementIlustrator = JsonDocument.Parse("\"Édouard Riou\"");
            JsonDocument elementGenres = JsonDocument.Parse("[ \"Science Fiction\", \"Adventure fiction\" ]");

            var listaBook = new List<Book>();

            var book = new Book
            {
                Id = 1,
                Name = "Abc",
                Price = 10,
                Specifications= new()
            };


            book.Specifications.Author = "Jose";
            book.Specifications.OriginallyPublished = "November 25, 1864";
            book.Specifications.PageCount = 1;
            WriteArrayOrString<string>((book.Specifications.Illustrator = elementIlustrator.RootElement),book);
            WriteArrayOrString<string>((book.Specifications.Genres = elementGenres.RootElement), book);

            
            
            listaBook.Add(book);
            return listaBook;
        }
        void WriteArrayOrString<T>(JsonElement element, Book b)
        {
            if (element.ValueKind == JsonValueKind.Array)
            {
                Console.Write(string.Join(", ", element.Deserialize<List<T>>()!));
                b.Specifications!.IllustratorContent = string.Join(", ", element.Deserialize<List<T>>()!);
      
            }
            else
            {

                Console.WriteLine(element);
                b.Specifications!.GeneresContent = element.ToString();
            }
        }

    }

   
}
