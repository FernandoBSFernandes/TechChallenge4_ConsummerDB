using MassTransit;
using Microsoft.Extensions.Configuration;

namespace Tech4AppProducer.Services
{
    public class CadastroService
    {
        private readonly IBus _bus;        

        public CadastroService(IBus bus)
        {
            _bus = bus;
        }

        public async Task EnviarCadastro(string username, string email)
        {
            try
            {
                var nomeFila = "filamobile";
                var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
                await endpoint.Send(new Tech4Core.Model.Usuario(username, email));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
