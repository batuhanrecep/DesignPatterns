using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();

        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }

    interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        //Without FACADE
        //private ILogging _logging;
        //private ICaching _caching;
        //private IAuthorize _authorize;

        //public CustomerManager(ILogging logging, ICaching caching, IAuthorize authorize)
        //{
        //    _logging = logging;
        //    _caching = caching;
        //    _authorize = authorize;
        //}

        //public void Save()
        //{
        //    _logging.Log();
        //    _caching.Cache();
        //    _authorize.CheckUser();
        //    Console.WriteLine("Saved");
        //}

        private CrossCuttingConcernsFacade _concerns;

        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            _concerns.Authorize.CheckUser();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade
    {

        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }

    }
}
