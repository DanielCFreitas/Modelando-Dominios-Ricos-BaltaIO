using System;
using System.Collections.Generic;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Shared.Repository
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        void Add(T entity);
        void Update(T entity);
        List<T> ListAll();
        T GetById(Guid id);
        void Delete(T entity);
    }
}
