using SampleProject11.View;
using System.Windows;

namespace SampleProject11
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Methods

        // <summary>
        /// Method called on start of application.
        /// </summary>
        /// <param name="sender">sender of start event.</param>
        /// <param name="e">event arguments of type <see cref="StartupEventArgs"/>.</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            EmployeeFormView empView = new EmployeeFormView();
            empView.Show();
        }

        #endregion
    }
}
