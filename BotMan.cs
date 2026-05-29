using BotmanChatbot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BotmanChatBot 
{
    internal class BotMan //this class acts as the connection between GUI and LogicHandler class
    {
        private string name; //Stores the user's name
        private string BotName; //Stores the chatbot's name
        private LogicHandler logic; //Creates an object for the LogicHandler class
        private Form1 form; //Reference to the Form1 GUI

        public BotMan(string name, Form1 form, string botName = "BotMan") //Constructor used to initialize the chatbot
        {
            this.name = name; //Assigns the users name
            this.logic = new LogicHandler(); //Creates a new LogicHandler object
            this.BotName = botName; //Assigns the chatbot name
            this.form = form; //Stores the form reference
        }


        //Gets the chatbot response from the LogicHandler class
        public string GetResponse(string input)
        {
            //Sends the user input to the LogicHandler class
            return logic.ProcessInput(input, name, BotName);
        }
    }
}
