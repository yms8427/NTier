using BilgeAdam.NTier.ERP.Data.Entities;
using System.Linq;

namespace BilgeAdam.NTier.ERP.Data.Access
{
    public interface IRepository<T> : IQueryable<T> where T : EntityBase
    {
        void Add(T entity);

        int Save();
    }
}