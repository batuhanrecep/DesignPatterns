using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Adapter design pattern allows incompatible interfaces to work together by converting the interface of a class into another interface
            //that a client expects, facilitating integration and enhancing the flexibility of existing code.

            ProductManager productManager1 = new ProductManager(new BRLogger());
            ProductManager productManager2 = new ProductManager(new Log4NetAdapter());
            productManager1.Save();
            productManager2.Save();
            Console.ReadLine();

        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class BRLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("{0}, Logged with BRLogger", message);
        }
    }

    //Let's say we get this from nuget
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("{0}, Logged with Log4net ", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4net = new Log4Net();
            log4net.LogMessage(message);
        }
    }
}
