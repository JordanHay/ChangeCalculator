using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AlgorithmsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DenomonationInfo> denomonations = new List<DenomonationInfo>();

            denomonations.Add(new DenomonationInfo { Name = "Quarter", Amount = 0.25M });
            denomonations.Add(new DenomonationInfo { Name = "Dime", Amount = 0.10M });
            denomonations.Add(new DenomonationInfo { Name = "Nickel", Amount = 0.05M });
            denomonations.Add(new DenomonationInfo { Name = "Penny", Amount = 0.01M });
            denomonations.Add(new DenomonationInfo { Name = "One Dollar Bill", Amount = 1M });
            denomonations.Add(new DenomonationInfo { Name = "Five Dollar Bill", Amount = 5M });
            denomonations.Add(new DenomonationInfo { Name = "Ten Dollar Bill", Amount = 10M });

            Console.Write("Please enter the amount owed: ");
            decimal amountOwed = decimal.Parse(Console.ReadLine());

            Console.Write("Please enter the amount paid: ");
            decimal amountPaid = decimal.Parse(Console.ReadLine());

            List<string> results = CalculateChange(amountOwed, amountPaid, denomonations);

            foreach (string result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }

        private static List<string> CalculateChange(decimal amountOwed, decimal amountPaid, List<DenomonationInfo> denomonations)
        {
            List<string> output = new List<string>();
            decimal change = amountPaid - amountOwed;

            if (change < 0)
            {
                output.Add("You need to pay more.");
            }
            else if (change < 0)
            {
                output.Add("No change required.");
            }
            else
            {
                var orderedDenominations = denomonations.OrderByDescending(x => x.Amount);
                int count = 0;

                foreach (var denomination in orderedDenominations)
                {
                    (change, count) = CalculateSpecificChange(change, denomination.Amount);

                    if (count > 0)
                    {
                        output.Add($"{ count } { denomination.Name }");
                    }
                }
            }
            return output;
        }

        private static (decimal remainder, int numberOfItems) CalculateSpecificChange(decimal amount, decimal denomination)
        {
            (decimal remainder, int numberOfItems) output = (0, 0);

            output.numberOfItems = (int)Math.Floor(amount / denomination);
            output.remainder = amount - (output.numberOfItems * denomination);

            return output;
        }

    }

    public class DenomonationInfo
    {
        public decimal Amount { get; set; }
        public string Name { get; set; }
    }

}



