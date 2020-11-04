using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ws.Financeiro.API;
using Ws.Financeiro.API.ViewModels;
using Ws.Financeiro.Domain.Models;
using Xunit;

namespace TesteIntegracao.API
{
    public class MainTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        protected string token { get; set; }

        public MainTest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
            token = GetToken().Result;
        }

        public async Task<string> GetToken()
        {
            var login = new LoginUserViewModel { 
                Email = "teste@teste.com",
                Password = "Teste@123"
            };

            var response = await _httpClient.PostAsync("api/usuarios/entrar", new StringContent(System.Text.Json.JsonSerializer.Serialize(login), Encoding.UTF8, "application/json"));
            var stringResponse = await response.Content.ReadAsStringAsync();

            var token = JsonConvert.DeserializeObject<Login>(stringResponse);

            return token.data.accessToken;
        }
    }
}
