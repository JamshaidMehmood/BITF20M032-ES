using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static Assignment_7.Iterator;
using static Assignment_7.Memento;
using static Assignment_7.Interpreter;
using static Assignment_7.Visitor;
using static Assignment_7.State;
using static Assignment_7.Command;
using static Assignment_7.Strategy;
using static Assignment_7.Template;
using static Assignment_7.Mediator;
using static Assignment_7.ChainOfResponsibility;
using static Assignment_7.Observer;

namespace Assignment_7
{   
    internal class Program
    {
        static void Main(string[] args)
        {
           
            SettingsManager settingsManager = new SettingsManager();
            SettingsHistory history = new SettingsHistory();

            // Initial settings
            settingsManager.Theme = "Dark";
            settingsManager.FontSize = 14;

            // Save settings
            history.Memento = settingsManager.Save();

            // Modify settings
            settingsManager.Theme = "Light";
            settingsManager.FontSize = 16;

            // Restore settings (undo)
            settingsManager.Restore(history.Memento);


            TextEditor editor = new TextEditor();
            TextEditorHistory history1 = new TextEditorHistory();

            // Initial state
            editor.Text = "Hello";

            // Save state
            history1.Push(editor.Save());

            // Modify state
            editor.Text += ", World!";

            // Save state
            history1.Push(editor.Save());

            // Restore to previous state (undo)
            editor.Restore(history1.Pop());

            Console.WriteLine($"Current text: {editor.Text}");


            Console.WriteLine("-------------------------------------------------------------------");

            int[] data = { 1, 3, 5, 7, 9 };
            CustomList list = new CustomList(data);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }



            string[] items = { "Apple", "Orange", "Banana", "Grapes" };
            CustomCollection collection = new CustomCollection(items);

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------------------------------------------------------");

            // Interpret the date expression: year(2023), month(11), day(29)
            IDateExpression expression = new DayExpression(
                new MonthExpression(
                    new YearExpression(2023),
                    11),
                29);

            DateTime date = expression.Interpret();
            Console.WriteLine($"Interpreted Date: {date}");


            // 10 + (20 - 5)
            IExpression expression1 = new Addition(
                new Number(10),
                new Subtraction(new Number(20), new Number(5))
            );

            int result = expression1.Interpret();
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("-------------------------------------------------------------------");
            List<Employee> employees = new List<Employee>
        {
                new Manager(),
            new Director(),
            new TeamMember(),
            new TeamMember(),
            new TeamMember()
        };

            var salaryCalculator = new SalaryCalculator();

            foreach (var employee in employees)
            {
                employee.Accept(salaryCalculator);
            }

            Console.WriteLine($"Total salary of all employees: {salaryCalculator.TotalSalary}");


            List<IShape> shapes = new List<IShape>
        {
            new Circle(5),
            new Rectangle(3, 4)
        };

            var areaCalculator = new AreaCalculator();
            var perimeterCalculator = new PerimeterCalculator();

            foreach (var shape in shapes)
            {
                shape.Accept(areaCalculator);
                shape.Accept(perimeterCalculator);
            }
            Console.WriteLine("-------------------------------------------------------------------");

            Fan fan = new Fan();

            // Control fan speed changes
            fan.ChangeSpeed(); // Off to Low
            fan.ChangeSpeed(); // Low to Medium
            fan.ChangeSpeed(); // Medium to High
            fan.ChangeSpeed(); // High to Off

            Console.WriteLine("-------------------------------------------------------------------");

            TrafficLight trafficLight = new TrafficLight();

            // Simulate traffic light changes
            trafficLight.ChangeLight(); // Red to Green
            trafficLight.ChangeLight(); // Green to Yellow
            trafficLight.ChangeLight(); // Yellow to Red

            Console.WriteLine("-------------------------------------------------------------------");

            Editor editor1 = new Editor();
            TextEditor1 textEditor = new TextEditor1();

            // Performing cut and paste operations
            var cutCommand = new CutCommand(editor1);
            textEditor.ExecuteCommand(cutCommand);

            var pasteCommand = new PasteCommand(editor1, "Hello, ");
            textEditor.ExecuteCommand(pasteCommand);

            // Undoing the last operation (Paste)
            textEditor.Undo();


            Light livingRoomLight = new Light();

            ICommand turnOn = new TurnOnCommand(livingRoomLight);
            ICommand turnOff = new TurnOffCommand(livingRoomLight);

            RemoteControl remote = new RemoteControl();

            remote.SetCommand(turnOn);
            remote.PressButton(); // Turns on the light

            remote.SetCommand(turnOff);
            remote.PressButton(); // Turns off the light

