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
      //PrintAllUsersEF();
      //var user = _sql.SelectUser();
      //UserMakeOrder(user);
      //var user = _sql.ReadOneUser("UserOne");

      var user = new User();
      Console.WriteLine("Enter username for new user");
      user.Name = Console.ReadLine();
      _sql.SaveUser(user);
      UserMakeOrder(user);
      //PrintAllStoresEF();
      //var store = _sql.SelectStore();
      //Console.WriteLine(store.UserOrderHistory(user));
      //Console.WriteLine(store.MonthlyPizzaStats());
      //Console.WriteLine(store.WeeklyPizzaStats());
      /*user.SelectedStore = _sql.SelectStore();
      user.SelectedStore.CreateOrder();
      user.Orders.Add(user.SelectedStore.Orders.Last());
      user.Orders.Last().MakeCustomPizza();
      user.Orders.Last().MakeCustomPizza();
      user.Orders.Last().OrderDate = DateTime.Now;
      _sql.Update();

      Console.WriteLine(user.OrderSummmary());*/

      //UserMakeOrder(user);
      //UserOrderHistory(user);
    }

    static void UserOrderHistory(User user)
    {
      Console.WriteLine(user.OrderHistory());
    }

    static void UserMakeOrder(User user)
    {
      bool addpizzas = true;
      if (user.OrderTimeLimitCheck())
      {
        Console.WriteLine("Cannot place an order within two hours of another order");
        return;
      }

      PrintAllStoresEF();
      var store = _sql.SelectStore();
      if (!(user.SelectedStore == null))
      {
        if (!user.SelectedStore.Equals(store))
        {
          if (user.StoreChangeCheck())
          {
            Console.WriteLine("Cannot changes stores within 24 hours of another order");
            return;
          }
        }
      }

      user.SelectedStore = store;
      user.SelectedStore.CreateOrder();
      user.Orders.Add(user.SelectedStore.Orders.Last());
      while (addpizzas)
      {
        Console.WriteLine("Choose action (number)");
        Console.WriteLine(""
        + "1. Order Summary\n"
        + "2. Order CustomPizza\n"
        + "3. Order MeatPizza\n"
        + "4. Remove a Pizza\n"
        + "5. Finish Order");
        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
          case 1:
            Console.WriteLine(user.OrderSummmary());
            break;
          case 2:
            user.Orders.Last().MakeCustomPizza();
            user.Orders.Last().LimitCheck();
            break;
          case 3:
            user.Orders.Last().MakeMeatPizza();
            user.Orders.Last().LimitCheck();
            break;
          case 4:
            Console.WriteLine(user.OrderSummmary());
            Console.WriteLine("Choose a pizza to remove (number)");
            int.TryParse(Console.ReadLine(), out int pizzaSelect);
            user.Orders.Last().DeletePizza(pizzaSelect - 1);
            break;
          case 5:
            addpizzas = false;
            break;
          default:
            Console.WriteLine("Unknown input try again");
            break;
        }
      }

      user.Orders.Last().OrderDate = DateTime.Now;
      _sql.Update();

      Console.WriteLine(user.OrderSummmary());
    }
  }
}
