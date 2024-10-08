using OnlyBooksApi.Models.Dtos;
using OnlyBooksBFF.Models.Mongo;
using Refit;

namespace OnlyBooksBFF.APis
{
    public interface ICreateEmprestimoAsyncApi
    {
        [Post("/Emprestimo")]
        Task<ApiResponse<EmprestimoResponse>> CreateEmprestimo([Body] CreateEmprestimoDto createEmprestimoDto);
    }
}
