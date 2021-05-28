using System.Collections.Generic;
using System.Linq;
using generate_card.Entity;
using Microsoft.EntityFrameworkCore;

namespace generate_card.Repository
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IBaseEntity
        where TContext : DbContext
    {
        protected readonly TContext _context;

        protected RepositoryBase(TContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity Delete(int id)
        {
            TEntity entity = _context.Set<TEntity>().Find(id);

            if (entity == null)
            {
                return null;
            }

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public bool VerifyIfExists(int id)
        {
            return _context
                .Set<TEntity>()
                .Any(entity => entity.Id.Equals(id));
        }
    }
}