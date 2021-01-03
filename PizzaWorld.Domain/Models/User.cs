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
            Orders = new List<Order>();
        }

        public string OrderHistory()
        {
            var sb = new StringBuilder();

            int cnt = 0;
            foreach(var p in Orders)
            {
                cnt += 1;
                sb.AppendLine($"Order {cnt} {p.ToString()}");
            }

            return $"order history: \n{sb.ToString()}";
        }

        public string OrderSummmary()
        {
            /*var sb = new StringBuilder();

            foreach(var p in Orders.Last().Pizzas)
            {
                sb.AppendLine($"{p.PizzaType}: {p.PizzaSize.Size}, {p.PizzaCrust.Crust} with {p.PizzaToppings.Count} toppings at price {p.Price}");
            }*/
            return $"You have selected this store {SelectedStore} and {Orders.Last().ToString()}";
            //ordered these pizzs:\n{sb.ToString()}Total price is:{Orders.Last().ComputePricing()}";
        }
    }
}