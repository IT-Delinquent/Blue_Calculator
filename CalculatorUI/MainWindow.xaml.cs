using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creating initial variables and hashtable
        double FirstNumber;
        string Operation;
        readonly Hashtable numbers = new Hashtable()
        {
            {"Zero", "0" },
            {"One", "1" },
            {"Two", "2" },
            {"Three", "3" },
            {"Four", "4" },
            {"Five", "5" },
            {"Six", "6" },
            {"Seven", "7" },
            {"Eight", "8" },
            {"Nine", "9" }
        };

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

        //Toggle buttons but AC
        private void ToggleButtonExceptAC(bool input)
        {
            foreach(Button i in ButtonsGrid.Children)
            {
                if (i.Name != "AC")
                {
                    i.IsEnabled = input;
                }
            }
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
        void updateOpText(string input, bool append)
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

        //Returns the current value of the Cal TextBox
        string GetCalText()
        {
            return Cal.Text;
        }

        //Event for when the user presses a number button
        private void Num_Click(object sender, RoutedEventArgs e)
        {
            //Getting the source button by name
            Button srcButton = e.Source as Button;
            string currentValue = numbers[srcButton.Name].ToString();
            //Checking if the Cal TextBox contains just a "0" or if it is null
            if (GetCalText() == "0" && GetCalText() != null )
            {
                UpdateCalText(currentValue, false);
            }
            else
            {
                UpdateCalText(currentValue, true);
            }
            updateOpText(currentValue, true);
        }

        //Event for when the user presses an operator button
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            //Checking if the Cal TextBox text can be parsed into a type double
            //If not, then do nothing
            if (double.TryParse(Cal.Text, out double i))
            {
                //Setting first number, updating Cal TextBox and getting source button
                FirstNumber = Convert.ToDouble(i);
                UpdateCalText("0", false);
                Button srcButton = e.Source as Button;
                //Using switch to update the operation variable based on the source button's name
                switch (srcButton.Name)
                {
                    case "Plus":
                        Operation = "+";
                        break;
                    case "Minus":
                        Operation = "-";
                        break;
                    case "Divide":
                        Operation = "/";
                        break;
                    case "Multiply":
                        Operation = "*";
                        break;
                }
                //Updating Op TextBox
                updateOpText(Operation, true);
            }
        }

        //Event for when the user clicks the equals button
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            //Creating two new variables for the calculation
            double SecondNumber, Result;
            SecondNumber = Convert.ToDouble(Cal.Text);
            //Switching the Operator variable to see what to do
            switch (Operation)
            {
                case "+":
                    Result = (FirstNumber + SecondNumber);
                    UpdateCalText(Convert.ToString(Result), false);
                    FirstNumber = Result;
                    updateOpText(Convert.ToString(Result), false);
                    break;
                case "-":
                    Result = (FirstNumber - SecondNumber);
                    UpdateCalText(Convert.ToString(Result), false);
                    FirstNumber = Result;
                    UpdateCalText(Convert.ToString(Result), false);
                    break;
                case "*":
                    Result = (FirstNumber * SecondNumber);
                    UpdateCalText(Convert.ToString(Result), false);
                    FirstNumber = Result;
                    UpdateCalText(Convert.ToString(Result), false);
                    break;
                case "/":
                    if (SecondNumber == 0)
                    {
                        UpdateCalText("Cannot divide by o!", false);
                        updateOpText(string.Empty, false);
                        ToggleButtonExceptAC(false);
                    }
                    else
                    {
                        Result = (FirstNumber / SecondNumber);
                        UpdateCalText(Convert.ToString(Result), false);
                        FirstNumber = Result;
                        UpdateCalText(Convert.ToString(Result), false);
                    }
                    break;
            }
        }

        //Event for when the user presses the dot button
        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            //Checking if there is already a full stop in the Cal TextBox
            //Ensures their is only one . in a calculation
            if (GetCalText().Contains("."))
            {
                UpdateCalText(".", true);
            }
        }

        //Event for when the user presses the dot button
        private void AC_Click(object sender, RoutedEventArgs e)
        {
            UpdateCalText("0", false);
            updateOpText(string.Empty, false);
            ToggleButtonExceptAC(true);
            Operation = string.Empty;
        }
    }
}
