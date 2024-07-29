using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Null Object design pattern provides a default, do-nothing implementation of an object interface,
            //representing the absence of an object instead of using null references, thereby avoiding null checks and preventing potential null reference exceptions.

            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.log();
        }
    }

    interface ILogger
    {
        void log();
    }

    class Log4NetLogger:ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    class NLogLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged with NLogLogger");
        }
    }

    //NullObject Design
    class StubLogger:ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock=new object();

        private StubLogger() { }

        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger==null)
                {
                    _stubLogger = new StubLogger();
                }
            }
            return _stubLogger;
        }
        public void log()
        {
            
        }
    }
    class CustomerManagerTests
    {
        public void SaveTest()
        {
            //Let's say, we need to make test, but we don't want to execute the logger
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }

    }
}
