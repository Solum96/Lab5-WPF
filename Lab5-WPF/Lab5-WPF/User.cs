namespace Lab5_WPF
{
    public class User
    {
        public string username { get; set; }
        public string eMail { get; set; }
        public User(string username, string eMail)
        {
            this.username = username;
            this.eMail = eMail;
        }
    }
}