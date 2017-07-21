using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using SalesModel.DataLayer;
using SalesModel.DomainClasses;
using SalesModel.DomainClasses.Enums;
using System.Data.Entity;

namespace ConsoleApp
{
  internal class Program
  {
    private static void Main()
    {
     //EF Profiler Requires a License 
      // App_Start.EntityFrameworkProfilerBootstrapper.PreStart();
      
      //LinqExpressionSyntax();

    
      //GetCustomers();
      //GetCustomer(2);
      //InsertCustomer();
      //UpdateCustomer();
      //DeleteJulie();
      //CreateCustomerWithOrder();
      
      EagerLoading();
      //LoadWithProjection();
      //ExplicitLoading
      // LazyLoading();
   
    }



    private static void EagerLoading()
    {
      using (var context = new SalesModelContext())
      {
        var eagerLoadGraph = context.Customers.Include(c => c.Orders).ToList();

        var eagerLoadGraph2 = context.Customers.Include("Orders").ToList();

        var eagerLoadGraph3 = context.Customers.Include("Orders.LineItems").ToList();

        var eagerLoadGraph4 = context.Customers
                .Where(c => c.Orders.Any())
                .Include(c => c.Orders.Select(o => o.LineItems.Select(l => l.Product)))
                .ToList();
        var customer = eagerLoadGraph4[0];

      }
    }

    private static void LoadWithProjection()
    {
      using (var context = new SalesModelContext())
      {

        var customerOrderGraph = context.Customers
          .Select(c => new { c, c.Orders })
          .ToList();

        var customer = customerOrderGraph[2].c;

        var customerWithFirstOrder =
          context.Customers
          .Select(c => new
          {
            c,
            FirstOrder = c.Orders.OrderBy(o => o.OrderDate).FirstOrDefault()
          })
          .ToList();
      }
    }



    private static void ExplicitLoading()
    {
      using (var context = new SalesModelContext())
      {
        var customer = context.Customers.First(c=>c.Orders.Any());
        context.Entry(customer).Collection(c => c.Orders).Load();
        Console.WriteLine("Order count for {0}: {1}", 
                           customer.FirstName, customer.Orders.Count);
      }
    }
    private static void LazyLoading()
    {
      using (var context = new SalesModelContext())
      {
        context.Configuration.LazyLoadingEnabled = true;
        var customer = context.Customers.First(c => c.Orders.Any());
        //context.Entry(customer).Collection(c => c.Orders).Load();
        Console.WriteLine("Order count for {0}: {1}",
                           customer.FirstName, customer.Orders.Count);
      }
    }


    private static void CreateCustomerWithOrder()
    {
      var products = GetProducts();
      var product1 = products[0];
      var product2 = products[1];
      var customer = new Customer
                       {
                         FirstName = "Julie",
                         LastName = "Lerman",
                         ContactDetail = new ContactDetail
                                           {
                                             TwitterAlias = "julielerman"
                                           },
                         DateOfBirth = DateTime.Now
                       };
      var order = new Order
        {
          DestinationLatLong = DbGeography.FromText("POINT(44.292401 -72.968102)"),
          OrderDate = DateTime.Now,
          OrderSource = OrderSource.InPerson,
          LineItems ={new LineItem{ProductId=product1.ProductId,Quantity =2},
                         new LineItem{ProductId = product2.ProductId,Quantity=1}
                        }
        };
      customer.Orders.Add(order);
      using (var context = new SalesModelContext())
      {
        context.Customers.Add(customer);
        context.SaveChanges();
      }
    }

    private static List<Product> GetProducts()
    {
      using (var context = new SalesModelContext())
      {
        return context.Products.ToList();
      }
    }

    private static void DeleteJulie()
    {
      using (var context = new SalesModelContext())
      {
        var julies = context.Customers
                            .Where(c => c.FirstName == "Julie")
                            .ToList();
        foreach (var customer in julies)
        {
          context.Customers.Remove(customer);
        }
        context.SaveChanges();
      }
      GetCustomers();

    }

    private static void UpdateCustomer()
    {
      int id;
      using (var context = new SalesModelContext())
      {
        var customer = context.Customers
          .FirstOrDefault(c => c.FirstName == "Julie");
        id = customer.CustomerId;
        Console.WriteLine(customer.DateOfBirth);
        customer.DateOfBirth = DateTime.Now.AddYears(-25);
        context.SaveChanges();
      }
      GetCustomer(id);
    }

    private static void InsertCustomer()
    {
      var customer = new Customer { FirstName = "Julie", LastName = "Lerman", DateOfBirth = DateTime.Now };
      using (var context = new SalesModelContext())
      {
        context.Customers.Add(customer);
        context.SaveChanges();
      }
      GetCustomer(customer.CustomerId);

    }

    private static void GetCustomer(int id)
    {
      using (var context = new SalesModelContext())
      {
        var customer = context.Customers.Find(id);
        Console.WriteLine(customer.FirstName);
        Console.WriteLine(customer.DateOfBirth);
      }
      Console.WriteLine("-------------");
      Console.ReadKey();
    }

    private static void GetCustomers()
    {
      using (var context = new SalesModelContext())
      {
        //   var customers = context.Customers.ToList();
        foreach (var customer in context.Customers)
        {
          Console.WriteLine(customer.FirstName);
        }
        Console.WriteLine("-------------");
        Console.ReadKey();


      }
    }
  }
}




