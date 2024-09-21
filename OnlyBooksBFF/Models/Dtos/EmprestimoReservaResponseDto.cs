using OnlyBooksApi.Models;

namespace OnlyBooksBFF.Models.Dtos
{
    public record EmprestimoReservaResponseDto
    {
        public Emprestimo Emprestimo { get; set; }
        public Reserva? Reserva { get; set; }
    }
}
