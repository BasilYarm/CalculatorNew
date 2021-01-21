using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.View
{
    class Show
    {
        public void ShowGreeting()
        {
            // Greeting output.
            // Output of the inscription approximately to the middle of the window.
            Console.Write("\t\t\t");

            // Change font and background color.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine("Hello! Welcome to the calculator program.");

            // Return color and background.
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();
        }

        public void Menu()
        {
            Console.Write("\t");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("MENU:");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\npress 1 for new calculation;");
            Console.WriteLine("press 2 to display the results of recent operations;");
            Console.WriteLine("press 3 for program information;");
            Console.WriteLine("press 4 to exit the program.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("select the required action: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ShowMenuOperation()
        {
            // A prompt to enter a character for the operation being performed (v - most like a root).
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nEnter the sign of the operation");
            Console.WriteLine("\tfor plus     - '+'");
            Console.WriteLine("\tfor minus    - '-'");
            Console.WriteLine("\tfor multiply - '*'");
            Console.WriteLine("\tfor divide   - '/'");
            Console.WriteLine("\tfor percent  - '%'");
            Console.WriteLine("\tfor power    - '^'");
            Console.Write("\tfor square   - 'v': ");
        }

        public void AboutProgram()
        {
            Console.WriteLine("Console CALCULATOR program, version 2.0");

            Console.WriteLine("\nAllows you to perform the following operations:");
            Console.WriteLine("- addition;");
            Console.WriteLine("- subtraction;");
            Console.WriteLine("- multiplication;");
            Console.WriteLine("- division;");
            Console.WriteLine("- exponentiation;");
            Console.WriteLine("- finding the square root.");
            Console.WriteLine("It allows you to save the result of the operation and use it in other");
            Console.WriteLine("calculations; after completing each block of calculations, it is");
            Console.WriteLine("possible to start a new block of calculations without leaving the program.");

            Console.WriteLine("\nDeveloper - Yarmalkevich V.I.");

            Console.ReadLine();
        }

        
    }
}
