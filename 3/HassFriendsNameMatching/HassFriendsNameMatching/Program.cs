using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HassFriendsNameMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter");

            var nameMatcher = new NameMatcher();

            string input;

            while ((input = Console.ReadLine()) != "quit")
            {
                nameMatcher.SetGenderMatchCount(input);

                nameMatcher.SetGenderMatchCount(Console.ReadLine());

                Console.WriteLine(nameMatcher.CalculateChanceOfSuccess(input));
            }
        }
    }
}
