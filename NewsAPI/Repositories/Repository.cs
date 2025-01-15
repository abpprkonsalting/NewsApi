using NewsAPI.Data;
using System.Linq.Expressions;

namespace NewsAPI.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly NewsAPIContext _context;
        public Repository(NewsAPIContext empDBContext)
        {
            _context = empDBContext;
        }
        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        public IQueryable<TEntity> GetAll()
        {
            var entity = _context.Set<TEntity>();
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = _context.Set<TEntity>();
            return entity.FirstOrDefault(predicate)!;
        }
    }
}
