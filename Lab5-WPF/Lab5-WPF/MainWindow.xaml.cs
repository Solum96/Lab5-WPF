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
            userList.DisplayMemberPath = "Username";
            adminList.ItemsSource = adminCollection;
            adminList.DisplayMemberPath = "Username";
        }

        private void OnAddUserButtonClick(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(userNameInput.Text) &&
               !String.IsNullOrWhiteSpace(userEmailInput.Text))
            {
                userCollection.Add(new User(userNameInput.Text, userEmailInput.Text));
                userNameInput.Clear();
                userEmailInput.Clear();
            }
        }

        private void OnUpdateUserButtonClick(object sender, RoutedEventArgs e)
        {
            var temp = new User(userNameInput.Text, userEmailInput.Text);

            if (userList.SelectedItem != null)
            {
                UpdateUser(temp, userCollection, userList);
            }
            if (adminList.SelectedItem != null)
            {
                UpdateUser(temp, adminCollection, adminList);
            }
        }

        private void UpdateUser(User temp, ObservableCollection<User> collection, ListBox listbox)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] == (User)listbox.SelectedItem)
                {
                    if (!String.IsNullOrWhiteSpace(userNameInput.Text)) collection[i].Username = temp.Username;
                    if (!String.IsNullOrWhiteSpace(userEmailInput.Text)) collection[i].Email = temp.Email;

                    userNameInput.Clear();
                    userEmailInput.Clear();
                    userList.Items.Refresh();
                    hudLabel.Content = $"Username: {collection[i].Username} \nEmail: {collection[i].Email}";
                    break;
                }
            }
        }

        private void OnRemoveUserButtonClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < userCollection.Count; i++)
            {
                if (userCollection[i] == userList.SelectedItem)
                {
                    hudLabel.Content = String.Empty;
                    userCollection.Remove(userCollection[i]);
                    if (userList.SelectedItems.Count <= 0) updateUserButton.IsEnabled = false;
                    break;
                }
            }
        }

        private void OnUserListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = (User)userList.SelectedItem;
            if(temp != null)
            {
                hudLabel.Content = $"Username: {temp.Username} \nEmail: {temp.Email}";
                adminList.SelectedIndex = -1;
                updateUserButton.IsEnabled = true;
            }
        }

        private void OnAdminListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = (User)adminList.SelectedItem;
            if (temp != null)
            {
                hudLabel.Content = $"Username: {temp.Username} \nEmail: {temp.Email}";
                userList.SelectedIndex = -1;
                updateUserButton.IsEnabled = true;
            }
        }

        private void OnMakeAdminButtonClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < userCollection.Count; i++)
            {
                if (userCollection[i] == (User)userList.SelectedItem)
                {
                    var temp = userCollection[i];
                    userCollection.Remove(userCollection[i]);
                    adminCollection.Add(temp);
                    hudLabel.Content = String.Empty;
                    if (userList.SelectedItems.Count <= 0) updateUserButton.IsEnabled = false;
                }
            }
        }

        private void OnRemoveAdminButtonClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < adminCollection.Count; i++)
            {
                if (adminCollection[i] == (User)adminList.SelectedItem)
                {
                    var temp = adminCollection[i];
                    adminCollection.Remove(adminCollection[i]);
                    userCollection.Add(temp);
                    hudLabel.Content = String.Empty;
                    if (adminList.SelectedItems.Count <= 0) updateUserButton.IsEnabled = false;
                }
            }
        }
    }
}
