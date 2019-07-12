using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUI
{
    public class CalculationsClass
    {
        //Storing user input
        public static string Input = string.Empty;
        //Storing first operand
        public static string Operand1 = string.Empty;
        //Storing second operand
        public static string Operand2 = string.Empty;
        //char for operation
        public static char Operation;
        //result of calculation
        public static double Result = 0.0;

        public static void ParseInput(string input)
        {
            switch (input)
            {
                case "Zero":
                    UpdateInput("0");
                    break;
                case "One":
                    UpdateInput("1");
                    break;
                case "Two":
                    UpdateInput("2");
                    break;
                case "Three":
                    UpdateInput("3");
                    break;
                case "Four":
                    UpdateInput("4");
                    break;
                case "Five":
                    UpdateInput("5");
                    break;
                case "Six":
                    UpdateInput("6");
                    break;
                case "Seven":
                    UpdateInput("7");
                    break;
                case "Eight":
                    UpdateInput("8");
                    break;
                case "Nine":
                    UpdateInput("9");
                    break;
                case "Dot":
                    UpdateInput(".");
                    break;
                case "Plus":
                    UpdateOperand1("+");
                    UpdateOperation('+');
                    ClearInput();
                    break;
                case "Minus":
                    UpdateOperand1("-");
                    UpdateOperation('-');
                    ClearInput();
                    break;
                case "Divide":
                    UpdateOperand1("/");
                    UpdateOperation('/');
                    ClearInput();
                    break;
                case "Multiple":
                    UpdateOperand1("*");
                    UpdateOperation('*');
                    ClearInput();
                    break;
                case "AC":
                    ACActions();
                    break;
                case "Equals":
                    EqualsAction();
                    break;
            }
        }

        private static void EqualsAction()
        {
            UpdateOperand2(Input);
            double.TryParse(Operand1, out double num1);
            double.TryParse(Operand2, out double num2);
            switch (Operation)
            {
                case '+':
                    Result = num1 + num2;
                    break;
                case '-':
                    Result = num1 - num2;
                    break;
                case '*':
                    Result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        Result = num1 / num2;
                    }
                    else
                    {
                       Result = 0;
                    }
                    break;
            }
        }

        private static void ACActions()
        {
            ClearInput();
            UpdateInput("AC");
            Operand1 = string.Empty;
            Operand2 = string.Empty;
        }

        private static void ClearInput()
        {
            Input = string.Empty;
        }

        private static void UpdateInput(string input)
        {
            Input += input;
        }

        private static void UpdateOperand1(string input)
        {
            Operand1 = input;
        }

        private static void UpdateOperand2(string input)
        {
            Operand2 = input;
        }

        private static void UpdateOperation(char input)
        {
            Operation = input;
        }

        public static string ReturnInput()
        {
            if (Input == "AC")
            {
                ClearInput();
                return "0";
            }
            else
            {
                try
                {
                    return Input;
                }
                catch
                {
                    return "Failed";
                }
            }
        }
    }
}
