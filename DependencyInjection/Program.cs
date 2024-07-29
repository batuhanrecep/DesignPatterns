using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //In a short example, Dependency Injection design pattern facilitates the decoupling of object creation from their dependencies
            //by injecting the required dependencies into a class, promoting loose coupling, testability, and easier maintenance.

            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProductDal>();
            //kernel.Bind<IProductDal>().To<NhProductDal>();
            //kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();  ->For the methods, it will increase the performance

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();


            //Its just an example of this pattern. Its actually wrong to call the class's like this in Dependency Inversion.
            //We are using IOC Containers for the correct way (autofac, ninject, etc.)
            //ProductManager productManager = new ProductManager(new EfProductDal());
            //ProductManager productManager2 = new ProductManager(new NhProductDal());
            //productManager.Save();
            //productManager2.Save();

            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();
    }
    class EfProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF");
        }
    }
    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with NH");
        }
    }
    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            //Business Code
            //without injection
            //ProductDal productDal = new ProductDal();
            //productDal.Save();

            _productDal.Save();
        }
    }
}
