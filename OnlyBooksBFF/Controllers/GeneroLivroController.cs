using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Models.Dtos;
using OnlyBooksBFF.APis;

namespace OnlyBooksBFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroLivroController : ControllerBase
    {
        private readonly IGeneroLivroApi _api;

        public GeneroLivroController(IGeneroLivroApi api)
        {
            _api = api;
        }

        [HttpGet("listarGeneros")]
        public async Task<ActionResult<List<GeneroLivroResponseDto>>> ListarGenerosLivro()
        {
            var response = await _api.ListarGeneros();
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroLivroResponseDto>> BuscarGeneroLivro(int id)
        {
            var response = await _api.BuscarGenero(id);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpPost]
        public async Task<ActionResult<GeneroLivroResponseDto>> CriarLivro([FromBody] GeneroLivroDto generoLivro)
        {
            var response = await _api.CriarGenero(generoLivro);
            if (response.IsSuccessStatusCode)
            {
                return CreatedAtAction(nameof(BuscarGeneroLivro), new { id = response.Content }, response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        // TODO: Rever
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverGeneroLivro(int id)
        {
            var response = await _api.RemoverGeneroLivro(id);
            if (response.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        // TODO: Rever
        [HttpPut("{id}")]
        public async Task<ActionResult<GeneroLivroResponseDto>> AtualizarGeneroLivro(int id, [FromBody] GeneroLivroDto livro)
        {
            var response = await _api.AtualizarGeneroLivro(id, livro);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
