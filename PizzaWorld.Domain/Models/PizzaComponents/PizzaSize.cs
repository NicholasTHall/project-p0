using System;

namespace PizzaWorld.Domain.Models.PizzaComponents
{
    public class PizzaSize
    {
        public string SelectSize()
        {
            Console.WriteLine("Select Size");
            int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 1:
                    return "Small";
                case 2:
                    return "Medium";
                case 3:
                    return "Large";
                case 4:
                    return "Extra Large";
                default:
                    return "Medium";
            }
        }
    }
}
