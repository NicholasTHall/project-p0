﻿using System;
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
            foreach(var store in _client.Stores)
            {
                Console.WriteLine(store);
            }
        }

        static void PrintAllStoresEF()
        {
            foreach(var store in _sql.ReadStores())
            {
                Console.WriteLine(store);
            }
        }

        static void PrintAllUsersEF()
        {
            foreach(var user in _sql.ReadUsers())
            {
                Console.WriteLine(user.Name);
            }
        }

        static void UserView()
        {
            PrintAllUsersEF();
            string userName = Console.ReadLine();
            var user = _sql.ReadOneUser(userName);
            //var user = new User();
            //_sql.SaveUser(user);

            PrintAllStoresEF();
            user.SelectedStore = _sql.SelectStore();
            user.SelectedStore.CreateOrder();            
            user.Orders.Add(user.SelectedStore.Orders.Last());
            user.Orders.Last().MakeMeatPizza();
            user.Orders.Last().MakeMeatPizza();
            _sql.Update();

            Console.WriteLine(user.ToString());
        }
    }
}
