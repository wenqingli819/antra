using System;
namespace Practice
{
    class Fact
    {
        static int Factorial(int number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }


        static void Main(string[] args)
        {
            for (int i = 1; i < 15; i++)
            {
                Console.WriteLine($"{i}! = {Factorial(i):N}");
            }
        }
    }
}