
using DersYonetimSistemi.Core.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DersYonetimSistemi.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(t => t.IsDeleted == false);
            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().Where(t => t.IsDeleted == false).ToList() : context.Set<TEntity>().Where(t => t.IsDeleted == false).Where(filter).ToList();
            }
        }

        public bool Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                var result = context.SaveChanges();
                return result > 0 ? true : false;

            }
        }

        public bool Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.Now;
                var deletedEntity = context.Entry(entity);

                deletedEntity.State = EntityState.Modified;
                var result = context.SaveChanges();
                return result > 0 ? true : false;
            }
        }

        public bool Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Modified;
                var result = context.SaveChanges();
                return result > 0 ? true : false;
            }
        }

        public bool IsExist(Expression<Func<TEntity, bool>> filter)
        {

            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(i => i.IsDeleted == false).Any(filter);
            }

        }
    }
}
