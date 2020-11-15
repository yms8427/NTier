using BilgeAdam.NTier.ERP.Service.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeAdam.NTier.ERP.App.Employees
{
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
            Limit = 15;
            Service = new EmployeeListService();
        }

        public int Limit { get; set; }
        public int PageIndex { get; set; }
        public EmployeeListService Service { get; set; }
        public void ClearSearch()
        {
            txtFirstName.ResetText();
            txtLastName.ResetText();
            RunQuery();
        }

        public void NextPage()
        {
            PageIndex++;
            RunQuery();
        }

        public void PreviousPage()
        {
            PageIndex--;
            if (PageIndex < 0)
            {
                PageIndex = 0;
            }
            RunQuery();
        }

        public void RunQuery()
        {
            var data = Service.GetPagedEmployees(PageIndex, Limit);
            btnNext.Enabled = data.Count() >= Limit;
            btnPrevious.Enabled = PageIndex != 0;
            dgvEmployees.DataSource = data;
        }

        public void Search()
        {
            var data = Service.Search(txtFirstName.Text, txtLastName.Text);

            btnNext.Enabled = data.Count() >= Limit;
            btnPrevious.Enabled = PageIndex != 0;
            dgvEmployees.DataSource = data;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PreviousPage();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void frmEmployees_Load(object sender, EventArgs e)
        {
            RunQuery();
        }
    }
}
