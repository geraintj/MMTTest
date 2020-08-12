using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MMTTest.API.Models;
using Newtonsoft.Json;

namespace MMTTest.Console
{
    public class ApiCaller : IApiCaller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ApiCaller(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Product>> FeaturedProducts()
        {
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://localhost:44352/api/products/featured"));
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException($"StatusCode: {response.StatusCode}");
            }
        }

        public async Task<List<string>> AvailableCategories()
        {
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://localhost:44352/api/categories"));
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException($"StatusCode: {response.StatusCode}");
            }
        }

        public async Task<List<Product>> ProductsByCategory(string category)
        {
            
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://localhost:44352/api/products/category/{category}"));
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException($"StatusCode: {response.StatusCode}");
            }
        }
    }
}
