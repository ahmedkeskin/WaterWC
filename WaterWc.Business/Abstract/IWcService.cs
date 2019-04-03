using System.Collections.Generic;
using WaterWc.Entities.Concrete;

namespace WaterWc.Business.Abstract
{
    public interface IWcService
    {
        List<Wc> GetAll();
        void Add(Wc wc);
        void Delete(Wc wc);
    }
}
