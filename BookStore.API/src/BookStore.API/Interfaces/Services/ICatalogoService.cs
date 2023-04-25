using BookStore.API.Domain.Models;

namespace BookStore.API.Interfaces.Services
{
    public interface ICatalogoService
    {
        Task<IEnumerable<Book>> BuscarPorNomeDoLivro(string nome);
        Task<IEnumerable<Book>> BuscarPorAutorDoLivro(string autor);
        Task<IEnumerable<Book>> BuscarPorIlustradorDoLivro(string ilustrador);
        Task<IEnumerable<Book>> BuscarPorGeneroDoLivro(string genero);
  

    }

}
