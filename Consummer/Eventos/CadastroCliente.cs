using Consummer.Service;
using Consummer.Service.Interface;
using Core.Model;
using MassTransit;

namespace Consummer.Eventos
{
    public class CadastroCliente : IConsumer<Usuario>
    {

        private readonly ICadastrarUsuarioService _cadastrarUsuarioService;
        private readonly IEmailService _emailService;

        public CadastroCliente(ICadastrarUsuarioService cadastrarUsuarioService, IEmailService emailService)
        {
            _cadastrarUsuarioService = cadastrarUsuarioService;
            _emailService = emailService;
        }

        public async Task Consume(ConsumeContext<Usuario> context)
        {

            var usuario = context.Message;

            //Enviar Email
            await _emailService.BoasVindas(usuario);
            

            //Salvar dados do usuário na base
            await _cadastrarUsuarioService.Cadastrar(usuario);

            await Console.Out.WriteLineAsync($"Cliente {usuario.Nome} ({context.Message.Email}) cadastrado com sucesso!");
        }
    }
}
