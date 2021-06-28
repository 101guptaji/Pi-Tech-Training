using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfAppDemo
{
    public class UserData
    {
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string[] Hobbies { get; set; }

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string dir = @"D:\HDD\PI Techniques\Training\WpfAppDemo\WpfAppDemo\UserDataFile";
            // If directory does not exist, create it. 
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
