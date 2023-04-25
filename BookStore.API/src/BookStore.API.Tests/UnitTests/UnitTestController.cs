using BookStore.API.Controllers;
using BookStore.API.Controllers.V1;
using BookStore.API.Domain.Models;
using BookStore.API.Interfaces.Services;
using BookStore.API.Tests.Configuracao;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.API.Tests.UnitTests
{
    public class BookControllerTest
    {

        [Fact]
        public async Task BuscaLivroNome_ReturnsOkResult_WhenLivroExists()
        {
            // Arrange
            var mockCatalogoService = new Mock<ICatalogoService>();
            mockCatalogoService
                .Setup(service => service.BuscarPorNomeDoLivro(It.IsAny<string>()))
                .ReturnsAsync(new List<Book> { new Book { Id = 1, Name = "Livro 1" } });

            var controller = new BookController(mockCatalogoService.Object);

            // Act
            var result = await controller.BuscaLivroNome("Livro");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var books = Assert.IsAssignableFrom<List<Book>>(okResult.Value);
            Assert.Equal(1, books.Count!);
            Assert.Equal("Livro 1", books[0].Name);
        }
       
        [Fact]
        public async Task BuscaLivroAutor_ReturnsOkResult_WhenLivroExists()
        {
            // Arrange
            var mockCatalogoService = new Mock<ICatalogoService>();
            mockCatalogoService
                .Setup(service => service.BuscarPorAutorDoLivro(It.IsAny<string>()))
                .ReturnsAsync(
                 new List<Book> {
                    new Book()
                    {
                        Id = 1,
                        Name = "Book A",
                        Specifications = new ()
                        {
                            Author = "Autor 1",
                            GeneresContent = "Genre A, Genre B",
                            IllustratorContent = "Illustrator A"
                        }
                }});

            var controller = new BookController(mockCatalogoService.Object);

            // Act
            var result = await controller.BuscaLivroAutor("Autor");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var books = Assert.IsAssignableFrom<List<Book>>(okResult.Value);
            Assert.Equal(1, books.Count!);
            Assert.Equal("Autor 1", books[0].Specifications!.Author);
        }

        [Fact]
        public async Task BuscaLivroIlustrador_ReturnsOkResult_WhenLivroExists()
        {
            // Arrange
            var mockCatalogoService = new Mock<ICatalogoService>();
            mockCatalogoService
                .Setup(service => service.BuscarPorIlustradorDoLivro(It.IsAny<string>()))
                .ReturnsAsync(new List<Book> {
                    new Book()
                    {
                        Id = 1,
                        Name = "Book A",
                        Specifications = new ()
                        {
                            Author = "Autor 1",
                            GeneresContent = "Genre A, Genre B",
                            IllustratorContent = "Ilustrador 1"
                        }
                }});

            var controller = new BookController(mockCatalogoService.Object);

            // Act
            var result = await controller.BuscaLivroIlustrador("Ilustrador");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var books = Assert.IsAssignableFrom<List<Book>>(okResult.Value);
            Assert.Equal(1, books.Count!);
            Assert.Equal(1, books[0].Id);
            Assert.Equal("Ilustrador 1", books[0].Specifications!.IllustratorContent);

        }
    }

}
