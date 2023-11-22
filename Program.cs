using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    /* Adapter Pattern
     * 
     * 
     */
    class EuropeanSocket
    {
        public int GetVoltage()
        {
            return 230;
        }
    }

    // Target: Expected interface
    interface IUSASocketInterface
    {
        int GetVoltage();
    }

    // Adapter: Adapts EuropeanSocket to IUSASocketInterface
    class EuropeanToUSAdapter : IUSASocketInterface
    {
        private EuropeanSocket socket;

        public EuropeanToUSAdapter(EuropeanSocket socket)
        {
            this.socket = socket;
        }

        public int GetVoltage()
        {
            return socket.GetVoltage() / 2; // Adapting voltage for USA usage
        }
    }

    // Client code
    class Laptop
    {
        private IUSASocketInterface power;

        public Laptop(IUSASocketInterface power)
        {
            this.power = power;
        }

        public int GetPower()
        {
            return power.GetVoltage();
        }
    }
    // 2nd example
    // Adaptee: Incompatible class to be adapted
    class FaxMachine
    {
        public void SendFax(string recipient, string document)
        {
            Console.WriteLine($"Sending fax to {recipient} with document: {document}");
        }
    }

    // Target: Expected interface
    interface IEmailService
    {
        void SendEmail(string recipient, string content);
    }

    // Adapter: Adapts FaxMachine to IEmailService
    class FaxToEmailAdapter : IEmailService
    {
        private FaxMachine faxMachine;

        public FaxToEmailAdapter(FaxMachine faxMachine)
        {
            this.faxMachine = faxMachine;
        }

        public void SendEmail(string recipient, string content)
        {
            // Emulating email by converting content and recipient to a fax format
            string faxContent = $"Email Content:\n{content}\n---End of Email---";
            string faxRecipient = $"Email converted to Fax:\nTo: {recipient}";

            faxMachine.SendFax(faxRecipient, faxContent);
        }
    }

    // Client code (Using EmailService)
    class EmailClient
    {
        private IEmailService emailService;

        public EmailClient(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public void SendEmail(string recipient, string content)
        {
            emailService.SendEmail(recipient, content);
        }
    }
    /* Composite Pattern
     * 
     * 
     */
    interface IGraphic
    {
        void Render();
    }

    // Leaf class: Represents individual graphic objects
    class Line : IGraphic
    {
        public void Render()
        {
            Console.WriteLine("Rendered Line");
        }
    }

    class Circle : IGraphic
    {
        public void Render()
        {
            Console.WriteLine("Rendered Circle");
        }
    }

    // Composite class: Represents complex graphic objects composed of children
    class CompoundGraphic : IGraphic
    {
        private List<IGraphic> children = new List<IGraphic>();

        public void Render()
        {
            Console.WriteLine("Rendered Compound Graphic");
            foreach (var child in children)
            {
                child.Render();
            }
        }

        public void Add(IGraphic graphic)
        {
            children.Add(graphic);
        }

        public void Remove(IGraphic graphic)
        {
            children.Remove(graphic);
        }
    }
    // 2nd example
    // Component interface: Defines the common operations
    interface IFileSystemComponent
    {
        void Display(int depth);
    }

    // Leaf class: Represents individual files
    class File : IFileSystemComponent
    {
        private readonly string name;

        public File(string name)
        {
            this.name = name;
        }

        public void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " File: " + name);
        }
    }

    // Composite class: Represents folders composed of files or subfolders
    class Folder : IFileSystemComponent
    {
        private readonly string name;
        private List<IFileSystemComponent> components = new List<IFileSystemComponent>();

        public Folder(string name)
        {
            this.name = name;
        }

        public void Add(IFileSystemComponent component)
        {
            components.Add(component);
        }

        public void Remove(IFileSystemComponent component)
        {
            components.Remove(component);
        }

        public void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " Folder: " + name);
            foreach (var component in components)
            {
                component.Display(depth + 2);
            }
        }
    }
    /* Proxy pattern
     * 
     * 
     */
    // Subject interface: Defines the common interface for RealSubject and Proxy
    interface IImage
    {
        void Display();
    }

    // RealSubject class: Represents the actual object to be accessed through the Proxy
    class HighResolutionImage : IImage
    {
        private readonly string filename;

        public HighResolutionImage(string filename)
        {
            this.filename = filename;
            LoadImageFromDisk();
        }

        private void LoadImageFromDisk()
        {
            Console.WriteLine("Loading image from disk: " + filename);
        }

        public void Display()
        {
            Console.WriteLine("Displaying image: " + filename);
        }
    }

    // Proxy class: Controls access to the RealSubject
    class ImageProxy : IImage
    {
        private readonly string filename;
        private HighResolutionImage image;

        public ImageProxy(string filename)
        {
            this.filename = filename;
        }

        public void Display()
        {
            if (image == null)
            {
                image = new HighResolutionImage(filename);
            }
            image.Display();
        }
    }
    // 2nd example
    // Subject interface: Defines the common interface for RealSubject and Proxy
    interface IRemoteService
    {
        void PerformAction();
    }

    // RealSubject class: Represents the actual object accessed remotely
    class RemoteService : IRemoteService
    {
        private readonly string endpoint;

        public RemoteService(string endpoint)
        {
            this.endpoint = endpoint;
            ConnectToRemote();
        }

        private void ConnectToRemote()
        {
            Console.WriteLine("Connected to remote service at: " + endpoint);
        }

        public void PerformAction()
        {
            Console.WriteLine("Performing action on remote service");
        }
    }

    // Proxy class: Controls access to the RealSubject through remote connection
    class RemoteProxy : IRemoteService
    {
        private readonly string endpoint;
        private RemoteService service;

        public RemoteProxy(string endpoint)
        {
            this.endpoint = endpoint;
        }

        public void PerformAction()
        {
            if (service == null)
            {
                service = new RemoteService(endpoint);
            }
            service.PerformAction();
        }
    }
    /* Flyweight
     * 
     * 
     */
    // Flyweight interface: Defines the common interface for flyweights
    interface ITextFormatter
    {
        void Format(string text);
    }

    // Concrete flyweight: Represents a specific font style
    class Font : ITextFormatter
    {
        private readonly string name;
        private readonly int size;

        public Font(string name, int size)
        {
            this.name = name;
            this.size = size;
        }

        public void Format(string text)
        {
            Console.WriteLine($"Formatting '{text}' using Font {name}, Size {size}");
        }
    }

    // Flyweight factory: Manages creation and reuse of flyweight objects
    class FontFactory
    {
        private readonly Dictionary<string, Font> fonts = new Dictionary<string, Font>();

        public Font GetFont(string name, int size)
        {
            string key = $"{name}-{size}";
            if (!fonts.ContainsKey(key))
            {
                fonts[key] = new Font(name, size);
            }
            return fonts[key];
        }
    }
    // 2nd example
    // Flyweight interface: Defines the common interface for flyweights
    interface IShape
    {
        void Draw(int x, int y);
    }

    // Concrete flyweight: Represents a specific shape
    class Circle1 : IShape
    {
        private readonly string color;

        public Circle1(string color)
        {
            this.color = color;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"Drawing {color} circle at ({x}, {y})");
        }
    }

    // Flyweight factory: Manages creation and reuse of flyweight objects
    class ShapeFactory
    {
        private readonly Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

        public IShape GetCircle(string color)
        {
            if (!shapes.ContainsKey(color))
            {
                shapes[color] = new Circle1(color);
            }
            return shapes[color];
        }
    }
    /* Facade pattern
     * 
     * 
     */
    // Subsystem classes: Represents various components of a home theater system
    class Amplifier
    {
        public void TurnOn()
        {
            Console.WriteLine("Amplifier: Turning on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Amplifier: Turning off");
        }
    }

    class DvdPlayer
    {
        public void TurnOn()
        {
            Console.WriteLine("DVD Player: Turning on");
        }

        public void TurnOff()
        {
            Console.WriteLine("DVD Player: Turning off");
        }

        public void Play()
        {
            Console.WriteLine("DVD Player: Playing");
        }
    }

    class Projector
    {
        public void TurnOn()
        {
            Console.WriteLine("Projector: Turning on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Projector: Turning off");
        }
    }

    // Facade class: Provides a simplified interface to the complex subsystem
    class HomeTheaterFacade
    {
        private readonly Amplifier amp;
        private readonly DvdPlayer dvd;
        private readonly Projector projector;

        public HomeTheaterFacade()
        {
            amp = new Amplifier();
            dvd = new DvdPlayer();
            projector = new Projector();
        }

        public void WatchMovie()
        {
            Console.WriteLine("Get ready to watch a movie...");
            amp.TurnOn();
            dvd.TurnOn();
            projector.TurnOn();
            dvd.Play();
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting down the movie...");
            dvd.TurnOff();
            projector.TurnOff();
            amp.TurnOff();
        }
    }
    // 2nd example
    // Subsystem classes: Represents various components of an online shopping system
    class InventorySystem
    {
        public void CheckAvailability(string product)
        {
            Console.WriteLine($"Checking availability of {product}");
        }
    }

    class PaymentSystem
    {
        public void MakePayment(decimal amount)
        {
            Console.WriteLine($"Making payment of {amount}");
        }
    }

    class ShippingSystem
    {
        public void ShipProduct(string product)
        {
            Console.WriteLine($"Shipping {product}");
        }
    }

    // Facade class: Provides a simplified interface to the complex subsystem
    class OnlineShoppingFacade
    {
        private readonly InventorySystem inventory;
        private readonly PaymentSystem payment;
        private readonly ShippingSystem shipping;

        public OnlineShoppingFacade()
        {
            inventory = new InventorySystem();
            payment = new PaymentSystem();
            shipping = new ShippingSystem();
        }

        public void BuyProduct(string product, decimal amount)
        {
            Console.WriteLine("Starting online shopping process...");
            inventory.CheckAvailability(product);
            payment.MakePayment(amount);
            shipping.ShipProduct(product);
            Console.WriteLine("Shopping process completed successfully!");
        }
    }

    /* Bridge Pattern
    *
    *
    */
    // Implementor interface
