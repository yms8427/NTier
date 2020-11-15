using BilgeAdam.NTier.ERP.Data.Access;
using BilgeAdam.NTier.ERP.Data.Entities;
using BilgeAdam.NTier.ERP.Dto.Products;

namespace BilgeAdam.NTier.ERP.Service.Products
{
    public class ProductInsertService
    {
        private readonly Repository<Product> repo;

        public ProductInsertService()
        {
            this.repo = new Repository<Product>();
        }
        
        public void Create(NewProductDto dto)
        {
            var entity = new Product
            {
                ProductName = dto.Name,
                UnitPrice = dto.Price,
                UnitsInStock = dto.Stock,
                QuantityPerUnit = dto.PackageInfo,
                CategoryID = dto.CategoryId,
                SupplierID = dto.SupplierId
            };
            repo.Add(entity);
            repo.Save();
        }
    }
}
