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
        public SqlClient()
        {
            if(ReadStores().Count() == 0)
            {
                CreateStore();
            }
        }
        public IEnumerable<Store> ReadStores()
        {
            return _db.Stores;
        }

        public void SaveStore(Store store)
        {
            _db.Add(store);
            _db.SaveChanges();
        }

        public void CreateStore()
        {
            SaveStore(new Store());
        }

        public IEnumerable<User> ReadUsers()
        {
            return _db.Users;
        }

        public void SaveUser(Store user)
        {
            _db.Add(user);
            _db.SaveChanges();
        }

        public IEnumerable<APizzaModel> ReadPizzaModel()
        {
            return _db.PizzaModels;
        }

        public void SavePizzaModel(Store pizzaModel)
        {
            _db.Add(pizzaModel);
            _db.SaveChanges();
        }
    }
}