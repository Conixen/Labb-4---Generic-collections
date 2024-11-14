namespace Labb_4___Generic_collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! Och välkommen till resturanté de SUT24");
            Console.WriteLine("----------------------------------------------------");
            Restaurant restaurantSut24 = new Restaurant();
            restaurantSut24.AddToMenu(new MenuItem(1, "Wagyu Kobe-biff", 1200m));
            restaurantSut24.AddToMenu(new MenuItem(2, "Veg-Wagyubiff ", 200m));
            restaurantSut24.AddToMenu(new MenuItem(3, "Matsutakesvamp-risotto", 1100m));
            restaurantSut24.AddToMenu(new MenuItem(4, "Flugsvamp-risotto", 100m));

            restaurantSut24.ShowMenu();
            Console.WriteLine("----------------------------------------------------");

            List<MenuItem> order1 = new List<MenuItem> { new MenuItem(1, "Wagyu Kobe-biff", 1200m), new MenuItem(3, "Matsutakesvamp-risotto", 1100m) };
            List<MenuItem> order2 = new List<MenuItem> { new MenuItem(3, "Matsutakesvamp-risotto", 1100m), new MenuItem(2, "Veg-Wagyubiff ", 200m) };
            List<MenuItem> order3 = new List<MenuItem> { new MenuItem(4, "Flugsvamp-risotto", 100m), new MenuItem(2, "Veg-Wagyubiff ", 200m) };

            restaurantSut24.CreateOrder(new Order(order1, 1));
            restaurantSut24.CreateOrder(new Order(order2, 2));
            restaurantSut24.CreateOrder(new Order(order3, 3));

            //5.Visa alla aktuella ordrar.
            //6.Visa antalet ordrar i kön.
            //7.Visa nästa order på kö.
            //8.Hantera en order.
            //9.Visa antalet ordrar i kön.
            //10.Lägg till en ny order.
            //11.Visa antalet ordrar i kön.
            //12.Hantera två ordrar.
            //13.Visa antalet ordrar i kön.
            //14.Visa nästa order på kö.
            //15.Hantera en order.
            //16.Visa antalet ordrar i kön.

            Console.WriteLine("Den som beställde flugsvamp-risotto bör åka till sjukhuset");
        }
    }
    public class MenuItem 
    {
        // I denna klass använder vi auto-implemented properties
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public MenuItem(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Price:C}";
        }
    }
    public class Order
    {
        // I denna klass använder vi i stället private fields
        static int orderIdCounter = 1;
        private int _orderId;
        private List<MenuItem> _orderItems;
        private int _tableNumber;

        public Order(List<MenuItem> orderItems, int tableNumber)
        {
            // Automatiskt skapande av id
            _orderId = orderIdCounter;
            orderIdCounter++;
            _orderItems = orderItems;
            _tableNumber = tableNumber;
        }
        public void WriteOutOrder() 
        { 
        
        }
    }
    public class Restaurant
    {
        public List<MenuItem> menu = new List<MenuItem> {};
        public Queue<Order> customerQueue = new Queue<Order>();

        public void AddToMenu(MenuItem menuItem) 
        { 
            menu.Add(menuItem);
            Console.WriteLine($"Matträtten { menuItem } är nu i menyn");
        }

        public void ShowMenu() 
        {
            Console.WriteLine("Meny");
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
        }
        public void CreateOrder (Order order) 
        {
            customerQueue.Enqueue(order);
            Console.WriteLine($"Beställningen är lagd för { order }");
        }
        public void HandleOrder() 
        { 
        
        }
        public void ShowOrder() 
        {
            
        }
        public void ShowNextOrder() 
        { 
        
        }

        public void ShowOrderCount() 
        { 
        
        }
    }
}
