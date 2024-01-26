using Consummer.Service;

namespace Consummer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICadastrarUsuarioService _cadastrarUsuarioService;

        public Worker(ILogger<Worker> logger, ICadastrarUsuarioService cadastrarUsuarioService)
        {
            _logger = logger;
            _cadastrarUsuarioService = cadastrarUsuarioService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                //Enviar Email
                //Salvar Dados do Usuário
                await _cadastrarUsuarioService.CadastrarUsuario(stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}