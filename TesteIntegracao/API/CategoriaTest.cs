using AutoBogus;
using Bogus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ws.Financeiro.API;
using Ws.Financeiro.API.ViewModels;
using Xunit;

namespace TesteIntegracao.API
{
    public class CategoriaTest : MainTest
    {
        //private readonly HttpClient _client;
        private readonly HttpClient _httpClient;
        private readonly IAutoFaker _autoFaker;
        private readonly Faker _faker;

        public CategoriaTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
            //_client = factory.WithWebHostBuilder(builder =>
            //{
            //    builder.ConfigureTestServices(services =>
            //    {
            //        services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();

            //    });
            //}).CreateClient();

            _httpClient = factory.CreateClient();

            _autoFaker = AutoFaker.Create();
            _faker = new Faker("pt_BR");
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
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);
            var response = await _httpClient.GetAsync("api/categorias");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Categoria_Post_ReturnsUnauthorizedResponse()
        {
            var categoriaMock = _autoFaker.Generate<CategoriaViewModel>();
            var response = await _httpClient.PostAsync("api/categorias", new StringContent(JsonSerializer.Serialize(categoriaMock), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Categoria_Post_ReturnsOkResponse()
        {
            var categoriaMock = _autoFaker.Generate<CategoriaViewModel>();
            categoriaMock.Gastos = null;
            categoriaMock.Id = 0;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);
            var response = await _httpClient.PostAsync("api/categorias", new StringContent(JsonSerializer.Serialize(categoriaMock), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Categoria_Put_ReturnsUnauthorizedResponse()
        {
            var categoriaMock = _autoFaker.Generate<CategoriaViewModel>();
            var response = await _httpClient.PutAsync($"api/categorias/{categoriaMock.Id}", new StringContent(JsonSerializer.Serialize(categoriaMock), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Categoria_Put_ReturnsNotFoundResponse()
        {
            var categoriaMock = _autoFaker.Generate<CategoriaViewModel>();

            categoriaMock.Id = -131313;
            categoriaMock.Gastos = null;
            
            var response = await _httpClient.PutAsync($"api/categorias/{categoriaMock.Id}", new StringContent(JsonSerializer.Serialize(categoriaMock), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
