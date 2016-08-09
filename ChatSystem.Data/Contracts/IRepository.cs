namespace ChatSystem.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using ChatSystem.Model.Contracts;

    public interface IRepository<T>
        where T : IDbDocument
    {
        IList<T> All();

        IList<T> Search(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        bool Delete(T entity);

        bool Delete(Expression<Func<T, bool>> conditions);
    }
}