using BilgeAdam.NTier.ERP.App.Models;
using BilgeAdam.NTier.ERP.Service.Auth;
using System;
using System.Windows.Forms;

namespace BilgeAdam.NTier.ERP.App.Auth
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            Service = new LoginService();
            lblFailed.Visible = false;
        }

        public LoginService Service { get; set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var result = Service.Login(txtuserName.Text, txtPassword.Text);
            if (result != null)
            {
                lblFailed.Visible = false;
                Session.CurrentUser = result.DisplayName;
                Close();
            }
            else
            {
                lblFailed.Visible = true;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var result = Service.Register(txtuserName.Text, txtPassword.Text);
            if (result)
            {
                MessageBox.Show("Kullanıcı kaydınız alındı");
            }
        }
    }
}