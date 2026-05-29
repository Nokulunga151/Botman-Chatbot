using System;
using System.Collections.Generic;
using System.Text;

namespace BotmanChatbot
{
    //this class detects the users mood/sentiment form their message
    internal class Sentiment
    {
        //Method used to detect sentiment
        public string DetectSentiment(string input)
        {
            //converts input to lowercase for easier mathing
            input = input.ToLower();

            //checks for worreid emotions
            if (input.Contains("worried") ||
              input.Contains("scared") ||
              input.Contains("nervous") ||
              input.Contains("anxious") ||
              input.Contains("afraid") ||
              input.Contains("unsafe"))
            {
                return "Worried";
            }

            //Checks for sad emotions
            if (input.Contains("sad") ||
                input.Contains("upset") ||
                input.Contains("depressed") ||
                input.Contains("unhappy"))
            {
                return "Sad";
            }

            //checks for happy emotions
            if (input.Contains("happy") ||
                input.Contains("excited") ||
                input.Contains("great") ||
                input.Contains("awesome"))
            {
                return "Happy";
            }

            //default mood is nothing matches
            return "Neutral";
        }
    }
}
