using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Models.Dtos;
using OnlyBooksBFF.APis;
using OnlyBooksApi.Models.Enums;
namespace OnlyBooksBFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroApi _livroApi;

        public LivroController(ILivroApi livroApi)
        {
            _livroApi = livroApi;
        }

        [HttpGet("listarLivros")]
        public async Task<ActionResult<List<LivroResponseDto>>> ListarLivros()
        {
            var response = await _livroApi.ListarLivros();
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroResponseDto>> BuscarLivro(int id)
        {
            var response = await _livroApi.BuscarLivro(id);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpPost]
        public async Task<ActionResult<LivroResponseDto>> CriarLivro([FromBody] CreateLivroDto livro)
        {
            var response = await _livroApi.CriarLivro(livro);
            if (response.IsSuccessStatusCode)
            {
                return CreatedAtAction(nameof(BuscarLivro), new { id = response.Content.Id }, response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverLivro([FromQuery] int id)
        {
            var response = await _livroApi.RemoverLivro(id);
            if (response.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LivroResponseDto>> AtualizarLivro(int id, [FromBody] LivroDto livro)
        {
            var response = await _livroApi.AtualizarLivro(id, livro);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpPatch("atualizarStatus")]
        public async Task<ActionResult<LivroResponseDto>> AtualizarStatus([FromQuery] int id, [FromQuery] StatusLivro novoStatus)
        {
            var response = await _livroApi.AtualizarStatus(id, novoStatus);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpPatch("avaliar")]
        public async Task<ActionResult<LivroResponseDto>> Avaliar([FromQuery] int id, [FromQuery] int novaNota)
        {
            var response = await _livroApi.AvaliarLivro(id, novaNota);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
