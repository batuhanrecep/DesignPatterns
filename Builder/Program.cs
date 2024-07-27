using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //In.NET, the Builder design pattern separates the construction of a complex object from its representation,
            //allowing developers to create different representations of the object by using the same construction process,
            //thus providing flexibility and clarity in the creation of complex objects.


            ProductDirector director = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.DiscountApplied);

            Console.ReadLine();

        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public String CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }


    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }
    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 2;
            model.CategoryName = "Alcohols";
            model.ProductName = "Beer";
            model.UnitPrice = 25;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
