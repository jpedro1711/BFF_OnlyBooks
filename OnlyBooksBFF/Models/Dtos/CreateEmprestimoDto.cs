using OnlyBooksApi.Models.Enums;

namespace OnlyBooksApi.Models.Dtos
{
    public record CreateEmprestimoDto
    {
        public int ReservaId { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
