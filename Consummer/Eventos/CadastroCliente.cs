using Consummer.Service;
using Core.Model;
using MassTransit;

namespace Consummer.Eventos
{
    public class CadastroCliente : IConsumer<Usuario>
    {

        private readonly ICadastrarUsuarioService _cadastrarUsuarioService;

        public CadastroCliente(ICadastrarUsuarioService cadastrarUsuarioService)
        {
            _cadastrarUsuarioService = cadastrarUsuarioService;
        }

        public async Task Consume(ConsumeContext<Usuario> context)
        {

            var usuario = context.Message;

            //Enviar Email

            //Salvar dados do usuário na base
            await _cadastrarUsuarioService.Cadastrar(usuario);

            await Console.Out.WriteLineAsync($"Cliente {usuario.Nome} ({context.Message.Email}) cadastrado com sucesso!");
        }
    }
}
