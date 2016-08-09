namespace ChatSystem.WPF_Client
{
    using System.Windows;

    using ChatSystem.Data;
    using ChatSystem.Data.Contracts;

    public partial class ChooseUserToChatWindow : Window
    {
        private readonly IChatSystemEngine chatEngine;

        public ChooseUserToChatWindow(IChatSystemEngine chatSystemEngine)
        {
            this.InitializeComponent();
            this.chatEngine = chatSystemEngine;

            this.InitializeListBoxAvailableUsers();
        }

        private void btnStartChat_Click(object sender, RoutedEventArgs e)
        {
            var recepient = this.chatEngine.GetUser(this.tbUserToChatWith.Text);
            if (recepient == null)
            {
                MessageBox.Show("Invalid recepient username.");
                return;
            }

            var chatWindow = new ChatWindow(this.chatEngine, recepient);
            this.Close();
            chatWindow.Show();
        }

        private void InitializeListBoxAvailableUsers()
        {
            var usernames = this.chatEngine.Usernames;
            foreach (var username in usernames)
            {
                this.listBoxUsers.Items.Add(username);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}