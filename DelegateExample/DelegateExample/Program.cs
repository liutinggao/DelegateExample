using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//this code show us the delegate with template Methold
namespace DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory productfactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();
            Func<Product> func1 = new Func<Product>(productfactory.MakePizza);//生产披萨委托给func1
            Func<Product> func2 = new Func<Product>(productfactory.MakeToy);//生产玩具
            Box box1= wrapFactory.WrapProduct(func1);
            Box box2= wrapFactory.WrapProduct(func2);
            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }
    }
    class Product
    {
        //the product's name
        public string Name{get;set;}
}
   
    class Box
    {
        //包装盒
        public Product Product{get;set;}
    }
    class WrapFactory
    {
        //包装整个产品的包装
        public Box WrapProduct(Func<Product> getProduct)
        {
            Box box = new Box();
            Product product = getProduct.Invoke();//拿到一个product
            box.Product = product;
            return box;
        }

    }
    class ProductFactory
    {
        //产品工厂
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            return product;
        }
        public Product MakeToy()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            return product;
        }
    }
}