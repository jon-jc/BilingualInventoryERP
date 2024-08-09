using System;
using System.Drawing;
using System.Windows.Forms;

namespace BilingualInventoryERP
{
    public partial class LoginForm : Form
    {
        private DatabaseManager dbManager;

        public LoginForm()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (dbManager.AuthenticateUser(txtUsername.Text, txtPassword.Text))
            {
                this.Hide();
                new Form1().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}