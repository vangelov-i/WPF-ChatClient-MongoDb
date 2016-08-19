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
        private IChatSystemMongoDbContext context;

        public Repository()
            : this(new ChatSystemMongoDbContext())
        {
        }

        public Repository(IChatSystemMongoDbContext chatSystemMongoDbContext)
        {
            this.Context = chatSystemMongoDbContext;
            this.collection = this.Context.GetCollection<T>();
        }

        private IChatSystemMongoDbContext Context
        {
            get
            {
                return this.context;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("ChatSystemMongoDbContext can not be null.");
                }

                this.context = value;
            }
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
            bool result = this.Delete(e => e.Id == entity.Id);

            return result;
        }

        public bool Delete(Expression<Func<T, bool>> conditions)
        {
            var deleteResult = this.collection.DeleteOne(conditions);

            return deleteResult.DeletedCount > 0;
        }
    }
}