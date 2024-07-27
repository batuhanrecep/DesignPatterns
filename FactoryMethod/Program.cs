using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FactoryMethod design pattern is one of the most used design patterns in today

            //In.NET, the Factory Method design pattern allows developers to define an abstract method for creating an object in a base class,
            //letting subclasses override this method to instantiate specific types, thereby promoting code flexibility and reusability.


            //This expression is not acceptable because of Solid principles. But, I used this to just understand logic of FactoryMethod
            //Usually, we are using IoC containers to do this 
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();


            Console.ReadLine();
        }
    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void log();
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new EdLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new AbLogger();
        }

    }
    
    public class EdLogger : ILogger
    {

        public void log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }
    public class AbLogger : ILogger
    {

        public void log()
        {
            Console.WriteLine("Logged with AbLogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.log();
        }
    }
}
