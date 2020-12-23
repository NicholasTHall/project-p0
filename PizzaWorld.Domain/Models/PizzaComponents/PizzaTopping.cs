using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWorld.Domain.Models.PizzaComponents
{
    class PizzaTopping
    {
        public List<String> SelectToppings()
        {
            List<string> toppings = new List<string>();
            Boolean addT = true;
            while (addT)
            {
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        toppings.Add("Pepperoni");
                        break;
                    case 2:
                        toppings.Add("Black Olives");
                        break;
                    case 3:
                        toppings.Add("Sausage");
                        break;
                    case 4:
                        addT = false;
                        break;
                }
            }
            return toppings;
        }
    }
}
