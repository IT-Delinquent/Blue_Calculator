namespace CalculatorUI
{
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public partial class MainWindow : Window
    {
        //Initializing component
        public MainWindow()
        {
            InitializeComponent();
        }

        //Drag event
        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //Close event
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Update Cal TextBox with the option to override or append
        void UpdateCalText(string input, bool append)
        {
            if (append)
            {
                Cal.Text += input;
            }
            else
            {
                Cal.Text = input;
            }
        }

        //Update Op TextBox with the option to override or append
        void UpdateOpText(string input, bool append)
        {
            if (append)
            {
                Op.Text += input;
            }
            else
            {
                Op.Text = input;
            }
        }

        //Returns the current value of the Op TextBox
        string GetOpText()
        {
            return Op.Text;
        }

        //Checks if the Op TextBlock ends with a digit - returns boolean
        private bool OpEndswithaDigit()
        {
            if ( Regex.Match(GetOpText(), @"\d{1}$").Success )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Event when the user presses a number button
        private void Num_Click(object sender, RoutedEventArgs e)
        {
            //Get the button that was pressed
            Button srcButton = e.Source as Button;
            //Add the content of the current button to currentValue
            string currentValue = srcButton.Content.ToString();
            //Get if the Op TextBlock is "0" or empty
            if (GetOpText() == "0" || GetOpText() == null)
            {
                UpdateOpText(currentValue, false);
            }
            else
            {
                UpdateOpText(currentValue, true);
            }
        }
        //Event when the user presses an operator button
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            //Setting the button that was just pressed
            Button srcButton = e.Source as Button;
            //Adding the content of the current button to currentValue
            string currentValue = srcButton.Content.ToString();
            //Checking if the Op TextBlock is not empty and ends with a digit
            if (GetOpText() != null && OpEndswithaDigit())
            {
                UpdateOpText(currentValue, true);
            }
        }

        //Event when the user presses the equals button
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            //Checking if the Op TextBlock ends with a digit
            //If not then don't do anything
            if (OpEndswithaDigit())
            {
                UpdateCalText(Equals_Operation(GetOpText()).ToString(), false);
                UpdateOpText(string.Empty, false);
            }
        }

        //Process when the equals button press event
        private double Equals_Operation(string expression)
        {
            //Checking if the Op TextBlock contains a divide by 0
            //Only perform the calculation if it doesn't
            if (GetOpText().Contains("/0"))
            {
                return 0;
            }
            else {
                DataTable table = new DataTable();
                table.Columns.Add("expression", typeof(string), expression);
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                return double.Parse((string)row["expression"]);
            }
        }

        //Event when the user presses the AC button
        private void AC_Click(object sender, RoutedEventArgs e)
        {
            //Clearing values
            UpdateCalText(string.Empty, false);
            UpdateOpText(string.Empty, false);
        }

        //Event for when the user presses the Dot button
        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            //Checking if the Op TextBlock doesn't already contain a dot and
            //if it isn't empty
            if (!GetOpText().Contains(".") && GetOpText() != "")
            {
                UpdateOpText(".", true);
            }
        }
    }
}
