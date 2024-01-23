using Core.Model;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
