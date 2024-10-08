using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlyBooksApi.Models;
using OnlyBooksApi.Models.Dtos;
using OnlyBooksApi.Models.Enums;
using OnlyBooksBFF.APis;
using OnlyBooksBFF.Models.Dtos;
using OnlyBooksBFF.Models.Mongo;
using Refit;
using System.Text.Json;

namespace OnlyBooksBFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmprestimosController : ControllerBase
    {
        private readonly IEmprestimoApi _api;
        private readonly ICreateEmprestimoAsyncApi _createEmprestimoApi;
        private readonly IReservaApi _reservaApi;
        private string azureFunctionHostKey;

        public EmprestimosController(IEmprestimoApi api, IConfiguration configuration, IReservaApi reservaApi, ICreateEmprestimoAsyncApi createEmprestimoApi)
        {
            _api = api;
            _reservaApi = reservaApi;
            azureFunctionHostKey = configuration["AzureFunction:HostKey"];
            _createEmprestimoApi = createEmprestimoApi;
        }

        [HttpGet]
        public async Task<ActionResult<EmprestimoResponse>> GetEmprestimos()
        {
            var response = await _api.GetEmprestimos(azureFunctionHostKey);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet("EmprestimosById/{id}")]
        public async Task<ActionResult<EmprestimoResponse>> GetEmprestimoById([FromRoute] string id)
        {
            ApiResponse<EmprestimoResponse> response = await _api.GetEmprestimoById(id, azureFunctionHostKey);

            if (response.IsSuccessStatusCode)
            {
                EmprestimoResponse emprestimo = response.Content;

                if (emprestimo == null)
                {
                    return NotFound();
                }

                var reserva = await _reservaApi.BuscarReserva(emprestimo.ReservaId);

                if (reserva != null)
                {
                    ReservaDto dadosReserva = reserva.Content;

                    EmprestimoReservaResponseDto emprestimoResponse = new EmprestimoReservaResponseDto
                    {
                        Emprestimo = new Emprestimo 
                        { 
                            Id = emprestimo.Id, 
                            ReservaId = (int)dadosReserva.Id, 
                            DataDevolucao = emprestimo.DataDevolucao, 
                            StatusEmprestimo = (StatusEmprestimo)emprestimo.StatusEmprestimo 
                        },
                        Reserva = null,
                    };

                    if (dadosReserva != null)
                    {
                        emprestimoResponse.Reserva = new Reserva
                        {
                            Id = (int)dadosReserva.Id,
                            DataReserva = dadosReserva.DataReserva,
                            StatusReserva = dadosReserva.StatusReserva,
                            UsuarioId = dadosReserva.UsuarioId,
                        };
                    }


                    return Ok(emprestimoResponse);
                }
 
            }

            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }


        [HttpPost]
        public async Task<ActionResult<EmprestimoResponse>> CreateEmprestimo([FromBody] CreateEmprestimoDto dto)
        {
            var result = await _createEmprestimoApi.CreateEmprestimo(dto);

            if (result.IsSuccessStatusCode)
            {
                return Ok("Sua requisição está sendo processada");
            }
            return StatusCode((int)result.StatusCode, result.ReasonPhrase);
        }

        [HttpPatch("{id}/{status}")]
        public async Task<ActionResult<EmprestimoResponse>> UpdateStatusEmprestimo(string id, string status)
        {
            var response = await _api.UpdateStatus(id, status, azureFunctionHostKey);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpDelete("DeleteEmprestimo/{id}")]
        public async Task<ActionResult<EmprestimoResponse>> DeleteEmprestimo([FromRoute] string id)
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
