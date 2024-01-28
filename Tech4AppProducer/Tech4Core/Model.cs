using System.ComponentModel.DataAnnotations;

namespace Tech4Core.Model
{
    public class Usuario
    {
        [Required]
        public string Nome { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public Usuario(string nome, string? email)
        {
            Nome = nome;
            Email = email;
        }

        public override string ToString()
        {
            return $"Usuário {Nome} ({Email})";
        }
    }
}