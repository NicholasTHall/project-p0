using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Models.PizzaModels
{
  public class MeatPizza : APizzaModel
  {
    protected override void AddCrust()
    {
      Crust = new Pizza().SelectCrust();
    }

    protected override void AddSize()
    {
      Size = new Pizza().SelectSize();
    }

    protected override void AddToppings()
    {
      Toppings = new List<string>
      {
        "cheese",
        "tomato"
      };
    }
  }
}