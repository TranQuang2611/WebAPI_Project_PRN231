using Newtonsoft.Json;
using System.Net.Http;

namespace WebAPI_Project_PRN231.Api
{
    public class CallApi
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public CallApi()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:5216/");
        }

        public async Task<List<ProductDTO>> GetAllProduct<ProductDTO>()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Products");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<ProductDTO> ls = JsonConvert.DeserializeObject<List<ProductDTO>>(responseBody);

            return ls;
        }

        public async Task<List<ProductDTO>> GetNewestProduct<ProductDTO>()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Products/Newest");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<ProductDTO> ls = JsonConvert.DeserializeObject<List<ProductDTO>>(responseBody);

            return ls;
        }
    }
}
