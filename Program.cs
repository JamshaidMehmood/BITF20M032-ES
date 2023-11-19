using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment_6
{
    /* Singelton method
     ** 
     ** 
     ** 
     */

    public class SingletonEager
    {
        private static readonly SingletonEager instance = new SingletonEager();

        private SingletonEager() 
        {
            Console.WriteLine("SingletonEager constructor called");
        }

        // lamda expression initialization of static constructor
        public static SingletonEager Instance
        {
            get { return instance; }
        }

        public void SomeMethod()
        {
            Console.WriteLine("SingletonEager SomeMethod called");
        }
    }

    public class SingletonLazy
    {
        private static SingletonLazy instance;
        private static readonly object padlock = new object();

        private SingletonLazy() 
        {
            Console.WriteLine("SingletonLazy constructor called");
        }

        public static SingletonLazy Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonLazy();
                    }
                    return instance;
                }
            }
        }

        public void SomeMethod()
        {
            Console.WriteLine("SingletonLazy SomeMethod called");
        }
    }

    /* Factory method
         ** 
         ** 
         ** 
         */
    public interface IProduct
    {
        void Operate();
    }

    // Concrete products
    public class ConcreteProductA : IProduct
    {
        public void Operate()
        {
            Console.WriteLine("Operating ConcreteProductA");
        }
    }

    public class ConcreteProductB : IProduct
    {
        public void Operate()
        {
            Console.WriteLine("Operating ConcreteProductB");
        }
    }

    // Factory class
    public class SimpleFactory
    {
        public IProduct CreateProduct(string productType)
        {
            switch (productType)
            {
                case "A":
                    return new ConcreteProductA();
                case "B":
                    return new ConcreteProductB();
                default:
                    throw new ArgumentException("Invalid product type");
            }
        }
    }


    // ---------------------------------------------------------------
    public interface IProduct1
    {
        void Operate1();
    }

    // Concrete products
    public class ConcreteProduct1A : IProduct1
    {
        public void Operate1()
        {
            Console.WriteLine("Operating ConcreteProduct1A");
        }
    }

    public class ConcreteProduct1B : IProduct1
    {
        public void Operate1()
        {
            Console.WriteLine("Operating ConcreteProduct1B");
        }
    }

    // Creator interface
    public interface ICreator1
    {
        IProduct1 FactoryMethod();
    }

    // Concrete creators
    public class ConcreteCreator1A : ICreator1
    {
        public IProduct1 FactoryMethod()
        {
            return new ConcreteProduct1A();
        }
    }

    public class ConcreteCreator1B : ICreator1
    {
        public IProduct1 FactoryMethod()
        {
            return new ConcreteProduct1B();
        }
    }

    /* Abstract Factory 
     * 
     * 
     * 
     * */
    public interface ICar
    {
        void Build();
    }

    public interface IBike
    {
        void Assemble();
    }

    // Concrete products implementing the interfaces
    public class Sedan : ICar
    {
        public void Build()
        {
            Console.WriteLine("Building Sedan car");
        }
    }

    public class SportsCar : ICar
    {
        public void Build()
        {
            Console.WriteLine("Building Sports car");
        }
    }

    public class MountainBike : IBike
    {
        public void Assemble()
        {
            Console.WriteLine("Assembling Mountain Bike");
        }
    }

    public class RoadBike : IBike
    {
        public void Assemble()
        {
            Console.WriteLine("Assembling Road Bike");
        }
    }

    // Abstract factory interface
    public interface IVehicleFactory
    {
        ICar CreateCar();
        IBike CreateBike();
    }

    // Concrete factory implementing the abstract factory
    public class LuxuryVehicleFactory : IVehicleFactory
    {
        public ICar CreateCar()
        {
            return new SportsCar();
        }

        public IBike CreateBike()
        {
            return new RoadBike();
        }
    }

    public class EconomyVehicleFactory : IVehicleFactory
    {
        public ICar CreateCar()
        {
            return new Sedan();
        }

        public IBike CreateBike()
        {
            return new MountainBike();
        }
    }
    //---------------------------------------------------------------------

    // Abstract product interfaces
    public interface IGUI
    {
        void Display();
    }

    public interface IKernel
    {
        void Execute();
    }

    // Concrete products implementing the interfaces
    public class WindowsGUI : IGUI
    {
        public void Display()
        {
            Console.WriteLine("Displaying Windows GUI");
        }
    }

    public class LinuxGUI : IGUI
    {
        public void Display()
        {
            Console.WriteLine("Displaying Linux GUI");
        }
    }

    public class WindowsKernel : IKernel
    {
        public void Execute()
        {
            Console.WriteLine("Executing Windows Kernel");
        }
    }

    public class LinuxKernel : IKernel
    {
        public void Execute()
        {
            Console.WriteLine("Executing Linux Kernel");
        }
    }

    // Abstract factory interface
    public interface IOperatingSystemFactory
    {
        IGUI CreateGUI();
        IKernel CreateKernel();
    }

    // Concrete factories implementing the abstract factory
    public class WindowsFactory : IOperatingSystemFactory
    {
        public IGUI CreateGUI()
        {
            return new WindowsGUI();
        }

        public IKernel CreateKernel()
        {
            return new WindowsKernel();
        }
    }

    public class LinuxFactory : IOperatingSystemFactory
    {
        public IGUI CreateGUI()
        {
            return new LinuxGUI();
        }

        public IKernel CreateKernel()
        {
            return new LinuxKernel();
        }
    }

    /* Builder
    *
    *
    */
    public class House
    {
        public string Foundation { get; set; }
        public string Walls { get; set; }
        public string Roof { get; set; }
        public string Interior { get; set; }

        public override string ToString()
        {
            return $"Foundation: {Foundation}, Walls: {Walls}, Roof: {Roof}, Interior: {Interior}";
        }
    }

    // Builder interface
    public interface IHouseBuilder
    {
        void BuildFoundation();
        void BuildWalls();
        void BuildRoof();
        void BuildInterior();
        House GetHouse();
    }

    // Concrete builder for different types of houses
    public class ConcreteHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildFoundation()
        {
            _house.Foundation = "Concrete foundation";
        }

        public void BuildWalls()
        {
            _house.Walls = "Concrete walls";
        }

        public void BuildRoof()
        {
            _house.Roof = "Concrete roof";
        }

        public void BuildInterior()
        {
            _house.Interior = "Basic interior";
        }

        public House GetHouse()
        {
            return _house;
        }
    }

    public class WoodenHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildFoundation()
        {
            _house.Foundation = "Wooden foundation";
        }

        public void BuildWalls()
        {
            _house.Walls = "Wooden walls";
        }

        public void BuildRoof()
        {
            _house.Roof = "Wooden roof";
        }

        public void BuildInterior()
        {
            _house.Interior = "Luxury interior";
        }

        public House GetHouse()
        {
            return _house;
        }
    }

    // Director class
    public class HouseDirector
    {
        private IHouseBuilder _builder;

        public HouseDirector(IHouseBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructHouse()
        {
            _builder.BuildFoundation();
            _builder.BuildWalls();
            _builder.BuildRoof();
            _builder.BuildInterior();
        }
    }
    // --------------------------------------------------------------------------

    // Product class
    public class Document
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}\nBody: {Body}\nFooter: {Footer}";
        }
    }

    // Builder interface
    public interface IDocumentBuilder
    {
        void BuildTitle();
        void BuildBody();
        void BuildFooter();
        Document GetDocument();
    }

    // Concrete builders for different types of documents
    public class FancyDocumentBuilder : IDocumentBuilder
    {
        private Document _document = new Document();

        public void BuildTitle()
        {
            _document.Title = "Fancy Title";
        }

        public void BuildBody()
        {
            _document.Body = "Fancy Body";
        }

        public void BuildFooter()
        {
            _document.Footer = "Fancy Footer";
        }

        public Document GetDocument()
        {
            return _document;
        }
    }

    public class SimpleDocumentBuilder : IDocumentBuilder
    {
        private Document _document = new Document();

        public void BuildTitle()
        {
            _document.Title = "Simple Title";
        }

        public void BuildBody()
        {
            _document.Body = "Simple Body";
        }

        public void BuildFooter()
        {
            _document.Footer = "Simple Footer";
        }

        public Document GetDocument()
        {
            return _document;
        }
    }

    // Director class
    public class DocumentDirector
    {
        private IDocumentBuilder _builder;

        public DocumentDirector(IDocumentBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructDocument()
        {
            _builder.BuildTitle();
            _builder.BuildBody();
            _builder.BuildFooter();
        }
    }
    
    /* Prototype
     * 
     * 
     * 
     */

    // Prototype interface
    public interface IColorPrototype
    {
        IColorPrototype Clone();
    }

    // Concrete prototypes
    public class Color : IColorPrototype
    {
        private string _colorName;

        public Color(string color)
        {
            _colorName = color;
        }

        public IColorPrototype Clone()
        {
            return new Color(_colorName);
        }

        public override string ToString()
        {
            return $"Color: {_colorName}";
        }
    }

    // Client class using prototypes
    // Client class using prototypes
    public class ColorManager
    {
        private readonly Dictionary<string, IColorPrototype> _colors =
            new Dictionary<string, IColorPrototype>();

        public IColorPrototype this[string key]
        {
            get => _colors[key].Clone();
            set => _colors.Add(key, value);
        }

        public Color GetColor(string key)
        {
            return (Color)_colors[key].Clone();
        }
    }

    //-----------------------------------------------------------------------------------
    // Prototype interface
    public interface IGraphicPrototype
    {
        IGraphicPrototype Clone();
        void Draw();
    }

    // Concrete prototypes
    public class Rectangle : IGraphicPrototype
    {
        public IGraphicPrototype Clone()
        {
            return new Rectangle();
        }

        public void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }

    public class Circle : IGraphicPrototype
    {
        public IGraphicPrototype Clone()
        {
            return new Circle();
        }

        public void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }

    // Client class using prototypes
    public class GraphicManager
    {
        private readonly System.Collections.Generic.Dictionary<string, IGraphicPrototype> _graphics =
            new System.Collections.Generic.Dictionary<string, IGraphicPrototype>();

        public IGraphicPrototype this[string key]
        {
            get => _graphics[key].Clone();
            set => _graphics.Add(key, value);
        }
    }
    //----------------------------------------------------------------------


    internal class Program
    {
        static void Main(string[] args)
        {
            SingletonEager instance1 = SingletonEager.Instance;
            SingletonEager instance2 = SingletonEager.Instance;
            // Output will be True
            // because Both references point to the same instance

            Console.WriteLine(object.ReferenceEquals(instance1, instance2)); 
            Console.WriteLine("---------------------------------------------------------");
           
            SingletonLazy instanc1 = SingletonLazy.Instance;
            SingletonLazy instanc2 = SingletonLazy.Instance;
            // Output: True
            // Both references point to the same instance
            
            Console.WriteLine(object.ReferenceEquals(instanc1, instanc2));
            Console.WriteLine("---------------------------------------------------------");

            SimpleFactory factory = new SimpleFactory();

            // Create products using the factory
            IProduct productA = factory.CreateProduct("A");
            IProduct productB = factory.CreateProduct("B");

            // Operate on products
            productA.Operate(); // Output: Operating ConcreteProductA
            productB.Operate(); // Output: Operating ConcreteProductB
            Console.WriteLine("---------------------------------------------------------");

            // Create concrete creators
            ICreator1 creatorA = new ConcreteCreator1A();
            ICreator1 creatorB = new ConcreteCreator1B();

            // Use creators to create products
            IProduct1 product1A = creatorA.FactoryMethod();
            IProduct1 product1B = creatorB.FactoryMethod();

            // Operate on products
            product1A.Operate1(); // Output: Operating ConcreteProductA
            product1B.Operate1(); // Output: Operating ConcreteProductB
            Console.WriteLine("---------------------------------------------------------");

            IVehicleFactory factory1;

            // Use a luxury vehicle factory
            factory1 = new LuxuryVehicleFactory();
            BuildVehicles(factory1);

            // Use an economy vehicle factory
            factory1 = new EconomyVehicleFactory();
            BuildVehicles(factory1);
            Console.WriteLine("---------------------------------------------------------");

            IOperatingSystemFactory factory2;

            // Use a Windows operating system factory
            factory2 = new WindowsFactory();
            SetupOS(factory2);

            // Use a Linux operating system factory
            factory2 = new LinuxFactory();
            SetupOS(factory2);
            Console.WriteLine("---------------------------------------------------------");
            
            // Create a concrete house builder
            IHouseBuilder concreteHouseBuilder = new ConcreteHouseBuilder();
            HouseDirector director = new HouseDirector(concreteHouseBuilder);

            // Construct a concrete house
            director.ConstructHouse();
            House concreteHouse = concreteHouseBuilder.GetHouse();
            Console.WriteLine("Concrete House constructed:");
            Console.WriteLine(concreteHouse);

            // Create a wooden house builder
            IHouseBuilder woodenHouseBuilder = new WoodenHouseBuilder();
            director = new HouseDirector(woodenHouseBuilder);

            // Construct a wooden house
            director.ConstructHouse();
            House woodenHouse = woodenHouseBuilder.GetHouse();
            Console.WriteLine("\nWooden House constructed:");
            Console.WriteLine(woodenHouse);
            Console.WriteLine("---------------------------------------------------------");

            // Create a fancy document builder
            IDocumentBuilder fancyDocumentBuilder = new FancyDocumentBuilder();
            DocumentDirector director1 = new DocumentDirector(fancyDocumentBuilder);

            // Construct a fancy document
            director1.ConstructDocument();
            Document fancyDocument = fancyDocumentBuilder.GetDocument();
            Console.WriteLine("Fancy Document created:");
            Console.WriteLine(fancyDocument);

            // Create a simple document builder
            IDocumentBuilder simpleDocumentBuilder = new SimpleDocumentBuilder();
            director1 = new DocumentDirector(simpleDocumentBuilder);

            // Construct a simple document
            director1.ConstructDocument();
            Document simpleDocument = simpleDocumentBuilder.GetDocument();
            Console.WriteLine("\nSimple Document created:");
            Console.WriteLine(simpleDocument);
            Console.WriteLine("---------------------------------------------------------");

            ColorManager colorManager = new ColorManager();

            // Add color prototypes
            colorManager["red"] = new Color("Red");
            colorManager["blue"] = new Color("Blue");

            // Clone and use color prototypes
            Color red = (Color)colorManager["red"].Clone();
            Console.WriteLine(red); // Output: Color: Red

            Color blue = (Color)colorManager["blue"].Clone();
            Console.WriteLine(blue); // Output: Color: Blue
            Console.WriteLine("---------------------------------------------------------");

            GraphicManager graphicManager = new GraphicManager();

            // Add graphic prototypes
            graphicManager["rectangle"] = new Rectangle();
            graphicManager["circle"] = new Circle();

            // Clone and use graphic prototypes
            IGraphicPrototype rectangle = graphicManager["rectangle"].Clone();
            rectangle.Draw(); // Output: Drawing a rectangle

            IGraphicPrototype circle = graphicManager["circle"].Clone();
            circle.Draw(); // Output: Drawing a circle

            Console.WriteLine("---------------------------------------------------------");

        }
        static void BuildVehicles(IVehicleFactory factory)
        {
            ICar car = factory.CreateCar();
            IBike bike = factory.CreateBike();

            car.Build();
            bike.Assemble();

            Console.WriteLine();
        }
        //------------------------------------------
        static void SetupOS(IOperatingSystemFactory factory)
        {
            IGUI gui = factory.CreateGUI();
            IKernel kernel = factory.CreateKernel();

            gui.Display();
            kernel.Execute();

            Console.WriteLine();
        }
    }
}
