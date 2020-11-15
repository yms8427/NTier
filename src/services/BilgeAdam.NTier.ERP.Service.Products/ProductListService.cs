using BilgeAdam.NTier.ERP.Data.Access;
using BilgeAdam.NTier.ERP.Data.Entities;
using BilgeAdam.NTier.ERP.Dto.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.NTier.ERP.Service.Products
{
    public class ProductListService
    {
        private readonly Repository<Product> repo;

        public ProductListService()
        {
            this.repo = new Repository<Product>();
        }
        public IEnumerable<ProductListDto> GetAllProducts()
        {
            var query = repo.Select(s => new ProductListDto
            {
                Id = s.Id,
                Name = s.ProductName,
                Price = s.UnitPrice,
                Stock = s.UnitsInStock
            });
            return query.ToList();
        }

        public IEnumerable<ProductListDto> GetPagedProducts(int pageIndex, int limit)
        {
            var query = repo.Select(s => new ProductListDto
            {
                Id = s.Id,
                Name = s.ProductName,
                Price = s.UnitPrice,
                Stock = s.UnitsInStock
            })
            .OrderBy(o => o.Name)
            .Skip(pageIndex * limit)
            .Take(limit);
            return query.ToList();
        }
    }
}
