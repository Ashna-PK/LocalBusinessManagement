using Admin.Api.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using User.Api.Data;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"https://localhost:7267/api/UserClasses/{id}";
            var response = await client.GetAsync(url);
            return Ok(JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync()));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient();
            var url = "https://localhost:7267/api/UserClasses";
            var response = await client.GetAsync(url);
            return Ok(JsonConvert.DeserializeObject<List<UserDto>>(await response.Content.ReadAsStringAsync()));
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserDto user)
        {
            var client = _httpClientFactory.CreateClient();

            //var url = "https://localhost:7267/api/UserClasses";
            //var response = await client.PostAsync(url,user);
            //return Ok(JsonConvert.DeserializeObject<UserDTO>(await response.Content.ReadAsStringAsync()));
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"https://localhost:7267/api/UserClasses/{id}";
            var response = await client.DeleteAsync(url);
            return Ok(JsonConvert.DeserializeObject<List<UserDto>>(await response.Content.ReadAsStringAsync()));
        }
    }
}
