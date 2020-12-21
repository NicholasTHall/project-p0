using System;
using System.Collections.Generic;

namespace PizzaWorld.Domain.Models
{
    public class Pizza
    {
        public string SelectCrust()
        {
            Console.WriteLine("Select Crust");
            int.TryParse(Console.ReadLine(), out int input);
            switch(input){
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

        public string SelectSize()
        {
            Console.WriteLine("Select Size");
            int.TryParse(Console.ReadLine(), out int input);
            switch(input){
                case 1:
                    return "Small";
                case 2:
                    return "Medium";
                case 3:
                    return "Large";
                default:
                    return "Extra Large";
            }
        }

        public string SelectToppings()
        {
            int.TryParse(Console.ReadLine(), out int input);
            switch(input){
                case 1:
                    return "Small";
                case 2:
                    return "Medium";
                case 3:
                    return "Large";
                default:
                    return "Extra Large";
            }
        }
    }
}