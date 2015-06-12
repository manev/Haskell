using System;
using System.Linq;

namespace HassRandomLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Define a language pattern.");

            string word = Console.ReadLine();

            var languageValidator = new LanguageValidator(word);
            while (!languageValidator.IsLanguageValid())
            {
                Console.WriteLine("Define a valid language pattern.");
                word = Console.ReadLine();
            }
            Console.WriteLine("Enter a word. Enter quit to exit.");

            while ((word = Console.ReadLine()) != "quit")
            {
                if (languageValidator.IsWordValid(word))
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }
    }
}
