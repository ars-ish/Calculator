﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorLibrary;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine();
            Console.WriteLine(Calculator.GetReversePolishNotation(expression));
            var a = Calculator.Calculate(expression);
           
            Console.WriteLine(a);
            Console.Write(float.MaxValue);
        }
    }
}
