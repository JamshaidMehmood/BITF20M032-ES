using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Observer
    {
        // Subject: WeatherStation
        public class WeatherStation
        {
            private int _temperature;
            private List<IObserver> _observers = new List<IObserver>();

            public int Temperature
            {
                get => _temperature;
                set
                {
                    _temperature = value;
                    NotifyObservers();
                }
            }

            public void Attach(IObserver observer)
            {
                _observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                _observers.Remove(observer);
            }

            private void NotifyObservers()
            {
                foreach (var observer in _observers)
                {
                    observer.Update(Temperature);
                }
            }
        }

        // Observer Interface
        public interface IObserver
        {
            void Update(int temperature);
        }

        // Concrete Observer: WeatherDisplay
        public class WeatherDisplay : IObserver
        {
            public void Update(int temperature)
            {
                Console.WriteLine($"Weather Display: Temperature is {temperature} °C");
            }
        }

        //-----------------------------------------------------------------------------------------
        // Subject: StockMarket
        public class StockMarket
        {
            private Dictionary<string, double> _stockPrices = new Dictionary<string, double>();
            private List<IObserver> _observers = new List<IObserver>();

            public void AddStock(string stockName, double price)
            {
                _stockPrices[stockName] = price;
            }

            public void Attach(IObserver observer)
            {
                _observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                _observers.Remove(observer);
            }

            public void NotifyObservers()
            {
                foreach (var observer in _observers)
                {
                    observer.Update(_stockPrices);
                }
            }

            public void UpdateStockPrice(string stockName, double price)
            {
                _stockPrices[stockName] = price;
                NotifyObservers();
            }
        }

        // Observer Interface
        public interface IObserver
        {
            void Update(Dictionary<string, double> stockPrices);
        }

        // Concrete Observer: Investor
        public class Investor : IObserver
        {
            private readonly string _name;

            public Investor(string name)
            {
                _name = name;
            }

            public void Update(Dictionary<string, double> stockPrices)
            {
                Console.WriteLine($"{_name}: Stock prices updated");
                foreach (var stock in stockPrices)
                {
                    Console.WriteLine($"{stock.Key} price: {stock.Value}");
                }
            }
        }
    }
}
