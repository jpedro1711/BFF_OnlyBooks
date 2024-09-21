using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Models.Dtos;
using OnlyBooksBFF.APis;

namespace OnlyBooksBFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApi _api;

        public UsuarioController(IUsuarioApi api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioResponseDto>>> ListarUsuarios()
        {
            var response = await _api.ListarUsuarios();
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDto>> BuscarUsuario(int id)
        {
            var response = await _api.BuscarUsuario(id);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpPost]
        public async Task<ActionResult> CriarUsuario([FromBody] CreateOrUpdateUsuarioDto usuarioDto)
        {
            var response = await _api.CriarUsuario(usuarioDto);
            if (response.IsSuccessStatusCode)
            {
                return CreatedAtAction(nameof(BuscarUsuario), new { id = response.Content }, response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverUsuario(int id)
        {
            var response = await _api.RemoverUsuario(id);
            if (response.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CreateOrUpdateUsuarioDto>> AtualizarUsuario(int id, [FromBody] CreateOrUpdateUsuarioDto usuario)
        {
            var response = await _api.AtualizarUsuario(id, usuario);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
