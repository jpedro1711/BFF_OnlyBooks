using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Models.Dtos;
using OnlyBooksApi.Models.Enums;
using Refit;

namespace OnlyBooksBFF.APis
{
    public interface IEmprestimoApi
    {
        [Get("/GetEmprestimos")]
        Task<ApiResponse<List<object>>> GetEmprestimos([Query] string code);
        [Get("/Emprestimos/{id}")]
        Task<ApiResponse<object>> GetEmprestimoById([AliasAs("id")] string emprestimoId, [Query] string code);
        [Post("/CreateEmprestimo")]
        Task<ApiResponse<object>> CreateEmprestimo([Body] CreateEmprestimoDto createEmprestimoDto,[Query] string code);
        [Patch("/Emprestimos/{id}/{status}")]
        Task<ApiResponse<object>> UpdateStatus(string id, string status, [Query] string code);
        [Delete("/Emprestimos/{id}")]
        Task<ApiResponse<object>> RemoverEmprestimo([AliasAs("id")] string emprestimoId, [Query] string code);
    }
}
