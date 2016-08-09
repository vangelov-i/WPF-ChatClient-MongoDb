namespace ChatSystem.WPF_Client
{
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;

    using ChatSystem.Data.Contracts;
    using ChatSystem.Model;

    public partial class ChatWindow : Window
    {
        private readonly IChatSystemEngine chatEngine;
        private readonly User recepient;
        private Timer timer;

        public ChatWindow(IChatSystemEngine chatSystemEngine, User recepient)
        {
            this.InitializeComponent();
            this.chatEngine = chatSystemEngine;
            this.recepient = recepient;

            this.InitializeTimer();
            this.LoadListBoxHistory();
        }

        private void InitializeTimer()
        {
            this.timer = new Timer();
            this.timer.Elapsed += this.RefreshMessages;
            this.timer.Interval = (1000 * (1));
            this.timer.Enabled = true;
            this.timer.Start();
        }

        private void RefreshMessages(object sender, ElapsedEventArgs e)
        {
            this.LoadListBoxHistory();
        }

        private void LoadListBoxHistory()
        {
            // TODO: learn how this.Dispatcher.Invoke works and why is needed
            this.Dispatcher.Invoke(
                () =>
                    {
                        this.lbChatHistory.Items.Clear();
                        var messages = this.chatEngine.GetMessagesWith(this.recepient);
                        foreach (var message in messages)
                        {
                            this.lbChatHistory.Items.Add(message.ToString());
                        }
                    });
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            this.chatEngine.SendMessage(this.recepient, this.tbCurrentMessage.Text);
            this.tbCurrentMessage.Text = string.Empty;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}