
using DersYonetimSistemi.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DersYonetimSistemi.Core.DataAccess
{
    //generic constraint
    // class : referens tip 
    // IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    // new() : new'lenebilir olabilir -IEntity new'lenemez!-
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool IsExist(Expression<Func<T, bool>> filter);

    }
}
