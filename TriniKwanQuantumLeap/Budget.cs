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

        public void checkBalance()
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
                var reply = Console.ReadLine();

                while(reply != "y")
                {
                    Console.WriteLine("Please reply with y or n");
                    reply = Console.ReadLine();
                    if (reply == "y")
                    {
                        Console.WriteLine("Enter an amount greater than $1000");
                        LeapFunds = int.Parse(Console.ReadLine());
                        _initialBalance += LeapFunds;
                        Console.WriteLine($"${LeapFunds} has been added to your account. Your balance is {_initialBalance}. Leap Authorized!!!");
                        // call method that authorize leap
                        // deduct cos of leap
                    }
                    else if (reply == "n")
                    {
                        Console.WriteLine("GoodLuck on your ventures");
                    }
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
