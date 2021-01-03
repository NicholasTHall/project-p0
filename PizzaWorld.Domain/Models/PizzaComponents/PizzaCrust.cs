using System;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models.PizzaComponents
{
    public class PizzaCrust : AEntity
    {
        public string Crust {get; set;}
        public PizzaCrust(){}
        public PizzaCrust(string crust)
        {
            Crust = crust;
        }
        public void SelectCrust()
        {
            Console.WriteLine("Select Crust");
            int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 1:
                    Crust = "Regular";
                    break;
                case 2:
                    Crust = "Thin";
                    break;
                case 3:
                    Crust = "Cheese Fill";
                    break;
                default:
                    Crust = "Regular";
                    break;
            }
        }
    }
}
