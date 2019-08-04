using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Library
{
    public static class CalculateHelper
    {
        private static int GetPriority(char operation)
        {
            switch (operation)
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

        public static bool TryGetReversePolishNotation(string input, out string result, out string error)
        {
            input = input.Replace(',', '.').Trim(' ');

            var operStack = new Stack<char>();
            var isPreviousSignOperator = true;
            result = "";

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
                        var oper = operStack.Pop();
                        while (oper != '(')
                        {
                            result += oper.ToString() + " ";
                            oper = operStack.Pop();
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
            error = null;
            return true;
        }

        private static CalculationResult CalculateByRPN(string input)
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
                    if (digitStack.Count() >= 2)
                    {
                        double secondArgument = digitStack.Pop();
                        if (secondArgument == 0 && symbols[i] == "/")
                            return CalculationResult.CreateError("Division by zero");
                        double firstArgument = digitStack.Pop();

                        switch (symbols[i])
                        {
                            case "+":
                                result = firstArgument + secondArgument;
                                break;
                            case "-":
                                result = firstArgument - secondArgument;
                                break;
                            case "*":
                                result = firstArgument * secondArgument;
                                break;
                            case "/":
                                result = firstArgument / secondArgument;
                                break;
                            case "^":
                                result = Math.Pow(firstArgument, secondArgument);
                                break;
                        }
                    }

                    else
                        return CalculationResult.CreateError("Invalid notation");
                    digitStack.Push(result);
                }
            }
            return CalculationResult.CreateSuccess(digitStack.Peek());
        }

        public static CalculationResult Calculate(string input)
        {
            var validationError = ValidateInput(input);
            if (validationError != null)
                return CalculationResult.CreateError(validationError);
            string rpn;
            string error;
            if (!TryGetReversePolishNotation(input, out rpn, out error))
                return CalculationResult.CreateError(error);
            return CalculateByRPN(rpn);
        }

        private static string ValidateInput(string input)
        {
            if (input.Trim().Count() == 0)
                return "Empty string";

            if (input.Count(c => c == ')') != input.Count(c => c == '('))
                return "Invalid notation";

            foreach (var symbol in input)
            {
                if (!IsOperator(symbol) && !char.IsDigit(symbol) && !" .,".Contains(symbol))
                    return "Incorrect symbols";

            }
            return null;
        }

        
    }
}
