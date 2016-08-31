namespace ChatSystem.Data
{
    using System.Configuration;
    using ChatSystem.Data.Contracts;

    using MongoDB.Driver;

    public class ChatSystemMongoDbContext : MongoClient, IChatSystemMongoDbContext
    {
        private const string DefaultDatabaseName = "iliyanschat";
        private static readonly string DefaultConnection = ConfigurationManager.ConnectionStrings[DefaultDatabaseName].ConnectionString;

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