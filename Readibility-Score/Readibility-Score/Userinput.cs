using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Readibility_Score
{
    public class Userinput
    {
        public string UserInputs { get; }
        private int characterCount = 0;
        private int wordCount = 0;
        private int sentenceCount = 0;
        private int syllableCount = 0;
        private int polysyllableCount = 0;

        // Constructor Declaration
        public Userinput(String userInput )
        {
            UserInputs = userInput;
        }


        // Method for counting the word, character, sentence, syllables, polysyllables
        public void ReadScore()
        {
            char[] charsToTrim = { '.', '!' };

            // Separate each sentence in the given string
            foreach (string userinput in UserInputs.TrimEnd(charsToTrim).Split(charsToTrim))
            {
                wordCount += userinput.Trim().Split(' ').Count();
                sentenceCount++;
            }
            foreach(string word in UserInputs.Split(' '))
            {
                characterCount += word.Length;
            }

            Console.WriteLine( $"Words: {wordCount}\n Sentences: {sentenceCount} \n Characters: {characterCount} \n ");
        }

        public void syllablesCount()
        {
            char[] charsToTrim = { '.', '!', '?' };
            char[] vowelLetter = { 'a', 'e', 'i', 'o', 'u', 'y' };
            bool prevVowel;
            bool isPolysyllable = false;
            int localSyllableCount = 0;
            foreach (string userinput in UserInputs.TrimEnd(charsToTrim).Split(charsToTrim))
            {
                foreach (string word in userinput.Split(' '))
                {
                    prevVowel = false;
                    isPolysyllable = false;
                    localSyllableCount = 0;
                    int i = 0;
                    int wordLength = word.Length;
                    foreach (char character in word.ToLower())
                    {
                        bool isLastLetter = i == (wordLength - 1);
                        //Rule3: if last letter in word is 'e' do not count as a vowel.
                        if (isLastLetter == true && character.Equals('e'))
                        {

                        }
                        else if (Array.Exists(vowelLetter, element => element == character))
                        {

                            // Rule 1: Count the Number of vowel
                            if (prevVowel == false)
                            {
                                localSyllableCount++;
                                prevVowel = true;
                            }
                            // Rule 2: Do Not count double vowels
                            else if(prevVowel == true)
                            {
                                prevVowel = true;
                            }
                        }
                        else
                        {
                            prevVowel = false;
                        }

                        if(localSyllableCount>2 && isPolysyllable == false)
                        {
                            polysyllableCount++;
                            isPolysyllable = true;
                        }

                        Console.WriteLine("syllable:{0}\n polysyllable:{1}", localSyllableCount,polysyllableCount);
                        i++;
                    }

                    // Rule 4:
                    // if a word contains 0 vowel then syllable is 1
                    if(localSyllableCount == 0)
                    {
                        localSyllableCount = 1;
                    }
                    syllableCount += localSyllableCount;
                }
            }
            Console.WriteLine($"Syllables: {syllableCount}");

        }


        public void RegexSyllablesCount()
        {
            char[] charsToTrim = { '.', '!', '?' };
            char[] vowelLetter = { 'a', 'e', 'i', 'o', 'u', 'y' };
            bool prevVowel;
            bool isPolysyllable = false;
            int localSyllableCount = 0;
            foreach (string userinput in UserInputs.TrimEnd(charsToTrim).Split(charsToTrim))
            {
                string syllabPattern = @"(?i)[aiou][aeiou]*|e[aeiou]*(?!d?\\b)";
                Regex regexPattern = new Regex(syllabPattern);

                foreach (string word in userinput.Split(' '))
                {
                    if (regexPattern.IsMatch(word))
                    {
                        localSyllableCount++;
                    }
                    Console.WriteLine("syllable:{0}\n polysyllable:{1}", localSyllableCount, polysyllableCount);
                }
                if(localSyllableCount>2)
                {
                    polysyllableCount++;
                }
            } 
        }


        // Method for Automated Readability Index
        public void AriTest()
        {
            double score = 0;
            string ageGroup = "";
            score = ((4.71 * (characterCount / wordCount)) + (0.5 * (wordCount / sentenceCount) - 21.43));

            if (score < 2)
            {
                ageGroup = "5-6";
            }
            else if (score < 3)
            {
                ageGroup = "6-7";
            }
            else if (score < 4)
            {
                ageGroup = "7-9";
            }
            else if (score < 5)
            {
                ageGroup = "9-10";
            }
            else if (score < 6)
            {
                ageGroup = "10-11";
            }
            else if (score < 7)
            {
                ageGroup = "11-12";
            }
            else if (score < 8)
            {
                ageGroup = "12-13";
            }
            else if (score < 9)
            {
                ageGroup = "13-14";
            }
            else if (score < 10)
            {
                ageGroup = "15-16";
            }
            else if (score < 11)
            {
                ageGroup = "17-18";
            }
            else if (score < 12)
            {
                ageGroup = "18-24";
            }
            else if (score < 13)
            {
                ageGroup = "24+";
            }

            Console.WriteLine($"The score is: {score:N2} \n This text should be understood by {ageGroup} year olds.");
        }

        // Flesch–Kincaid readability tests
        public void FkrTest()
        {

        }
    }
}
