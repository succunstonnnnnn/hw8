//порушено принцип SRP. Клас EmailSender відповідає і за відправлення листів,
//і за логування. Треба розділити
class Email
{
    public string Theme { get; set; }
    public string From { get; set; }
    public string To { get; set; }
}

// Додаємо клас, що відповідає за логування
class Logger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
class EmailSender
{
    private readonly Logger _logger;

    public EmailSender(Logger logger)
    {
        _logger = logger;
    }

    public void Send(Email email)
    {
        // ... sending logic ...
        _logger.Log($"Email from '{email.From}' to '{email.To}' was sent");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger logger = new Logger();
        
        EmailSender emailSender = new EmailSender(logger);
        
        Email e1 = new Email { From = "Me", To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
        Email e3 = new Email { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email { From = "Vasya", To = "Me", Theme = "washing machines!" };
        Email e5 = new Email { From = "Me", To = "Vasya", Theme = "Yes" };
        Email e6 = new Email { From = "Vasya", To = "Petya", Theme = "+2" };
        
        emailSender.Send(e1);
        emailSender.Send(e2);
        emailSender.Send(e3);
        emailSender.Send(e4);
        emailSender.Send(e5);
        emailSender.Send(e6);
        
        Console.ReadKey();
    }
}