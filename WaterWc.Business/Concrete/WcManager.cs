using System.Collections.Generic;
using WaterWc.Business.Abstract;
using WaterWc.DataAccess.Abstract;
using WaterWc.Entities.Concrete;

namespace WaterWc.Business.Concrete
{
    class WcManager : IWcService
    {
        private readonly IWcDal _wcDal;

        public WcManager(IWcDal wcDal)
        {
            _wcDal = wcDal;
        }

        public List<Wc> GetAll()
        {
            return _wcDal.GetAll();
        }

        public void Add(Wc wc)
        {
            _wcDal.Add(wc);
        }

        public void Delete(Wc wc)
        {
            _wcDal.Delete(wc);
        }
    }
}