using System;
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

        double FirstNumber;
        string Operation;


        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (Cal.Text == "0" && Cal.Text != null)
            {
                Cal.Text = "0";
            }
            else
            {
                Cal.Text += "0";
            }
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            if (Cal.Text == "0" && Cal.Text != null)
            {
                Cal.Text = "9";
            }
            else
            {
                Cal.Text += "9";
            }
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            if (Cal.Text == "0" && Cal.Text != null)
            {
                Cal.Text = "8";
            }
            else
            {
                Cal.Text += "8";
            }
        }

        private void Sevem_Click(object sender, RoutedEventArgs e)
        {
            if (Cal.Text == "0" && Cal.Text != null)
            {
                Cal.Text = "7";
            }
            else
            {
                Cal.Text += "7";
            }
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            if (Cal.Text == "0" && Cal.Text != null)
            {
                Cal.Text = "6";
            }
            else
            {
                Cal.Text += "6";
            }
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            if (Cal.Text == "0" && Cal.Text != null)
            {
                Cal.Text = "5";
            }
            else
            {
                Cal.Text += "5";
            }
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            if (Cal.Text == "0" && Cal.Text != null)
            {
                Cal.Text = "4";
            }
            else
            {
                Cal.Text += "4";
            }
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            if (Cal.Text == "0" && Cal.Text != null)
            {
                Cal.Text = "3";
            }
            else
            {
                Cal.Text += "3";
            }
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            if (Cal.Text == "0" && Cal.Text != null)
            {
                Cal.Text = "2";
            }
            else
            {
                Cal.Text += "2";
            }
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (Cal.Text == "0" && Cal.Text != null)
            {
                Cal.Text = "1";
            }
            else
            {
                Cal.Text += "1";
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            FirstNumber = Convert.ToDouble()
            operand1 = input;
            operation = '+';
            input += string.Empty;

        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '-';
            input += string.Empty;

        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '/';
            input += string.Empty;

        }

        private void Multply_Click(object sender, RoutedEventArgs e)
        {
            operand1 = input;
            operation = '*';
            input += string.Empty;

        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            operand2 = input;
            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            if (operation == '+')
            {
                result = num1 + num2;
                Cal.Text = result.ToString();
            }else if (operation == '-')
            {
                result = num1 - num2;
                Cal.Text = result.ToString();
            }

        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {

            Cal.Text = "";

            input += ".";
            Cal.Text = input;


        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";
            input = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;
        }

        //private void Click(object sender, RoutedEventArgs e)
        //{
        //Cal.Text = "";
        //Button srcButton = e.Source as Button;
        //CalculationsClass.ParseInput(srcButton.Name);
        //Cal.Text += CalculationsClass.ReturnInput().ToString();

        //Checking if the calculation already has a .
        //if (Cal.Text.Contains("."))
        //{
        //    Dot.IsEnabled = false;
        //}

        //Op.Text = CalculationsClass.Result.ToString();
        //}
    }
}
