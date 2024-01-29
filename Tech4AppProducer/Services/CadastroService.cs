using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Tech4AppProducer.Services
{
    public static class CadastroService
    {

        private static readonly string _url = "https://10.0.2.2:7043/api/Usuario/cadastrar"; //Local

        public  static async Task EnviarCadastro(string username, string email)
        {
            var httpClientHandler = new HttpClientHandler();
#if DEBUG
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;
#endif
            var httpClient = new HttpClient(httpClientHandler);

            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(new Tech4Core.Model.Usuario(username , email)), Encoding.UTF8, "application/json");
                ServicePointManager.ServerCertificateValidationCallback = (message, certificate, chain, sslPolicyErrors) => true;
                var response = await httpClient.PostAsync(_url, content);
                //response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }     
    }
}
