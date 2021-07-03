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
    /// Interaction logic for DBNorthwindFrom.xaml
    /// </summary>
    public partial class DBNorthwindFrom : Window
    {
        NorthwindEntities db=null;
        ObservableCollection<Product> prodList;
        public DBNorthwindFrom()
        {
            InitializeComponent();
            db = new NorthwindEntities();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //load all data of products table into observable collection
            prodList = new ObservableCollection<Product>(db.Products);
            //bind observable collection with listbox control
            lstItems.DataContext = prodList;
            txtProdId.IsReadOnly = true;
        }

        //Listbox selection event
        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainGrid.DataContext = lstItems.SelectedItem as Product;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Add empty record in obs collection
            prodList.Add(new Product());
            //Make that record as an active selection
            lstItems.SelectedIndex = prodList.Count - 1;

            //focus- ProductName, set ProductID=0
            txtProdId.Text = "0"; //identity field
            txtProdName.Focus();

            btnAdd.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            lstItems.IsEnabled = false;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Product p = lstItems.SelectedItem as Product;
            db.Products.Add(p);
            db.SaveChanges();
            MessageBox.Show("Record inserted");
            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            lstItems.IsEnabled = true;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Product p = lstItems.SelectedItem as Product;
            db.SaveChanges();
            MessageBox.Show("Record updated");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgResult = MessageBox.Show("Are you sure you want to delete the record?",
                "Delete Product", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if(msgResult==MessageBoxResult.Yes)
            {
                Product p = lstItems.SelectedItem as Product;
                db.Products.Remove(p); //remove from DbSet<Product>
                db.SaveChanges(); //remove from database table
                prodList.Remove(p); //remove from collection
                MessageBox.Show("Record Deleted");
            }
           
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Product p = lstItems.SelectedItem as Product;
            prodList.Remove(p);
            lstItems.SelectedIndex = 0;
            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            lstItems.IsEnabled = true;
        }
    }
}
