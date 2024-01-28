using System.Text;
using Core.Model;
using Consummer.Model.Config;
using System.Text.Json;
using Consummer.Service.Interface;
using Consummer.Model.Brevo;

namespace Consummer.Service
{
    public class EmailService : IEmailService
	{
		private readonly HttpClient _client;
		private readonly SenderModel _sender;
		private readonly IHttpClientFactory _clientFactory;

		public EmailService(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
			_sender = new SenderModel("no-reply@techchallenge.com", "techChallenge");
			_client = _clientFactory.CreateClient("Brevo");
		}

		public async Task BoasVindas(Usuario usuario)
		{
			try
			{
				var email = new BoasVindas();

				var lista = new List<ToModel>();
				lista.Add(new ToModel(usuario.Email, usuario.Nome));

				await Enviar(lista, "Boas Vindas!", email.Corpo, usuario.Id.ToString());

			}
			catch (Exception)
			{

				throw;
			}
		}

		private async Task Enviar(List<ToModel> to, string subject, string htmlContent, string idUsuario)
		{
			try
			{
				var tag = new List<string>();

				tag.Add(idUsuario);

				var email = new SmtpEmailModel(_sender, to, htmlContent, subject, tags: tag);

				var json = JsonSerializer.Serialize<SmtpEmailModel>(email);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var result = await _client.PostAsync("smtp/email", content);
			}
			catch 
			{
				new Exception("Erro ao enviar email.");
			}
		}
	}
}