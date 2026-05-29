using BotmanChatBot;
using Microsoft.VisualBasic;
using System.Drawing.Text;
using System.Media;
using System.Runtime.InteropServices;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BotmanChatbot
{
    //Main GUI class for teh chatbot application
    public partial class Form1 : Form  
    {
        //Panels used for welcome screen and chat layout
        private Panel welcomePanel;
        private Panel chatPanel;

        //controls used on the welcome screen
        private Label logoLabel;
        private Label welcomeLabel;
        private Button startButton;

        //controls used for chat functionality
        private Panel inputPanel;
        private RichTextBox inputBox;
        private Button sendButton;
        private FlowLayoutPanel messageContainer;

        //creates BotMan object
        private BotMan botman;

        //Stores the users name
        private string name = "User";

        //constructor for the form
        public Form1()
        {
            InitializeComponent();

            //initialises the custom chatbot UI
            InitializeChatUI();
        }

        //this method creates and styles the chatbot interface
        private void InitializeChatUI()
        {
            //form setting
            this.Text = "Botman";
            this.Size = new Size(550, 750);
            this.BackColor = Color.Black;

            //container used to display chat messages
            messageContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10),
                BackColor = Color.Black

            };

            //panel containing the input box and send button
            inputPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            //Textbox where the user types messages
            inputBox = new RichTextBox
            {
                Location = new Point(20, 15),
                Size = new Size(370, 50),
                Font = new Font("Segoe UI", 11),
                BackColor = Color.DarkGray,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                Multiline = true,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            //send button
            sendButton = new Button
            {
                Text = "\u2794",
                Location = new Point(410, 15),
                Size = new Size(70, 50),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

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

            //adds contolds to input panel
            inputPanel.Controls.Add(inputBox);
            inputPanel.Controls.Add(sendButton);

            //adds controls to form
            this.Controls.Add(messageContainer);
            this.Controls.Add(inputPanel);

            //hides chat until welcome screen starts
            messageContainer.Visible = false;
            inputPanel.Visible = false;

            //creates the welcome screen
            CreateWelcomeScreen();
            
        } 
        
        private void CreateWelcomeScreen() //creates the welcome screen shown when the application starts
        {
            //welcome panel settings
            welcomePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black
            };

            //ASCII art logo label
            logoLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Consolas", 12, FontStyle.Bold),
                ForeColor = Color.Yellow,
                Location = new Point(250, 50),

                Text = @"
                 
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

                  "

            };

            //start button
            startButton = new Button  
            {
                Text = "START",
                Size = new Size(180, 60),
                Location = new Point(1300, 700),

                BackColor = Color.LightGreen, 
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            //start button event
            startButton.FlatAppearance.BorderSize = 0;

            startButton.Click += StartButton_Click;

            welcomeLabel = new Label{
                Text = "",
                AutoSize = true,
                ForeColor = Color.Yellow,
                Font = new Font("Consolas", 12, FontStyle.Bold),
                Location = new Point(850, 900)
            };

            //adds controls too welcome panel
            welcomePanel.Controls.Add(logoLabel);
            welcomePanel.Controls.Add(welcomeLabel);
            welcomePanel.Controls.Add(startButton);

            startButton.BringToFront();

            //adds welcome panel to form
            this.Controls.Add(welcomePanel);

            try //Plays the voice recording when the application starts
            {
                SoundPlayer player = new SoundPlayer("botman.intro_1.wav");
                player.Play();
            }
            catch 
            { 
            }
           
        }

        //Starts the chatbot after the start button is clicked
        private void StartButton_Click(object sender, EventArgs e)
        {
            //Hides welcome screen
            welcomePanel.Visible = false;

            //Shows chat interface
            messageContainer.Visible = true;
            inputPanel.Visible = true;

            //asks user for their name
            name = Interaction.InputBox("What is your name?", "Botman");

            //default name if nothing is entered
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "User";
            }

            //created botman object
            botman = new BotMan(name, this);

            //Displays weclome message to user
            AddMessage($"Welcome {name}! I'm Botman. Type 'help' to see everything i can do for you.", true);
        }


        //Handles sending messages
        private void SendMessage(object sender, EventArgs e)
        {
            //gets user message
           string userMessage = inputBox.Text.Trim();

            //checks if message is empty
            if (string.IsNullOrWhiteSpace(userMessage))
              return;

            AddMessage(userMessage,false); //displays user message


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
        public void AddMessage(string text, bool isBot)
        {
            Panel wrapper = new Panel
            {
                AutoSize = true,
                Width = messageContainer.Width - 30,
                Margin = new Padding(0, 3, 0, 3)

            };

            Label nameLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.LightGray,
                Text = isBot ? "BotMan" : name
            };

            wrapper.Controls.Add(nameLabel);

            int maxWidth;

            if (isBot)
            {
                maxWidth = 650;
            }
            else
            {
                maxWidth = 450;
            }

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

           bubble.Paint += (s, e) =>
           {
               e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
           };


           Label messageLabel = new Label
           {
              Text = text,
              AutoSize = true,
              MaximumSize = new Size(maxWidth - 20, 0),
              Font = new Font("Segoe UI", 10),
              ForeColor = Color.White,
              BackColor = Color.Transparent,
              Padding = new Padding(5)
           };


            bubble.Controls.Add(messageLabel);
            bubble.Size = new Size(
               messageLabel.Width + 24,
               messageLabel.Height + 24

            );



            wrapper.Controls.Add(bubble);

            nameLabel.Top = 0;

            bubble.Top = nameLabel.Bottom + 3;

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


            Label timeLabel = new Label
            { 
               Text = DateTime.Now.ToString("HH:mm"),
               Font = new Font("Segeo UI", 7),
               ForeColor = Color.Gray,
               AutoSize = true
            };

            timeLabel.Top = bubble.Bottom + 2;
            timeLabel.Left = isBot ? 10 : bubble.Left;
            wrapper.Controls.Add(timeLabel);


            messageContainer.Controls.Add(wrapper);
            messageContainer.ScrollControlIntoView(wrapper);
        }

    }
}
