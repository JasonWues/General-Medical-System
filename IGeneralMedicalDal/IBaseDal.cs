using System.Linq.Expressions;

namespace IGeneralMedicalDal
{
    public interface IBaseDal<TEntity> where TEntity : class
    {
        /// <summary>
        /// 提交当前单元操作的更改
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// 提交当前单元操作的更改(异步)
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// 获取 当前实体类型的查询数据集，数据将使用不跟踪变化的方式来查询，当数据用于展现时，推荐使用此数据集，如果用于新增，更新，删除时，请使用<see cref="GetTrackEntities"/>数据集
        /// </summary>
        IQueryable<TEntity> GetEntities { get; }

        /// <summary>
        /// 获取 当前实体类型的查询数据集，当数据用于新增，更新，删除时，使用此数据集，如果数据用于展现，推荐使用<see cref="GetEntities"/>数据集
        /// </summary>
        IQueryable<TEntity> GetTrackEntities { get; }

        /// <summary>
        /// 插入 - 通过实体对象添加
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool Add(TEntity entity);

        /// <summary>
        /// 插入 - 通过实体对象添加(异步)
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        Task<bool> AddAsync(TEntity entity);

        /// <summary>
        /// 删除 - 通过实体对象删除
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool Delete(TEntity entity);

        /// <summary>
        /// 删除 - 通过实体对象删除(异步)
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity);

        /// <summary>
        /// 删除 - 通过主键ID删除
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns></returns>
        bool Delete(string Id);

        /// <summary>
        /// 删除 - 通过主键ID删除(异步)
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string Id);

        /// <summary>
        /// 修改 - 通过实体对象修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool Update(TEntity entity);

        /// <summary>
        /// 修改 - 通过实体对象修改(异步)
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// 是否满足条件
        /// </summary>
        /// <param name="whereFunc">过滤条件</param>
        /// <returns></returns>
        bool Any(Expression<Func<TEntity, bool>> whereFunc);

        /// <summary>
        /// 是否满足条件(异步)
        /// </summary>
        /// <param name="whereFunc">过滤条件</param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereFunc);

        /// <summary>
        /// 去重查询
        /// </summary>
        /// <param name="whereFunc">过滤条件</param>
        /// <returns></returns>
        IQueryable<TEntity> Distinct(Expression<Func<TEntity, bool>> whereFunc);

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="whereFunc">过滤条件</param>
        /// <returns></returns>
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> whereFunc);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns></returns>
        TEntity Find(string Id);

        /// <summary>
        /// 根据Id查询(异步)
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns></returns>
        Task<TEntity> FindAsync(string Id);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="whereFunc">修改条件</param>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        bool Update(Expression<Func<TEntity, bool>> whereFunc, List<TEntity> entities);

        /// <summary>
        /// 批量更新(异步)
        /// </summary>
        /// <param name="whereFunc">修改条件</param>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> whereFunc, List<TEntity> entities);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        bool Delete(List<TEntity> entities);

        /// <summary>
        /// 批量删除(异步)
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(List<TEntity> entities);
        /// <summary>
        /// 批量添加(异步)
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddAsync(List<TEntity> entities);

        /// <summary>
        /// 批量修改(异步)
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task UpdateAsync(List<TEntity> entities);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="whereFunc">修改条件</param>
        /// <param name="UpdateFunc">修改数据</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> whereFunc, Expression<Func<TEntity, TEntity>> updateFunc);
    }
}