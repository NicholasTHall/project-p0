using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
  class Program
  {
    private static readonly ClientSingleton _client = ClientSingleton.Instance;

    private readonly static SqlClient _sql = new SqlClient();
    static void Main(string[] args)
    {
      UserView();
    }

    static void PrintAllStores()
    {
      foreach (var store in _client.Stores)
      {
        Console.WriteLine(store);
      }
    }

    static void PrintAllStoresEF()
    {
      foreach (var store in _sql.ReadStores())
      {
        Console.WriteLine(store);
      }
    }

    static void PrintAllUsersEF()
    {
      foreach (var user in _sql.ReadUsers())
      {
        Console.WriteLine(user.Name);
      }
    }

    static void UserView()
    {
      PrintAllUsersEF();
      var user = _sql.SelectUser();
      //var user = _sql.ReadOneUser("UserOne");

      //var user = new User();
      //_sql.SaveUser(user);
      UserMakeOrder(user);

    }

    static void UserOrderHistory(User user)
    {
      Console.WriteLine(user.OrderHistory());
    }

    static void UserMakeOrder(User user)
    {
      if (user.OrderTimeLimitCheck())
      {
        Console.WriteLine("Cannot place an order within two hours of another order");
        return;
      }

      PrintAllStoresEF();
      var store = _sql.SelectStore();
      if (!user.SelectedStore.Equals(store))
      {
        if (user.StoreChangeCheck())
        {
          Console.WriteLine("Cannot changes stores within 24 hours of another order");
          return;
        }
      }

      user.SelectedStore = store;
      user.SelectedStore.CreateOrder();
      user.Orders.Add(user.SelectedStore.Orders.Last());
      user.Orders.Last().MakeMeatPizza();
      user.Orders.Last().MakeMeatPizza();
      user.Orders.Last().OrderDate = DateTime.Now;
      _sql.Update();

      Console.WriteLine(user.OrderSummmary());
    }
  }
}
