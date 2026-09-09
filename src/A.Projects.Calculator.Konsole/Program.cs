using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A.Projects.Calculator;

namespace A.Projects.Calculator.Konsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator!");
            Console.WriteLine("Enter first number:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int num2 = Convert.ToInt32(Console.ReadLine());
           A.Projects.Calculator.Calculator calculator = new A.Projects.Calculator.Calculator();
            Console.WriteLine($"Addition: {calculator.Add(num1, num2)}");
            Console.WriteLine($"Subtraction: {calculator.Subtract(num1, num2)}");
            Console.WriteLine($"Multiplication: {calculator.Multiply(num1, num2)}");
            try
            {
                Console.WriteLine($"Division: {calculator.Divide(num1, num2)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
