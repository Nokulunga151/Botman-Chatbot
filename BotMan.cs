using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatBot
{
    internal class BotMan
    {
        // Fields to store user name, bot name, and logic handler
        private string name;
        private string BotName;
        private LogicHandler logic;

        public BotMan(string name, string botName = "BotMan")
        {
            this.name = name;
            this.logic = new LogicHandler();
            this.BotName = botName;
        }


        private void TypeLikeBotman(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;

           

           foreach (char c in text)
           {
              Console.Write(c);
              Thread.Sleep(5);
           }

           Console.ResetColor();
           Console.WriteLine();
            
        }

        private void ShowTypingDots()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{BotName} is typing");

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(450);
                Console.Write(".");
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        public void Respond(string input)
        {
            string response = logic.ProcessInput(input, name, BotName);

            ShowTypingDots();

            TypeLikeBotman(response);
        }
    }
}
