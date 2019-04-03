using System.Collections.Generic;
using WaterWc.Entities.Concrete;

namespace WaterWc.Business.Abstract
{
    public interface IWaterService
    {
        List<Water> GetAll();
        void Add(Water water);
        void Delete(Water water);
        void Update(Water water);

    }
}
