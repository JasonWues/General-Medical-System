using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    public class BaseDal<TEntity> : IBaseDal<TEntity> where TEntity : class
    {
        private readonly GeneralMedicalContext _generalMedicalContext;
        public BaseDal(GeneralMedicalContext generalMedicalContext)
        {
            _generalMedicalContext = generalMedicalContext;
        }

        public TEntity Find(string Id)
        {
            return _generalMedicalContext.Set<TEntity>().Find(Id);
        }

        public async Task<TEntity> FindAsync(string Id)
        {
            return await _generalMedicalContext.Set<TEntity>().FindAsync(Id);
        }
    }
}
