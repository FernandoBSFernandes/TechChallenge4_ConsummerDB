using AutoMapper;
using Consummer.Repository;
using Core.Model;

namespace Consummer.Service
{
    public interface ICadastrarUsuarioService
    {
        public Task Cadastrar(Usuario usuario);
    }

    public class CadastrarUsuarioService : ICadastrarUsuarioService
    {

		private readonly IMapper _mapper;
        private readonly ICadastrarUsuarioRepository _repository;

        public CadastrarUsuarioService(IMapper mapper, ICadastrarUsuarioRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Cadastrar(Usuario usuario)
        {
			try
			{
				var usuarioToTable = _mapper.Map<Core.TableModel.Usuario>(usuario);
                
                await _repository.Cadastrar(usuarioToTable);
			}
			catch (Exception)
			{

				throw;
			}
        }

    }
}
