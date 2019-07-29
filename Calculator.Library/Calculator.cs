using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorLibrary
{
    public class Calculator
    {
        private static int GetPriority(char oper)
        {
            switch (oper)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 5;
                case '^': return 6;
                default: return 7;
            }
        }

        private static bool IsOperator(char symbol)
        {
            return ("()+-*/^".Contains(symbol));
        }

        public static string GetReversePolishNotation(string input)
        {
            input = input.Trim(' ').Replace(',', '.');

            var operStack = new Stack<char>();
            var result = "";

            var isPreviousSignOperator = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]) || input[i] == '.')
                {
                    isPreviousSignOperator = false;
                    result += input[i];
                }

                if (IsOperator(input[i]))
                {
                    if (input[i] == '-')
                    {
                        if (isPreviousSignOperator)
                        {
                            result += '-';
                            continue;
                        }
                    }

                    result += " ";

                    if (input[i] == '(')
                        operStack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        var stack = operStack.Pop();
                        while (stack != '(')
                        {
                            result += stack.ToString() + " ";
                            stack = operStack.Pop();
                        }
                    }
                    else
                    {
                         isPreviousSignOperator = true;
                        if (operStack.Count > 0 &&
                            GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                            result += operStack.Pop() + " ";
                        operStack.Push(input[i]);
                    }
                }
            }

            while (operStack.Count != 0)
            {
                result += " " + operStack.Pop();
            }
            return result;
        }

        private static double CalculateByRPN(string input)
        {
            var result = 0.0;
            var number = 0.0;
            var digitStack = new Stack<double>();
            var symbols = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < symbols.Length; i++)
            {
                if (double.TryParse(symbols[i], System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out number))
                    digitStack.Push(number);

                else
                {
                    double a = digitStack.Pop();
                    double b = digitStack.Pop();

                    switch (symbols[i])
                    {
                        case "+":
                            result = b + a;
                            break;
                        case "-":
                            result = b - a;
                            break;
                        case "*":
                            result = b * a;
                            break;
                        case "/":
                            result = b / a;
                            break;
                        case "^":
                            result = Math.Pow(b, a);
                            break;
                    }
                    digitStack.Push(result);
                }
            }
            return digitStack.Peek();
        }

        public static double Calculate(string input)
        {
            return CalculateByRPN(GetReversePolishNotation(input));
        }
    }
}
