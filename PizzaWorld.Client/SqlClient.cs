using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.Client
{
    public class SqlClient
    {
        private readonly PizzaWorldContext _db = new PizzaWorldContext();

        public void Update()
        {
            _db.SaveChanges();
        }

        public IEnumerable<Store> ReadStores()
        {
            return _db.Stores;
        }

        public Store ReadOneStore(string name)
        {
            return _db.Stores.FirstOrDefault(s => s.Name == name);
        }

        public void SaveStore(Store store)
        {
            _db.Add(store);
            _db.SaveChanges();
        }        

        public Store SelectStore(){
            string input = Console.ReadLine();
            return ReadOneStore(input);
        }

        public IEnumerable<Order> ReadOrders(Store store)
        {
            return ReadOneStore(store.Name).Orders;
        }

        public IEnumerable<User> ReadUsers()
        {
            return _db.Users;
        }

        public void SaveUser(User user)
        {
            _db.Add(user);
            _db.SaveChanges();
        }

        public IEnumerable<APizzaModel> ReadPizzaModel()
        {
            return _db.PizzaModels;
        }

        public void SavePizzaModel(APizzaModel pizzaModel)
        {
            _db.Add(pizzaModel);
            _db.SaveChanges();
        }
    }
}