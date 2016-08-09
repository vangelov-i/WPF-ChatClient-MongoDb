namespace ChatSystem.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using ChatSystem.Data.Contracts;
    using ChatSystem.Model;

    public class ChatSystemEngine : IChatSystemEngine
    {
        private readonly IChatSystemData chatData;
        private User hostUser;

        public ChatSystemEngine()
            : this(new ChatSystemData())
        {
        }

        public ChatSystemEngine(IChatSystemData chatSystemData)
        {
            this.chatData = chatSystemData;
        }

        public IEnumerable<string> Usernames
        {
            get
            {
                return this.chatData.Users
                    .Search(u => u.Username != this.hostUser.Username)
                    .Select(u => u.Username);
            }
        } 

        public void LogIn(string username, string password)
        {
            var logInUser = this.GetUser(username, password);
            if (logInUser == null)
            {
                throw new ArgumentException("The username or/and password is not valid.");
            }

            this.hostUser = logInUser;
        }

        public void RegisterUser(string username, string password)
        {
            bool usernameIsAvailable = this.CheckUsernameIsAvailable(username);
            if (!usernameIsAvailable)
            {
                throw new ArgumentException(string.Format("User with username {0} already exists.", username));
            }

            bool passwordIsValid = !string.IsNullOrEmpty(password) && password.Length >= 3;
            if (!passwordIsValid)
            {
                // TODO: make constat for "3" and exceptions messages 
                throw new ArgumentException("Pasword must be at least 3 symbols long.");
            }

            var users = this.chatData.Users;
            var newUser = new User(username, password);

            users.Add(newUser);
        }

        public IList<Message> GetMessagesWith(User recepient, int skipCount = 0)
        {
            var result = this.chatData.Messages.Search(m =>
                    (m.Sender == this.hostUser && m.Recepient == recepient)
                    || (m.Sender == recepient && m.Recepient == this.hostUser),
                    skipCount);

            return result;
        }

        public Message SendMessage(User recepient, string content)
        {
            var newMessage = new Message(this.hostUser, recepient, content);
            this.chatData.Messages.Add(newMessage);

            return newMessage;
        }

        public User GetUser(string username)
        {
            var users = this.chatData.Users;
            var user = users.Search(u => u.Username == username).FirstOrDefault();

            return user;
        }

        private User GetUser(string username, string password)
        {
            var user = this.GetUser(username);
            if (user != null && user.Password != password)
            {
                user = null;
            }

            return user;
        }

        private bool CheckUsernameIsAvailable(string username)
        {
            var users = this.chatData.Users;

            bool usernameIsAvailable = !users.Search(u => u.Username == username).Any();

            return usernameIsAvailable;
        }
    }
}