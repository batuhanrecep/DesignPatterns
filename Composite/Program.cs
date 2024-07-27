using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //The Composite design pattern enables the representation of a tree-like structure of objects by treating individual objects and
            //compositions of objects uniformly, allowing clients to interact with both simple and complex elements through a common interface.

            Employee kaan = new Employee { Name = "Kaan" };
            Employee su = new Employee { Name = "Su" };
            kaan.AddSubordinate(su);
            Employee nil = new Employee { Name = "Nil" };
            kaan.AddSubordinate(nil);
            Contractor recep = new Contractor { Name = "Recep" };
            nil.AddSubordinate(recep);
            Employee batu = new Employee { Name = "Batuhan" };
            su.AddSubordinate(batu);

            Console.WriteLine(kaan.Name);
            foreach (Employee manager in kaan)
            {
                Console.WriteLine("  {0}", manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("     {0}", employee.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }
    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinate = new List<IPerson>();
        public void AddSubordinate(IPerson person)
        {
            _subordinate.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinate.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinate[index];
        }
        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinate)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
