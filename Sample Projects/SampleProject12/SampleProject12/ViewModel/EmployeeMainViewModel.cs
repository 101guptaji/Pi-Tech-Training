using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SampleProject12.Common;
using SampleProject12.ViewModel.Data;

namespace SampleProject12.ViewModel
{
    /// <summary>
    /// This class is view model for EmployeeMainView.
    /// </summary>
    public class EmployeeMainViewModel : ObservableObject ,ICleanup
    {
        #region Properties

        /// <summary>
        /// Gets or sets the current view.
        /// </summary>
        private SpecialisedObservableCollection<EmployeeViewModel> _currentView;

        /// <summary>
        /// Gets or sets the current view.
        /// </summary>
        /// <value>
        /// The current view.
        /// </value>
        public SpecialisedObservableCollection<EmployeeViewModel> CurrentView
        {
            get { return _currentView; }
            set { Set(() => CurrentView, ref _currentView, value); }
        }

        #endregion

        #region Relay Commands

        /// <summary>
        /// The list view command.
        /// </summary>
        private RelayCommand _listViewCommand;

        /// <summary>
        /// Gets the list view command.
        /// </summary>
        /// <value>
        /// The  list view command.
        /// </value>
        public RelayCommand ListViewCommand
        {
            get { return _listViewCommand ?? (_listViewCommand = new RelayCommand(GetListView)); }
        }     


        /// <summary>
        /// The thumbnail view command.
        /// </summary>
        private RelayCommand _thumbnailViewCommand;

        /// <summary>
        /// Gets the thumbnail view command.
        /// </summary>
        /// <value>
        /// The thumbnail view command.
        /// </value>
        public RelayCommand ThumbnailViewCommand
        {
            get { return _thumbnailViewCommand ?? (_thumbnailViewCommand = new RelayCommand(GetThumbnailView)); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeMainViewModel"/> class.
        /// </summary>
        public EmployeeMainViewModel()
        {
            CurrentView = new EmployeeListViewModel();//By deafult load the list view.
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list view.
        /// </summary>
        private void GetListView()
        {
            if (CurrentView == null || CurrentView.GetType() != typeof(EmployeeListViewModel))
            {
                CurrentView = new EmployeeListViewModel();
            }
        }

        /// <summary>
        /// Gets the thumbnail view.
        /// </summary>
        private void GetThumbnailView()
        {
            if (CurrentView == null || CurrentView.GetType() != typeof(EmployeeThumbnailViewModel))
            {
                CurrentView = new EmployeeThumbnailViewModel();
            }
        }

        #endregion      

        #region Cleanup

        /// <summary>
        /// This clean up items
        /// </summary>
        public void Cleanup()
        {
            if(CurrentView !=null)
            {
                CurrentView.CleanupItems();
                CurrentView.Cleanup();
                CurrentView = null;
            }

            if(_listViewCommand!=null)
            {
                _listViewCommand = null;
            }

            if(_thumbnailViewCommand!=null)
            {
                _thumbnailViewCommand = null;
            }          
        }

        #endregion
    }
}
