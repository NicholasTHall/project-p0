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

        static void Main(string[] args)
        {            
            UserView();
        }

        static void PrintAllStores()
        {
            foreach(var store in _client.Stores)
            {
                Console.WriteLine(store);
            }
        }

        static void UserView()
        {
            var user = new User();

            PrintAllStores();
            user.SelectedStore = _client.SelectStore();
            user.SelectedStore.CreateOrder();
            user.Orders.Add(user.SelectedStore.Orders.Last());
            user.Orders.Last().MakeMeatPizza();
            user.Orders.Last().MakeMeatPizza();

            Console.WriteLine(user.ToString());
        }
    }
}
