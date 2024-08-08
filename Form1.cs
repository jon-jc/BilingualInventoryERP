using System;
using System.Data;
using System.Windows.Forms;

namespace BilingualInventoryERP
{
    public partial class Form1 : Form
    {
        private readonly DatabaseManager dbManager;
        private bool isEnglish = true;

        public Form1()
        {
            InitializeComponent();
            string connectionString = @"Data Source=(local);Initial Catalog=InventoryDB;Integrated Security=True";
            dbManager = new DatabaseManager(connectionString);
            SetupControls();
            LoadProducts();
            SetLanguage();
        }

        private void SetupControls()
        {
            // Set up DataGridView
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Size = new System.Drawing.Size(600, 200);
            this.dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);

            // Set up labels and textboxes
            this.lblProductName.Location = new System.Drawing.Point(10, 220);
            this.lblProductName.AutoSize = true;
            this.txtProductName.Location = new System.Drawing.Point(120, 220);

            this.lblProductNameJP.Location = new System.Drawing.Point(10, 250);
            this.lblProductNameJP.AutoSize = true;
            this.txtProductNameJP.Location = new System.Drawing.Point(120, 250);

            this.lblQuantity.Location = new System.Drawing.Point(10, 280);
            this.lblQuantity.AutoSize = true;
            this.txtQuantity.Location = new System.Drawing.Point(120, 280);

            this.lblPrice.Location = new System.Drawing.Point(10, 310);
            this.lblPrice.AutoSize = true;
            this.txtPrice.Location = new System.Drawing.Point(120, 310);

            // Set up buttons
            this.btnAdd.Location = new System.Drawing.Point(10, 340);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new EventHandler(btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(100, 340);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(190, 340);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new EventHandler(btnDelete_Click);

            // Set up language combo box
            this.cboLanguage.Location = new System.Drawing.Point(280, 340);
            this.cboLanguage.Items.AddRange(new object[] { "English", "日本語" });
            this.cboLanguage.SelectedIndex = 0;
            this.cboLanguage.SelectedIndexChanged += new EventHandler(cboLanguage_SelectedIndexChanged);

            // Set form size
            this.Size = new System.Drawing.Size(620, 400);
        }

        private void LoadProducts()
        {
            try
            {
                dataGridView1.DataSource = dbManager.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                dbManager.AddProduct(txtProductName.Text, txtProductNameJP.Text, int.Parse(txtQuantity.Text), decimal.Parse(txtPrice.Text));
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = (int)dataGridView1.SelectedRows[0].Cells["ProductID"].Value;
                    dbManager.UpdateProduct(id, txtProductName.Text, txtProductNameJP.Text, int.Parse(txtQuantity.Text), decimal.Parse(txtPrice.Text));
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = (int)dataGridView1.SelectedRows[0].Cells["ProductID"].Value;
                    if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dbManager.DeleteProduct(id);
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                        ClearInputFields();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLanguage_SelectedIndexChanged(object? sender, EventArgs e)
        {
            isEnglish = cboLanguage.SelectedIndex == 0;
            SetLanguage();
        }

        private void SetLanguage()
        {
            if (isEnglish)
            {
                this.Text = "Inventory Management";
                lblProductName.Text = "Product Name:";
                lblProductNameJP.Text = "Product Name (JP):";
                lblQuantity.Text = "Quantity:";
                lblPrice.Text = "Price:";
                btnAdd.Text = "Add";
                btnUpdate.Text = "Update";
                btnDelete.Text = "Delete";
            }
            else
            {
                this.Text = "在庫管理";
                lblProductName.Text = "製品名:";
                lblProductNameJP.Text = "製品名 (日本語):";
                lblQuantity.Text = "数量:";
                lblPrice.Text = "価格:";
                btnAdd.Text = "追加";
                btnUpdate.Text = "更新";
                btnDelete.Text = "削除";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) || 
                string.IsNullOrWhiteSpace(txtProductNameJP.Text) || 
                string.IsNullOrWhiteSpace(txtQuantity.Text) || 
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Quantity must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Price must be a valid decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInputFields()
        {
            txtProductName.Text = "";
            txtProductNameJP.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                txtProductNameJP.Text = row.Cells["ProductNameJP"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
            }
        }
    }
}