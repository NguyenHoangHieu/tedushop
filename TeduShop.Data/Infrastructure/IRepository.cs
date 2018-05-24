using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TeduShop.Data.Infrastructure
{
    //b5 cac phuong thuc co san
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        T Add(T entity);

        // Marks an entity as modified
        void Update(T entity);

        // Marks an entity to be removed
        T Delete(T entity);//đổi void thành T

        T Delete(int id);//đổi void thành T

        //Delete multi records
        void DeleteMulti(Expression<Func<T, bool>> where);

        // Get an entity by int id
        T GetSingleById(int id);  //đổi void thành T

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null); //đổi void thành T

        IEnumerable<T> GetAll(string[] includes = null);//đổi IQueryable thành IEnumerable

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);//đổi IQueryable thành IEnumerable

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);//đổi IQueryable thành IEnumerable

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}