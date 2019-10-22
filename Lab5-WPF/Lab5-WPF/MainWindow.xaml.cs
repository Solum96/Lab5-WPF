﻿using System;
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
            userList.DisplayMemberPath = "name";
            adminList.ItemsSource = adminCollection;
            adminList.DisplayMemberPath = "name";

        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            userCollection.Add(new User(userNameInput.Text, userEmailInput.Text));
            userNameInput.Clear();
            userEmailInput.Clear();
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = (User)userList.SelectedItem;
            if(temp != null)
            {
                userNameDisplay.Content = temp.name;
                userEmailDisplay.Content = temp.eMail;
            }
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
                        userCollection[i].name = temp.name;
                        userCollection[i].eMail = temp.eMail;

                        userNameInput.Clear();
                        userEmailInput.Clear();
                        userList.Items.Refresh();
                        userNameDisplay.Content = userCollection[i].name;
                        userEmailDisplay.Content = userCollection[i].eMail;
                        break;
                    }
                }
            }
            else
            {
                userNameDisplay.Content = "You must choose an item from the User List.";
                userEmailDisplay.Content = "";
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
                    userNameDisplay.Content = "";
                    userEmailDisplay.Content = "";
                }
            }
        }
    }
}
