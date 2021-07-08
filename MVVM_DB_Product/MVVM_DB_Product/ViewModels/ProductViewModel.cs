using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_DB_Product.Models;
using MVVM_DB_Product.Commands;
using System.Windows.Input;
using System.Windows;

namespace MVVM_DB_Product.ViewModels
{

    public class ProductViewModel:INotifyPropertyChanged
    {
        ObservableCollection<Product> productList = null;
        NorthwindEntities db;

        public ProductViewModel()
        {
            db = new NorthwindEntities();
            productList = new ObservableCollection<Product>();
            LoadCommand = new RelayCommand(Load, CanLoad);
            SearchCommand = new RelayCommand(Search, CanSearch);
            ClearCommand= new RelayCommand(Clear);
            AddCommand = new RelayCommand(Add, CanAdd);
            UpdateCommand = new RelayCommand(Update, CanUpdate);
            DeleteCommand = new RelayCommand(Delete, CanDelete);
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region Product's Properties
        private Product prod = new Product();

        public string UI_ProductId
        {
            get { return prod.ProductID.ToString(); }
            set { 
                if(value!=string.Empty)
                {
                    prod.ProductID = Convert.ToInt32(value);
                    OnPropertyChanged("UI_ProductId");
                }
             }
        }

        public string UI_ProductName
        {
            get { return prod.ProductName; }
            set
            {
                
                prod.ProductName = value;
                OnPropertyChanged("UI_ProductName");
       
            }
        }

        public string UI_UnitPrice
        {
            get { return prod.UnitPrice.ToString(); }
            set
            {
                if (value != string.Empty)
                {
                    prod.UnitPrice = Convert.ToDecimal(value);
                   
                }
                else
                {
                    prod.UnitPrice = null;
                }
                OnPropertyChanged("UI_UnitPrice");
            }
        }

        public string UI_Discontinued
        {
            get { return prod.Discontinued.ToString(); }
            set
            {
                if (value != string.Empty)
                {
                    prod.Discontinued = Convert.ToBoolean(value);
                }
                else
                    prod.Discontinued = false;

                OnPropertyChanged("UI_Discontinued");
            }
        }

        
        public ObservableCollection<Product> ProductList
        {
            get { return productList; }
            set
            {
                productList = value;
                OnPropertyChanged("ProductList");
            }
        }

        #endregion

        #region Commands
        private ICommand loadCommand;

        public ICommand LoadCommand
        {
            get { return loadCommand; }
            set { loadCommand = value; }
        }

        private ICommand searchCommand;

        public ICommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; }
        }

        private ICommand clearCommand;

        public ICommand ClearCommand
        {
            get { return clearCommand; }
            set { clearCommand = value; }
        }

        private ICommand addCommand;

        public ICommand AddCommand
        {
            get { return addCommand; }
            set { addCommand = value; }
        }

        private ICommand updateCommand;

        public ICommand UpdateCommand
        {
            get { return updateCommand; }
            set { updateCommand = value; }
        }

        private ICommand deleteCommand;

        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value; }
        }

        #endregion

        #region Methods
        public bool CanLoad(object obj)
        {
            //return true;
            return true;
        }

        public void Load(object obj)
        {
            ProductList = new ObservableCollection<Product>((from p in db.Products select p).ToList());
            if(ProductList.Count>0)
            {
                this.UI_ProductId = ProductList[0].ProductID.ToString() ;
                this.UI_ProductName = ProductList[0].ProductName;
                this.UI_UnitPrice = ProductList[0].UnitPrice.ToString();
                this.UI_Discontinued = ProductList[0].Discontinued.ToString();
            }
        }
        public bool CanSearch(object obj)
        {
            if (int.Parse(UI_ProductId) != 0)
                return true;
            return false;
        }

        public void Search(object obj)
        {
            int Pid = int.Parse(UI_ProductId);
            Product prod = db.Products.Where(p => p.ProductID == Pid).SingleOrDefault();
            if(prod!=null)
            {
                UI_ProductName = prod.ProductName;
                UI_UnitPrice = prod.UnitPrice.ToString();
                UI_Discontinued = prod.Discontinued.ToString();
            }
        }

        public void Clear(object obj)
        {
            UI_ProductId = null;
            UI_ProductName = null;
            UI_UnitPrice = string.Empty;
            UI_Discontinued = string.Empty;

        }

        public bool CanAdd(object obj)
        {
            if (UI_ProductName!=null)
                return true;
            return false;
        }

        public void Add(object obj)
        {
            Product prod = new Product();
            prod.ProductID = int.Parse(UI_ProductId);
            prod.ProductName = UI_ProductName;
            if (UI_UnitPrice != string.Empty)
            {
                prod.UnitPrice = Convert.ToDecimal(UI_UnitPrice);

            }
            else
            {
                prod.UnitPrice = null;
            }

            if (UI_Discontinued != string.Empty)
            {
                prod.Discontinued = Convert.ToBoolean(UI_Discontinued);
            }
            else
                prod.Discontinued = false;

            db.Products.Add(prod);
            db.SaveChanges();

            Load(null);
        }

        public bool CanUpdate(object obj)
        {
            if (int.Parse(UI_ProductId) != 0)
                return true;
            return false;
        }

        public void Update(object obj)
        {
            //Product prod = new Product();
            int Pid = int.Parse(UI_ProductId);
            Product prod = db.Products.Where(p => p.ProductID == Pid).SingleOrDefault();
            if (prod != null)
            {
                if(UI_ProductName!=null)
                    prod.ProductName = UI_ProductName;

                if (UI_UnitPrice != string.Empty)
                {
                    prod.UnitPrice = Convert.ToDecimal(UI_UnitPrice);

                }
            

                if (UI_Discontinued != string.Empty)
                {
                    prod.Discontinued = Convert.ToBoolean(UI_Discontinued);
                }

               
                db.SaveChanges();
            }
            Load(null);
        }
        public bool CanDelete(object obj)
        {
            if (int.Parse(UI_ProductId) != 0)
                return true;
            return false;
        }

        public void Delete(object obj)
        {
            MessageBox.Show("Do you want to Delete this record", "Warning", MessageBoxButton.YesNo,MessageBoxImage.Question, MessageBoxResult.No);
            if (MessageBoxResult.Yes.ToString().Equals("Yes"))
            {
                int Pid = int.Parse(UI_ProductId);
                Product prod = db.Products.Where(p => p.ProductID == Pid).SingleOrDefault();
                if (prod != null)
                {
                    db.Products.Remove(prod);

                    db.SaveChanges();
                }
            }
            //Product prod = new Product();
            
            Load(null);
        }

        #endregion
    }
}
