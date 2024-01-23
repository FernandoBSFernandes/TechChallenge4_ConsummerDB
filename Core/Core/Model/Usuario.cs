using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Usuario
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public Usuario(Guid id, string nome, string? email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public override string ToString()
        {
            return $"Usuário {Nome} ({Email})";
        }
    }
}