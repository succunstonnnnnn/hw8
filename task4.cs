//Працює зі знижками
interface IDiscountable
{
    void ApplyDiscount(string discount);
    void ApplyPromocode(string promocode);
}

// Працює з розмірами
interface ISizedItem
{
    void SetSize(byte size);
}

//Працює з кольором
interface IColoredItem
{
    void SetColor(byte color);
}

//Працює з ціною
interface IPricedItem
{
    void SetPrice(double price);
}
class Book : IPricedItem, IDiscountable
{
    public double Price { get; private set; }

    public void SetPrice(double price)
    {
        Price = price;
        Console.WriteLine($"Book price set to: {price}");
    }

    public void ApplyDiscount(string discount)
    {
        Console.WriteLine($"Applied discount: {discount} to the book");
    }

    public void ApplyPromocode(string promocode)
    {
        Console.WriteLine($"Applied promocode: {promocode} to the book");
    }
}

class Outerwear : IPricedItem, IDiscountable, ISizedItem, IColoredItem
{
    public double Price { get; private set; }
    public byte Size { get; private set; }
    public byte Color { get; private set; }

    public void SetPrice(double price)
    {
        Price = price;
        Console.WriteLine($"Outerwear price set to: {price}");
    }

    public void ApplyDiscount(string discount)
    {
        Console.WriteLine($"Applied discount: {discount} to the outerwear");
    }

    public void ApplyPromocode(string promocode)
    {
        Console.WriteLine($"Applied promocode: {promocode} to the outerwear");
    }

    public void SetSize(byte size)
    {
        Size = size;
        Console.WriteLine($"Outerwear size set to: {size}");
    }

    public void SetColor(byte color)
    {
        Color = color;
        Console.WriteLine($"Outerwear color set to: {color}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();
        book.SetPrice(19.99);
        book.ApplyDiscount("10%");
        book.ApplyPromocode("SUMMER2024");

        Outerwear outerwear = new Outerwear();
        outerwear.SetPrice(99.99);
        outerwear.ApplyDiscount("15%");
        outerwear.ApplyPromocode("WINTER2024");
        outerwear.SetSize(42);
        outerwear.SetColor(3); // Умовно: 3 = червоний

        Console.ReadKey();
    }
}
