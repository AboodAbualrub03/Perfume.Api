namespace Perfume.Api.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string NameAr { get; set; }  = string.Empty;

        public string NameEn { get; set; }  = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        
    }
}
