using Microsoft.AspNetCore.Mvc;
using BookStore.API.Domain.Models;
using BookStore.API.Interfaces.Services;

namespace BookStore.API.Controllers.V1;

[ApiController]
[Route("v1/api/[controller]")]
public class BookController : ControllerBase
{
    private readonly ICatalogoService _catalogoService;
   
    public BookController(ICatalogoService catalogoService)
    {
        _catalogoService = catalogoService;

    }

    /// <summary>
    /// Obtem a lista de books por nome do livro
    /// </summary>
    /// <param name="nomeLivro">Uma sequencia de caracteres que contenha o nome do livro</param>
    /// <response code="200">Se todas as informacoes forem recuperadas com sucesso</response>
    /// <response code="400">Se ocorrerem falhas nas validações</response>
    /// <response code="500">Se ocorrerem erros de processamento no servidor</response>
    [HttpGet("busca-livro-nome")]
    [ProducesResponseType(typeof(Book), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(object), 500)]
    public async Task<ActionResult<List<Book>>> BuscaLivroNome([FromQuery] string nomeLivro)
    {
        return Ok(await _catalogoService.BuscarPorNomeDoLivro(nomeLivro));
    }

    /// <summary>
    /// Obtem a lista de books por autor
    /// </summary>
    /// <param name="autor">Uma sequencia de caracteres que contenha o nome do author do livro</param>
    /// <response code="200">Se todas as informacoes forem recuperadas com sucesso</response>
    /// <response code="400">Se ocorrerem falhas nas validações</response>
    /// <response code="500">Se ocorrerem erros de processamento no servidor</response>
    [HttpGet("busca-livro-autor")]
    [ProducesResponseType(typeof(Book), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(object), 500)]
    public async Task<ActionResult<Book>> BuscaLivroAutor([FromQuery] string autor)
    {
        return Ok(await _catalogoService.BuscarPorAutorDoLivro(autor));
    }


    /// <summary>
    /// Obtem a lista de books por nome do Ilustrador
    /// </summary>
    /// <param name="ilustrador">Uma sequencia de caracteres que contenha no nome do ilustrador do livro</param>
    /// <response code="200">Se todas as informacoes forem recuperadas com sucesso</response>
    /// <response code="400">Se ocorrerem falhas nas validações</response>  
    /// <response code="500">Se ocorrerem erros de processamento no servidor</response>
    [HttpGet("busca-livro-por-ilustrador")]
    [ProducesResponseType(typeof(Book), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(object), 500)]
    public async Task<ActionResult<List<Book>>> BuscaLivroIlustrador([FromQuery] string ilustrador)
    {
        return Ok( await _catalogoService.BuscarPorIlustradorDoLivro(ilustrador));
    }
    /// <summary>
    /// Obtem a lista de books por nome do Genero
    /// </summary>
    /// <param name="genero">Uma sequencia de caracteres que contenha no nome do genero do livro</param>
    /// <response code="200">Se todas as informacoes forem recuperadas com sucesso</response>
    /// <response code="400">Se ocorrerem falhas nas validações</response>
    /// <response code="500">Se ocorrerem erros de processamento no servidor</response>
    [HttpGet("busca-livro-por-genero")]
    [ProducesResponseType(typeof(Book), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(object), 500)]
    public async Task<ActionResult<List<Book>>> BuscaLivroGenero([FromQuery] string genero)
    {
        return Ok(await _catalogoService.BuscarPorGeneroDoLivro(genero));
    }
}