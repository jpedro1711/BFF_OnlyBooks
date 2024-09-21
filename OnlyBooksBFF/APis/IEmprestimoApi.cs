using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Models.Dtos;
using OnlyBooksApi.Models.Enums;
using OnlyBooksBFF.Models.Mongo;
using Refit;

namespace OnlyBooksBFF.APis
{
    public interface IEmprestimoApi
    {
        [Get("/GetEmprestimos")]
        Task<ApiResponse<List<EmprestimoResponse>>> GetEmprestimos([Query] string code);
        [Get("/Emprestimos/{id}")]
        Task<ApiResponse<EmprestimoResponse>> GetEmprestimoById([AliasAs("id")] string emprestimoId, [Query] string code);
        [Post("/CreateEmprestimo")]
        Task<ApiResponse<EmprestimoResponse>> CreateEmprestimo([Body] CreateEmprestimoDto createEmprestimoDto,[Query] string code);
        [Patch("/Emprestimos/{id}/{status}")]
        Task<ApiResponse<EmprestimoResponse>> UpdateStatus(string id, string status, [Query] string code);
        [Delete("/Emprestimos/{id}")]
        Task<ApiResponse<EmprestimoResponse>> RemoverEmprestimo([AliasAs("id")] string emprestimoId, [Query] string code);
    }
}
