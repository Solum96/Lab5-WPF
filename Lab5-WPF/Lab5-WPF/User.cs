namespace Lab5_WPF
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public User(string username, string eMail)
        {
            Username = username;
            Email = eMail;
        }
    }
}