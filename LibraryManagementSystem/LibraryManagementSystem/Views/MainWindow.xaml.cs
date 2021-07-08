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

namespace LibraryManagementSystem.Views
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

        private void btnIssue_Click(object sender, RoutedEventArgs e)
        {
            BookIssueWindow issue = new BookIssueWindow();
            issue.Show();
            this.Close();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            BookReturnWindow returnWindow = new BookReturnWindow();
            returnWindow.Show();
            this.Close();
            
        }
    }
}
