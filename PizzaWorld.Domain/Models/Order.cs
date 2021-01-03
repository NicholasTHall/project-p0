using System.Collections.Generic;
using System.Text;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;
using PizzaWorld.Domain.Models.PizzaModels;

namespace PizzaWorld.Domain.Models
{
    public class Order : AEntity
    {
        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();
        public List<APizzaModel> Pizzas {get; set;}

        public Order()
        {
            Pizzas = new List<APizzaModel>();
        }

        public decimal ComputePricing()
        {
            decimal price = 0;
            foreach(var pizza in Pizzas)
            {
                price += pizza.Price;
            }

            return price;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach(var p in Pizzas)
            {
                sb.AppendLine(p.PizzaType);
            };

            return $"ordered pizzs:\n{sb.ToString()}Total price is:{ComputePricing()}";
        }

        public void MakeMeatPizza()
        {
            Pizzas.Add(_pizzaFactory.Make<MeatPizza>());
        }
    }
}