using System;

namespace TriniKwanQuantumLeap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HELLO THERE! WOULD YOU LIKE TO TAKE A LEAP? REPLY WITH Y OR N");
            string answer = Console.ReadLine().ToUpper();
            while (true)
            {
                if (answer == "N")
                {
                    Console.WriteLine("FINE! BE BORING!");
                    break;
                }
                
                if (answer == "Y")
                {
                    var budget = new Budget();
                    budget.checkBalance();
                    break;
                }
                Console.WriteLine("PLEASE REPLY WITH A Y OR N");
                answer = Console.ReadLine().ToUpper();
            }

        }
    }
}
