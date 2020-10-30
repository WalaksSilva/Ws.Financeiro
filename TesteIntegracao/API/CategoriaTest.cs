using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Ws.Financeiro.API;
using Xunit;

namespace TesteIntegracao.API
{
    public class CategoriaTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly Faker _faker;

        public CategoriaTest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public async Task Categoria_Get_ReturnsUnauthorizedResponse()
        {
            var response = await _httpClient.GetAsync("api/categorias");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

    }
}
