using IGeneralMedicalBll;
using IGeneralMedicalDal;
using System.Linq.Expressions;

namespace GeneralMedicalBll
{
    public class BaseBll<TEntity> : IBaseBll<TEntity> where TEntity : class
    {
        protected IBaseDal<TEntity> _iBaseDal;

        public IQueryable<TEntity> GetEntities
        {
            get { return _iBaseDal.GetEntities; }
        }

        public IQueryable<TEntity> GetTrackEntities
        {
            get { return _iBaseDal.GetTrackEntities; }
        }

        public bool Add(TEntity entity)
        {
            return _iBaseDal.Add(entity);
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            return await _iBaseDal.AddAsync(entity);
        }

        public bool Any(Expression<Func<TEntity, bool>> whereFunc)
        {
            return _iBaseDal.Any(whereFunc);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereFunc)
        {
            return await _iBaseDal.AnyAsync(whereFunc);
        }

        public bool Delete(TEntity entity)
        {
            return _iBaseDal.Delete(entity);
        }

        public bool Delete(string Id)
        {
            return _iBaseDal.Delete(Id);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await _iBaseDal.DeleteAsync(entity);
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            return await _iBaseDal.DeleteAsync(Id);
        }

        public IQueryable<TEntity> Distinct(Expression<Func<TEntity, bool>> whereFunc)
        {
            return _iBaseDal.Distinct(whereFunc);
        }

        public TEntity Find(string Id)
        {
            return _iBaseDal.Find(Id);
        }

        public async Task<TEntity> FindAsync(string Id)
        {
            return await _iBaseDal.FindAsync(Id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _iBaseDal.GetAll();
        }

        public int SaveChanges()
        {
            return _iBaseDal.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _iBaseDal.SaveChangesAsync();
        }

        public bool Update(TEntity entity)
        {
            return _iBaseDal.Update(entity);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await _iBaseDal.UpdateAsync(entity);
        }

        public bool Update(Expression<Func<TEntity, bool>> whereFunc, List<TEntity> entities)
        {
            return _iBaseDal.Update(whereFunc, entities);
        }

        public async Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> whereFunc, List<TEntity> entities)
        {
            return await _iBaseDal.UpdateAsync(whereFunc, entities);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> whereFunc)
        {
            return _iBaseDal.Where(whereFunc);
        }

        public bool Delete(List<TEntity> entities)
        {
            return _iBaseDal.Delete(entities);
        }

        public async Task<bool> DeleteAsync(List<TEntity> entities)
        {
            return await _iBaseDal.DeleteAsync(entities);
        }

        public async Task AddAsync(List<TEntity> entities)
        {
            await _iBaseDal.AddAsync(entities);
        }

        public async Task UpdateAsync(List<TEntity> entities)
        {
            await _iBaseDal.UpdateAsync(entities);
        }
    }
}