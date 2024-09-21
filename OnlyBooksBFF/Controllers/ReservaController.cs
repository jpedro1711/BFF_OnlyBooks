using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Models.Dtos;
using OnlyBooksApi.Models.Enums;
using OnlyBooksBFF.APis;

namespace OnlyBooksBFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaApi _api;

        public ReservaController(IReservaApi api)
        {
            _api = api;
        }

        [HttpGet("listarReservas")]
        public async Task<ActionResult<List<ReservaDto>>> ListarReservas()
        {
            var response = await _api.ListarReservas();
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDto>> BuscarReserva(int id)
        {
            var response = await _api.BuscarReserva(id);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpPost]
        public async Task<ActionResult<ReservaDto>> CriarReserva([FromBody] CreateReservaDto reservaDto)
        {
            var response = await _api.CriarReserva(reservaDto);
            if (response.IsSuccessStatusCode)
            {
                return CreatedAtAction(nameof(BuscarReserva), new { id = response.Content.Id }, response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpPatch("atualizarStatus")]
        public async Task<ActionResult<ReservaDto>> AtualizarStatus([FromQuery] int id, [FromQuery] StatusReserva novoStatus)
        {
            var response = await _api.AtualizarStatus(id, novoStatus);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet("usuario")]
        public async Task<ActionResult<LivroResponseDto>> Avaliar([FromQuery] string userEmail)
        {
            var response = await _api.GetReservasByUserEmail(userEmail);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
