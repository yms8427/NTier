namespace BilgeAdam.NTier.ERP.Dto.Products
{
    public class NewProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public short? Stock { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string PackageInfo { get; set; }
    }
}
