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
            restaurantSut24.AddToMenu(new MenuItem(2, "Veg Kobe-biff ", 200m));
            restaurantSut24.AddToMenu(new MenuItem(3, "Matsutakesvamp-risotto", 1100m));
            restaurantSut24.AddToMenu(new MenuItem(4, "Flugsvamp-risotto", 100m));
            Console.WriteLine("----------------------------------------------------");
            Console.ReadKey();
            restaurantSut24.ShowMenu();
            Console.WriteLine("----------------------------------------------------");

            List<MenuItem> order1 = new List<MenuItem> { new MenuItem(1, "Wagyu Kobe-biff", 1200m), new MenuItem(3, "Matsutakesvamp-risotto", 1100m) };
            List<MenuItem> order2 = new List<MenuItem> { new MenuItem(3, "Matsutakesvamp-risotto", 1100m), new MenuItem(2, "Veg-Wagyubiff ", 200m) };
            List<MenuItem> order3 = new List<MenuItem> { new MenuItem(4, "Flugsvamp-risotto", 100m), new MenuItem(2, "Veg-Wagyubiff ", 200m) };
            Console.ReadKey();

            restaurantSut24.CreateOrder(new Order(order1, 1));
            Console.ReadKey();
            restaurantSut24.CreateOrder(new Order(order2, 2));
            Console.ReadKey();
            restaurantSut24.CreateOrder(new Order(order3, 3));
            Console.ReadKey();

            //5.Visa alla aktuella ordrar.
            restaurantSut24.ShowOrder();
            Console.ReadKey();

            //6.Visa antalet ordrar i kön.
            restaurantSut24.ShowOrderCount();

            //7.Visa nästa order på kö.
            restaurantSut24.ShowNextOrder();

            //8.Hantera en order.
            restaurantSut24.HandleOrder();

            //9.Visa antalet ordrar i kön.
            restaurantSut24.ShowOrderCount();

            //10.Lägg till en ny order.
            List<MenuItem> order4 = new List<MenuItem> { 
                new MenuItem(1, "Wagyu Kobe-biff", 1200m), 
                new MenuItem(4, "Flugsvamp-risotto", 100m) 
            };
            restaurantSut24.CreateOrder(new Order(order4, 4));

            //11.Visa antalet ordrar i kön.
            restaurantSut24.ShowOrderCount();

            //12.Hantera två ordrar.
            restaurantSut24.HandleOrder();
            restaurantSut24.HandleOrder();

            //13.Visa antalet ordrar i kön.
            restaurantSut24.ShowOrderCount();

            //14.Visa nästa order på kö.
            restaurantSut24.ShowNextOrder();

            //15.Hantera en order.
            restaurantSut24.HandleOrder();

            //16.Visa antalet ordrar i kön.
            restaurantSut24.ShowNextOrder();

            Console.WriteLine("Den som beställde flugsvamp-risotto bör åka till sjukhuset");
            Console.ReadKey();
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
        public override string ToString()
        {
            var items = string.Join(", ", _orderItems);
            return $"Order {_orderId} för bord {_tableNumber}: {items}";
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
            if (customerQueue.Count > 0) 
            {
                var handlingOrder = customerQueue.Dequeue();
                Console.WriteLine($"Beställning { handlingOrder } är klar");
            }
        }
        public void ShowOrder() 
        {
            Console.WriteLine("Väntande ordrar");
            foreach(var cQueue in customerQueue) 
            {
                Console.WriteLine(cQueue);
            }
        }
        public void ShowNextOrder() 
        {
            if (customerQueue.Count > 0)
            {
                var nextOrder = customerQueue.Peek();
                Console.WriteLine($" {nextOrder} förbereds ");

            }
            else 
            {
                Console.WriteLine("Finns inga mer beställningar");
            }
        }

        public void ShowOrderCount() 
        {
            Console.WriteLine($"Beställningar i kö: { customerQueue.Count }");
        }
    }
}
