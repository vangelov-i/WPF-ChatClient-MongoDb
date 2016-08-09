namespace ChatSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Contracts;
    using Model.Contracts;

    using MongoDB.Driver;

    public class Repository<T> : IRepository<T> where T : IDbDocument
    {
        private readonly IMongoCollection<T> collection;
        private readonly IChatSystemMongoDbContext context;

        public Repository()
            : this(new ChatSystemMongoDbContext())
        {
        }

        public Repository(IChatSystemMongoDbContext chatSystemMongoDbContext)
        {
            this.context = chatSystemMongoDbContext;
            this.collection = this.context.GetCollection<T>();
        }

        public IList<T> All()
        {
            // TODO: test if this .Skip is executing on DB level!
            var allEntities = this.collection.AsQueryable().ToList();

            return allEntities;
        }

        public IList<T> Search(Expression<Func<T, bool>> conditions, int skipCount = 0)
        {
            var filteredEntities = this.collection.Find(conditions).Skip(skipCount).ToList();

            return filteredEntities;
        }

        public void Add(T entity)
        {
            this.collection.InsertOne(entity);
        }

        public void Update(T entity)
        {
            this.collection.ReplaceOne(e => e.Id == entity.Id, entity);
        }

        public bool Delete(T entity)
        {
            var result = this.collection.DeleteOne(e => e.Id == entity.Id);

            bool documentIsRemoved = result.DeletedCount > 0;

            return documentIsRemoved;
        }

        public bool Delete(Expression<Func<T, bool>> conditions)
        {
            var deletedDocument = this.collection.FindOneAndDelete(conditions);

            return deletedDocument != null;
        }
    }
}