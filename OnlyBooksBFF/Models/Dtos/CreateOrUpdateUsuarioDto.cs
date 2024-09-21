using OnlyBooksApi.Models.Enums;

namespace OnlyBooksApi.Models.Dtos
{
    public record CreateOrUpdateUsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoUsuario { get; set; }
    }
}
