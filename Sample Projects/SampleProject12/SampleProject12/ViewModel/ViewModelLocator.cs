namespace SampleProject12.ViewModel
{
    /// <summary>
    /// This class contains references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        #region Properties
        /// <summary>
        /// Gets the view model for EmployeeMainView.
        /// </summary>
        /// <value>
        /// The view model for EmployeeMainView.
        /// </value>
        public EmployeeMainViewModel StartViewModel
        {
            get { return new EmployeeMainViewModel(); }
        }
        #endregion

    }
}
