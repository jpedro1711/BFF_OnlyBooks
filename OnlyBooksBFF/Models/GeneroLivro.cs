using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlyBooksApi.Models
{
    public class GeneroLivro
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public List<Livro> Livros { get; set; }
    }
}
