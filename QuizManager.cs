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
                Question = "",
                Options = new string[]
                {

                },

                CorrectAnswer = ,
                Explanation = ""

            });

            questions.Add(new QuizQuestion
            {
                Question = "",
                Options = new string[]
                {

                },

                CorrectAnswer = ,
                Explanation = ""

            });

            questions.Add(new QuizQuestion
            {
                Question = "",
                Options = new string[]
                {

                },

                CorrectAnswer = ,
                Explanation = ""

            });

            questions.Add(new QuizQuestion
            {
                Question = "",
                Options = new string[]
                {

                },

                CorrectAnswer = ,
                Explanation = ""

            });
        }

        public QuizQuestion GetCurrentQuestion()
        {
            return questions[currentQuestion];
        }


        public bool CheckAnswer(int answer)
        {
            bool correct =
                answer == questions[currentQuestion].CorrectAnswer;

            if(correct) 
            {
                score++;
            }
            return correct;
        }


        public void NextQuestion()
        {
            currentQuestion++;
        }


        public bool QuizFinished()
        {
            return currentQuestion >= questions.Count;
        }


        public int GetScore()
        {
            return score;
        }

    }
}
