using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();

        }

        class CustomerManager
        {
            //Singleton ensures that a particular class has only one instance throughout the application.
            //This is particularly useful for classes that manage shared resources, such as database connections,
            //configuration settings, or logging mechanisms, where multiple instances might lead to inconsistent states or excessive resource consumption.
            //For example, number of visitors to website


            private static CustomerManager _customerManager;

            //For thread safe singleton
            static object _lockObject = new object();
            public CustomerManager()
            {

            }

            public static CustomerManager CreateAsSingleton()
            {
                //1
                //if (_customerManager == null) 
                //{ 
                //    _customerManager = new CustomerManager();
                //}
                //return _customerManager;


                //1.1
                //With ?? operator - its easy to do this with resharper
                // return _customerManager ?? (_customerManager = new CustomerManager());


                //2
                //Thread safe singleton version
                lock (_lockObject)
                {
                    if (_customerManager == null)
                    {
                        _customerManager = new CustomerManager();
                    }
                }
                return _customerManager;

            }

            public void Save()
            {
                Console.WriteLine("Saved!!");
            }
        }
    }
}
