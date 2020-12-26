using System.Collections.Generic;
using PizzaWorld.Domain.Models.PizzaComponents;

namespace PizzaWorld.Domain.Abstracts
{
    public class APizzaModel : AEntity
    {
        public string Crust {get; set;}
        public string Size {get; set;}
        public List<PizzaTopping> PizzaToppings {get; set;}
        public double Price {get; set;}

        protected APizzaModel()
        {
            PizzaToppings = new List<PizzaTopping>();
            AddCrust();
            AddSize();
            AddToppings();
        }

        protected virtual void AddCrust() {}
        protected virtual void AddSize() {}
        protected virtual void AddToppings() {}
    }
}