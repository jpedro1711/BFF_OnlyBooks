using OnlyBooksApi.Models.Enums;
using OnlyBooksBFF.Models.Mongo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyBooksApi.Models
{
    public class Emprestimo
    {
        [Key]
        public MongoId Id { get; set; }
        [ForeignKey("Reserva")]
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
        public DateTime DataDevolucao  { get; set; }
        public StatusEmprestimo StatusEmprestimo { get; set; } = StatusEmprestimo.Ativo;
    }
}
