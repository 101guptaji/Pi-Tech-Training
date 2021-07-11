using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using LibraryManagementSystem.Commands;

namespace LibraryManagementSystem.ViewModels
{
    public class IssueBookViewModel : INotifyPropertyChanged
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

        #region Issue's Properties
        IssueBook issue = new IssueBook();

        public string UI_IssueCode
        {
            get { return issue.IssueCode.ToString(); }
            set {
                if(value!=string.Empty)
                {
                    issue.IssueCode = Convert.ToInt32(value);
                    GetReturnDetails(issue.IssueCode);
                    OnPropertyChanged("UI_IssueCode");
                }
            }
        }

        private void GetReturnDetails(int issueCode)
        {
            if(issueCode>0)
            {
                IssueBook issueBook = db.IssueBooks.Where(i => i.IssueCode == issueCode).SingleOrDefault();
                if(issueBook!=null)
                {
                    UI_BookCode = issueBook.BookCode.ToString();
                    UI_BookName = issueBook.Book.BookName;
                    UI_MemberCode = issueBook.MemberCode.ToString();
                    UI_MemberName = issueBook.Member.MemberName;
                    UI_IssueDate = issueBook.IssueDate;
                    UI_DueDate = issueBook.DueDate.ToString();
                    UI_ReturnDate = DateTime.Today.ToString();
                }
            }
        }

