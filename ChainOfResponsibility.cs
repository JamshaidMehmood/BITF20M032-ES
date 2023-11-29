using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class ChainOfResponsibility
    {
        // Handler Interface
        public abstract class Approver
        {
            protected Approver _successor;
            protected int _approvalLimit;

            public void SetSuccessor(Approver successor)
            {
                _successor = successor;
            }

            public abstract void ProcessRequest(Purchase purchase);
        }

        // Concrete Handler: Manager
        public class Manager1 : Approver
        {
            public Manager1(int approvalLimit)
            {
                _approvalLimit = approvalLimit;
            }

            public override void ProcessRequest(Purchase purchase)
            {
                if (purchase.Amount <= _approvalLimit)
                {
                    Console.WriteLine($"Manager approves purchase of {purchase.ProductName}");
                }
                else if (_successor != null)
                {
                    _successor.ProcessRequest(purchase);
                }
            }
        }

        // Concrete Handler: Director
        public class Director1 : Approver
        {
            public Director1(int approvalLimit)
            {
                _approvalLimit = approvalLimit;
            }

            public override void ProcessRequest(Purchase purchase)
            {
                if (purchase.Amount <= _approvalLimit)
                {
                    Console.WriteLine($"Director approves purchase of {purchase.ProductName}");
                }
                else if (_successor != null)
                {
                    _successor.ProcessRequest(purchase);
                }
            }
        }

        // Request Class
        public class Purchase
        {
            public string ProductName { get; }
            public decimal Amount { get; }

            public Purchase(string productName, decimal amount)
            {
                ProductName = productName;
                Amount = amount;
            }
        }
        //-----------------------------------------------------------------------------------
        // Handler Interface
        public abstract class RequestProcessor
        {
            protected RequestProcessor _successor;

            public void SetSuccessor(RequestProcessor successor)
            {
                _successor = successor;
            }

            public abstract void ProcessRequest(Request request);
        }

        // Concrete Handler: LowPriorityProcessor
        public class LowPriorityProcessor : RequestProcessor
        {
            public override void ProcessRequest(Request request)
            {
                if (request.Priority == Priority.Low)
                {
                    Console.WriteLine($"Low priority request handled by LowPriorityProcessor");
                }
                else if (_successor != null)
                {
                    _successor.ProcessRequest(request);
                }
            }
        }

        // Concrete Handler: MediumPriorityProcessor
        public class MediumPriorityProcessor : RequestProcessor
        {
            public override void ProcessRequest(Request request)
            {
                if (request.Priority == Priority.Medium)
                {
                    Console.WriteLine($"Medium priority request handled by MediumPriorityProcessor");
                }
                else if (_successor != null)
                {
                    _successor.ProcessRequest(request);
                }
            }
        }

        // Concrete Handler: HighPriorityProcessor
        public class HighPriorityProcessor : RequestProcessor
        {
            public override void ProcessRequest(Request request)
            {
                if (request.Priority == Priority.High)
                {
                    Console.WriteLine($"High priority request handled by HighPriorityProcessor");
                }
                else if (_successor != null)
                {
                    _successor.ProcessRequest(request);
                }
            }
        }

        // Request Class
        public class Request
        {
            public Priority Priority { get; }

            public Request(Priority priority)
            {
                Priority = priority;
            }
        }

        public enum Priority
        {
            Low,
            Medium,
            High
        }

    }
}
