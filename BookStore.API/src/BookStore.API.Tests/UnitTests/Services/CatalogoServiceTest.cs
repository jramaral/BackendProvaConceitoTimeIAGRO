using BookStore.API.Domain.Models;
using BookStore.API.Interfaces.Services;
using BookStore.API.Services;
using BookStore.API.Tests.Configuracao;
using Moq;
using Moq.AutoMock;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.API.Tests.UnitTests.Services 
{
    public class CatalogoServiceTest : BaseTest
    {
        private readonly List<Book> _books;
        private readonly ICatalogoService _catalogoService;

        public CatalogoServiceTest()
        {
            _books = new List<Book>()
            {
                new Book()
                {
                    Name = "Book A",
                    Specifications = new ()
                    {
                        Author = "Author A",
                        GeneresContent = "Genre A, Genre B",
                        IllustratorContent = "Illustrator A"
                    }
                },
                new Book()
                {
                    Name = "Book B",
                    Specifications = new ()
                    {
                        Author = "Author B",
                        GeneresContent = "Genre B, Genre C",
                        IllustratorContent = "Illustrator B"
                    }
                },
                new Book()
                {
                    Name = "Book C",
                    Specifications =new ()
                    {
                        Author = "Author C",
                        GeneresContent = "Genre C, Genre D",
                        IllustratorContent = "Illustrator C"
                    }
                }
            };

            _catalogoService = new CatalogoService(_books);
        }

        [Fact]
        public async Task BuscarPorAutorDoLivro_Deve_Retornar_Livros_Do_Autor_Correspondente()
        {
            // Arrange
            string autor = "Author A";

            // Act
            var result = await _catalogoService.BuscarPorAutorDoLivro(autor);

            // Assert
            Assert.Single(result);
            Assert.Contains(result, x => x.Specifications!.Author == autor);
        }

        [Fact]
        public async Task BuscarPorGeneroDoLivro_Deve_Retornar_Livros_Do_Genero_Correspondente()
        {
            // Arrange
            string genero = "Genre C";

            // Act
            var result = await _catalogoService.BuscarPorGeneroDoLivro(genero);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, x => x.Specifications!.GeneresContent.Contains(genero));
        }
        [Fact]
        public async Task BuscarPorIlustradorDoLivro_Deve_Retornar_Livros_Do_Ilustrador_Correspondente()
        {
            // Arrange
            string ilustrador = "Illustrator B";

            // Act
            var result = await _catalogoService.BuscarPorIlustradorDoLivro(ilustrador);

            // Assert
            Assert.Single(result);
            Assert.Contains(result, x => x.Specifications!.IllustratorContent.Contains(ilustrador));
        }
        [Fact]
        public async Task BuscarPorNomeDoLivro_Deve_Retornar_Livros_Com_Nome_Correspondente()
        {
            // Arrange
            string nome = "Book A";

            // Act
            var result = await _catalogoService.BuscarPorNomeDoLivro(nome);

            // Assert
            Assert.Single(result);
            Assert.Contains(result, _ => _.Name!.Contains(nome));
        }
    }
}