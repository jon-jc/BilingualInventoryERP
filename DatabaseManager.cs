using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace BilingualInventoryERP
{
    public class DatabaseManager
    {
        private string dbPath = "inventory.db";
        private string connectionString;

        public DatabaseManager()
        {
            connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        CREATE TABLE Users (
                            UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL UNIQUE,
                            PasswordHash TEXT NOT NULL,
                            IsAdmin INTEGER NOT NULL
                        );
                        CREATE TABLE Products (
                            ProductId INTEGER PRIMARY KEY AUTOINCREMENT,
                            ProductName TEXT NOT NULL,
                            ProductNameJP TEXT NOT NULL,
                            Quantity INTEGER NOT NULL,
                            Price REAL NOT NULL
                        );
                        INSERT INTO Users (Username, PasswordHash, IsAdmin) VALUES ('admin', 'admin123', 1);";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Products";
                using (var adapter = new SQLiteDataAdapter(sql, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public void AddProduct(string name, string nameJP, int quantity, decimal price)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Products (ProductName, ProductNameJP, Quantity, Price) VALUES (@Name, @NameJP, @Qty, @Price)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@NameJP", nameJP);
                    cmd.Parameters.AddWithValue("@Qty", quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @Password";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}