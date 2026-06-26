using BotmanChatBot;
using Microsoft.VisualBasic;
using System.Drawing.Text;
using System.Media;
using System.Runtime.InteropServices;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BotmanChatbot
{
    //Main GUI class for the chatbot application
    public partial class Form1 : Form
    {
        //Panels used for welcome screen and chat layout

        private Panel chatPanel;


        //controls used on the welcome screen 



        //creates BotMan object
        private BotMan botman;


        //Stores the users name
        private string name = "User";


        //constructor for the form
        public Form1()
        {
            InitializeComponent();

            //initialises the custom chatbot UI
            //InitializeChatUI();
        }



        //this method creates and styles the chatbot interface
        private void InitializeChatUI()
        {
            //form setting
            this.Text = "Botman";
            this.Size = new Size(550, 750);
            this.BackColor = Color.Black;

            sendButton.FlatAppearance.BorderSize = 0; //removes button border
            sendButton.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue; //changes button color when hovering

            sendButton.Click += SendMessage; //send button click event

            inputBox.KeyDown += (s, e) => //allows Enter key to send messages
            {
                if (e.KeyCode == Keys.Enter && !e.Shift)
                {
                    e.SuppressKeyPress = true;
                    SendMessage(s, e);
                }
            };


            //hides chat until welcome screen starts
            messageContainer.Visible = true;
            inputPanel.Visible = true;
            

        }



        
            //ASCII art logo label
            logoLabel.Text = @"
                 
                 ================================================== Welcome =================================================
                 
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







                 ========================================== Your Cybersecurity Mentor =======================================

                 ";





            try //Plays the voice recording when the application starts
            {
                SoundPlayer player = new SoundPlayer("botman.intro_1.wav");
                player.Play();
            }
            catch
            {
            }

            

        //Starts the chatbot after the start button is clicked
       


        //Handles sending messages
        private void SendMessage(object sender, EventArgs e)
        {
            //gets user message
            string userMessage = inputBox.Text.Trim();

            //checks if message is empty
            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            AddMessage(userMessage, false); //displays user message


            inputBox.Clear(); //clears the input box

            //disables controls while bot responds
            sendButton.Enabled = false;
            inputBox.Enabled = false;


            //checks if bot exists
            if (botman == null)
            {
                MessageBox.Show("Botman is null");
                return;
            }


            Task.Run(() =>
            {
                string response = botman.GetResponse(userMessage);

                Thread.Sleep(800);

                this.Invoke(() =>
                {
                    //displays bot respose
                    AddMessage(response, true);

                    //re-enables controls
                    sendButton.Enabled = true;
                    inputBox.Enabled = true;
                    inputBox.Focus();
                });
            });
        }

        //creates and display message bubbles 
        public void AddMessage(string text, bool isBot) //Creates and displays message bubbls in the chat UI
        {
            //Wrapper pane to hold the name, bubble and timestamp
            Panel wrapper = new Panel
            {
                AutoSize = true,
                Width = messageContainer.Width - 30,
                Margin = new Padding(0, 3, 0, 3)

            };



            //Label for the senders name 
            Label nameLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.LightGray,
                Text = isBot ? "BotMan" : name
            };



            wrapper.Controls.Add(nameLabel);

            //set maximum bubbble width dependind on sender
            int maxWidth;

            if (isBot)
            {
                maxWidth = 650;
            }
            else
            {
                maxWidth = 450;
            }



            //Panel representing the message bubble
            Panel bubble = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size(maxWidth, 0),
                Padding = new Padding(10),
                Margin = new Padding(5),

                BackColor = isBot
                   ? Color.Blue
                   : Color.ForestGreen
            };



            //Smooth out bubble edges when painting
            bubble.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            };



            //label for teh actual message text
            Label messageLabel = new Label
            {
                Text = text,
                AutoSize = true,
                MaximumSize = new Size(maxWidth - 20, 0),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Padding = new Padding(5)
            };



            //add messge text to bubble and size the bubble accordingly
            bubble.Controls.Add(messageLabel);
            bubble.Size = new Size(
               messageLabel.Width + 24,
               messageLabel.Height + 24

            );



            //add bubble to wrapper
            wrapper.Controls.Add(bubble);

            //position the name label above the bubble
            nameLabel.Top = 0;

            bubble.Top = nameLabel.Bottom + 3;


            //align bubble and name depending on the sender
            if (!isBot)
            {
                bubble.Left = wrapper.Width - bubble.Width - 20;

                nameLabel.Left = bubble.Left;
            }
            else
            {
                bubble.Left = 5;

                nameLabel.Left = 5;
            }



            //Timestamp label for when the message was sent
            Label timeLabel = new Label
            {
                Text = DateTime.Now.ToString("HH:mm"),
                Font = new Font("Segoe UI", 7),
                ForeColor = Color.Gray,
                AutoSize = true
            };



            timeLabel.Top = bubble.Bottom + 2;
            timeLabel.Left = isBot ? 10 : bubble.Left;
            wrapper.Controls.Add(timeLabel);

            //Add wrapper to the main message container and scroll into view
            messageContainer.Controls.Add(wrapper);
            messageContainer.ScrollControlIntoView(wrapper);

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            SendMessage(sender, e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
