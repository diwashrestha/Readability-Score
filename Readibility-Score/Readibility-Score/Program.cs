using System;
using System.Text.RegularExpressions;

namespace Readibility_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            Console.WriteLine("Enter Your Sentences: ");
            string userInput = Console.ReadLine();
            if(userInput.Length==0)
            {
                Console.WriteLine("Error!! No input was given. Please enter the text again:");
                goto Start;
            }
            userInput = userInput.TrimStart(' ');
            userInput = Regex.Replace(userInput, @"\s+", " ");
            userInput = Regex.Replace(userInput, @"\.\s+", ".");
            userInput = Regex.Replace(userInput, @"\s+\.", ".");

            Console.WriteLine("{0}", userInput);
            Userinput sentence = new Userinput(userInput);


            sentence.ReadScore();
            sentence.syllablesCount();
            sentence.FkrTest();
            sentence.AriTest();
            sentence.SmogTest();
            sentence.CliTest();
            sentence.AvgTest();

            Console.WriteLine("Check more Sentences: Yes[Y]/No[N]?");
            if(Console.ReadLine() == "Y")
            {
                goto Start;
            }
        }
    }
}
