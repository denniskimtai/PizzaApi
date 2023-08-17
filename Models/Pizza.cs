namespace PizzaApi.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Size { get; set; }
        public string? Toppings { get; set; }

        public bool isReady { get; set; }

    }
}
