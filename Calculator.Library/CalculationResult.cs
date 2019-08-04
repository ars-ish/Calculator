using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Library
{
    public class CalculationResult
    {
        public double Result { get; private set; }
        public string Error { get; private set; }

        public static CalculationResult CreateError(string error)
        {
            return new CalculationResult { Error = error };
        }

        public static CalculationResult CreateSuccess(double result)
        {
            return new CalculationResult { Result = result };
        }

        public bool IsSuccess()
        {
            return Error == null;
        }
    }
}
