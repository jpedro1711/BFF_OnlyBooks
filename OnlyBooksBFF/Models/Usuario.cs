using Microsoft.EntityFrameworkCore;
using OnlyBooksApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlyBooksApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        [JsonIgnore]
        public List<Reserva> Reservas { get; set; }
    }
}
