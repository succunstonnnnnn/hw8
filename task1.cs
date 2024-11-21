//порушено принцип SRP, тому що в класі Order забагато дій.
//Крім виправлення додала ще клас program, щоб можна було запустити

class Item
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
//Додаємо клас з діями над товаром
class Order
{
    private List<Item> itemList = new();

    public IReadOnlyList<Item> Items => itemList;

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }

    public int GetItemCount()
    {
        return itemList.Count;
    }

    public decimal CalculateTotalSum()
    {
        return itemList.Sum(item => item.Price);
    }
}
//Додаємо клас для виведення інф про замовлення
class OrderPrinter
{
    public void PrintOrder(Order order)
    {
        Console.WriteLine("Order details:");
        foreach (var item in order.Items)
        {
            Console.WriteLine($"- {item.Name}: ${item.Price}");
        }
        Console.WriteLine($"Total: ${order.CalculateTotalSum()}");
    }
}

//Додаємл клас для збереження та завантаження даних
class OrderRepository
{
    public void Save(Order order)
    {
        Console.WriteLine("Saving order...");
    }

    public Order Load()
    {
        Console.WriteLine("Loading order...");
        return new Order();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var order = new Order();
        
        order.AddItem(new Item { Name = "Laptop", Price = 1200.00m });
        order.AddItem(new Item { Name = "Mouse", Price = 25.50m });
        
        var printer = new OrderPrinter();
        printer.PrintOrder(order);
        
        var repository = new OrderRepository();
        repository.Save(order);

        Console.WriteLine("Order saved successfully.");
    }
}