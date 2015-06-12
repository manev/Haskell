using System;
using System.Linq;

namespace HelpHassMeetFriend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter ['Start' 'End' (A B)] station. Enter quit to exit or result to check the final solution");

            var routeFinder = new RouteFinder();

            string line;
            while ((line = Console.ReadLine()) != "quit")
            {
                if (line.Trim().Equals("result", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine(string.Join("", routeFinder.GetRoutes()));
                    Console.ReadKey();
                    return;
                }
                else
                {
                    if (!routeFinder.TrySetStationsFromLine(line))
                    {
                        Console.WriteLine("Invalid stations! Enter ['Start' 'End' (A B)] station.");
                    }
                }
            }
        }
    }
}