public interface IDrawingAPI
{
    void DrawCircle(int x, int y, int radius);
}

// Concrete Implementor A
public class DrawingAPI1 : IDrawingAPI
{
    public void DrawCircle(int x, int y, int radius)
    {
        Console.WriteLine($"API1.circle at {x}:{y} radius {radius}");
    }
}

// Concrete Implementor B
public class DrawingAPI2 : IDrawingAPI
{
    public void DrawCircle(int x, int y, int radius)
    {
        Console.WriteLine($"API2.circle at {x}:{y} radius {radius}");
    }
}

// Abstraction
public abstract class Shape
{
    protected IDrawingAPI drawingAPI;

    protected Shape(IDrawingAPI drawingAPI)
    {
        this.drawingAPI = drawingAPI;
    }

    public abstract void Draw();
}

// Refined Abstraction
public class CircleShape : Shape
{
    private int x, y, radius;

    public CircleShape(int x, int y, int radius, IDrawingAPI drawingAPI) : base(drawingAPI)
    {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    public override void Draw()
    {
        drawingAPI.DrawCircle(x, y, radius);
    }
}
// 2nd example
// Implementor interface
public interface IDevice
{
    bool IsEnabled { get; }
    void Enable();
    void Disable();
}

// Concrete Implementor A
public class TV : IDevice
{
    private bool isEnabled = false;

