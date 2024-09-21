using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlyBooksApi.Models.Dtos;
using OnlyBooksApi.Models.Enums;
using OnlyBooksBFF.APis;

namespace OnlyBooksBFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmprestimosController : ControllerBase
    {
        private readonly IEmprestimoApi _api;
        private string azureFunctionHostKey;

        public EmprestimosController(IEmprestimoApi api, IConfiguration configuration)
        {
            _api = api;
            azureFunctionHostKey = configuration["AzureFunction:HostKey"];
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetEmprestimos()
        {
            var response = await _api.GetEmprestimos(azureFunctionHostKey);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet("EmprestimosById/{id}")]
        public async Task<ActionResult<object>> GetEmprestimoById([FromRoute] string id)
        {
            var response = await _api.GetEmprestimoById(id, azureFunctionHostKey);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }


        [HttpPost]
        public async Task<ActionResult<object>> CreateEmprestimo([FromBody] CreateEmprestimoDto dto)
        {
            var result = await _api.CreateEmprestimo(dto, azureFunctionHostKey);

            if (result.IsSuccessStatusCode)
            {
                return CreatedAtAction(nameof(GetEmprestimoById), new { id = result.Content }, result.Content);
            }
            return StatusCode((int)result.StatusCode, result.ReasonPhrase);
        }

        [HttpPatch("{id}/{status}")]
        public async Task<ActionResult<object>> UpdateStatusEmprestimo(string id, string status)
        {
            var response = await _api.UpdateStatus(id, status, azureFunctionHostKey);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpDelete("DeleteEmprestimo/{id}")]
        public async Task<ActionResult<object>> DeleteEmprestimo([FromRoute] string id)
        {
            var response = await _api.RemoverEmprestimo(id, azureFunctionHostKey);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

    }
}
