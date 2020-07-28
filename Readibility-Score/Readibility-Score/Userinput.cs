using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Readibility_Score
{
    public class Userinput
    {
        public string UserInputs { get; }

        // Constructor Declaration
        public Userinput(String userInput )
        {
            UserInputs = userInput;
        }

        public String ReadScore()
        {
            string message;
            int wordcount = 0;
            int sentencecount = 0;
            char[] charsToTrim = { '.', '!' };

            // Counting Words in Each Sentences
            foreach (string userinput in UserInputs.TrimEnd(charsToTrim).Split(charsToTrim))
            {
                wordcount += userinput.Trim().Split(' ').Count();
                sentencecount++;
                Console.WriteLine("WordCount:{0}\n Sentence Count:{1}", wordcount, sentencecount);
            }

            if (wordcount / sentencecount > 10)
            {
                message = "The Text is Hard.";
            }
            else
                message = "The Text is Easy.";

            return message;
        }
    }
}
