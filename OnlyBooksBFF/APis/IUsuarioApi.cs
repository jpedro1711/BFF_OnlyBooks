using OnlyBooksApi.Models.Dtos;
using Refit;

namespace OnlyBooksBFF.APis
{
    public interface IUsuarioApi
    {
        [Get("/Usuario")]
        Task<ApiResponse<List<UsuarioResponseDto>>> ListarUsuarios();
        [Get("/Usuario/{id}")]
        Task<ApiResponse<UsuarioResponseDto>> BuscarUsuario(int id);
        [Post("/Usuario")]
        Task<ApiResponse<UsuarioResponseDto>> CriarUsuario([Body] CreateOrUpdateUsuarioDto createOrUpdateUsuarioDto);
        [Delete("/Usuario")]
        Task<ApiResponse<UsuarioResponseDto>> RemoverUsuario(int id);
        [Put("/Usuario/{id}")]
        Task<ApiResponse<UsuarioResponseDto>> AtualizarUsuario(int id, [Body] CreateOrUpdateUsuarioDto createOrUpdateUsuarioDto);
    }
}
