using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            string currentValue = numbers[srcButton.Name].ToString();
            if (Cal.Text == "0" && Cal.Text != null )
            {
                Cal.Text = currentValue;
            }
            else
            {
                Cal.Text += currentValue;
            }
            Op.Text += currentValue;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Cal.Text, out double i))
            {
                FirstNumber = Convert.ToDouble(i);
                Cal.Text = "0";
                Button srcButton = e.Source as Button;
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
                Op.Text += Operation;
            }
        }


        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double SecondNumber, Result;
            SecondNumber = Convert.ToDouble(Cal.Text);

            switch (Operation)
            {
                case "+":
                    Result = (FirstNumber + SecondNumber);
                    Cal.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                    Op.Text = Convert.ToString(Result);
                    break;
                case "-":
                    Result = (FirstNumber - SecondNumber);
                    Cal.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                    Op.Text = Convert.ToString(Result);
                    break;
                case "*":
                    Result = (FirstNumber * SecondNumber);
                    Cal.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                    Op.Text = Convert.ToString(Result);
                    break;
                case "/":
                    if (SecondNumber == 0)
                    {
                        Cal.Text = "Cannot divide by 0!";
                        Op.Text = string.Empty;
                        ToggleButtonExceptAC(false);
                    }
                    else
                    {
                        Result = (FirstNumber / SecondNumber);
                        Cal.Text = Convert.ToString(Result);
                        FirstNumber = Result;
                        Op.Text = Convert.ToString(Result);
                    }
                    break;
            }
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            //Ensures their is only one . in a calculation
            if (!Cal.Text.Contains(".") )
            {
                Cal.Text += ".";

            }
        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "0";
            Op.Text = string.Empty;
            ToggleButtonExceptAC(true);
        }
    }
}
