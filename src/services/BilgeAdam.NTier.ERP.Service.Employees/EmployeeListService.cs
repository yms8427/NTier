using BilgeAdam.NTier.ERP.Data.Access;
using BilgeAdam.NTier.ERP.Data.Entities;
using BilgeAdam.NTier.ERP.Dto.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.NTier.ERP.Service.Employees
{
    public class EmployeeListService
    {
        private Repository<Employee> repo;

        public EmployeeListService()
        {
            this.repo = new Repository<Employee>();
        }
        public List<EmployeeListDto> GetPagedEmployees(int pageIndex, int limit)
        {
            return repo.Select(s => new EmployeeListDto
                        {
                            FullName = s.FirstName + " " + s.LastName,
                            City = s.City,
                            HireDate = s.HireDate.Value,
                            Manager = s.Manager.FirstName + " " + s.Manager.LastName,
                            Phone = s.HomePhone
                        })
                       .OrderBy(i => i.FullName)
                       .Skip(pageIndex * limit)
                       .Take(limit)
                       .ToList();
        }

        public List<EmployeeListDto> Search(string firstName, string lastName)
        {
            return repo.Where(f => f.FirstName.StartsWith(firstName) && 
                                   f.LastName.StartsWith(lastName))
                       .Select(s => new EmployeeListDto
                       {
                           FullName = s.FirstName + " " + s.LastName,
                           City = s.City,
                           HireDate = s.HireDate.Value,
                           Manager = s.Manager.FirstName + " " + s.Manager.LastName,
                           Phone = s.HomePhone
                       })
                       .OrderBy(i => i.FullName)
                       .Take(15)
                       .ToList();
        }
    }
}
