using System;
using System.Configuration;
using System.Collections.Specialized;
using Calculator.View;
using Calculator.Model;

namespace Calculator.Controller
{
    class CalcController
    {
        public int NumberMenu { get; set; }

        public int CounterRepit { get; set; }

        public int CounterOper { get; set; }

        public string Save { get; set; }

        // Repeat operation.
        public string Reapit { get; set; }

        // Continuation of calculations.
        public string Contin { get; set; }

        double[] results = new double[1];

        Calculate Calculate { get; set; }

        Show show = null;

        public CalcController(Calculate calculate)
        {
            show = new Show();

            Calculate = calculate;

            Calculate.Result = 0.0;

            NumberMenu = 0;

            CounterRepit = 0;

            Save = "";

            Reapit = "";

            Contin = "";
        }

        public void Run()
        {
            Console.Title = "Calculator";

            // Setting the height and width of the console window.
            Console.WindowWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("windowWidth"));
            Console.WindowHeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("windowHeight")); ;

            bool flag = false;

            // Greeting output.
            show.ShowGreeting();

            while (true)
            {
                if (flag)
                {
                    Console.Clear();
                }
                
                show.Menu();

                NumberMenu = EnterNumberMenu();

                SwichNumberMenu();

                flag = true;
            }
        }

        public int EnterNumberMenu()
        {
            int numberMenu = 0;

            // Cycle until one of the menu item numbers is entered.
            while (true)
            {
                // Entering the action number from the menu.
                try
                {
                    numberMenu = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Check for correspondence of the number from the menu to the entered number.
                if (numberMenu > 0 && numberMenu < 5)
                {
                    break;
                }
                else
                {
                    Console.Clear();

                    show.Menu();

                    Console.Write("\nEnter a number from 1 to 4: ");

                    continue;
                }
            }

            return numberMenu;
        }

        public void SwichNumberMenu()
        {
            switch (NumberMenu)
            {
                case 1: CaseNewCalculation(); break;

                case 2:
                    {
                        ShowResults();
                        Console.ReadKey();
                    }
                    break;

                case 3: 
                    {
                        Console.Clear();

                        show.AboutProgram();
                    }
                    break;

                case 4: Environment.Exit(0); break;
            }
        }

        void CaseNewCalculation()
        {
            Console.Clear();

            while (true)
            {
                // To write the result to the first element of the array.
                double temp;

                AllRead();

                // Calculating and returning the result.
                Calculate.Calculation();

                // With different lengths of the array, it is necessary to write to it in different ways
                // the last result is written to the first element of the array,
                // the rest of the results are shifted one position further in the array
                // if there are more than 5 results, then the older ones are destroyed.
                if (results.Length == 1)
                {
                    results[0] = (double)Calculate.Result;
                }
                else
                {
                    temp = (double)Calculate.Result;

                    for (int i = results.Length - 1; i > 0; i--)
                    {
                        results[i] = results[i - 1];
                    }
                    results[0] = temp;
                }

                // Increasing array size.
                if (results.Length < 5)
                {
                    Array.Resize(ref results, results.Length + 1);
                }

                // Result output.
                Calculate.ShowResult();

                Console.WriteLine();

                // Actions to save, redo or continue.
                Save = SaveResult();

                if (Save == "y")
                {
                    Reapit = RepeatOperation();
                    continue;
                }
                else
                {
                    Contin = Continue();

                    if (Contin == "y")
                    {
                        Reapit = RepeatOperation();
                    }
                    else
                    {
                        break;
                    }
                    continue;
                }
            }
        }

        void ShowResults()
        { 
            Console.Clear();

                    if (results.Length < 5)
                    {
                        for (int i = 0; i < results.Length - 1; i++)
                            Console.WriteLine("result{0} = {1}", i + 1, results[i]);
                    }
                    else
                    {
                        for (int i = 0; i < results.Length; i++)
                            Console.WriteLine("result{0} = {1}", i + 1, results[i]);
                    }

                    Console.WriteLine();
        }

        string Continue()
        {
            Console.Write("Continue? y/n ");

            string contin = Console.ReadLine();

            while (true)
            {
                // If we start a new calculation, then we need to remove the repetition of the operation.
                if (contin.ToLower() == "n" || contin.ToLower() == "y")
                {
                    CounterRepit = 0;

                    Console.Clear();

                    break;
                }
                else
                {
                    Console.Write("Enter y/n: ");

                    contin = Console.ReadLine();

                    continue;
                }
            }

            return contin;
        }

        string SaveResult()
        {
            string save = "";

            Console.Write("Save the result? y/n ");

            save = Console.ReadLine();

            // The cycle is tied to the value of the flag.
            bool flag = true;

            while (flag)
            {
                // Always cast save to lowercase, if it is equal to n,
                // then we make it possible to enter the first number and exit the loop.
                if (save.ToLower() == "n")
                {
                    CounterOper = 0;

                    Console.Clear();

                    break;
                }

                // Do not exit the loop until we enter "y" or "n".
                else if (save.ToLower() != "y")
                {
                    Console.Clear();

                    Console.Write("Enter y/n: ");

                    save = Console.ReadLine();

                }
                else
                {
                    Console.Clear();

                    // The first number we assign the current result.
                    Calculate.FirstValue = Calculate.Result;

                    // Prohibition of entering the first number.
                    CounterOper++;

                    flag = false;
                }
            }
            return save;
        }

        string RepeatOperation()
        {
            // Almost everything is like in the SaveResult() method.
            string repit = "";

            Console.Write("Repit the operation? y/n ");

            repit = Console.ReadLine();

            bool flag = true;

            while (flag)
            {
                if (repit.ToLower() == "n")
                {
                    CounterRepit = 0;

                    Console.Clear();

                    break;
                }
                else if (repit.ToLower() != "y")
                {
                    Console.Clear();

                    Console.Write("Enter y/n: ");

                    repit = Console.ReadLine();
                }
                else
                {
                    Console.Clear();

                    CounterRepit++;

                    Console.Clear();

                    flag = false;
                }
            }
            return repit;
        }

        void ReadOperation()
        {
            if (CounterRepit == 0)
            {
                // Endlessly catching exceptions until we enter one character.
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Calculate.Operation = Char.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Gray;

                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;

                        show.ShowMenuOperation();
                        continue;
                    }
                }

                // Endless input of characters until we enter one of the required.
                while (true)
                {
                    bool condition = Calculate.Operation == '+' || Calculate.Operation == '-' || Calculate.Operation == '*'
                        || Calculate.Operation == '/' || Calculate.Operation == '%' || Calculate.Operation == '^' || Calculate.Operation == 'v';

                    Console.Clear();

                    if (condition)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Enter the sign ('+' or '-' or '*' or '/' or '%' or '^' or 'v'): ");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Calculate.Operation = Char.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }

        void ReadFirstValue()
        {
            while (true)
            {
                if (CounterOper == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Enter the first value: ");

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Calculate.FirstValue = Double.Parse(Console.ReadLine());

                        // When entering the operation of taking a root, 
                        // I ensure the prohibition of entering negative values.
                        if (Calculate.Operation == 'v' && Calculate.FirstValue < 0)
                            // Closest exception.
                            throw new InvalidOperationException();

                        Console.ForegroundColor = ConsoleColor.Gray;

                        break;
                    }
                    catch (OverflowException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);

                        continue;
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message + "\nEnter value >= 0.");

                        continue;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message + "\nEnter an integer or real value, for example 7 or 3,14.");

                        continue;
                    }
                }
                // If the first number is not entered, then its value is displayed.
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("First value = ");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Calculate.FirstValue);
                    Console.ForegroundColor = ConsoleColor.Gray;

                    break;
                }
            }
        }

        void ReadSecondValue()
        {
            Console.Clear();

            Console.Write("FirstValue = ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Calculate.FirstValue);

            Console.WriteLine();

            // The second number should not be entered when finding the square root.
            if (Calculate.Operation != 'v')
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write("Enter the second value: ");

                    // Plus handling zero input when performing a division operation.
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Calculate.SecondValue = Double.Parse(Console.ReadLine());

                        if (Calculate.SecondValue == 0)
                            throw new DivideByZeroException();

                        Console.ForegroundColor = ConsoleColor.Gray;

                        break;

                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("FirstValue = ");
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine(Calculate.FirstValue);

                        Console.WriteLine("\n" + ex.Message + "\nEnter an integer or real value (such as 7 or 3.14) that is not zero.");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        continue;
                    }
                    catch (OverflowException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("FirstValue = ");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Calculate.FirstValue);

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("\n" + ex.Message);

                        continue;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("FirstValue = ");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Calculate.FirstValue);

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("\n" + ex.Message + "\nEnter an integer or real value, for example 7 or 3,14.");

                        continue;
                    }
                }
            }
        }

        void AllRead()
        {
            // When the operation is repeated, the operation selection menu should not be displayed.
            if (CounterRepit == 0)
            {
                show.ShowMenuOperation();
            }

            ReadOperation();

            ReadFirstValue();

            ReadSecondValue();
        }
    }
}
