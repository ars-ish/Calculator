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
            while (true)
            {
                var expression = Console.ReadLine();
                var result = CalculateHelper.Calculate(expression);

                if (result.IsSuccess())
                    Console.WriteLine(result.Result);
                else
                    Console.WriteLine(result.Error);
            }
        }
    }
}
