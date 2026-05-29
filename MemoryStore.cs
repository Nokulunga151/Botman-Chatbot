using System;
using System.Collections.Generic;
using System.Text;

namespace BotmanChatbot
{
    //This class stores information that botman remembers about the user
    internal class MemoryStore
    {
        public string UserName //Stores the users name
        {
            get; set;
        }

        public List<string> FavouriteTopics //Stores the cybersecurtiy topics that the user has shown interest in
        {
            get; set;
        }

        public string CurrentMood //Stores the users detected mood/sentiment
        {
            get; set;
        }

        public List<string> ConversationHistory //Stores all previous user messages
        { 
            get; set; 
        }


        //Constructor used to initialize lists and default values
        public MemoryStore()
        {
            FavouriteTopics = new List<string>();
            ConversationHistory = new List<string>();
            CurrentMood = "Neutral"; //Default mood
        }

        public void AddTopic(string topic) //Adds a cybersecurity topic if it doesn't already exist
        {
            if (!FavouriteTopics.Contains(topic)) 
            {  
                FavouriteTopics.Add(topic); 
            }
        }

        public void AddConversation(string message) //Stores user messages into conversation history
        {
            ConversationHistory.Add(message);
        }



        public string GetPersonalisedOpener() //Creates personalised opening based on the latest topic
        {
            //Checks if not topics exist yet
            if (FavouriteTopics.Count == 0) 
            { 

                return "";
            }

            //Gets the latest detected topic
            string latestTopic = FavouriteTopics[FavouriteTopics.Count - 1];

            //returns a personalised sentence
            return $"Since you're interested in {latestTopic}...\n";

            
        }

        //Returns a summary of what he chatbot remembers about the user
        public string RecallSummary()
        { 
            //Checks if topics exist
            string topics = FavouriteTopics.Count > 0
                            ? string.Join(",", FavouriteTopics)
                            : "No cybersecurity interests detected yet";

            //returns stored information
            return $@"
                     Here's what i remember about you: 

                     Your name: {UserName}
                     Mood: {CurrentMood}
                     Cybersecurity Interests: {topics}";
        }
    }
}