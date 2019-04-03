using Ninject;

namespace WaterWc.Business.DependencyResolvers.Ninject
{
    public class NinjectInstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
