using BilgeAdam.NTier.ERP.Service.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeAdam.NTier.ERP.App.Products
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
            Service = new ProductListService();
            Limit = 15;
            btnPrevious.Enabled = false;
        }

        public ProductListService Service { get; set; }
        public int PageIndex { get; set; }
        public int Limit { get; set; }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            RunQuery();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PreviousPage();
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
            var data = Service.GetPagedProducts(PageIndex, Limit);
            btnNext.Enabled = data.Count() >= Limit;
            btnPrevious.Enabled = PageIndex != 0;
            dgvProducts.DataSource = data;
        }
    }
}
