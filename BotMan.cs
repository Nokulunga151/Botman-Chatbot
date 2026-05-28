using BotmanChatbot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BotmanChatBot 
{
    internal class BotMan
    {
        private string name;
        private string BotName;
        private LogicHandler logic;
        private Form1 form;

        public BotMan(string name, Form1 form, string botName = "BotMan")
        {
            this.name = name;
            this.logic = new LogicHandler();
            this.BotName = botName;
            this.form = form;
        }



        public string GetResponse(string input)
        {
            return logic.ProcessInput(input, name, BotName);
        }
    }
}
