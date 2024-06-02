using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
   
            string password = PassText.Password;
            string username = UserText.Text;
            // check if user is in file
            List<User> users = Serializer.getUsers();
            bool userExists=users.Any(u => u.Name == username && u.Password == password);
            if(userExists)
            {
                ActionsWindow actionsWindow = new ActionsWindow();
                this.Close();
                actionsWindow.ShowDialog();
            }
            else
            {
                Error.Visibility = Visibility.Visible;
            }

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}
