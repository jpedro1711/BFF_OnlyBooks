using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Models.Dtos;
using OnlyBooksBFF.APis;
using System.Text.Json;

namespace OnlyBooksBFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroApi _livroApi;

        public LivroController(ILivroApi livroApi)
        {
            _livroApi =livroApi;
        }

        [HttpGet("listarLivros")]
        public async Task<ActionResult<List<LivroResponseDto>>> ListarLivros()
        {
            var livros = await _livroApi.ListarLivros();

            return Ok(livros);
        }

    }
}
