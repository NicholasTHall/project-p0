using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWorld.Domain.Models.PizzaComponents
{
    public class PizzaCrust
    {        
        public string SelectCrust()
        {
            Console.WriteLine("Select Crust");
            int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 1:
                    return "Regular";
                case 2:
                    return "Thin";
                case 3:
                    return "Cheese Fill";
                default:
                    return "Regular";
            }
        }
    }
}
