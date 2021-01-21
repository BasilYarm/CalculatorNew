using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Model
{
    class Calculate
    {
        public double FirstValue { get; set; }

        public double SecondValue { get; set; }

        public char Operation {get; set;}

        public double Result { get; set; }

        public void Calculation()
        {
                Console.Clear();

                // Performing the desired operation with the entered values.
                switch (Operation)
                {
                    case '+': Result = FirstValue + SecondValue; break;
                    case '-': Result = FirstValue - SecondValue; break;
                    case '*': Result = FirstValue * SecondValue; break;
                    case '/': Result = FirstValue / SecondValue; break;
                    case '%': Result = (FirstValue / 100) * SecondValue; break;
                    case '^': Result = Math.Pow((double)FirstValue, (double)SecondValue); break;
                    case 'v': Result = Math.Sqrt((double)FirstValue); break;
                    default: Console.WriteLine("Не задано одно из условий!"); break;
                }
        }

        public void ShowResult()
        {
            Console.Clear();

            // All operations have two operands, the sign of the operation and the result. 
            if (Operation != 'v' && Operation != '%')
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Your result: ");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("{0} {1} {2} = {3}", FirstValue, Operation, SecondValue, Result);

                Console.ForegroundColor = ConsoleColor.Gray;
            }

            // In the operation of finding the root - the sign of the operation, the number and the result.
            else if (Operation != '%')
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Your result: ");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("{0}{1} = {2}", Operation, FirstValue, Result);

                Console.ForegroundColor = ConsoleColor.Gray;
            }

            // When finding a percentage, for example 10% of 100 = 10 
            // (second number, operation sign, first number, result).
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Your result: ");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("{0} {1} of {2} = {3}", SecondValue, Operation, FirstValue, Result);

                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
