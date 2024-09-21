using OnlyBooksApi.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyBooksApi.Models.Dtos
{
    public record LivroDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int? Status { get; set; }
        public double NotaAvaliacao { get; set; } = 0;
        public int totalAvaliações { get; set; } = 0;
        public int GeneroLivroId { get; set; }
    }
}
