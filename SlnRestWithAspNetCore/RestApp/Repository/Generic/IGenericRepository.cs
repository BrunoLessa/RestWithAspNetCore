using RestApp.Model.Base;
using System.Collections.Generic;

namespace RestApp.Repository.Generic
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        TEntity Create(TEntity objeto);
        TEntity FindById(long id);
        List<TEntity> FindAll();
        TEntity Update(TEntity objeto);
        void Delete(long id);
    }
}
