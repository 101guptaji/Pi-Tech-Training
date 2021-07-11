namespace SampleProject11.ViewModel
{
    /// <summary>
    /// This class contains references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        #region Properties

        /// <summary>
        /// Gets the view model for EmployeeFormView.
        /// </summary>
        /// <value>
        /// The view model for EmployeeFormView.
        /// </value>
        public EmployeeFormViewModel StartViewModel
        {
            get { return new EmployeeFormViewModel(); }
        }

        #endregion
    }
}
