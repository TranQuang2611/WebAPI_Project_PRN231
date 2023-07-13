using Newtonsoft.Json;
using System.Drawing;
using System.Net.Http;
using WebAPI_Project_PRN231.DTO;

namespace WebAPI_Project_PRN231.Api
{
    public class CallApi
    {
        private readonly HttpClient _httpClient;
        private readonly ISession _session;
        public CallApi(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _session = httpContextAccessor.HttpContext.Session;
            if (!string.IsNullOrEmpty(_session.GetString("token")))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer" , _session.GetString("token"));
            }
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

        public async Task<List<ProductDTO>> SearchProductByAdmin(SearchForm searchForm)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Products/SearchByAdmin", searchForm);
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

        public async Task<List<ReviewDTO>> GetReviewOfProduct(ReviewModel model)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Review", model);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ReviewDTO> result = JsonConvert.DeserializeObject<List<ReviewDTO>>(responseBody);
            return result;
        }

        public async Task<ApiRespond> Login(LoginModel model)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/User/Login", model);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            ApiRespond result = JsonConvert.DeserializeObject<ApiRespond>(responseBody);
            return result;
        }

        public async Task<List<ReviewDTO>> GetAllReviews()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Review/GetAll");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ReviewDTO> result = JsonConvert.DeserializeObject<List<ReviewDTO>>(responseBody);
            return result;
        }

        public async Task<string> Register(RegisterModel model)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/User/Register", model);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
