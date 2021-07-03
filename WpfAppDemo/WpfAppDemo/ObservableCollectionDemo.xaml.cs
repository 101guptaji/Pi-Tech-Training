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
using System.Windows.Shapes;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for ObservableCollectionDemo.xaml
    /// </summary>
    public partial class ObservableCollectionDemo : Window
    {
        //List<Person> personList;
        ObservableCollection<Person> personList;
        public ObservableCollectionDemo()
        {
            InitializeComponent();

           // personList = new List<Person>();
            personList = new ObservableCollection<Person>();

            personList.Add(new Person() { FirstName = "Himanshu", LastName = "Gupta", City = "Jaipur" });
            personList.Add(new Person() { FirstName = "Sonu", LastName = "Sirohi", City = "Mumbai" });
            personList.Add(new Person() { FirstName = "Manu", LastName = "Dada", City = "Kolkata" });

            lstNames.ItemsSource = personList;
            lblTotal.Content = "Total Product in List=" + personList.Count;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            personList.Add(new Person() { FirstName = fName.Text, LastName = lName.Text, City = city.Text });
            lblTotal.Content = "Total Product in List=" + personList.Count;
            fName.Clear();
            lName.Clear();
            city.Clear();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Person p = personList.SingleOrDefault(p1=>p1.FirstName==fName.Text);
            personList.Remove(p);

            lblTotal.Content = "Total Product in List=" + personList.Count;
            fName.Clear();
            lName.Clear();
            city.Clear();
        }
    }
}
