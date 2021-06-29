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
    /// Interaction logic for CollectionBindingDemo.xaml
    /// </summary>
    public partial class CollectionBindingDemo : Window
    {
        public CollectionBindingDemo()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ProductModel pro = new ProductModel();
            lstItems.DataContext = pro.GetProducts();
        }

        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainGrid.DataContext = lstItems.SelectedItem as ProductModel;
        }


    }
}
