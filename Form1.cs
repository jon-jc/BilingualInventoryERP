using System;
using System.Drawing;
using System.Windows.Forms;

namespace BilingualInventoryERP
{
    public partial class Form1 : Form
    {
        private DatabaseManager dbManager;
        private bool isEnglish = true;

        public Form1()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadProducts();
            SetLanguage();
        }

        private void LoadProducts()
        {
            dataGridView1.DataSource = dbManager.GetAllProducts();
            dataGridView1.Columns["ProductID"].Visible = false;
            dataGridView1.Columns["ProductName"].HeaderText = isEnglish ? "Product Name" : "製品名";
            dataGridView1.Columns["ProductNameJP"].HeaderText = isEnglish ? "Product Name (JP)" : "製品名 (日本語)";
            dataGridView1.Columns["Quantity"].HeaderText = isEnglish ? "Quantity" : "数量";
            dataGridView1.Columns["Price"].HeaderText = isEnglish ? "Price" : "価格";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string name = txtProductName.Text;
                string nameJP = txtProductNameJP.Text;
                int quantity = int.Parse(txtQuantity.Text);
                decimal price = decimal.Parse(txtPrice.Text);

                dbManager.AddProduct(name, nameJP, quantity, price);
                LoadProducts();
                ClearInputs();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtProductNameJP.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show(isEnglish ? "All fields are required." : "すべてのフィールドが必要です。", 
                                isEnglish ? "Validation Error" : "検証エラー", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show(isEnglish ? "Quantity must be a valid number." : "数量は有効な数値である必要があります。", 
                                isEnglish ? "Validation Error" : "検証エラー", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show(isEnglish ? "Price must be a valid number." : "価格は有効な数値である必要があります。", 
                                isEnglish ? "Validation Error" : "検証エラー", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtProductName.Clear();
            txtProductNameJP.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            isEnglish = !isEnglish;
            SetLanguage();
            LoadProducts();
        }

        private void SetLanguage()
        {
            this.Text = isEnglish ? "Bilingual Inventory ERP" : "バイリンガル在庫管理ERP";
            lblProductName.Text = isEnglish ? "Product Name:" : "製品名:";
            lblProductNameJP.Text = isEnglish ? "Product Name (JP):" : "製品名 (日本語):";
            lblQuantity.Text = isEnglish ? "Quantity:" : "数量:";
            lblPrice.Text = isEnglish ? "Price:" : "価格:";
            btnAdd.Text = isEnglish ? "Add Product" : "製品追加";
            btnLanguage.Text = isEnglish ? "日本語" : "English";
        }
    }
}