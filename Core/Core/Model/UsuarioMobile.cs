using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class UsuarioMobile
    {

        [Required]
        public string Nome { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public UsuarioMobile(string nome, string? email)
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
