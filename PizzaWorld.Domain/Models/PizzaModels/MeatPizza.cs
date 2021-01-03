using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models.PizzaComponents;

namespace PizzaWorld.Domain.Models.PizzaModels
{
    public class MeatPizza : APizzaModel
    {
        protected override void AddPizzaType()
        {
            PizzaType = this.GetType().Name;
        }
        
        protected override void AddCrust()
        {
            Crust = new PizzaCrust();
            Crust.SelectCrust();
        }

        protected override void AddSize()
        {
            Size = new PizzaSize();
            Size.SelectSize();
        }

        protected override void AddToppings()
        {
            PizzaToppings.Add(new PizzaTopping("cheese"));
            PizzaToppings.Add(new PizzaTopping("tomato"));
        }

        protected override void CalculatePrice()
        {
            Price = new PizzaPrice().CalculatePrice(Crust.Crust, Size.Size, PizzaToppings.Count);
        }
    }
}