using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<string> Files=new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (string f in Directory.GetFiles(dir))
            {
                Files.Add(f);
            }
            lstFiles.ItemsSource = Files;
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
                sw.WriteLine(cmbCountry.SelectedItem.ToString());
                sw.WriteLine(optMale.IsChecked);
                sw.WriteLine(optFemale.IsChecked);
                sw.WriteLine(chkReading.IsChecked);
                sw.WriteLine(chkMusic.IsChecked);
            }
            Files.Add($"{dir}//{txtUname.Text}.txt");
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
                string line = sr.ReadLine();
                txtUname.Text=line;
                txtAddress.Text= sr.ReadLine();
                cmbCountry.SelectedItem= sr.ReadLine();
                optMale.IsChecked = Boolean.Parse(sr.ReadLine());
                optFemale.IsChecked = Boolean.Parse(sr.ReadLine());
                chkReading.IsChecked = Boolean.Parse(sr.ReadLine());
                chkMusic.IsChecked = Boolean.Parse(sr.ReadLine());
            }
        }
    }
}
