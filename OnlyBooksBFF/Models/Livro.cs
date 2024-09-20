using OnlyBooksApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlyBooksApi.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public StatusLivro Status { get; set; } = StatusLivro.Disponivel;
        public double NotaAvaliacao { get; set; } = 0;
        public int? SomaTotalAvaliaçoes { get; set; } = 0;
        public int? TotalAvaliações { get; set; } = 0;
        [ForeignKey("GeneroLivro")]
        public int GeneroLivroId { get; set; }
        public GeneroLivro? Genero { get; set; }
        [JsonIgnore]
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