    public bool IsEnabled { get { return isEnabled; } }

    public void Enable()
    {
        isEnabled = true;
    }

    public void Disable()
    {
        isEnabled = false;
    }
}

// Concrete Implementor B
public class Radio : IDevice
{
    private bool isEnabled = false;

    public bool IsEnabled { get { return isEnabled; } }

    public void Enable()
    {
        isEnabled = true;
    }

    public void Disable()
    {
        isEnabled = false;
    }
}

// Abstraction
public abstract class Remote
{
    protected IDevice device;

    protected Remote(IDevice device)
    {
        this.device = device;
    }

    public abstract void TogglePower();
}

// Refined Abstraction
public class RemoteControl : Remote
{
    public RemoteControl(IDevice device) : base(device)
    {
    }

    public override void TogglePower()
    {
        if (device.IsEnabled)
        {
            device.Disable();
            Console.WriteLine("Turned off");
        }
        else
        {
            device.Enable();
            Console.WriteLine("Turned on");
        }
    }
}

/*
*
*
*/
// Component interface
public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Concrete component
public class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double GetCost()
    {
        return 1.0;
    }
}

// Decorator
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee decoratedCoffee;

    public CoffeeDecorator(ICoffee decoratedCoffee)
    {
        this.decoratedCoffee = decoratedCoffee;
    }

    public virtual string GetDescription()
    {
        return decoratedCoffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return decoratedCoffee.GetCost();
    }
}

