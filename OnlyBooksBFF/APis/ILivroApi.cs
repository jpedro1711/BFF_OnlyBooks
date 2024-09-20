using OnlyBooksApi.Models.Dtos;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlyBooksBFF.APis
{
    public interface ILivroApi
    {
        [Get("/Livro")]
        Task<List<LivroResponseDto>> ListarLivros();
    }
}
