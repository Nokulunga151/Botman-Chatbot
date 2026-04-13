using ChatBot;
using System;
using System.Media;


class Program
{
    static void Main(string[] args)
    {

        //Instance of locgic handler, this will handle Botman's responses
        LogicHandler logic = new LogicHandler();

        if (OperatingSystem.IsWindows())
        {
            SoundPlayer player = new SoundPlayer("botman.intro_1.wav");
            player.Play();

        }


        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow; //Displays the welcome banner with some colour

        Console.WriteLine("===========================================================================================================================================================");
        Console.WriteLine("                                                                        WELOME                                                                             ");
        Console.WriteLine("===========================================================================================================================================================");

        Console.ResetColor();


        //ASCII art
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
                                 
                                  .   .
                                  |\__|\
                                  |     \
                                  | 0__0 \
                                  | |  "" ]
                              ____| ' - \___          IIIIII ,,  M     M
                             /.----._____.-''\          II   ,   MM   MM 
                            //        _       \         II       M M M M
                           //   .-. (~v~)    / |        II       M  M  M  
                          |'|  /\:  .--     /  \        II       M     M  
                         // |-/  \_/_______/\/~ |     IIIIII     M     M  
                        |/  \ |  []_|_|_|_]  \  |     
                        |  \ | \ |___     _\  ]_}    
                        |  | '-' /   ' . '  |             BBBBBBB     OOOOO   TTTTTTTT  M     M    AAAA    N    N
                        |  |    /     /| :  |             B      B   O     O     TT     MM   MM   A    A   NN   N
                        |  |    |    / | :  /\            BBBBBBB    O     O     TT     M M M M  A      A  N  N N
                        |  |    /   /  |   /  \           B      B   O     O     TT     M  M  M  AAAAAAAA  N   NN
                        |  |   |   /  /   |    \          BBBBBBB     OOOOO      TT     M     M  A      A  N    N
                        \  |   |/\/  | /|/\     \                       
                         \ |\|\|  |  |  / /\/\___\
                          \|   |  /  | |__
                               /  |  |____)
                               |__/
  

        ");


        Console.ForegroundColor= ConsoleColor.Yellow;
        Console.WriteLine("==========================================================================================================================================================");
        Console.WriteLine("                                                         Your CyberSecurity Mentor                                                                      ");
        Console.WriteLine("==========================================================================================================================================================");
        Console.ResetColor();


        //This prompts the user for their name
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("BotMan: ");
        Console.ResetColor();
        Console.WriteLine("What is your name?");

        //Takes in the user input
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("You: ");
        Console.ResetColor();
        string name = Console.ReadLine() ?? "User"; //This is for when ther user does not provide botman with their name, botman autmatically calls them user

        //Greets the user 
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"BotMan: Nice to meet you, {name}!");
        Console.WriteLine($@"BotMan: I'm your cybersecurity mentor. Ask me anything on cybersecurity and I will try my best to provide you with informative insights");
        Console.ResetColor();

        
        //Creats the chatbot instance
        BotMan botman = new BotMan(name);

        //this loop will keep the bot running
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{name}: ");
            Console.ResetColor();

            string input = Console.ReadLine() ?? "";

            //Send input to Botman for processing
            botman.Respond(input); // uses the typing dots + typing effect
        }


    }
} 