            Console.WriteLine("-------------------------------------------------------------------");

            double paymentAmount = 100.50;

            // Using Credit Card payment strategy
            PaymentProcessor processor = new PaymentProcessor(new CreditCardPaymentStrategy());
            processor.Process(paymentAmount);

            // Using PayPal payment strategy
            processor.SetPaymentStrategy(new PayPalPaymentStrategy());
            processor.Process(paymentAmount);

            int[] arr = { 7, 2, 5, 1, 9 };

            // Using Bubble Sort
            Sorter sorter = new Sorter(new BubbleSortStrategy());
            sorter.SortArray(arr);

            // Using Quick Sort
            sorter.SetSortStrategy(new QuickSortStrategy());
            sorter.SortArray(arr);

            Console.WriteLine("-------------------------------------------------------------------");


            Console.WriteLine("Making tea...");
            Beverage tea = new Tea();
            tea.PrepareBeverage();

            Console.WriteLine("\nMaking coffee...");
            Beverage coffee = new Coffee();
            coffee.PrepareBeverage();

            Console.WriteLine("Creating a report document...");
            Document report = new ReportDocument();
            report.CreateDocument();

            Console.WriteLine("\nCreating a letter document...");
            Document letter = new LetterDocument();
            letter.CreateDocument();

            Console.WriteLine("-------------------------------------------------------------------");


            IAuctionMediator auction = new Auction();

            Bidder bidder1 = new AuctionParticipant(auction, "Alice");
            Bidder bidder2 = new AuctionParticipant(auction, "Bob");
            Bidder bidder3 = new AuctionParticipant(auction, "Charlie");

            auction.AddBidder(bidder1);
            auction.AddBidder(bidder2);
            auction.AddBidder(bidder3);

            bidder1.PlaceBid(100);
            bidder2.PlaceBid(150);
            bidder3.PlaceBid(120);

            IAirTrafficControl controlTower = new AirTrafficControlTower();

            Aircraft plane1 = new Airplane(controlTower, "Flight 101");
            Aircraft plane2 = new Airplane(controlTower, "Flight 202");
            Aircraft plane3 = new Airplane(controlTower, "Flight 303");

            controlTower.RegisterAircraft(plane1);
            controlTower.RegisterAircraft(plane2);
            controlTower.RegisterAircraft(plane3);

            plane1.SendMessage("Requesting landing clearance.");
            plane2.SendMessage("Inbound for landing.");
            plane3.SendMessage("Ready for departure.");

            Console.WriteLine("-------------------------------------------------------------------");
            // Create the chain of handlers
            Approver manager = new Manager1(1000);
            Approver director = new Director1(5000);

            manager.SetSuccessor(director);

            // Handling purchase requests
            Purchase purchase1 = new Purchase("Laptop", 800);
            Purchase purchase2 = new Purchase("Conference Table", 3000);
            Purchase purchase3 = new Purchase("Projector", 6000);

            manager.ProcessRequest(purchase1);
            manager.ProcessRequest(purchase2);
            manager.ProcessRequest(purchase3);

            // Create the chain of processors
            RequestProcessor lowPriorityProcessor = new LowPriorityProcessor();
            RequestProcessor mediumPriorityProcessor = new MediumPriorityProcessor();
            RequestProcessor highPriorityProcessor = new HighPriorityProcessor();

            lowPriorityProcessor.SetSuccessor(mediumPriorityProcessor);
            mediumPriorityProcessor.SetSuccessor(highPriorityProcessor);

            // Handling requests
            Request request1 = new Request(Priority.Medium);
            Request request2 = new Request(Priority.High);
            Request request3 = new Request(Priority.Low);

            lowPriorityProcessor.ProcessRequest(request1);
            lowPriorityProcessor.ProcessRequest(request2);
            lowPriorityProcessor.ProcessRequest(request3);
            
            Console.WriteLine("-------------------------------------------------------------------");


            WeatherStation weatherStation = new WeatherStation();
            WeatherDisplay display = new WeatherDisplay();

            weatherStation.Attach(display);

            // Simulate temperature change
            weatherStation.Temperature = 25;

            StockMarket stockMarket = new StockMarket();
            Investor investor1 = new Investor("Alice");
            Investor investor2 = new Investor("Bob");

            stockMarket.Attach(investor1);
            stockMarket.Attach(investor2);

            stockMarket.AddStock("AAPL", 150.0);
            stockMarket.AddStock("GOOGL", 2500.0);

            // Simulate stock price changes
            stockMarket.UpdateStockPrice("AAPL", 155.0);

        }
    }
}
