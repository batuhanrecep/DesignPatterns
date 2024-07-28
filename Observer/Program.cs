using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Observer design pattern defines a one-to-many dependency between objects, so that when one object (the subject) changes state,
            //all its dependents (observers) are notified and updated automatically, promoting loose coupling and dynamic behavior in applications.


            var customerObserver = new CustomerObsever();
            var employeeObserver = new EmployeeObsever();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver);
            productManager.Attach(employeeObserver);
            productManager.Detach(customerObserver);
            productManager.UpdatePrice();



            Console.ReadLine();

        }
    }

    class ProductManager
    {
        List<Observer> _observers=new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product Price Changed");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObsever : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer: Product Price Changed");
        }
    }

    class EmployeeObsever : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee: Product Price Changed");
        }
    }
}
