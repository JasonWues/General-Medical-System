using Entity;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace GeneralMedicalDal
{
    public class BaseDal<TEntity> : IBaseDal<TEntity> where TEntity : BaseId
    {
        private readonly GeneralMedicalContext _generalMedicalContext;
        public BaseDal(GeneralMedicalContext generalMedicalContext)
        {
            _generalMedicalContext = generalMedicalContext;
        }


        public IQueryable<TEntity> GetEntities
        {
            get { return _generalMedicalContext.Set<TEntity>().AsNoTracking(); }
        }

        public IQueryable<TEntity> GetTrackEntities
        {
            get { return _generalMedicalContext.Set<TEntity>(); }
        }

        public bool Add(TEntity entity)
        {
            _generalMedicalContext.Set<TEntity>().Add(entity);
            if (SaveChanges() > 0) return true;
            return false;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _generalMedicalContext.Set<TEntity>().AddAsync(entity);
            if (await SaveChangesAsync() > 0) return true;
            return false;
        }

        public bool Delete(TEntity entity)
        {
            _generalMedicalContext.Remove(entity);
            if (SaveChanges() > 0) return true;
            return false;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _generalMedicalContext.Remove(entity);
            if (await SaveChangesAsync() > 0) return true;
            return false;
        }

        public bool Delete(string Id)
        {
            var entity = _generalMedicalContext.Set<TEntity>().Find(Id);
            _generalMedicalContext.Remove(entity ?? throw new InvalidOperationException());
            if (SaveChanges() > 0) return true;
            return false;
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var entity = await _generalMedicalContext.Set<TEntity>().FindAsync(Id);
            _generalMedicalContext.Remove(entity ?? throw new InvalidOperationException());
            if (await SaveChangesAsync() > 0) return true;
            return false;
        }

        public bool Update(TEntity entity)
        {
            var entry = _generalMedicalContext.Entry(entity);
            if(entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
            if (SaveChanges() > 0) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var entry = _generalMedicalContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
            if (await SaveChangesAsync() > 0) return true;
            return false;
        }

        public TEntity Find(string Id)
        {
            return _generalMedicalContext.Set<TEntity>().Find(Id);
        }

        public async Task<TEntity> FindAsync(string Id)
        {
            return await _generalMedicalContext.Set<TEntity>().FindAsync(Id);
        }

        public bool Any(Expression<Func<TEntity, bool>> whereFunc)
        {
            return _generalMedicalContext.Set<TEntity>().AsNoTracking().Any(whereFunc);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereFunc)
        {
            return await _generalMedicalContext.Set<TEntity>().AsNoTracking().AnyAsync(whereFunc);
        }

        public IQueryable<TEntity> Distinct(Expression<Func<TEntity, bool>> whereFunc)
        {
            return _generalMedicalContext.Set<TEntity>().AsNoTracking().Where(whereFunc).Distinct();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _generalMedicalContext.Set<TEntity>().AsNoTracking();
        }

        public int SaveChanges()
        {
            return _generalMedicalContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _generalMedicalContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> whereFunc)
        {
            return _generalMedicalContext.Set<TEntity>().Where(whereFunc);
        }
    }
}
