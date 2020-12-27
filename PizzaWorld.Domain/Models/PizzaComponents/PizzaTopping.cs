using System;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models.PizzaComponents
{
    public class PizzaTopping : AEntity
    {
        public string Toppings {get; set;}

        public PizzaTopping(){}
        public PizzaTopping(String topping)
        {
            Toppings = topping;
        }
        public void SelectToppings()
        {
            Boolean addT = true;
            while (addT)
            {
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        Toppings = "Pepperoni";
                        break;
                    case 2:
                        Toppings = "Black Olives";
                        break;
                    case 3:
                        Toppings = "Sausage";
                        break;
                    case 4:
                        addT = false;
                        break;
                }
            }
        }
    }
}
