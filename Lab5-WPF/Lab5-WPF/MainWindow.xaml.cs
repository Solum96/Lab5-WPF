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

        public MainWindow()
        {
            InitializeComponent();
            userList.ItemsSource = userCollection;
            userList.DisplayMemberPath = "name";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userCollection.Add(new User(UserNameInput.Text, EmailInput.Text));
            
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userNameDisplay.Content = "name";
            userEmailDisplay.Content = "eMail";
        }
    }
}
