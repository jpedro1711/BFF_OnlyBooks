using OnlyBooksApi.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyBooksApi.Models.Dtos
{
    public record EmprestimoDto
    {
        public class EmprestimoResponseDto
        {
            public int IdTimestamp { get; set; }
            public int IdMachine { get; set; }
            public int IdPid { get; set; }
            public int IdIncrement { get; set; }
            public DateTime IdCreationTime { get; set; }
            public int ReservaId { get; set; }
            public DateTime DataDevolucao { get; set; }
            public int StatusEmprestimo { get; set; }
        }

    }
}
