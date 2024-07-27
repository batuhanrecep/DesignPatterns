using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //In.NET, the Prototype design pattern allows for the cloning of existing objects without depending on their concrete classes,
            //enabling the creation of new instances by copying a prototype instance, thus promoting flexibility and reducing the overhead of object creation.


            Customer customer1 = new Customer{FirstName = "Kaan",LastName = "Demir",City = "Ankara", Id = 1};
            

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Nil";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);



            Console.ReadLine();
        }
    }


    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
    public class Employee : Person
    {
        public string City { get; set; }
        public Decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

}
