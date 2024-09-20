using OnlyBooksApi.Models.Enums;

namespace OnlyBooksApi.Models.Dtos
{
    public record CreateLivroDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int GeneroLivroId { get; set; }
    }
}
