namespace ChatSystem.Data.Contracts
{
    using MongoDB.Driver;

    public interface IChatSystemMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>();
    }
}