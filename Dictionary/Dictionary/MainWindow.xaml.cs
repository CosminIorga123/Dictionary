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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adm=new AdminWindow();
            this.Close();
            adm.ShowDialog();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            this.Close();
            searchWindow.ShowDialog();
        }

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            this.Close();
            gameWindow.ShowDialog();
        }
    }
}
