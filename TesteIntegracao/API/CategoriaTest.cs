using Bogus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Ws.Financeiro.API;
using Xunit;

namespace TesteIntegracao.API
{
    public class CategoriaTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly HttpClient _httpClient;

        public CategoriaTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                });
            }).CreateClient();

            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Categoria_Get_ReturnsUnauthorizedResponse()
        {
            var response = await _httpClient.GetAsync("api/categorias");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Categoria_Get_ReturnsOkResponse()
        {

            var response = await _client.GetAsync("api/categorias");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}
