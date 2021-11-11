using Example.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Example.Application.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> AsQueryable();

        Task<IEnumerable<T>> FilterBy(Expression<Func<T, bool>> filterExpression);

        Task<IEnumerable<TProjected>> FilterBy<TProjected>(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, TProjected>> projectionExpression);

        T FindOne(Expression<Func<T, bool>> filterExpression);

        Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression);

        T FindById(string id);

        Task<T> FindByIdAsync(string id);

        void InsertOne(T document);

        Task InsertOneAsync(T document);

        void InsertMany(ICollection<T> documents);

        Task InsertManyAsync(ICollection<T> documents);

        bool Update(T document);

        Task<bool> UpdateAsync(T document);

        bool DeleteOne(Expression<Func<T, bool>> filterExpression);

        Task<bool> DeleteOneAsync(Expression<Func<T, bool>> filterExpression);

        bool DeleteById(string id);

        Task<bool> DeleteByIdAsync(string id);

        bool DeleteMany(Expression<Func<T, bool>> filterExpression);

        Task<bool> DeleteManyAsync(Expression<Func<T, bool>> filterExpression);
    }
}
