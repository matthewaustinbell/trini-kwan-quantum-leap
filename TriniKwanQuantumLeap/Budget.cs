using System;
using System.Collections.Generic;
using System.Text;

namespace TriniKwanQuantumLeap
{
    class Budget
    {
        readonly int _leapingCost = 1000;
        public int _initialBalance = 500;
        public int FinalBalance { get; set; }
        public int LeapFunds { get; set; }

        public void checkBalance(int leapCost)
        {

            if (_initialBalance >= 1000)
            {
                Console.WriteLine("Leap Authorized");
                // call the Leap method from the Leap repository
                // deduct cost of leap from initial balance
            }
            else
            {
                Console.WriteLine("More funds required for leap. Would you like to add more funds? y/n");
                string reply = Console.ReadLine().ToUpper();
                while (true)
                {
                    if (reply == "Y")
                    {
                        Console.WriteLine("Enter an amount greater than $1000");
                        LeapFunds = int.Parse(Console.ReadLine());
                        // Adding data validation for if the user enters less than $1000
                        if (LeapFunds < 1000)
                        {
                            Console.WriteLine("You're bad at math but we fixed it for you");
                            LeapFunds = LeapFunds + 1000;
                            Console.WriteLine($"You added a total of ${LeapFunds}");
                            break;
                        }
                        _initialBalance += LeapFunds;
                        Console.WriteLine($"${LeapFunds} has been added to your account. Your balance is {_initialBalance}. Leap Authorized!!!");
                        break;
                        // call method that authorize leap
                        // deduct cos of leap
                    }
                    if (reply == "N")
                    {
                        Console.WriteLine("GoodLuck on your ventures");
                        break;
                    }
                    Console.WriteLine("Please reply with y or n");
                    reply = Console.ReadLine().ToUpper();
                }

            }

            }
        public void TotalLeapCost()
        {

        }

        public void EventTimeSpan()
        {

        }
    }

}
