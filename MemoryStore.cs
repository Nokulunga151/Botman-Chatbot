using System;
using System.Collections.Generic;
using System.Text;

namespace BotmanChatbot
{
    internal class MemoryStore
    {
        public string UserName
        {
            get; set;
        }

        public List<string> FavouriteTopics
        {
            get; set;
        }

        public string CurrentMood
        {
            get; set;
        }

        public List<string> ConversationHistory
        { 
            get; set; 
        }

        public MemoryStore()
        {
            FavouriteTopics = new List<string>();
            ConversationHistory = new List<string>();
            CurrentMood = "Neutral";
        }

        public void AddTopic(string topic)
        {
            if (!FavouriteTopics.Contains(topic)) 
            {  
                FavouriteTopics.Add(topic); 
            }
        }

        public void AddConversation(string message)
        {
            ConversationHistory.Add(message);
        }



        public string GetPersonalisedOpener()
        {
            if (FavouriteTopics.Count == 0) 
            { 

                return "";
            }

            string latestTopic = FavouriteTopics[FavouriteTopics.Count - 1];

            return $"Since you're interested in {latestTopic}...\n";

            
        }

        public string RecallSummary()
        {
            string topics = FavouriteTopics.Count > 0
                            ? string.Join(",", FavouriteTopics)
                            : "No cybersecurity interests detected yet";

            return $@"
                     Here's what i remember about you: 

                     Your name: {UserName}
                     Mood: {CurrentMood}
                     Cybersecurity Interests: {topics}";
        }
    }
}