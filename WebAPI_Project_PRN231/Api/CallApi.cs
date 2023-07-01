using Newtonsoft.Json;
using System.Drawing;
using System.Net.Http;
using WebAPI_Project_PRN231.DTO;

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

        public async Task<List<ProductDTO>> GetFeatureProd<ProductDTO>()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Products/Feature");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<ProductDTO> ls = JsonConvert.DeserializeObject<List<ProductDTO>>(responseBody);

            return ls;
        }

        public async Task<List<ColorDTO>> GetAllColors()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Color");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<ColorDTO> ls = JsonConvert.DeserializeObject<List<ColorDTO>>(responseBody);

            return ls;
        }

        public async Task<List<SizeDTO>> GetAllSizes()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Size");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<SizeDTO> ls = JsonConvert.DeserializeObject<List<SizeDTO>>(responseBody);

            return ls;
        }

        public async Task<List<RamDTO>> GetAllRams()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Ram");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<RamDTO> ls = JsonConvert.DeserializeObject<List<RamDTO>>(responseBody);

            return ls;
        }

        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Category");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<CategoryDTO> ls = JsonConvert.DeserializeObject<List<CategoryDTO>>(responseBody);

            return ls;
        }

        public async Task<List<ProductDTO>> SearchProduct(SearchForm searchForm)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Products/Search",  searchForm);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<ProductDTO> ls = JsonConvert.DeserializeObject<List<ProductDTO>>(responseBody);

            return ls;
        }

        public async Task<List<BrandDTO>> GetAllBrand()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Brand");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<BrandDTO> ls = JsonConvert.DeserializeObject<List<BrandDTO>>(responseBody);

            return ls;
        }

        public async Task<ProductDTO> GetProductDetail(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Products/Detail?id="+id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            ProductDTO result = JsonConvert.DeserializeObject<ProductDTO>(responseBody);
            return result;
        }
    }
}
