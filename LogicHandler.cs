using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing.Text;
using BotmanChatbot;

namespace BotmanChatBot
{

    //This class processes user input and it will return the responses Botman provides
    internal class LogicHandler
    {

        private MemoryStore memory; //Creates a MemoryStore object used for storing user information
        private Sentiment sentiment; //Creates a Sentiment object used for mood detection

        //Constructor used to initialise objects
        public LogicHandler()
        {
            memory = new MemoryStore(); //Initialises memory system
            sentiment = new Sentiment(); //Intialises sentiment detection system
        }

        //Method that matched user input to specific keywords and returns responses based on thosed keywords
        public string ProcessInput(string input, string name, string botName)
        {

            //Checks for empty input
            if (string.IsNullOrWhiteSpace(input))
            {
                return $"UHM? I didn't quite get that could you please enter something else";
            }

            memory.AddConversation(input); //Stores the user message in conversation history

            //converts input to lowercase for case-sensitive matching
            input = input.ToLower();

            memory.UserName = name; //Stores user name in memory
            string currentMood = sentiment.DetectSentiment(input); // detects user mood
            memory.CurrentMood = currentMood; //Stores the detected mood
            DetectTopics(input); //Detects cybersecurity topics form the input

            //Checks if the user asks what the bot remembers 
            if(input.Contains("What do you remember about me?"))
            {
                return memory.RecallSummary();
            }

            //Checks if the user asks about favourite topics
            if (input.Contains("what topics do i like?"))
            {
                //Checks if no topics have been stored yet
                if (memory.FavouriteTopics.Count == 0)
                {
                    return "I haven't learned enough about your interests yet.";
                }

                //Returns stored cybersecurity topics
                return $"You seem interested in these cyber security topics: " +
                       $"{string.Join("\n ", memory.FavouriteTopics)}";
            }

            //Checks if the user asks about previous topics discussed
            if (input.Contains("what did i ask before?"))
            {
                //Checks if too few topics exist
                if (memory.FavouriteTopics.Count <= 1)
                {
                    return "You haven't asked many questions yet.";
                }

                //Returns all stored cybersecurity topics
                return $"Earlier you asked about topics such as:\n" +
                        string.Join("\n", memory.FavouriteTopics);
            }



            //Sentiment response for worried mood
            if (currentMood == "Worried")
            {
                return $"You seem alitle worried {name}. Cybersecurity can feel overwhelming, but learning about it is the first step toward staying safe online ";
            }

            //Sentiment response for sad mood
            if (currentMood == "Sad")
            {
                return $" It sounds like you are feeling down today {name}. If you would like we can focus on some cybersecurtiy topics together";
            }

            //Sentiment response for happy
            if (currentMood == "Happy")
            {
                return $" I like the enthusiasm {name}! Let's continue learning about cybersecurity";
            }


            //the if statements help with kewyword recognition
            if (input.Contains("phishing"))//Phishing keyword
            {
                return $@"{memory.GetPersonalisedOpener()} GREAT {name}! You're ready to learn about Phishing Attacks. Below are some of the things to
                 know pertaining Phishing.

                 What is Phishing? 
                 Phishing is when attackers pretend to be someone trustworthy (a bank, delivery company, boss, etc.) 
                 to trick you into:
                 -Giving personal info
                 -Clicking malicious links
                 -Downloading harmful files
                 -Sending money
                 -Sharing passwords 

                 Here are some of the common phishing methods used:
                 -Email phishing – fake emails pretending to be legitimate services.
                 -SMS phishing (Smishing) – messages claiming urgent issues.
                 -Voice phishing (Vishing) – scammers calling pretending to be officials.
                 -Social media phishing – fake accounts DM’ing you.Spear phishing – personalised attack targeted 
                  specifically at you.
                 -Clone phishing – attackers replicate a real message but change a link/file.

                 Why phishing happens you may ask?
                 -To steal money-Steal login details
                 -Take over accounts
                 -Spread malware
                 -Access company networks-Identity theft

                 How to protect yourself from phishing attacks?
                 -Don’t click links from unknown or suspicious senders.
                 -Check the sender’s email address closely.
                 -Hover over links to see the real URL.
                 -Never share passwords or OTPs.
                 -Enable 2FA everywhere.
                 -Use spam filters + antivirus.
                 -If something feels urgent or threatening, it’s often fake.
                ";
            }


            else if (input.Contains("password"))//passowrd safety keyword
            {
                return @$" {memory.GetPersonalisedOpener()} Password safety is something everyone should know, I'm glad you aksed about that. let me tell you
                 what it is and give you some insights on why it is important.
                  
                 Password Safety is the practice of creating, managing, protecting passwords to prevent unauthorized access 
                 to accounts, devices and sensitive data

                 Below are some of the practices you should use or avoid when creating passwords:
                 Bad password practices to avoid are:
                 -Using the same password everywhere
                 -Short passwords
                 -Personal info (birth year, name, pet)
                 -“123456”, “password”, “qwerty” etc.

                 Good password practices to use are:
                 -Minimum 8–15 characters
                 -Mix uppercase, lowercase, numbers, symbols (e.g. ILoveKnY_9123)
                 -Avoid dictionary words
                 -Use passphrases (e.g., “PurpleSunsetsJump4Joy!”)
                 -Don’t reuse your passwords
                 
                 Password Managers
                 Tools like 1Password, Bitwarden, Chrome/Google Passwords:
                 -Store all your passwords
                 -Auto-generate strong ones
                 -Autofill safely

                 Here are some reasons why strong passwords matter
                 -Harder to guess
                 -Harder to crack with brute force
                 -Protects you even if one service is breached
                ";

            }


            else if (input.Contains("malware"))//malware keyword
            {
                return @$" {memory.GetPersonalisedOpener()} What is Malware?
                 Malware short for Malicious software is designed to harm or exploit your device.

                 Common Types of Malware
                 -Viruses – replicate themselves
                 -Worms – spread without your interaction
                 -Trojans – look legit but contain malicious code
                 -Ransomware – locks your files until ransom is paid
                 -Spyware – monitors your activity
                 -Adware – bombards you with ads
                 -Keyloggers – steal what you type (passwords!!)
                 -Bots/Botnets – use your device for attacks


                 How Malware Spreads
                 -Infected attachments
                 -Fake apps/software
                 -Malicious websites
                 -USB drives
                 -Torrent downloads
                 -Phishing links

                 Protection
                 -Keep software updated
                 -Don’t download cracked/pirated apps
                 -Scan files before opening
                 -Use antivirus
                 -Avoid unknown USBs
                 -Be careful with public Wi-Fi
                ";

            }


            else if (input.Contains("safe browsing"))//safe browsing keyword
            {
                return @$" {memory.GetPersonalisedOpener()} Great to see that you are interesed about safe browsingon the internet.
                 This could benefit you in the future.Here is some infomation to know 
                 safe browsing.
   
                 Safe browsing is the practice of navigating the internet securely to protect
                 your devices, personal information and online actuvity form cyber threats 
                 like malware, phishing and malicious websites.

                 Here are some of the danger signs you might see on websites that you need to avoid:
                 -No HTTPS
                 -A lot of popups
                 -Fake download buttons
                 -Requests for unnecessary information

                 Safe Browsing Tips
                 -Check for HTTPS + lock icon
                 -Don’t install random browser extensions
                 -Use private browsing if needed
                 -Clear cookies regularly
                 -Don’t save passwords in random sites
                 -Verify URLs before logging in
                 -Look for Typosquatting

                 Hackers create URLs like:
                 -go0gle.com instead of google.com
                 -paypa1.com instead of paypal.com
                 -yotube.com instead of youtube.com

                 !IMPORTANT! These URLs are very convincing, especially if you are not paying attention
                 Double‑check every time. This could happen to anyone.

                ";

            }


            else if (input.Contains("social engineering"))//socila engineering keyword
            {
                return @$" {memory.GetPersonalisedOpener()} What is Social Engineering?
                 Social  engineerng is a form of human hacking that exploits phsycological weaknesses rather than tecnical
                 vulnerabilities to achieve malicious goals.
                 The attackers manipulate politeness, fear, trus and curiosity to trick people into revealing sensitive information,
                 downloading malware or granting 
                 access to restricted systems. Social engineering relies on persuasion and deception rather than brute force or software exploits
 
                 These are some of the examples of social engineering:
                 “Your account will be closed in 24 hours unless you click this link.”
                 “I’m from IT, what’s your password?”
                 “Your child was in an accident, pay this immediately.”
                 Fake giveaways or competitions

                 Social engineering can lead to identity theft, financila fraud, aunothorized access to networks and large scale cyberattacks


                 Prevention of social engineering:
                 -Educate employees and users to recognize suspicious requests and behaviours
                 -Avoid clicking unknown links, downloading verified files r sharing personal information with unverifed sources
                 -Implement strict access controls and monitoring unusual activities.


                 {name}, I'm so proud you're interested in learning about cybersecurity everyone should have knowledge about the different
                 kinds of scams yhey could come across online. 
                 Keep it up!!
                ";

            }


            else if (input.Contains("two-factor authentication") || input.Contains("2fa"))//2fa keyword
            {
                return @$" {memory.GetPersonalisedOpener()} TWO‑FACTOR AUTHENTICATION (2FA)
                 What is 2FA?
                 Two factor authentication(2FA) is a security method that requires users to provide two different forms of identification to verify 
                 their identity. This involves something the user knows, it could be a password ans something a user has, like a mobile device

                 This is how 2FA works:
                 Lets say you attempt to to lof into an account with 2FA enabled, you will first need to enter yor username/email and password. 
                 After that you will be prompted to provide a second form of verification, which could be:
                 -One-time passcode sent to you via email or SMS
                 -Code generated by an authenticator app(microsoft authenticator, google authenticator)
                 -A physical security key that you must insert into your device

                 Benefits of 2FA:
                 -Reduces the risk of unauthorized access, even if your passowrd is compromised
                 -Helps protect against phishing attacks where attackers may steal your password
                 -Users can often choose their preferred method of authentication, making it convenient while still being secure.
 
                ";

            }

            //These are some of the other keywords botman can resond to
            else if (input.Contains("hello") || input.Contains("hi"))
            {
                return $" Hello {name}! How can I assist you today?";
            }

            else if (input.Contains("how are you") || input.Contains("how are you feeling"))
            {
                return $"I am a bot {name}, no emotions here—just a bunch of ones and zeros pretending to be charming haha.";
            }


            else if (input.Contains("what is your purpose") || input.Contains("what do you do"))
            {
                return @$"My puprose is to help you get an understanding of cybersecurity and raise awareness. I provide guidance on how to avoid 
             cyber attacks.";
            }


            else if (input.Contains("what can i ask you about?") ||
                      input.Contains("topics") ||
                      input.Contains("help"))
            {
                return @$"Here are some things I can help you with:
                 ==================================
                        CYBERSECURITY TOPICS
                 ==================================
                 1. Password Safety
                 2. Phishing Scams
                 3. Malware
                 4. Social Engineering
                 5. Safe Browsing
                 6. Two-Factor Authentication

                 ==================================
                         MEMORY FEATURES
                 ==================================
                 7. What do you remember about me?
                 8. What topics do I like?
                 9. What did I ask before?

                 ==================================
                          OTHER COMMANDS
                 ==================================
                 *Hello
                 *How are you?
                 *What is your purpose?
                 

                 How would you like me to help you today {name}?
                ";

            }

            else if (input.Contains("thank you"))
            {
                return $@"You're very welcome {name}. Come back if you need more help:)";

            }


            //if user types something that doesn't contain any cybersecurity topics the bot provides
            return $"I didn't quite get that {name}, could you ask about cybersecurity";
        }

        //This method detects cybersecurity topics from user input
        private void DetectTopics(string input)
        {
            //Checks for phishing topic
            if (input.Contains("phishing"))
            {
                memory.AddTopic("Phishing");
            }

            //Checks for password safety topic
            if (input.Contains("password"))
            {
                memory.AddTopic("Password Safety");
            }

            //Checks for priavcy topic
            if (input.Contains("privacy"))
            {
                memory.AddTopic("Privacy");
            }

            //Checks for malware topic
            if (input.Contains("malware"))
            {
                memory.AddTopic("Malware");
            }

            //Checks for 2fa topic
            if (input.Contains("2fa") ||
                input.Contains("two factor authentication"))
            {
                memory.AddTopic("Two-Factor Authentication");
            }

            //Checks for safe browsing topic
            if (input.Contains("safe browsing"))
            {
                memory.AddTopic("Safe browsing");
            }

            //Checks for social engineering topic
            if (input.Contains("social engineering"))
            {
                memory.AddTopic("Social engineering");
            }
        }



    }
}

