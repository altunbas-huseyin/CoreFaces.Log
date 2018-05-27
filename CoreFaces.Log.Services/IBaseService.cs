using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.Services
{
    public interface IBaseService<TEntity>
    {
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
        Guid Save(TEntity tEntity);
        bool Update(TEntity tEntity);
        bool Delete(Guid id);
    }
}
