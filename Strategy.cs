using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Strategy
    {
        // Strategy Interface
        public interface IPaymentStrategy
        {
            void ProcessPayment(double amount);
        }

        // Concrete Strategy 1: Credit Card Payment
        public class CreditCardPaymentStrategy : IPaymentStrategy
        {
            public void ProcessPayment(double amount)
            {
                // Process payment using credit card
                Console.WriteLine($"Processing credit card payment of ${amount}");
                // ... (implementation of credit card payment)
            }
        }

        // Concrete Strategy 2: PayPal Payment
        public class PayPalPaymentStrategy : IPaymentStrategy
        {
            public void ProcessPayment(double amount)
            {
                // Process payment using PayPal
                Console.WriteLine($"Processing PayPal payment of ${amount}");
                // ... (implementation of PayPal payment)
            }
        }

        // Context
        public class PaymentProcessor
        {
            private IPaymentStrategy _paymentStrategy;

            public PaymentProcessor(IPaymentStrategy paymentStrategy)
            {
                _paymentStrategy = paymentStrategy;
            }

            public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
            {
                _paymentStrategy = paymentStrategy;
            }

            public void Process(double amount)
            {
                _paymentStrategy.ProcessPayment(amount);
            }
        }
        //---------------------------------------------------------------------------------
        // Strategy Interface
        public interface ISortStrategy
        {
            void Sort(int[] array);
        }

        // Concrete Strategy 1: Bubble Sort
        public class BubbleSortStrategy : ISortStrategy
        {
            public void Sort(int[] array)
            {
                // Implement Bubble Sort algorithm
                Console.WriteLine("Sorting array using Bubble Sort");
                // ... (implementation of Bubble Sort)
            }
        }

        // Concrete Strategy 2: Quick Sort
        public class QuickSortStrategy : ISortStrategy
        {
            public void Sort(int[] array)
            {
                // Implement Quick Sort algorithm
                Console.WriteLine("Sorting array using Quick Sort");
                // ... (implementation of Quick Sort)
            }
        }

        // Context
        public class Sorter
        {
            private ISortStrategy _sortStrategy;

            public Sorter(ISortStrategy sortStrategy)
            {
                _sortStrategy = sortStrategy;
            }

            public void SetSortStrategy(ISortStrategy sortStrategy)
            {
                _sortStrategy = sortStrategy;
            }

            public void SortArray(int[] array)
            {
                _sortStrategy.Sort(array);
            }
        }


    }
}
