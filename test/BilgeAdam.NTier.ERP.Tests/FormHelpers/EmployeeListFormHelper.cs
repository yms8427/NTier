using BilgeAdam.NTier.ERP.App.Employees;
using BilgeAdam.NTier.ERP.Dto.Employees;
using System.Collections.Generic;

namespace BilgeAdam.NTier.ERP.Tests.FormHelpers
{
    public class EmployeeListFormHelper
    {
        private readonly frmEmployees form;

        public EmployeeListFormHelper(frmEmployees frm)
        {
            this.form = frm;
        }

        public void GoNext()
        {
            form.NextPage();
        }

        public void GoPrevious()
        {
            form.PreviousPage();
        }

        public void Search()
        {
            form.Search();
        }

        public void ClearFilter()
        {
            form.ClearSearch();
        }

        public void SetFirstName(string value)
        {
            form.txtFirstName.Text = value;
        }

        public void SetLastName(string value)
        {
            form.txtLastName.Text = value;
        }

        public void Load()
        {
            form.RunQuery();
        }

        public List<EmployeeListDto> Items => (form.dgvEmployees.DataSource as List<EmployeeListDto>);

        public bool NextButtonEnabled => form.btnNext.Enabled;
        public bool PreviousButtonEnabled => form.btnPrevious.Enabled;
        public string FirstName => form.txtFirstName.Text;
        public string LastName => form.txtLastName.Text;
    }
}