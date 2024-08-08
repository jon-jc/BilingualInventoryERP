using System;
using System.Data;
using System.Windows.Forms;

namespace BilingualInventoryERP
{
    public partial class Form1 : Form
    {
        private readonly DatabaseManager dbManager;
        private readonly User currentUser;
        private bool isEnglish = true;

        public Form1(DatabaseManager dbManager, User user)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            this.currentUser = user;
            SetupControls();
            LoadProducts();
            SetLanguage();
            UpdateUIBasedOnUserRole();
        }

        private void UpdateUIBasedOnUserRole()
        {
            if (!currentUser.IsAdmin)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        // ... (rest of the Form1 code remains the same)
    }
}