        public string UI_MemberCode
        {
            get { return issue.MemberCode.ToString(); }
            set
            {
                if(value!=string.Empty)
                {
                    Boolean isMem = MemValidate(Convert.ToInt32(value));
                    if (isMem)
                    {
                        issue.MemberCode = Convert.ToInt32(value);
                        GetMember(Convert.ToInt32(value));
                        OnPropertyChanged("UI_MemberCode");
                    }
                    else
                    {
                        ClearMem();
                        MessageBox.Show("Invalid Member Code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void ClearMem()
        {
            UI_MemberCode = string.Empty;
            UI_MemberName = string.Empty;
            UI_MemberType = string.Empty;
            UI_BookIssued = null;
            UI_BookAllowed = null;
        }

        private bool MemValidate(int memCode)
        {
            Member mem = null;
            if (memCode > 100)
            {
                mem = db.Members.Where(m => m.MemberCode == memCode).SingleOrDefault();
                if (mem != null)
                    return true;
            }
            return false;

        }

        private void GetMember(int memberCode)
        {
            if(memberCode>100)
            {
                Member mem = db.Members.Where(m => m.MemberCode == memberCode).SingleOrDefault();
                
                UI_MemberName = mem.MemberName;
                UI_MemberType = mem.MemberType.MemberType1;
                UI_BookIssued = mem.No_of_BookIssued.ToString();
                UI_BookAllowed = mem.MemberType.No_of_BookAllowed.ToString();
                updateDueDate();
            }
        }

        Member member = new Member();

        public string UI_MemberName
        {
            get { return member.MemberName; }
            set
            {
                member.MemberName = value;
                OnPropertyChanged("UI_MemberName");
            }
        }
        public string UI_BookIssued
        {
            get { return member.No_of_BookIssued.ToString(); }
            set
            {
                if (value != string.Empty)
                {
                    member.No_of_BookIssued = Convert.ToInt32(value);
                    OnPropertyChanged("UI_BookIssued");
                }
            }
        }

        MemberType type = new MemberType();
        public string UI_MemberType
        {
            get { return type.MemberType1; }
            set
            {
                type.MemberType1 = value;
                OnPropertyChanged("UI_MemberType");
            }
        }

        public string UI_BookAllowed
        {
            get { return type.No_of_BookAllowed.ToString(); }
            set
            {
                if (value != string.Empty)
                {
                    type.No_of_BookAllowed = Convert.ToInt32(value);
                    OnPropertyChanged("UI_BookAllowed");
                }
            }
        }

        public string UI_BookCode
        {
            get { return issue.BookCode.ToString(); }
            set
            {
                if (value != string.Empty)
                {
                    int issueCode = int.Parse(UI_IssueCode);
                    if(issueCode==0)
                    {
                        Boolean isBook = BookValidate(Convert.ToInt32(value));
                        if (isBook)
                        {
                            GetBook(Convert.ToInt32(value));
                            issue.BookCode = Convert.ToInt32(value);
                            OnPropertyChanged("UI_BookCode");
                        }
                        else
                        {
                            ClearBook();
                            MessageBox.Show("Invalid Book Code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        IssueBook issueBook = db.IssueBooks.Where(i => i.IssueCode == issueCode && i.ReturnDate == null).LastOrDefault();
                    }
                    
                    
                }
            }
        }

        private void ClearBook()
        {
            UI_BookCode = string.Empty;
            UI_BookName = string.Empty;
            UI_Author = string.Empty;
            UI_DueDate = string.Empty;
        }

        private void GetBook(int bCode)
        {
            if (bCode > 0)
            {
                Book book = db.Books.Where(b=>b.BookCode==bCode).SingleOrDefault();
                if(book.IsIssuable && !book.IsIssued )
                {
                    UI_BookName = book.BookName;
                    UI_Author = book.Author;
                }
                else
                {
                    ClearBook();
                    MessageBox.Show("This Book can not issue,\n Choose other one", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                
            }
        }

        private bool BookValidate(int bCode)
        {
            Book book = null;
            if (bCode > 0)
            {
                book = db.Books.Where(b => b.BookCode == bCode).SingleOrDefault();
                if (book != null)
                    return true;
            }
            return false;
        }

        //public string UI_IssueDate
        //{
        //    get { return issue.IssueDate.ToString(); }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            issue.IssueDate = Convert.ToDateTime(value);
        //            OnPropertyChanged("UI_DueDate");
        //        }
        //    }
        //}

        private DateTime _issueDate = DateTime.Today;
        
        public DateTime UI_IssueDate
        {
            get { return _issueDate; }
            set { _issueDate = value;
                updateDueDate();
                OnPropertyChanged("UI_IssueDate");
            }
        }

        private void updateDueDate()
        {
            int memCode = Convert.ToInt32(UI_MemberCode);
            Member mem = db.Members.Where(m => m.MemberCode == memCode).SingleOrDefault();
            if (mem != null)
            {
                UI_DueDate = UI_IssueDate.AddDays(mem.MemberType.DaysAllowed).ToString();
            }
        }

        private string dueDate=DateTime.Today.ToString();
        public string UI_DueDate
        {
            get { return dueDate.ToString(); }
            set
            {
                dueDate = value;
                OnPropertyChanged("UI_DueDate");

            }
        }

        public string UI_ReturnDate
        {
            get { return issue.ReturnDate.ToString(); }
            set
            {
                if (value != string.Empty)
                {
                    issue.ReturnDate = Convert.ToDateTime(value);
                    OnPropertyChanged("UI_ReturnDate");
                }
                else
                    issue.ReturnDate = null;
            }
        }
       
        Book book = new Book();

        public string UI_BookName
        {
            get { return book.BookName; }
            set { book.BookName = value;
                OnPropertyChanged("UI_BookName");

            }
        }
        public string UI_Author
        {
            get { return book.Author; }
            set
            {
                book.Author = value;
                OnPropertyChanged("UI_Author");

            }
        }

        private ObservableCollection<IssueBook> IssueBooks;

        public ObservableCollection<IssueBook> IssueBooksList
        {
            get { return IssueBooks; }
            set { IssueBooks = value;
                OnPropertyChanged("IssueBookList");
            }
        }

        #endregion

        #region Commands
        private ICommand issueCommand;

        public ICommand IssueCommand
        {
            get { return issueCommand; }
            set { issueCommand = value; }
        }

        private ICommand clearCommand;

        public ICommand ClearCommand
        {
            get { return clearCommand; }
            set { clearCommand = value; }
        }

        private ICommand submitCommand;

        public ICommand SubmitCommand
        {
            get { return submitCommand; }
            set { submitCommand = value; }
        }

        #endregion

        #region Methods
        public bool CanIssue(object obj)
        {
            if(int.Parse(UI_MemberCode)>100 && int.Parse(UI_BookCode)>0)
                return true;
            return false;
        }

        public void Issue(object obj)
        {
            IssueBook issueBook = new IssueBook();
            if(Convert.ToInt32(UI_BookAllowed)==Convert.ToInt32(UI_BookIssued))
            {
                MessageBox.Show("You have issued maximum no of books.\n Please return, then try ", "Stop", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {
                int memCode= int.Parse(UI_MemberCode);
                int bookCode= int.Parse(UI_BookCode);


                issueBook.MemberCode = memCode;
                issueBook.BookCode = bookCode;
                issueBook.IssueDate = UI_IssueDate;
                issueBook.DueDate = Convert.ToDateTime(UI_DueDate);
                issueBook.ReturnDate = null;

                db.IssueBooks.Add(issueBook);

                Book book = db.Books.Where(b => b.BookCode == bookCode).SingleOrDefault();
                book.IsIssued = true;

                Member mem = db.Members.Where(m => m.MemberCode == memCode).SingleOrDefault();
                mem.No_of_BookIssued += 1;

                IssueBooksList.Add(issueBook);
                db.SaveChanges();
                MessageBox.Show("Book has issued Successfully ", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                Clear(null);
            }
            
        }

        public void Clear(Object obj)
        {
            ClearMem();
            ClearBook();
        }

        public bool CanSubmit(object obj)
        {
            int issueCode = int.Parse(UI_IssueCode);
            if (issueCode > 0 && int.Parse(UI_BookCode) > 0)
                return true;
            return false;
        }

        public void Submit(object obj)
        {
            int issueCode = int.Parse(UI_IssueCode);
            IssueBook issueBook = db.IssueBooks.Where(i => i.IssueCode == issueCode).SingleOrDefault();
            if (issueBook == null)
            {
                MessageBox.Show("Invalid Issue Code ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Clear(null);
            }
            else
            {
                int memCode = int.Parse(UI_MemberCode);
                int bookCode = int.Parse(UI_BookCode);

                issueBook.ReturnDate = DateTime.Parse(UI_ReturnDate);

                Book book = db.Books.Where(b => b.BookCode == bookCode).SingleOrDefault();
                book.IsIssued = false;

                Member mem = db.Members.Where(m => m.MemberCode == memCode).SingleOrDefault();
                mem.No_of_BookIssued -= 1;

                db.SaveChanges();
                MessageBox.Show("Book has returned Successfully ", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                Clear(null);
            }

        }

        #endregion

        #region Constructor
        public IssueBookViewModel()
        {
            db = new LibraryEntities1();
            IssueBooksList = new ObservableCollection<IssueBook>(db.IssueBooks.ToList());
            IssueCommand = new RelayCommand(Issue, CanIssue);
            ClearCommand = new RelayCommand(Clear);
            submitCommand = new RelayCommand(Submit, CanSubmit);
        }
        #endregion
    }
}
