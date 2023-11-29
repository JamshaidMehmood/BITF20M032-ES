using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Template
    {
        // Abstract Class: Beverage
        public abstract class Beverage
        {
            public void PrepareBeverage()
            {
                BoilWater();
                Brew();
                PourInCup();
                if (CustomerWantsCondiments())
                {
                    AddCondiments();
                }
            }

            protected abstract void Brew();
            protected abstract void AddCondiments();

            protected void BoilWater()
            {
                Console.WriteLine("Boiling water");
            }

            protected void PourInCup()
            {
                Console.WriteLine("Pouring into cup");
            }

            // Hook method
            protected virtual bool CustomerWantsCondiments()
            {
                return true;
            }
        }

        // Concrete Class: Coffee
        public class Coffee : Beverage
        {
            protected override void Brew()
            {
                Console.WriteLine("Brewing coffee");
            }

            protected override void AddCondiments()
            {
                Console.WriteLine("Adding sugar and milk");
            }

            protected override bool CustomerWantsCondiments()
            {
                Console.WriteLine("Would you like sugar and milk? (y/n)");
                var input = Console.ReadLine();
                return input?.ToLower() == "y";
            }
        }

        // Concrete Class: Tea
        public class Tea : Beverage
        {
            protected override void Brew()
            {
                Console.WriteLine("Steeping the tea");
            }

            protected override void AddCondiments()
            {
                Console.WriteLine("Adding lemon");
            }
        }
        //---------------------------------------------------------------------------------
        // Abstract Class: Document
        public abstract class Document
        {
            public void CreateDocument()
            {
                CreateHeader();
                AddContent();
                CreateFooter();
            }

            protected abstract void CreateHeader();
            protected abstract void AddContent();
            protected abstract void CreateFooter();
        }

        // Concrete Class: Report Document
        public class ReportDocument : Document
        {
            protected override void CreateHeader()
            {
                Console.WriteLine("Creating Report Header");
            }

            protected override void AddContent()
            {
                Console.WriteLine("Adding Report Content");
            }

            protected override void CreateFooter()
            {
                Console.WriteLine("Creating Report Footer");
            }
        }

        // Concrete Class: Letter Document
        public class LetterDocument : Document
        {
            protected override void CreateHeader()
            {
                Console.WriteLine("Creating Letter Header");
            }

            protected override void AddContent()
            {
                Console.WriteLine("Adding Letter Content");
            }

            protected override void CreateFooter()
            {
                Console.WriteLine("Creating Letter Footer");
            }
        }

    }
}
