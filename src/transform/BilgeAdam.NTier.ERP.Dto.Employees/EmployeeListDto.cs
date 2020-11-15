using System;

namespace BilgeAdam.NTier.ERP.Dto.Employees
{
    public class EmployeeListDto
    {
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Manager { get; set; }
    }
}