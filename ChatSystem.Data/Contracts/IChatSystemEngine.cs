namespace ChatSystem.Data.Contracts
{
    using System.Collections;
    using System.Collections.Generic;

    using ChatSystem.Model;

    public interface IChatSystemEngine
    {
        void LogIn(string username, string password);

        void RegisterUser(string username, string password);

        IList<Message> GetMessagesWith(User recepient);

        Message SendMessage(User recepient, string content);

        User GetUser(string username);

        IEnumerable<string> Usernames { get; }
    }
}