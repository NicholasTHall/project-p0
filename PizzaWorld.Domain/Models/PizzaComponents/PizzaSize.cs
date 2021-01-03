using System;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models.PizzaComponents
{
    public class PizzaSize : AEntity
    {
        public string Size {get; set;}

        public PizzaSize(){}
        public PizzaSize(string size)
        {
            Size = size;
        }
        public void SelectSize()
        {
            Console.WriteLine("Select Size");
            int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 1:
                    Size = "Small";
                    break;
                case 2:
                    Size = "Medium";
                    break;
                case 3:
                    Size = "Large";
                    break;
                case 4:
                    Size = "Extra Large";
                    break;
                default:
                    Size = "Medium";
                    break;
            }
        }
    }
}
