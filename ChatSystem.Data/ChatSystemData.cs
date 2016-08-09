namespace ChatSystem.Data
{
    using System;
    using System.Collections.Generic;

    using ChatSystem.Data.Contracts;
    using ChatSystem.Data.Repositories;
    using ChatSystem.Model;
    using ChatSystem.Model.Contracts;

    public class ChatSystemData : IChatSystemData
    {
        private readonly IChatSystemMongoDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public ChatSystemData()
            : this(new ChatSystemMongoDbContext())
        {
        }

        public ChatSystemData(IChatSystemMongoDbContext chatSystemMongoDbContext)
        {
            this.context = chatSystemMongoDbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        private IRepository<T> GetRepository<T>() where T : IDbDocument
        {
            var typeOfDocument = typeof(T);

            bool repositoryExists = this.repositories.ContainsKey(typeOfDocument);
            if (!repositoryExists)
            {
                var typeOfRepository = typeof(Repository<T>);
                var newRepository = Activator.CreateInstance(typeOfRepository, this.context);

                this.repositories.Add(typeOfDocument, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfDocument];
        }
    }
}