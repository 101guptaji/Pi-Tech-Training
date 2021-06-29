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
        string dir = @"D:\HDD\PI Techniques\Training\WpfAppDemo\WpfAppDemo\UserDataFile";

        public MainWindow()
        {
            InitializeComponent();
            foreach (string f in Directory.GetFiles(dir))
            {
                //Console.WriteLine(f);
                lstFiles.Items.Add(f);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
              // If directory does not exist, create it. 
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (StreamWriter sw = File.CreateText($"{dir}//{txtUname.Text}.txt"))
            {
                sw.WriteLine(txtUname.Text);
                sw.WriteLine(txtAddress.Text);
                sw.WriteLine(cmbCountry.SelectedItem);
                sw.WriteLine(optMale.IsChecked);
                sw.WriteLine(optFemale.IsChecked);
                sw.WriteLine(chkReading.IsChecked);
                sw.WriteLine(chkMusic.IsChecked);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtUname.Clear();
            txtAddress.Clear();
            cmbCountry.SelectedIndex = 1;
            optMale.IsChecked = false;
            optFemale.IsChecked = false;
            chkReading.IsChecked = false;
            chkMusic.IsChecked = false;
        }

        private void lstFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string file = lstFiles.SelectedItem.ToString();
            using (StreamReader sr = File.OpenText(file))
            {
                string data = sr.ReadToEnd();
                rchBox.Document.Blocks.Clear();
                rchBox.AppendText(data);
            }
        }
    }
}
