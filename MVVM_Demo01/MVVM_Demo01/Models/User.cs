using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Demo01.Models
{
    public class User : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region Properties

        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value;
                OnPropertyChanged("UserId");
            }
        }

        private string fname;

        public string FirstName
        {
            get { return fname; }
            set { fname = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lName;

        public string LastName
        {
            get { return lName; }
            set { lName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value;
                OnPropertyChanged("Country");
            }
        }

        #endregion


    }
}
