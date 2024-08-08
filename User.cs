namespace BilingualInventoryERP
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }

        public User(string username, string passwordHash, bool isAdmin = false)
        {
            Username = username;
            PasswordHash = passwordHash;
            IsAdmin = isAdmin;
        }
    }
}