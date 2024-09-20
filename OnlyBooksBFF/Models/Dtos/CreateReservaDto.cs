namespace OnlyBooksApi.Models.Dtos
{
    public record CreateReservaDto
    {
        public int UsuarioId { get; set; }
        public List<int> LivrosIds { get; set; }
    }
}
