using BilgeAdam.NTier.ERP.App.Auth;
using BilgeAdam.NTier.ERP.App.Employees;
using BilgeAdam.NTier.ERP.App.Models;
using BilgeAdam.NTier.ERP.App.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeAdam.NTier.ERP.App
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void msnProduct_List_Click(object sender, EventArgs e)
        {
            var f = new frmProducts();
            f.MdiParent = this;
            f.Show();
        }

        private void msbEmployees_List_Click(object sender, EventArgs e)
        {
            var f = new frmEmployees();
            f.MdiParent = this;
            f.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var f = new frmLogin();
            f.ShowDialog();
            Text += $" - {Session.CurrentUser}";
        }
    }
}
