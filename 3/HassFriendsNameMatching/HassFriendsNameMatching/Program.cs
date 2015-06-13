using System;

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

                Console.WriteLine("Enter names");

                input = Console.ReadLine();

                Console.WriteLine(nameMatcher.CalculateChanceOfSuccess(input));
            }
        }
    }
}
