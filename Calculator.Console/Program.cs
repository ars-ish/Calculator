using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Library;

namespace Calculator.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine();
            Console.WriteLine(CalculateHelper.GetReversePolishNotation(expression));
            var a = CalculateHelper.Calculate(expression);
        }
    }
}
