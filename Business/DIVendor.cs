using System;
using System.Reflection;
using Ninject;
using Ninject.Modules;
using Models;
namespace Business
{
    public class DIVendor : NinjectModule
    {
        public static StandardKernel GetKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetEntryAssembly());

            return kernel;
        }

        public override void Load()
        {
            Bind<IInventory>().To<DrinkInventory>();
            Bind<IInventory>().To<FoodInventory>();
        }
    }
}
