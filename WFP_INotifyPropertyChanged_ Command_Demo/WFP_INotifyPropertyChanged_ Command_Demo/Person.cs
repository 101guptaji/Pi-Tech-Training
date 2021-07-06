using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_INotifyPropertyChanged__Command_Demo
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            //Fire the PropertyChnaged event incase somebody subscribed to it.
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { 
                firstName = value;
                OnPropertyChanged("FullName");
            }
        }

       

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { 
                lastName = value;
                OnPropertyChanged("FullName");
            }
        }


        //private readonly string fullName;

        public string FullName
        {
            get { return FirstName + " " + LastName; }
            
        }

        
        

    }
}
