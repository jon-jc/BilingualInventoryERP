namespace BilingualInventoryERP
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pnlLogin = new System.Windows.Forms.Panel();

            // Set up pnlLogin
            this.pnlLogin.SuspendLayout();
            this.pnlLogin.Location = new System.Drawing.Point(20, 20);
            this.pnlLogin.Size = new System.Drawing.Size(260, 180);
            this.pnlLogin.BorderStyle = BorderStyle.FixedSingle;

            // Set up lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(20, 20);
            this.lblUsername.Size = new System.Drawing.Size(60, 15);
            this.lblUsername.Text = "Username:";

            // Set up txtUsername
            this.txtUsername.Location = new System.Drawing.Point(20, 40);
            this.txtUsername.Size = new System.Drawing.Size(220, 23);

            // Set up lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 80);
            this.lblPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPassword.Text = "Password:";

            // Set up txtPassword
            this.txtPassword.Location = new System.Drawing.Point(20, 100);
            this.txtPassword.Size = new System.Drawing.Size(220, 23);
            this.txtPassword.PasswordChar = '•';

            // Set up btnLogin
            this.btnLogin.Location = new System.Drawing.Point(90, 140);
            this.btnLogin.Size = new System.Drawing.Size(80, 30);
            this.btnLogin.Text = "Login";
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Add controls to pnlLogin
            this.pnlLogin.Controls.Add(this.lblUsername);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.btnLogin);

            // Set up form
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.pnlLogin);
            this.Name = "LoginForm";
            this.Text = "Bilingual Inventory ERP - Login";
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlLogin;
    }
}