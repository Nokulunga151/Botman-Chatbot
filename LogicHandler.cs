using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot
{

    //This class processes user input and it will return the responses Botman provides
    internal class LogicHandler
    {

        //Method that matched user input to specific keywords and returns responses based on thosed keywords
        public string ProcessInput(string input, string name, string botName)
        {

            //Checks for empty input
            if (string.IsNullOrWhiteSpace(input))
            {
                return $"{botName}: UHM? I didn't quite get that could you please enter something else";
            }

            //converts input to lowercase for case-sensitive matching
            input = input.ToLower();


            //the if statements help with kewyword recognition
            if (input.Contains("phishing"))//Phishing keyword
            {
                return $@"{botName}: GREAT {name}! You're ready to learn about Phishing Attacks. Below are some of the things to
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
                return @$"{botName}: Password safety is something everyone should know, I'm glad you aksed about that. let me tell you
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
                return @$"{botName}: What is Malware?
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
                return @$"{botName}: Great to see that you are interesed about safe browsingon the internet.
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
                return @$"{botName}: What is Social Engineering?
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
                return @$"{botName}: TWO‑FACTOR AUTHENTICATION (2FA)
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
                return $"{botName}: Hello {name}! How can I assist you today?";
            }

            else if (input.Contains("how are you") || input.Contains("how are you feeling"))
            {
                return $"{botName}: I am a bot {name}, no emotions here—just a bunch of ones and zeros pretending to be charming haha.";
            }


            else if (input.Contains("what is your purpose") || input.Contains("what do you do"))
            {
                return @$"{botName}: My puprose is to help you get an understanding of cybersecurity and raise awareness. I provide guidance on how to avoid 
             cyber attacks.";
            }


            else if (input.Contains("what can i ask you about?") ||
                      input.Contains("topics") ||
                      input.Contains("help"))
            {
                return @$"{botName}:Here are some topics I can educate you on:
                 1. Password Safety
                 2. Phishing Scams
                 3. Malware
                 4. Social Engineering
                 5. Safe Browsing
                 6. Two-Factor Authentication

                 Which one would you like to learn about {name}?
                ";

            }

            else if (input.Contains("thank you"))
            {
                return $@"{botName}: You're very welcome {name}. Come back if you need more help:)";

            }
               
            
            //if user types something that doesn't contain any cybersecurity topics the bot provides
            return $"{botName}: I didn't quite get that {name}, could you ask about cybersecurity";
                

            
        }
    }
}
