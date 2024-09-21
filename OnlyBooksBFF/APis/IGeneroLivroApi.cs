using OnlyBooksApi.Models.Dtos;
using Refit;

namespace OnlyBooksBFF.APis
{
    public interface IGeneroLivroApi
    {
        [Get("/GeneroLivro")]
        Task<ApiResponse<List<GeneroLivroResponseDto>>> ListarGeneros();
        [Get("/GeneroLivro/{id}")]
        Task<ApiResponse<GeneroLivroResponseDto>> BuscarGenero(int id);
        [Post("/GeneroLivro")]
        Task<ApiResponse<GeneroLivroResponseDto>> CriarGenero([Body] GeneroLivroDto generoLivro);
        [Put("/GeneroLivro/{id}")]
        Task<ApiResponse<GeneroLivroResponseDto>> AtualizarGeneroLivro(int id, [Body] GeneroLivroDto livro);
        [Delete("/GeneroLivro")]
        Task<ApiResponse<object>> RemoverGeneroLivro([Query] int id);
    }
}
