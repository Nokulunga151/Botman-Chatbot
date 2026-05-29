using System;
using System.Collections.Generic;
using System.Text;

namespace BotmanChatbot
{
    //this class detects the users mood/sentiment form their message
    internal class Sentiment
    {
        public string DetectSentiment(string input)
        {
            input = input.ToLower();

            if (input.Contains("worried") ||
              input.Contains("scared") ||
              input.Contains("nervous") ||
              input.Contains("anxious") ||
              input.Contains("afraid") ||
              input.Contains("unsafe"))
            {
                return "Worried";
            }

            if (input.Contains("sad") ||
                input.Contains("upset") ||
                input.Contains("depressed") ||
                input.Contains("unhappy"))
            {
                return "Sad";
            }

            if (input.Contains("happy") ||
                input.Contains("excited") ||
                input.Contains("great") ||
                input.Contains("awesome"))
            {
                return "Happy";
            }

            return "Neutral";
        }
    }
}
