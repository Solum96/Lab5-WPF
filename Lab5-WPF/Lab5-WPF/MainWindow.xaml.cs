using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<User> userCollection = new ObservableCollection<User>();
        ObservableCollection<User> adminCollection = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();
            userList.ItemsSource = userCollection;
            userList.DisplayMemberPath = "username";
            adminList.ItemsSource = adminCollection;
            adminList.DisplayMemberPath = "username";
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            userCollection.Add(new User(userNameInput.Text, userEmailInput.Text));
            userNameInput.Clear();
            userEmailInput.Clear();
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {
            var temp = new User(userNameInput.Text, userEmailInput.Text);

            if (userList.SelectedItem != null)
            {
                for (int i = 0; i < userCollection.Count; i++)
                {
                    if (userCollection[i] == (User)userList.SelectedItem)
                    {
                        if (!String.IsNullOrWhiteSpace(userNameInput.Text)) userCollection[i].username = temp.username;
                        if (!String.IsNullOrWhiteSpace(userEmailInput.Text)) userCollection[i].eMail = temp.eMail;

                        userNameInput.Clear();
                        userEmailInput.Clear();
                        userList.Items.Refresh();
                        hudLabel.Content = $"Username: {userCollection[i].username} \nEmail: {userCollection[i].eMail}";
                        break;
                    }
                }
            }
            else
            {
                hudLabel.Content = "You must choose an item from the User List.";
            }
        }

        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < userCollection.Count; i++)
            {
                if (userCollection[i] == userList.SelectedItem)
                {
                    hudLabel.Content = String.Empty;
                    userCollection.Remove(userCollection[i]);
                    break;
                }
            }
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = (User)userList.SelectedItem;
            if(temp != null)
            {
                hudLabel.Content = $"Username: {temp.username} \nEmail: {temp.eMail}";
                adminList.SelectedIndex = -1;
            }
        }

        private void AdminList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = (User)adminList.SelectedItem;
            if (temp != null)
            {
                hudLabel.Content = $"Username: {temp.username} \nEmail: {temp.eMail}";
                userList.SelectedIndex = -1;
            }
        }

        

        private void MakeAdminButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < userCollection.Count; i++)
            {
                if (userCollection[i] == (User)userList.SelectedItem)
                {
                    var temp = userCollection[i];
                    userCollection.Remove(userCollection[i]);
                    adminCollection.Add(temp);
                    hudLabel.Content = String.Empty;
                }
            }
        }

        private void RemoveAdminButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < adminCollection.Count; i++)
            {
                if (adminCollection[i] == (User)adminList.SelectedItem)
                {
                    var temp = adminCollection[i];
                    adminCollection.Remove(adminCollection[i]);
                    userCollection.Add(temp);
                    hudLabel.Content = String.Empty;
                }
            }
        }
    }
}
