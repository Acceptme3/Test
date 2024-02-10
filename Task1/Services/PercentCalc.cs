using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task1.Services
{
    internal class PercentCalc : IPercentCalc
    {
        public double GetInterestRate(int deposit)
        {
            if (deposit < 0)
            {
                return 0.0;
            }

            if (deposit < 100) 
            {
                return RateCalc(deposit, 5);
            }

            if (deposit >= 100 && deposit < 200)
            {
                return RateCalc(deposit, 7);
            }

            if (deposit >= 200)
            {
                return RateCalc(deposit, 10);
            }
            return 0.0;
        }

        double RateCalc(int value, double percentage)
        {
            return value + (value * (percentage / 100));
        }
    }
}
