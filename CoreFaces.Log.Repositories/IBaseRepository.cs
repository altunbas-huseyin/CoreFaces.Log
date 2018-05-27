using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
        Guid Save(TEntity tEntity);
        bool Update(TEntity tEntity);
        bool Delete(Guid id);
    }
}
