namespace ChatSystem.WPF_Client
{
    using System.CodeDom;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;

    using ChatSystem.Data.Contracts;
    using ChatSystem.Model;

    public partial class ChatWindow : Window
    {
        private const int DefaultUpdateInterval = 1000 * 1;

        private readonly IChatSystemEngine chatEngine;
        private readonly User recepient;
        private Timer timer;

        public ChatWindow(IChatSystemEngine chatSystemEngine, User recepient)
        {
            this.InitializeComponent();
            this.Title = recepient.Username;
            this.chatEngine = chatSystemEngine;
            this.recepient = recepient;

            this.InitializeTimer();
            this.UpdateListBoxHistory();
        }

        private void InitializeTimer()
        {
            this.timer = new Timer();
            this.timer.Elapsed += this.RefreshMessages;
            this.timer.Interval = DefaultUpdateInterval;
            this.timer.Enabled = true;
            this.timer.Start();
        }

        private void RefreshMessages(object sender, ElapsedEventArgs e)
        {
            // TODO: learn how this.Dispatcher.Invoke works and why is needed
            this.Dispatcher.Invoke(this.UpdateListBoxHistory);
        }

        private void UpdateListBoxHistory()
        {
            int messagesCountToSkip = this.lbChatHistory.Items.Count;
            var messages = this.chatEngine.GetMessagesWith(this.recepient, messagesCountToSkip);
            foreach (var message in messages)
            {
                this.lbChatHistory.Items.Add(message.ToString());
            }

            this.ScrollListBoxToBottom();
        }

        private void ScrollListBoxToBottom()
        {
            int lastItemIndex = this.lbChatHistory.Items.Count - 1;
            var lastItem = this.lbChatHistory.Items[lastItemIndex];
            this.lbChatHistory.ScrollIntoView(lastItem);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            this.chatEngine.SendMessage(this.recepient, this.tbCurrentMessage.Text);
            this.tbCurrentMessage.Text = string.Empty;
        }
    }
}