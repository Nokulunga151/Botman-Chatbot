namespace BotmanChatbot
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            messageContainer = new FlowLayoutPanel();
            inputPanel = new Panel();
            sendButton = new Button();
            inputBox = new RichTextBox();
            HeaderPanel = new Panel();
            LogoLabel = new Label();
            messageContainer.SuspendLayout();
            inputPanel.SuspendLayout();
            HeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // messageContainer
            // 
            messageContainer.AutoScroll = true;
            messageContainer.BackColor = Color.Beige;
            messageContainer.Controls.Add(HeaderPanel);
            messageContainer.Dock = DockStyle.Fill;
            messageContainer.FlowDirection = FlowDirection.TopDown;
            messageContainer.Location = new Point(0, 0);
            messageContainer.Name = "messageContainer";
            messageContainer.Size = new Size(1182, 853);
            messageContainer.TabIndex = 0;
            messageContainer.WrapContents = false;
            messageContainer.Paint += flowLayoutPanel1_Paint;
            // 
            // inputPanel
            // 
            inputPanel.BackColor = Color.Beige;
            inputPanel.Controls.Add(sendButton);
            inputPanel.Controls.Add(inputBox);
            inputPanel.Dock = DockStyle.Bottom;
            inputPanel.Location = new Point(0, 788);
            inputPanel.Name = "inputPanel";
            inputPanel.Size = new Size(1182, 65);
            inputPanel.TabIndex = 1;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(600, 7);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(94, 46);
            sendButton.TabIndex = 3;
            sendButton.Text = "➤";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // inputBox
            // 
            inputBox.BackColor = Color.White;
            inputBox.BorderStyle = BorderStyle.None;
            inputBox.ForeColor = Color.Black;
            inputBox.Location = new Point(124, 7);
            inputBox.Name = "inputBox";
            inputBox.Size = new Size(441, 46);
            inputBox.TabIndex = 2;
            inputBox.Text = "";
            // 
            // HeaderPanel
            // 
            HeaderPanel.Controls.Add(LogoLabel);
            HeaderPanel.Location = new Point(3, 3);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(1192, 540);
            HeaderPanel.TabIndex = 0;
            // 
            // LogoLabel
            // 
            LogoLabel.AutoSize = true;
            LogoLabel.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LogoLabel.ForeColor = Color.FromArgb(0, 192, 0);
            LogoLabel.Location = new Point(121, 28);
            LogoLabel.Name = "LogoLabel";
            LogoLabel.Size = new Size(936, 450);
            LogoLabel.TabIndex = 0;
            LogoLabel.Text = resources.GetString("LogoLabel.Text");
            LogoLabel.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 853);
            Controls.Add(inputPanel);
            Controls.Add(messageContainer);
            Name = "Form1";
            Text = "Botman Chatbot";
            messageContainer.ResumeLayout(false);
            inputPanel.ResumeLayout(false);
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel messageContainer;
        private Panel inputPanel;
        private RichTextBox inputBox;
        private Button sendButton;
        private Panel HeaderPanel;
        private Label LogoLabel;
    }
}