// Concrete Decorator A
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee decoratedCoffee) : base(decoratedCoffee)
    {
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, with Milk";
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.5;
    }
}

// Concrete Decorator B
public class WhipDecorator : CoffeeDecorator
{
    public WhipDecorator(ICoffee decoratedCoffee) : base(decoratedCoffee)
    {
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, with Whip";
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.7;
    }
}
// 2nd example
// Component interface
public interface INotifier
{
    void SendNotification(string message);
}

// Concrete component
public class EmailNotifier : INotifier
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Email notification: {message}");
    }
}

// Decorator
public abstract class NotifierDecorator : INotifier
{
    protected INotifier notifier;

    public NotifierDecorator(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public virtual void SendNotification(string message)
    {
        notifier.SendNotification(message);
    }
}

// Concrete Decorator A
public class SMSDecorator : NotifierDecorator
{
    public SMSDecorator(INotifier notifier) : base(notifier)
    {
    }

    public override void SendNotification(string message)
    {
        base.SendNotification(message);
        Console.WriteLine($"SMS notification: {message}");
    }
}

// Concrete Decorator B
public class LoggingDecorator : NotifierDecorator
{
    public LoggingDecorator(INotifier notifier) : base(notifier)
    {
    }

    public override void SendNotification(string message)
    {
        Console.WriteLine($"Logging notification: {message}");
        base.SendNotification(message);
    }
}


    
    internal class Program
    {
        static void Main(string[] args)
        {
            EuropeanSocket europeanSocket = new EuropeanSocket();
            EuropeanToUSAdapter adapter = new EuropeanToUSAdapter(europeanSocket);
            Laptop laptop = new Laptop(adapter);

            Console.WriteLine($"Laptop power: {laptop.GetPower()}V (Expected: 115V)");
            Console.WriteLine("-----------------------------------------------------");
            FaxMachine faxMachine = new FaxMachine();
            FaxToEmailAdapter adapte = new FaxToEmailAdapter(faxMachine);
            EmailClient emailClient = new EmailClient(adapte);

            emailClient.SendEmail("jamshaidmehmood123@gmail.com", "Hello, this is a email is for you!");
            Console.WriteLine("-----------------------------------------------------");

            Line line = new Line();
            Circle circle = new Circle();
            CompoundGraphic compound = new CompoundGraphic();
            compound.Add(line);
            compound.Add(circle);

            // Rendering individual elements
            line.Render();
            circle.Render();

            // Rendering compound graphic
            compound.Render();
            Console.WriteLine("-----------------------------------------------------");

            File file1 = new File("File1.txt");
            File file2 = new File("File2.jpg");
            File file3 = new File("File3.doc");

            Folder folder1 = new Folder("Folder 1");
            folder1.Add(file1);
            folder1.Add(file2);

            Folder folder2 = new Folder("Folder 2");
            folder2.Add(file3);

            Folder root = new Folder("Root");
            root.Add(folder1);
            root.Add(folder2);

            // Displaying the file system hierarchy
            root.Display(0);
            Console.WriteLine("-----------------------------------------------------");
            // Using the proxy to display the image
            IImage image = new ImageProxy("sample_image.jpg");
            image.Display();
            Console.WriteLine("-----------------------------------------------------");
            // Using the proxy to perform an action on the remote service
            IRemoteService proxy = new RemoteProxy("http://remote-service.com/api");
            proxy.PerformAction();
            Console.WriteLine("-----------------------------------------------------");
            FontFactory fontFactory = new FontFactory();

            ITextFormatter font1 = fontFactory.GetFont("Arial", 12);
            font1.Format("Hello");

            ITextFormatter font2 = fontFactory.GetFont("Times New Roman", 14);
            font2.Format("Flyweight");

            ITextFormatter font3 = fontFactory.GetFont("Arial", 12);
            font3.Format("Design Pattern");

            Console.WriteLine("-----------------------------------------------------");
            ShapeFactory shapeFactory = new ShapeFactory();

            IShape redCircle = shapeFactory.GetCircle("Red");
            redCircle.Draw(100, 100);

            IShape blueCircle = shapeFactory.GetCircle("Blue");
            blueCircle.Draw(200, 200);

            IShape anotherRedCircle = shapeFactory.GetCircle("Red");
            anotherRedCircle.Draw(300, 300);

            Console.WriteLine("-----------------------------------------------------");
            HomeTheaterFacade homeTheater = new HomeTheaterFacade();

            // Watching a movie using the facade
            homeTheater.WatchMovie();

            // Ending the movie using the facade
            homeTheater.EndMovie();
            Console.WriteLine("-----------------------------------------------------");
            OnlineShoppingFacade onlineShopping = new OnlineShoppingFacade();

            // Buying a product using the facade
            onlineShopping.BuyProduct("Smartphone", 599.99m);
            Console.WriteLine("-----------------------------------------------------");
            CircleShape circle1 = new CircleShape(1, 2, 3, new DrawingAPI1());
            circle1.Draw();

            CircleShape circle2 = new CircleShape(5, 7, 11, new DrawingAPI2());
            circle2.Draw();

            Console.WriteLine("-----------------------------------------------------");
            RemoteControl tvRemote = new RemoteControl(new TV());
            RemoteControl radioRemote = new RemoteControl(new Radio());

            tvRemote.TogglePower(); // Turned on
            Console.WriteLine(tvRemote.device.IsEnabled); // True

            radioRemote.TogglePower(); // Turned on
            Console.WriteLine(radioRemote.device.IsEnabled); // True

            tvRemote.TogglePower(); // Turned off
            Console.WriteLine(tvRemote.device.IsEnabled); // False
            Console.WriteLine("-----------------------------------------------------");

            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine(coffee.GetDescription() + " $" + coffee.GetCost());

            coffee = new MilkDecorator(coffee);
            Console.WriteLine(coffee.GetDescription() + " $" + coffee.GetCost());

            coffee = new WhipDecorator(coffee);
            Console.WriteLine(coffee.GetDescription() + " $" + coffee.GetCost());
            Console.WriteLine("-----------------------------------------------------");

            INotifier notifier = new EmailNotifier();
            notifier.SendNotification("Sample notification");

            notifier = new SMSDecorator(notifier);
            notifier.SendNotification("Another notification");

            notifier = new LoggingDecorator(notifier);
            notifier.SendNotification("Final notification");
            Console.WriteLine("-----------------------------------------------------");




        }
    }
}
