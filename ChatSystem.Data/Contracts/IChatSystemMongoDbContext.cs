namespace ChatSystem.Data.Contracts
{
    using ChatSystem.Model;

    using MongoDB.Driver;

    public interface IChatSystemMongoDbContext
    {
        //IMongoCollection<Message> Messages { get; }

        //IMongoCollection<User> Users { get; }

        IMongoCollection<TEntity> GetCollection<TEntity>();
    }
}