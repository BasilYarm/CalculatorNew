using System;
using Calculator.Controller;
using Calculator.Model;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate calculate = new Calculate();

            CalcController calculator = new CalcController(calculate);

            calculator.Run();

            Console.ReadKey();
        }
    }
}
