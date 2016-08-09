namespace ChatSystem.Data
{
    using ChatSystem.Data.Contracts;
    using ChatSystem.Model;

    using MongoDB.Driver;

    public class ChatSystemMongoDbContext : MongoClient, IChatSystemMongoDbContext
    {
        private const string DefaultConnection = "mongodb://Iliyan:fuck@ds145395.mlab.com:45395/iliyanschat";
        private const string DefaultDatabaseName = "iliyanschat";

        private IMongoDatabase database;

        public ChatSystemMongoDbContext()
            : base(DefaultConnection)
        {
            this.database = this.GetDatabase(DefaultDatabaseName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            string collectionName = typeof(TEntity).Name + "s";
            var result = this.database.GetCollection<TEntity>(collectionName);

            return result;
        } 
    }
}