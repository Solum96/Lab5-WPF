namespace Lab5_WPF
{
    public class User
    {
        public string name { get; set; }
        public string eMail { get; set; }
        public bool admin { get; set; }
        public User(string name, string eMail)
        {
            this.name = name;
            this.eMail = eMail;
        }
    }
}