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
        [Delete("/GeneroLivro/{id}")]
        Task<ApiResponse<object>> RemoverGeneroLivro(int id);
        [Put("/Livro/{id}")]
        Task<ApiResponse<GeneroLivroResponseDto>> AtualizarGeneroLivro(int id, [Body] GeneroLivroDto livro);
    }
}
