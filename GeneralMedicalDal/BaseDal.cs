using EFCore.BulkExtensions;
using Entity;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GeneralMedicalDal
{
    public class BaseDal<TEntity> : IBaseDal<TEntity> where TEntity : BaseId
    {
        private readonly GeneralMedicalContext _DbContext;

        public BaseDal(GeneralMedicalContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IQueryable<TEntity> GetEntities
        {
            get { return _DbContext.Set<TEntity>().AsNoTracking(); }
        }

        public IQueryable<TEntity> GetTrackEntities
        {
            get { return _DbContext.Set<TEntity>(); }
        }

        public bool Add(TEntity entity)
        {
            _DbContext.Set<TEntity>().Add(entity);
            if (SaveChanges() > 0) return true;
            return false;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _DbContext.Set<TEntity>().AddAsync(entity);
            if (await SaveChangesAsync() > 0) return true;
            return false;
        }

        public bool Delete(TEntity entity)
        {
            _DbContext.Remove(entity);
            if (SaveChanges() > 0) return true;
            return false;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _DbContext.Remove(entity);
            if (await SaveChangesAsync() > 0) return true;
            return false;
        }

        public bool Delete(string Id)
        {
            var entity = _DbContext.Set<TEntity>().Find(Id);
            _DbContext.Remove(entity ?? throw new InvalidOperationException());
            if (SaveChanges() > 0) return true;
            return false;
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var entity = await _DbContext.Set<TEntity>().FindAsync(Id);
            _DbContext.Remove(entity ?? throw new InvalidOperationException());
            if (await SaveChangesAsync() > 0) return true;
            return false;
        }

        public bool Delete(List<TEntity> entities)
        {
            _DbContext.RemoveRange(entities);
            return _DbContext.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(List<TEntity> entities)
        {
            _DbContext.RemoveRange(entities);
            return await _DbContext.SaveChangesAsync() > 0;
        }

        public bool Update(TEntity entity)
        {
            var entry = _DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
            if (SaveChanges() > 0) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var entry = _DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
            if (await SaveChangesAsync() > 0) return true;
            return false;
        }

        public TEntity Find(string Id)
        {
            return _DbContext.Set<TEntity>().Find(Id);
        }

        public async Task<TEntity> FindAsync(string Id)
        {
            return await _DbContext.Set<TEntity>().FindAsync(Id);
        }

        public bool Any(Expression<Func<TEntity, bool>> whereFunc)
        {
            return _DbContext.Set<TEntity>().AsNoTracking().Any(whereFunc);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereFunc)
        {
            return await _DbContext.Set<TEntity>().AsNoTracking().AnyAsync(whereFunc);
        }

        public IQueryable<TEntity> Distinct(Expression<Func<TEntity, bool>> whereFunc)
        {
            return _DbContext.Set<TEntity>().AsNoTracking().Where(whereFunc).Distinct();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _DbContext.Set<TEntity>().AsNoTracking();
        }

        public int SaveChanges()
        {
            return _DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _DbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> whereFunc)
        {
            return _DbContext.Set<TEntity>().Where(whereFunc);
        }

        public bool Update(Expression<Func<TEntity, bool>> whereFunc, List<TEntity> entities)
        {
            return _DbContext.Set<TEntity>().Where(whereFunc).BatchUpdate(entities) > 0;
        }

        public async Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> whereFunc, List<TEntity> entities)
        {
            return await _DbContext.Set<TEntity>().Where(whereFunc).BatchUpdateAsync(entities) > 0;
        }

        public async Task AddAsync(List<TEntity> entities)
        {
            await _DbContext.BulkInsertAsync(entities);
        }

        public async Task UpdateAsync(List<TEntity> entities)
        {
            await _DbContext.BulkUpdateAsync(entities);
        }
    }
}