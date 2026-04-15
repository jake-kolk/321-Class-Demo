using SpreadsheetEngine;

namespace ExpressionTreeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            string? choice;
            string? expression = "";
            ExpressionTree? tree = null;
            while (running)
            {
                Console.WriteLine($"Current expression: {(string.IsNullOrEmpty(expression) ? "Expression is empty!" : expression)}");
                Console.WriteLine("1 = Enter a new expression");
                Console.WriteLine("2 = Set a variable value");
                Console.WriteLine("3 = Evauate Tree");
                Console.WriteLine("4 = Quit");
                Console.Write("Choice: ");

                choice = Console.ReadLine();

               switch (choice)
                {
                    case "1":
                        Console.Write("Enter new expression: ");
                        expression = Console.ReadLine();
                        if (expression == null)
                            continue;
                        tree = new ExpressionTree(expression);
                        Console.WriteLine($"Expression set to: {expression}");
                        break;

                    case "2":
                        Console.Write("Enter variable name: ");
                        string? name = Console.ReadLine();
                        if (name == null)
                            continue;
                        Console.Write("Enter variable value: ");
                        if (double.TryParse(Console.ReadLine(), out double value))
                        {
                            if (tree == null)
                                continue;
                            tree.SetVariable(name, value);
                            Console.WriteLine($"Variable {name} set to {value}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid value entered.");
                        }
                        break;

                    case "3":
                        if (tree == null)
                            continue;
                        Console.WriteLine($"Result: {tree.Evaluate()}");
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        // Ignore invalid options
                        break;
                }
            }
        }
    }
}