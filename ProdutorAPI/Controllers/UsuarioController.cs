using Core.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProdutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IBus _bus;

        public UsuarioController(IConfiguration configuration, IBus bus)
        {
            _configuration = configuration;
            _bus = bus;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Send()
        {
            var usuario = new Usuario("Fernando Barros", "rm384842@fiap.edu.br");

            var nomeFila = _configuration["NomeFila"] ?? string.Empty;

            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));

            await endpoint.Send(usuario);

            return Ok("Usuário cadastrado na fila.");
        }

        
    }
}
