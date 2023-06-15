namespace WebAPI_Project_PRN231.DTO
{
    public class SearchForm
    {
        public List<int> catId { get; set; }
        public List<int> colorSearch { get; set; }
        //public List<int> sizeSearch { get; set; }
        public int sizeSearch { get; set; }
        public string minPrice { get; set; }
        public string maxPrice { get; set; }
    }
}
