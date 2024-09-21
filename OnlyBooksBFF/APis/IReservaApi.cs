using OnlyBooksApi.Models.Dtos;
using OnlyBooksApi.Models.Enums;
using Refit;

namespace OnlyBooksBFF.APis
{
    public interface IReservaApi
    {
        [Get("/Reserva")]
        Task<ApiResponse<List<ReservaDto>>> ListarReservas();
        [Get("/Reserva/{id}")]
        Task<ApiResponse<ReservaDto>> BuscarReserva(int id);
        [Post("/Reserva")]
        Task<ApiResponse<ReservaDto>> CriarReserva([Body] CreateReservaDto reserva);
        [Get("/Reserva/usuario")]
        Task<ApiResponse<ReservaDto>> GetReservasByUserEmail([Query] string userEmail);
        [Patch("/Reserva/atualizarStatus")]
        Task<ApiResponse<ReservaDto>> AtualizarStatus([Query] int id, [Query] StatusReserva novoStatus);
    }
}
