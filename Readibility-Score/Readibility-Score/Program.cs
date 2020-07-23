using System;

namespace Readibility_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Sentences: ");
            string userInput = Console.ReadLine();
            Userinput sentence = new Userinput(userInput);
            Console.WriteLine(sentence.ReadScore());
        }
    }
}
