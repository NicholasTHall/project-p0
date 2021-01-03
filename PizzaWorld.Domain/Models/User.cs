using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class User : AEntity
    {
        public List<Order> Orders {get; set;}
        public Store SelectedStore {get; set;}
        public string Name {get; set;}

        public User()
        {
            Name = Console.ReadLine();
            Orders = new List<Order>();
        }

        public string OrderHistory()
        {
            var sb = new StringBuilder();

            foreach(var p in Orders)
            {
                sb.AppendLine(p.ToString());
            }

            return $"order history: \n{sb.ToString()}";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach(var p in Orders.Last().Pizzas)
            {
                sb.AppendLine(p.ToString() + " at price " + p.Price);
            }
            return $"You have selected this store {SelectedStore} and ordered these pizzs:\n{sb.ToString()}Total price is:{Orders.Last().ComputePricing()}";
        }
    }
}