namespace BilingualInventoryERP
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductNameJP = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductNameJP = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnLanguage = new System.Windows.Forms.Button();
            this.pnlInput = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 300);
            this.dataGridView1.TabIndex = 0;

            // pnlInput
            this.pnlInput.BorderStyle = BorderStyle.FixedSingle;
            this.pnlInput.Location = new System.Drawing.Point(12, 324);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(776, 100);
            this.pnlInput.TabIndex = 1;

            // lblProductName
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(10, 15);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(84, 13);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name:";

            // txtProductName
            this.txtProductName.Location = new System.Drawing.Point(100, 12);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(150, 20);
            this.txtProductName.TabIndex = 1;

            // lblProductNameJP
            this.lblProductNameJP.AutoSize = true;
            this.lblProductNameJP.Location = new System.Drawing.Point(260, 15);
            this.lblProductNameJP.Name = "lblProductNameJP";
            this.lblProductNameJP.Size = new System.Drawing.Size(102, 13);
            this.lblProductNameJP.TabIndex = 2;
            this.lblProductNameJP.Text = "Product Name (JP):";

            // txtProductNameJP
            this.txtProductNameJP.Location = new System.Drawing.Point(368, 12);
            this.txtProductNameJP.Name = "txtProductNameJP";
            this.txtProductNameJP.Size = new System.Drawing.Size(150, 20);
            this.txtProductNameJP.TabIndex = 3;

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(10, 45);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Quantity:";

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(100, 42);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(150, 20);
            this.txtQuantity.TabIndex = 5;

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(260, 45);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price:";

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(368, 42);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(150, 20);
            this.txtPrice.TabIndex = 7;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(530, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 50);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add Product";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnLanguage
            this.btnLanguage.Location = new System.Drawing.Point(640, 12);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(100, 50);
            this.btnLanguage.TabIndex = 9;
            this.btnLanguage.Text = "日本語";
            this.btnLanguage.UseVisualStyleBackColor = true;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlInput);
            this.Name = "Form1";
            this.Text = "Bilingual Inventory ERP";

            this.pnlInput.Controls.Add(this.lblProductName);
            this.pnlInput.Controls.Add(this.txtProductName);
            this.pnlInput.Controls.Add(this.lblProductNameJP);
            this.pnlInput.Controls.Add(this.txtProductNameJP);
            this.pnlInput.Controls.Add(this.lblQuantity);
            this.pnlInput.Controls.Add(this.txtQuantity);
            this.pnlInput.Controls.Add(this.lblPrice);
            this.pnlInput.Controls.Add(this.txtPrice);
            this.pnlInput.Controls.Add(this.btnAdd);
            this.pnlInput.Controls.Add(this.btnLanguage);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductNameJP;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductNameJP;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnLanguage;
        private System.Windows.Forms.Panel pnlInput;
    }
}