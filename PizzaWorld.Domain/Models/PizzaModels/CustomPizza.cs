using System;
using System.Collections.Generic;
using System.Text;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models.PizzaComponents;

namespace PizzaWorld.Domain.Models.PizzaModels
{
  public class CustomPizza : APizzaModel
  {
    protected override void AddPizzaType()
    {
      PizzaType = this.GetType().Name;
    }

    protected override void AddCrust()
    {
      PizzaCrust = new PizzaCrust();
      PizzaCrust.SelectCrust();
    }

    protected override void AddSize()
    {
      PizzaSize = new PizzaSize();
      PizzaSize.SelectSize();
    }

    protected override void AddToppings()
    {
      PizzaToppings.Add(new PizzaTopping("Sauce"));
      PizzaToppings.Add(new PizzaTopping("Cheese"));
      Boolean addT = true;
      while (addT)
      {
        Console.WriteLine("Choose an Action:\n 1. Add/Remove toppings\n 2. Done");
        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
          case 1:
            Console.WriteLine(ToppingsToString());
            PizzaTopping newTopping = new PizzaTopping();
            newTopping.SelectToppings();
            if (ContainsTopping(newTopping)) { RemoveTopping(newTopping); }
            else { PizzaToppings.Add(newTopping); }
            break;
          case 2:
            if (5 >= PizzaToppings.Count && PizzaToppings.Count >= 2) { addT = false; }
            else { Console.WriteLine("must have 2-5 toppings on pizza"); }
            break;
          default:
            Console.WriteLine("Unknown input try again");
            break;
        }
      }
    }
    private bool ContainsTopping(PizzaTopping topping)
    {
      foreach (PizzaTopping t in PizzaToppings)
      {
        if (t.Toppings.Equals(topping.Toppings)) { return true; }
      }
      return false;
    }
    private bool RemoveTopping(PizzaTopping topping)
    {
      foreach (PizzaTopping t in PizzaToppings)
      {
        if (t.Toppings.Equals(topping.Toppings))
        {
          PizzaToppings.Remove(t);
          return true;
        }
      }
      return false;
    }

    private string ToppingsToString()
    {
      var sb = new StringBuilder();

      foreach (PizzaTopping t in PizzaToppings)
      {
        sb.Append($" [{t.Toppings}]");
      }

      return $"Current Toppings:{sb.ToString()}";
    }
    protected override void CalculatePrice()
    {
      Price = new PizzaPrice().CalculatePrice(PizzaCrust.Crust, PizzaSize.Size, PizzaToppings.Count);
    }
  }
}
