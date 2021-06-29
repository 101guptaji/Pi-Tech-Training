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

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for LogInForm.xaml
    /// </summary>
    public partial class LogInForm : Window
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        int count = 0;
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUname.Text.Length == 0)
            {
                MessageBox.Show("Enter username.");
                txtUname.Focus();
            }
            else if (txtUname.Text=="admin" && txtPass.Password=="123")
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                count++;
                if (count == 3)
                    this.Close();
                else
                    MessageBox.Show("You have entered a wrong username/password. \nAttempt Remaining: "+Convert.ToString(3-count));
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
