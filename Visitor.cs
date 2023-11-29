using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Visitor
    {

        // Visitor interface
        public interface IEmployeeVisitor
        {
            void Visit(Employee employee);
            void Visit(Manager manager);
            void Visit(Director director);
        }

        // Element interface
        public abstract class Employee
        {
            public abstract void Accept(IEmployeeVisitor visitor);
            public abstract double GetSalary();
        }

        // Concrete Element 1: Manager
        public class Manager : Employee
        {
            public override void Accept(IEmployeeVisitor visitor)
            {
                visitor.Visit(this);
            }

            public override double GetSalary()
            {
                return 5000; // Fixed salary for a manager
            }
        }

        // Concrete Element 2: Director
        public class Director : Employee
        {
            public override void Accept(IEmployeeVisitor visitor)
            {
                visitor.Visit(this);
            }

            public override double GetSalary()
            {
                return 10000; // Fixed salary for a director
            }
        }

        // Concrete Element 3: Team Member
        public class TeamMember : Employee
        {
            public override void Accept(IEmployeeVisitor visitor)
            {
                visitor.Visit(this);
            }

            public override double GetSalary()
            {
                return 3000; // Fixed salary for a team member
            }
        }

        // Concrete Visitor: SalaryCalculator
        public class SalaryCalculator : IEmployeeVisitor
        {
            private double _totalSalary;

            public void Visit(Employee employee)
            {
                _totalSalary += employee.GetSalary();
            }

            public void Visit(Manager manager)
            {
                _totalSalary += manager.GetSalary();
            }

            public void Visit(Director director)
            {
                _totalSalary += director.GetSalary();
            }

            public double TotalSalary => _totalSalary;
        }

        //-----------------------------------------------------------------------------------
        // Visitor interface
        public interface IShapeVisitor
        {
            void VisitCircle(Circle circle);
            void VisitRectangle(Rectangle rectangle);
        }

        // Element interface
        public interface IShape
        {
            void Accept(IShapeVisitor visitor);
        }

        // Concrete Element 1: Circle
        public class Circle : IShape
        {
            public double Radius { get; }

            public Circle(double radius)
            {
                Radius = radius;
            }

            public void Accept(IShapeVisitor visitor)
            {
                visitor.VisitCircle(this);
            }
        }

        // Concrete Element 2: Rectangle
        public class Rectangle : IShape
        {
            public double Width { get; }
            public double Height { get; }

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public void Accept(IShapeVisitor visitor)
            {
                visitor.VisitRectangle(this);
            }
        }

        // Concrete Visitor: AreaCalculator
        public class AreaCalculator : IShapeVisitor
        {
            public void VisitCircle(Circle circle)
            {
                double area = Math.PI * circle.Radius * circle.Radius;
                Console.WriteLine($"Area of circle: {area}");
            }

            public void VisitRectangle(Rectangle rectangle)
            {
                double area = rectangle.Width * rectangle.Height;
                Console.WriteLine($"Area of rectangle: {area}");
            }
        }

        // Concrete Visitor: PerimeterCalculator
        public class PerimeterCalculator : IShapeVisitor
        {
            public void VisitCircle(Circle circle)
            {
                double perimeter = 2 * Math.PI * circle.Radius;
                Console.WriteLine($"Perimeter of circle: {perimeter}");
            }

            public void VisitRectangle(Rectangle rectangle)
            {
                double perimeter = 2 * (rectangle.Width + rectangle.Height);
                Console.WriteLine($"Perimeter of rectangle: {perimeter}");
            }
        }
    }
}
