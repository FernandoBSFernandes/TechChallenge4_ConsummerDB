using Consummer.Context;
using Core.TableModel;

namespace Consummer.Repository
{
    public interface ICadastrarUsuarioRepository
    {
        public Task Cadastrar(Usuario usuario);

    }

    public class CadastrarUsuarioRepository : ICadastrarUsuarioRepository
    {

        private readonly UsuarioContext _context;

        public CadastrarUsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public async Task Cadastrar(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
    }

}
