using System;
using System.Windows.Forms;

namespace BilingualInventoryERP
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = @"Data Source=(local);Initial Catalog=InventoryDB;Integrated Security=True";
            DatabaseManager dbManager = new DatabaseManager(connectionString);

            Application.Run(new LoginForm(dbManager));
        }
    }
}