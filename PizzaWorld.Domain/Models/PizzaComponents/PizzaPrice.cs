using System;

namespace PizzaWorld.Domain.Models.PizzaComponents
{
    public class PizzaPrice
    {
        public double CalculatePrice(String crust, String size, int toppings)
        {
            double price = 0;

            price += CalculateCrustPrice(crust);
            price += CalculateSizePrice(size);
            price += CalculateToppingsPrice(toppings);

            return price;
        }

        public double CalculateCrustPrice(String crust)
        {
            switch(crust)
            {
                case "Regular":
                    return 1.00;
                case "Thin":
                    return 0.75;
                case "Cheese Fill":
                    return 1.50;
                default:
                    return 1.00;
            }
        }

        public double CalculateSizePrice(String size)
        {
            switch(size)
            {
                case "Small":
                    return 1.00;
                case "Medium":
                    return 1.50;
                case "Large":
                    return 2.00;
                case "Extra Large":
                    return 2.50;
                default:
                    return 1.50;
            }
        }

        public double CalculateToppingsPrice(int toppings)
        {
            return 0.50 * toppings;
        }
    }
}