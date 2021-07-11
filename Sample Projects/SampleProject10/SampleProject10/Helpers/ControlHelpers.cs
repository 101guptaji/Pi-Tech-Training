using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SampleProject10.Helpers
{
    public static class ControlHelpers
    {
        /// <summary>
        /// The disable double click property
        /// </summary>
        public static readonly DependencyProperty ValidateEmailTextProperty =
            DependencyProperty.RegisterAttached("ValidateEmailText", typeof(bool), typeof(TextBox), new PropertyMetadata(false,OnValidateEmailTextChanged));
      
        /// <summary>
        /// Called when [disable double click changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnValidateEmailTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox control = (TextBox)d;
            
            if ((bool)e.NewValue)
            {
                control.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
                
            }
        }

        private static void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // ... Get control that raised this event.
            var textBox = sender as TextBox;
            string email = textBox.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            
            if (!match.Success)
            {
                textBox.Background = Brushes.Red;
            }
            else
            {
                textBox.Background = Brushes.Transparent;
            }
        }

        /// <summary>
        /// Sets the validate email text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetValidateEmailText(UIElement element, bool value)
        {
            element.SetValue(ValidateEmailTextProperty, value);
        }

        /// <summary>
        /// Gets the validate email text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static bool GetValidateEmailText(UIElement element)
        {
            return (bool)element.GetValue(ValidateEmailTextProperty);
        }


       
    }
}
