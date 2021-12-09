namespace IGeneralMedicalDal
{
    public interface IBaseDal<TEntity> where TEntity : class
    {
        public TEntity Find(string Id);
        public Task<TEntity> FindAsync(string Id);
    }
}
