namespace ChatSystem.WPF_Client
{
    using System;
    using System.Windows;

    using ChatSystem.Data;
    using ChatSystem.Data.Contracts;
    using ChatSystem.Model;
    
    public partial class MainWindow : Window
    {
        private readonly IChatSystemEngine chatEngine;

        public MainWindow()
        {
            this.InitializeComponent();
            this.chatEngine = new ChatSystemEngine();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = this.tbPasswordBox.Password;
                this.chatEngine.LogIn(this.tbUsername.Text, password);

                MessageBox.Show("Login successfull.");

                var chooseUserWindow = new ChooseUserToChatWindow(this.chatEngine);
                this.Close();
                chooseUserWindow.Show();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = this.tbUsername.Text;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username must be at least 1 character long.");
                return;
            }

            try
            {
                string password = this.tbPasswordBox.Password;
                this.chatEngine.RegisterUser(username, password);
                MessageBox.Show("Registration successfull. You may now log in.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}