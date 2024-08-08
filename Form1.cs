private void btnAdd_Click(object sender, EventArgs e)
{
    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Products (ProductName, ProductNameJP, Quantity, Price) VALUES (@Name, @NameJP, @Qty, @Price)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", txtProductName.Text);
            cmd.Parameters.AddWithValue("@NameJP", txtProductNameJP.Text);
            cmd.Parameters.AddWithValue("@Qty", int.Parse(txtQuantity.Text));
            cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        LoadProducts();
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}