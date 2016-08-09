namespace ChatSystem.Model
{
    using System;

    using ChatSystem.Model.Contracts;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message : IDbDocument
    {
        public Message(User sender, User recepient, string content)
        {
            this.TimeSent = DateTime.Now;
            this.Content = content;
            this.Sender = sender;
            this.Recepient = recepient;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime TimeSent { get; set; }

        public string Content { get; set; }

        public User Sender { get; set; }

        public User Recepient { get; set; }

        public override string ToString()
        {
            return string.Format(
                "[{0:00}:{1:00}:{2:00}] {3}: {4}",
                this.TimeSent.Hour,
                this.TimeSent.Minute,
                this.TimeSent.Second,
                this.Sender,
                this.Content);
        }
    }
}