namespace SampleProject6.ViewModel
{
    /// <summary>
    /// This class contains references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        #region Properties

        /// <summary>
        /// Gets the view model for EmployeeGridView.
        /// </summary>
        /// <value>
        /// The view model for EmployeeGridView.
        /// </value>
        public EmployeeGridViewModel StartViewModel
        {
            get { return new EmployeeGridViewModel(); }
        }

        #endregion

    }
}
