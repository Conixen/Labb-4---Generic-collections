using static System.Net.WebRequestMethods;

namespace Labb_4___Generic_collections
{
    internal class Program
    {
        static void Main(string[] args)                         // Leon SUT24
        {
            Console.WriteLine("Hello, World! Och välkommen till resturanté de SUT24");
            Console.WriteLine("Press any key to countinue...");
            Console.WriteLine("----------------------------------------------------"); 
            //1.Skapa ett nytt objekt av Restaurant-klassen.
            Restaurant restaurantSut24 = new Restaurant();
            //2.Lägg till fyra olika rätter i menyn.
            restaurantSut24.AddToMenu(new MenuItem(1, "Wagyu Kobe-biff", 1200m));
            restaurantSut24.AddToMenu(new MenuItem(2, "Veg Kobe-biff ", 200m));
            restaurantSut24.AddToMenu(new MenuItem(3, "Matsutakesvamp-risotto", 1100m));
            restaurantSut24.AddToMenu(new MenuItem(4, "Flugsvamp-risotto", 100m));
            Console.WriteLine("----------------------------------------------------");
            Console.ReadKey();
            //3.Skriv ut menyn.
            restaurantSut24.ShowMenu();
            Console.WriteLine("----------------------------------------------------");
            //4.Skapa 3 st nya ordrar, med minst två olika rätter i varje, och lägg till dem i orderkön
            //(du kan hitta på bordsnummer för beställningarna).
            List<MenuItem> order1 = new List<MenuItem> { new MenuItem(1, "Wagyu Kobe-biff", 1200m), new MenuItem(3, "Matsutakesvamp-risotto", 1100m) };
            List<MenuItem> order2 = new List<MenuItem> { new MenuItem(3, "Matsutakesvamp-risotto", 1100m), new MenuItem(2, "Veg Kobe-biff ", 200m) };
            List<MenuItem> order3 = new List<MenuItem> { new MenuItem(4, "Flugsvamp-risotto", 100m), new MenuItem(2, "Veg Kobe-biff ", 200m) };
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
            Console.ReadKey();
            //7.Visa nästa order på kö.
            restaurantSut24.ShowNextOrder();
            Console.ReadKey();
            //8.Hantera en order.
            restaurantSut24.HandleOrder();
            Console.ReadKey();
            //9.Visa antalet ordrar i kön.
            restaurantSut24.ShowOrderCount();
            Console.ReadKey();
            //10.Lägg till en ny order.
            List<MenuItem> order4 = new List<MenuItem> { 
                new MenuItem(1, "Wagyu Kobe-biff", 1200m), 
                new MenuItem(4, "Flugsvamp-risotto", 100m) 
            };
            restaurantSut24.CreateOrder(new Order(order4, 4));
            Console.ReadKey();
            //11.Visa antalet ordrar i kön.
            restaurantSut24.ShowOrderCount();
            Console.ReadKey();
            //12.Hantera två ordrar.
            restaurantSut24.ShowNextOrder();
            restaurantSut24.HandleOrder();
            Console.ReadKey();
            restaurantSut24.ShowNextOrder();
            restaurantSut24.HandleOrder();
            Console.ReadKey();
            //13.Visa antalet ordrar i kön.
            restaurantSut24.ShowOrderCount();
            Console.ReadKey();
            //14.Visa nästa order på kö.
            restaurantSut24.ShowNextOrder();
            Console.ReadKey();
            //15.Hantera en order.
            restaurantSut24.HandleOrder();
            Console.ReadKey();
            //16.Visa antalet ordrar i kön.
            restaurantSut24.ShowNextOrder();
            Console.ReadKey();
            Console.WriteLine("\nDe som beställde flugsvamp-risotto bör åka till sjukhuset...");
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
        // All info about the order id, what they ordered, table nummer 
        public override string ToString()
        {
            var items = string.Join(", ", _orderItems); // .Join orderitems from a list to string
            return $"Order {_orderId}  \nBord {_tableNumber}: \n{items}";
        }
    }
    public class Restaurant
    {
        public List<MenuItem> menu = new List<MenuItem> {};     // List for all items on the menu
        public Queue<Order> customerQueue = new Queue<Order>();     // A queue to manage customers and the orders


        public void AddToMenu(MenuItem menuItem)    // Add new menu item
        {
            menu.Add(menuItem);
            Console.WriteLine($"Matträtten { menuItem } är nu i menyn");
        }

        public void ShowMenu()  // Show all items in meny/resturant
        {
            Console.WriteLine("Meny");
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
        }
        public void CreateOrder (Order order)   // Adds new order to the queue
        {
            customerQueue.Enqueue(order);
            Console.WriteLine($"Beställningen är lagd för { order }");
        }
        public void HandleOrder()   // Handeling the next order in line/queue
        {
            Console.WriteLine("");
            if (customerQueue.Count > 0) 
            {
                var handlingOrder = customerQueue.Dequeue();

                Console.WriteLine($"Beställning { handlingOrder } är klar");
                Console.WriteLine("----------------------------------------------------");

            }
        }
        public void ShowOrder() // Shows all the orders in the queue
        {
            Console.WriteLine("");
            Console.WriteLine("Inväntande ordrar");
            foreach(var cQueue in customerQueue) 
            {
                Console.WriteLine(cQueue);
            }
        }
        public void ShowNextOrder() // Peeks and shows the neext order in queue
        {
            Console.WriteLine("");
            if (customerQueue.Count > 0)
            {
                var nextOrder = customerQueue.Peek();
                Console.WriteLine($"{nextOrder} förbereds ");
            }
            else 
            {
                Console.WriteLine("Finns inga mer beställningar");
            }
        }
        public void ShowOrderCount()    // Shows how many orders there are in queue
        {
            Console.WriteLine("");
            Console.WriteLine($"Beställningar i kö: { customerQueue.Count }");
        }
    }
}
