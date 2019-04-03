using System.Collections.Generic;
using WaterWc.Entities.Abstract;

namespace WaterWc.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class, IEntity
    {
        List<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
