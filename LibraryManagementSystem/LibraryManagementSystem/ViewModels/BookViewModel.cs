using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        LibraryEntities1 db;

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region Book's Properties
        Book book = new Book();

        public string UI_BookCode
        {
            get { return book.BookCode.ToString(); }
            set { 
                if(value!=null)
                {
                    book.BookCode = Convert.ToInt32(value);
                    OnPropertyChanged("UI_BookCode");
                }
            }
        }

        public string UI_BookName
        {
            get { return book.BookName.ToString(); }
            set
            {
                book.BookName = value;
                OnPropertyChanged("UI_BookName"); 
            }
        }

        public string UI_Author
        {
            get { return book.Author; }
            set
            {
                if (value != string.Empty)
                {
                    book.Author = value;
                    OnPropertyChanged("UI_Author");
                }
            }
        }

        public string UI_IsIssuable
        {
            get { return book.IsIssuable.ToString(); }
            set
            {
                if (value != null)
                {
                    book.IsIssuable = Convert.ToBoolean(value);
                }
                else
                    book.IsIssuable = false;

                OnPropertyChanged("UI_IsIssuable");
            }
        }

        public string UI_IsIssued
        {
            get { return book.IsIssued.ToString(); }
            set
            {
                if (value != null)
                {
                    book.IsIssued = Convert.ToBoolean(value);
                }
                else
                    book.IsIssued = false;

                OnPropertyChanged("UI_IsIssued");
            }
        }

        #endregion

        #region Constructor
        public BookViewModel()
        {
            db = new LibraryEntities1();
        }

        #endregion
    }
}
