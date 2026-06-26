using System;
using System.Collections.Generic;
using System.Text;

namespace BotmanChatbot
{
    internal class QuizManager
    {
        private List<QuizQuestion> questions;
        private int currentQuestion;
        private int score;

        public QuizManager()
        {
            questions = new List<QuizQuestion>();

            LoadQuestions();

            ResetQuiz();

        }

        private void LoadQuestions()
        {
            questions.Add(new QuizQuestion
            {
                Question = "What is Phishing?",
                Options = new string[]
                {
                    "A fake login scam used to steal personal information",
                    "A type of an antivirus",
                    "A type of computer hardware",
                    "A VPN"
                },

                CorrectAnswer = 0,
                Explanation = "Phishing tricks users into revealing information"
            });

           


            questions.Add(new QuizQuestion
            {
                Question = "Which of the following is the strongest password?",
                Options = new string[]
                {
                   "password123",
                   "12345678",
                   "P@ssw0rd!2026",
                   "qwerty"
                },

                CorrectAnswer = 2 ,
                Explanation = "Strong passwords include uppercase and lowercase letter, numbers and special characters"

            });


            questions.Add(new QuizQuestion
            {
                Question = "Is it safe to click links in emails from unknown senders",
                Options = new string[]
                {
                    "True",
                    "False"
                },

                CorrectAnswer = 1,
                Explanation = "Unknown links may lead to phishing websies or install malware, if you don't know the sender dont click the link"

            });


            questions.Add(new QuizQuestion
            {
                Question = "Two-factor Authentication provides an extra layer of security",
                Options = new string[]
                {
                   "True",
                   "False"
                },

                CorrectAnswer = 0 ,
                Explanation = "2FA requires a second verifcation step, making accounts much harder to compromise"

            });


            questions.Add(new QuizQuestion
            {
                Question = "Which of these is a type of malware",
                Options = new string[]
                {
                    "Microsoft Word",
                    "Trojan Horse",
                    "Google Chrome",
                    "Microsoft Excel"
                },

                CorrectAnswer = 1 ,
                Explanation = "A Trojan Horse is malicious software that disguises itsself as legitimate software"

            });

            questions.Add(new QuizQuestion
            {
                Question = "Keeping your software updated helps protect your computer from security threats",
                Options = new string[]
                {
                    "True",
                    "False"

                },

                CorrectAnswer = 0 ,
                Explanation = "Software updates often include imprtant security patched that fix vulnerabilities"

            });


            questions.Add(new QuizQuestion
            {
                Question = "What should you do if you recieve a suspicious email asking for your password?",
                Options = new string[]
                {
                    "Reply with your passowrd",
                    "Ignore it or report it as phishing",
                    "Forward it to friends",
                    "Click every link to investigate"

                },

                CorrectAnswer =1 ,
                Explanation = "Never share your email through email. Suspicious emails should be reported or deleted "

            });

            questions.Add(new QuizQuestion
            {
                Question = "Using public wifi without a VPN is always safe",
                Options = new string[]
                {
                    "True",
                    "False"

                },

                CorrectAnswer = 1,
                Explanation = "Public wifi is often unsecure, meaning attackers can intercept your traffic. A VPN encrypts your connection, protecting sensitive data"

            });

            questions.Add(new QuizQuestion
            {
                Question = "What does the padlock icon in a browser indicate?",
                Options = new string[]
                {
                    "The site is free to use",
                    "The site is encypted with HTTPS",
                    "The site has no ads",
                    "The site is gvernment approved"
                },

                CorrectAnswer = 1,
                Explanation = "The padlock shows taht the site uses HTTPS, which encrypts communication between your browser and the server"

            });

            questions.Add(new QuizQuestion
            {
                Question = "Which of the following is an example of social engineering?",
                Options = new string[]
                {
                    "A hacker exploiting a software bug",
                    "A fake IT support call asking for your password",
                    "A firewall blocking suspicious traffic",
                    "An antivirus detecting malware"

                },

                CorrectAnswer = 1,
                Explanation = "Socail engineering manipulate people, not systems. Pretending to be IT support is a classic example"

            });

            questions.Add(new QuizQuestion
            {
                Question = "What is ransomeware designed to do?",
                Options = new string[]
                {
                    "Encrypt files and demand payment",
                    "Speed up your computer",
                    "Protect against viruses",
                    "Block pop-ups"

                },

                CorrectAnswer = 0,
                Explanation = "Ransomware locks your files with encryption and demands moeny for the decryption key"

            });
        }

        public void ResetQuiz()
        {
            currentQuestion = 0;
            score = 0;
        }


        public QuizQuestion GetCurrentQuestion()
        {
            return questions[currentQuestion];
        }


        public bool CheckAnswer(int answer)
        {
            if (currentQuestion >= questions.Count)
                return false;

            QuizQuestion q = questions[currentQuestion];

            bool correct =
                answer == questions[currentQuestion].CorrectAnswer;


            string feedback = correct
                ? " Correct! " + q.Explanation
                : "Incorrect. " + q.Explanation;

            if (correct)  score++;
            
            return correct; 
        }

        public string GetExplanation()
        {
            if (currentQuestion < questions.Count)
                return questions[currentQuestion].Explanation;
            return "";
        }


        public void NextQuestion()
        {
            currentQuestion++;
        }


        public bool QuizFinished()
        {
            return currentQuestion >= questions.Count;
        }

        public int TotalQuestions
        {
            get { return questions.Count; }
        }


        public int GetScore()
        {
            return score;
        }

    }
}
