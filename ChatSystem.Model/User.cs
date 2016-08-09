namespace ChatSystem.Model
{
    using ChatSystem.Model.Contracts;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class User : IDbDocument
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; private set; }

        public override string ToString()
        {
            return this.Username;
        }
    }
}