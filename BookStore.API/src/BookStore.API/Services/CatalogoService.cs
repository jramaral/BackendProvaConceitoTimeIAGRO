using BookStore.API.Domain.Models;
using BookStore.API.Interfaces.Services;


namespace BookStore.API.Services
{
    public class CatalogoService : ICatalogoService
    {
        private readonly IEnumerable<Book> _books;
           public CatalogoService(IEnumerable<Book> books)
        {
            _books = books;
        }

        public async Task<IEnumerable<Book>> BuscarPorAutorDoLivro(string autor)
        {
            var data = (from b in _books
                     where b.Specifications.Author.Contains(autor, StringComparison.OrdinalIgnoreCase)
                     select b).ToList();

            return await Task.FromResult(data);
        }

        public async Task<IEnumerable<Book>> BuscarPorGeneroDoLivro(string genero)
        {
            var data = (from b in _books
                        let genresContent = b.Specifications.GeneresContent
                        where genresContent.Contains(genero, StringComparison.OrdinalIgnoreCase)
                        select b).ToList();

            return await Task.FromResult(data);

        }

        public async Task<IEnumerable<Book>> BuscarPorIlustradorDoLivro(string ilustrador)
        {
            var data = (from b in _books
                        let illustratorContent = b.Specifications.IllustratorContent
                        where illustratorContent.Contains(ilustrador, StringComparison.OrdinalIgnoreCase)
                        select b).ToList();

            return await Task.FromResult(data);
        }

        public async Task<IEnumerable<Book>> BuscarPorNomeDoLivro(string nome)
        {
            var data = (from b in _books
             where b.Name.Contains(nome, StringComparison.OrdinalIgnoreCase)
             select b).ToList();
            
            return await Task.FromResult(data);
        }


    }
}

