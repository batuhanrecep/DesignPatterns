using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // In.NET, the Abstract Factory design pattern provides an interface for creating
            // families of related or dependent objects without specifying their concrete classes,
            // enabling the encapsulation of a group of factory methods and supporting the creation of various products that are designed to work together.


            ProductManager productManager = new ProductManager(new Factory1());
            //ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();


            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }

    class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }
    }

    public class MemCache:Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();

    }

    class Factory1: CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }

        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }

    class Factory2 : CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new NLogger();
        }

        public override Caching CreateCaching()
        {
            return new MemCache();
        }
    }

    public class ProductManager //
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _caching = _crossCuttingConcernsFactory.CreateCaching();
            _logging = _crossCuttingConcernsFactory.CreateLogger();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Products Listed!");
        }
    }


}
