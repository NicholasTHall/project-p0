using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models.PizzaComponents;

namespace PizzaWorld.Domain.Models.PizzaModels
{
    public class MeatPizza : APizzaModel
    {
        protected override void AddCrust()
        {
            Crust = new PizzaCrust().SelectCrust();
        }

        protected override void AddSize()
        {
            Size = new PizzaSize().SelectSize();
        }

        protected override void AddToppings()
        {
            PizzaToppings.Add(new PizzaTopping("cheese"));
            PizzaToppings.Add(new PizzaTopping("tomato"));
        }
    }
}