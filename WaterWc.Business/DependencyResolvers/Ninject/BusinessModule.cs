using Ninject.Modules;
using WaterWc.Business.Abstract;
using WaterWc.Business.Concrete;
using WaterWc.DataAccess.Abstract;
using WaterWc.DataAccess.Concrete.Xml;

namespace WaterWc.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IWaterService>().To<WaterManager>();
            Bind<IWaterDal>().To<XmlWaterDal>();

            Bind<IWcService>().To<WcManager>();
            Bind<IWcDal>().To<XmlWcDal>();
        }
    }
}
