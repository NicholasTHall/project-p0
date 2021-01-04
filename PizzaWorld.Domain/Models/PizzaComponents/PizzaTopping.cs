using System;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models.PizzaComponents
{
  public class PizzaTopping : AEntity
  {
    public string Toppings { get; set; }

    public PizzaTopping() { }
    public PizzaTopping(String topping)
    {
      Toppings = topping;
    }
    public void SelectToppings()
    {
      string[] lines = System.IO.File.ReadAllLines(@"Toppings.txt");

      // Display the file contents by using a foreach loop.
      System.Console.WriteLine("Add/Remove toppings:");
      int cnt = 0;
      foreach (string line in lines)
      {
        cnt += 1;
        Console.WriteLine(cnt + " " + line);
      }
      int.TryParse(Console.ReadLine(), out int input);
      try
      {
        Toppings = lines[input - 1];
      }
      catch
      {
        Toppings = lines[1];
      }
    }
  }
}
