using System.Collections.Generic;
using WaterWc.Business.Abstract;
using WaterWc.DataAccess.Abstract;
using WaterWc.Entities.Concrete;

namespace WaterWc.Business.Concrete
{
    public class WaterManager:IWaterService
    {
        private readonly IWaterDal _waterDal;

        public WaterManager(IWaterDal waterDal)
        {
            _waterDal = waterDal;
        }
        public List<Water> GetAll()
        {
            return _waterDal.GetAll();
        }

        public void Add(Water water)
        {
            _waterDal.Add(water);
        }

        public void Delete(Water water)
        {
            _waterDal.Delete(water);
        }

        public void Update(Water water)
        {
            _waterDal.Update(water);
        }
    }
}
