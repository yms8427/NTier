namespace BilgeAdam.NTier.ERP.Dto.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public short? Stock { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
    }
}