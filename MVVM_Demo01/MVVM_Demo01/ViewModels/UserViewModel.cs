using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_Demo01.Models;
using MVVM_Demo01.Commands;

namespace MVVM_Demo01.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region User's Properties
        private User user = new User();

        //convert all properties of user class to string 
        public string UserId
        {
            get { return user.UserId.ToString(); }
            set
            {
                user.UserId = Convert.ToInt32(value);
                OnPropertyChanged("UserId");
            }
        }

        public string FirstName
        {
            get { return user.FirstName; }
            set
            {
                user.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return user.LastName; }
            set
            {
                user.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Country
        {
            get { return user.Country; }
            set
            {
                user.Country = value;
                OnPropertyChanged("Country");
            }
        }

        #endregion

        #region Collection

        private ObservableCollection<User> users;

        public ObservableCollection<User> UserList
        {
            get { return users; }
            set { users = value; }
        }

        #endregion

        #region Command

        private ICommand addCommand;

        public ICommand AddCommand
        {
            get { return addCommand; }
            set { addCommand = value; }
        }

        private ICommand deleteCommand;

        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value; }
        }

        #endregion

        public UserViewModel()
        {
            UserList = new ObservableCollection<User>()
            {
                new User(){ UserId=1, FirstName="Hanni", LastName="Gupta", Country="India" },
                 new User(){ UserId=2, FirstName="Jons", LastName="Cristo", Country="USA" },
                  new User(){ UserId=3, FirstName="Chi", LastName="Sungai", Country="China" }
            };
            addCommand = new RelayCommand(AddUser, CanAdd);
            deleteCommand = new RelayCommand(DeleteUser, CanDelete);
        }


        #region Methods

        public bool CanAdd(object obj)
        {
            //return true;
            if (UserId != null && FirstName != null)
                return true;
            return false;
        }

        public void AddUser(object obj)
        {
            User userObj = new User()
            {
                UserId=Convert.ToInt32(UserId),
                FirstName=FirstName,
                LastName=LastName,
                Country=Country
            };
            UserList.Add(userObj);
        }

        public bool CanDelete(object obj)
        {
            //return true;
            if (Convert.ToInt32(UserId) > 0)
                return true;
            return false;
        }

        public void DeleteUser(object obj)
        {
            User userObj = UserList.Where(u => u.UserId == Convert.ToInt32(UserId)).SingleOrDefault();
            UserList.Remove(userObj);
        }
        #endregion
    }
}
