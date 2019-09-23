using System;
using System.Collections.Generic;
using System.Text;
using TriniKwanQuantumLeap.Data;

namespace TriniKwanQuantumLeap
{
    class Budget
    {
        public double LeapingCost { get; set; }
        public double _initialBalance = 50000000;
        public double FinalBalance { get; set; } 
        public double LeapFunds { get; set; }

        public void checkBalance(double costToLeap, Event destination)
        {

            if (_initialBalance >= costToLeap)
            {
                Console.WriteLine("Leap Authorized");
                Console.WriteLine($"You have arrived at the {destination.Location}, the year is {destination.Date.Year}. You have ${_initialBalance - costToLeap} remaining");
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
                        Console.WriteLine($"Enter an amount greater than or equal to ${costToLeap}");
                        LeapFunds = double.Parse(Console.ReadLine());
                        // Adding data validation for if the user enters less than $1000
                        if (LeapFunds < costToLeap)
                        {
                            Console.WriteLine("You're bad at math but we fixed it for you");
                            LeapFunds = LeapFunds + 100000000;
                            Console.WriteLine($"You added a total of ${LeapFunds}");
                            // Need to route user back to start
                            break;
                        }
                        _initialBalance += LeapFunds;
                        _initialBalance -= costToLeap;

                        Console.WriteLine($"${LeapFunds} has been added to your account. Your balance is ${_initialBalance}. Leap Authorized!");
                        Console.WriteLine($"You have arrived at the {destination.Location}, the year is {destination.Date.Year}.");

                        break;

                    }
                    if (reply == "N")
                    {

                        Console.Clear();
                        Console.WriteLine("GoodLuck on your ventures");
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Please reply with y or n");
                    reply = Console.ReadLine().ToUpper();
                    
                }

            }
        }
      
        public double TotalLeapCost(TimeSpan daysToLeap)
        {
            var cost = daysToLeap.Days;
            LeapingCost = Math.Abs(cost) * 1000;

            return LeapingCost;

        }

    }

}
