using System;
using System.Collections.Generic;
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
            if(UserInputs.Length > 100)
            {
                message = "Hard";
            }
            else
            {
                message = "easy";
            }
            return (message);

        }
    }
}
