using System;
using System.Data;
using System.Data.SqlClient;

namespace BilingualInventoryERP
{
    public class DatabaseManager
    {
        private readonly string connectionString;

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public void AddProduct(string name, string nameJP, int quantity, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (ProductName, ProductNameJP, Quantity, Price) VALUES (@Name, @NameJP, @Qty, @Price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@NameJP", nameJP);
                cmd.Parameters.AddWithValue("@Qty", quantity);
                cmd.Parameters.AddWithValue("@Price", price);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(int id, string name, string nameJP, int quantity, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET ProductName=@Name, ProductNameJP=@NameJP, Quantity=@Qty, Price=@Price WHERE ProductID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@NameJP", nameJP);
                cmd.Parameters.AddWithValue("@Qty", quantity);
                cmd.Parameters.AddWithValue("@Price", price);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Products WHERE ProductID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}