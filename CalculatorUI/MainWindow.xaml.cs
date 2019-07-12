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

        string input = string.Empty;
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        char operation;
        double result = 0.0;

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";
            input += "0";
            Cal.Text = input;

        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";

            input += "9";
            Cal.Text = input;
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";

            input += "8";
            Cal.Text = input;
        }

        private void Sevem_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";

            input += "7";
            Cal.Text = input;
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";

            input += "6";
            Cal.Text = input;
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";

            input += "5";
            Cal.Text = input;
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";

            input += "4";
            Cal.Text = input;
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";

            input += "3";
            Cal.Text = input;
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";

            input += "2";
            Cal.Text = input;
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            Cal.Text = "";

            input += "1";
            Cal.Text = input;
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
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
