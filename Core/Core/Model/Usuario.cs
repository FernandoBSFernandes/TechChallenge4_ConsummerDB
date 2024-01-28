using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Usuario
    {
        [Required]
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Guid Id { get; set; }

        public Usuario(string nome, string email, Guid id)
        {
            Nome = nome;
            Email = email;
            Id = id;
        }

        public override string ToString() => $"Usuário {Nome} ({Email})";
    }
}