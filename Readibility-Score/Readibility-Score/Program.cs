﻿using System;

namespace Readibility_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            Console.WriteLine("Enter Your Sentences: ");
            string userInput = Console.ReadLine();
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
