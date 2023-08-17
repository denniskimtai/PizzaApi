using PizzaApi.Models;

namespace PizzaApi.Services
{
    public class PizzaService
    {
        public static List<Pizza> Pizzas { get; } = new List<Pizza>(){
                new Pizza() { Id = 1,
                Name = "Classic Italian",
                Size = "Small",
                Toppings = "Pepperoni",
                isReady = true}
            };
        public PizzaService()
        {
        
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza? Get(int id)
        {
            return Pizzas?.FirstOrDefault(p => p.Id == id);
        }

        public static void Add(Pizza pizza)
        {
            Pizzas?.Add(pizza);
        }

        public static void Remove(int id)
        {
            //check the id and get the pizza item using Get method
            var pizza = Get(id);

            //check if pizza item exist  in pizzas list
            if(pizza != null)
            {
                Pizzas?.Remove(pizza);
            }
            else
            {
                return;
            }
            
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);

            if(index == -1)
            {
                return;
            }

            Pizzas[index] = pizza;
        }

    }
}
