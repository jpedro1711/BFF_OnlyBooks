using OnlyBooksApi.Models.Dtos;
using OnlyBooksApi.Models.Enums;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlyBooksBFF.APis
{
    public interface ILivroApi
    {
        [Get("/Livro")]
        Task<ApiResponse<List<LivroResponseDto>>> ListarLivros();
        [Get("/Livro/{id}")]
        Task<ApiResponse<LivroResponseDto>> BuscarLivro(int id);

        [Post("/Livro")]
        Task<ApiResponse<LivroResponseDto>> CriarLivro([Body] CreateLivroDto livro);

        [Delete("/Livro")]
        Task<ApiResponse<object>> RemoverLivro([Query] int id);

        [Put("/Livro/{id}")]
        Task<ApiResponse<LivroResponseDto>> AtualizarLivro(int id, [Body] LivroDto livro);

        [Patch("/Livro/atualizarStatus")]
        Task<ApiResponse<LivroResponseDto>> AtualizarStatus([Query] int id, [Query] StatusLivro novoStatus);

        [Patch("/Livro/avaliar")]
        Task<ApiResponse<LivroResponseDto>> AvaliarLivro([Query] int id, [Query] int novaNota);
    }
}
