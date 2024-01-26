using Core.Model;
using MassTransit;

namespace Consummer.Eventos
{
    public class CadastroCliente : IConsumer<Usuario>
    {
        public async Task Consume(ConsumeContext<Usuario> context)
        {
            await Console.Out.WriteLineAsync($"Cliente {context.Message.Nome} ({context.Message.Email}) cadastrado com sucesso!");
        }
    }
}
