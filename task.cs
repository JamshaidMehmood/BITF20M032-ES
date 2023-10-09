using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Book
{
    public string Title 
    { get;
      set;
    }
    public string Author 
    { get;
      set;
    }

    // Constructor with optional author parameter
    public Book(string title, string author = "Unknown")
    {
        Title = title;
        Author = author;
    }
}

// Generics 
class MyList<T>
{
    private List<T> items = new List<T>();

    // Method to add an element to the list
    public void Add(T itemToAdd)
    {
        items.Add(itemToAdd);
    }

    // Method to remove an element from the list
    public void Remove(T itemToAdd)
    {
        items.Remove(itemToAdd);
    }

    // Method to display the list
    public void Display()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}



namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Greet();
            // Calling Greet with custom values for parameters
            Greet("Hellow", "Jamshaid");

            Console.WriteLine("------------------------------------------------");
            // Default values
            double area1 = CalculateArea(); 
            Console.WriteLine($"Area : {area1}"); 
            // Calling CalculateArea with custom values for parameters
            double area2 = CalculateArea(5.0, 3.0); 
            Console.WriteLine($"Area : {area2}");
            
            Console.WriteLine("------------------------------------------------");
            int sum1 = AddNumbers(5, 7);
            Console.WriteLine($"Sum : {sum1}"); 
            int sum2 = AddNumbers(3, 8, 2);
            Console.WriteLine($"Sum 2: {sum2}");

            Console.WriteLine("------------------------------------------------");
            Book book1 = new Book("python 3");
            Book book2 = new Book("Introduction to C++", "Tonny gaddis");

            Console.WriteLine("Book 1 Details:");
            Console.WriteLine($"Title: {book1.Title}");
            Console.WriteLine($"Author: {book1.Author}");
            Console.WriteLine("\nBook 2 Details:");
            Console.WriteLine($"Title: {book2.Title}");
            Console.WriteLine($"Author: {book2.Author}");
            
            
            Console.WriteLine("------------------------------------------------");
            MyList<int> intList = new MyList<int>();
            intList.Add(100);
            intList.Add(230);
            intList.Add(990);
            intList.Display();
            
            Console.WriteLine("------------------------------------------------");
            intList.Remove(230);
            intList.Display();

            Console.WriteLine("------------------------------------------------");
            // string lists names
            MyList<string> names = new MyList<string>();
            names.Add("Virat Kholi");
            names.Add("Babar Azam");
            names.Add("Aiden Markram");
            names.Display();

            Console.WriteLine("------------------------------------------------");
            int a = 18, b = 180;
            Console.WriteLine($"Before swapping: a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"After swapping: a = {a}, b = {b}");
            
            Console.WriteLine("------------------------------------------------");
            string str1 = "jam", str2 = "J.18";
            Console.WriteLine($"Before swapping: str1 = {str1}, str2 = {str2}");
            Swap(ref str1, ref str2);
            Console.WriteLine($"After swapping: str1 = {str1}, str2 = {str2}");

            Console.WriteLine("------------------------------------------------");
            int[] num = { 1, 2, 3, 4, 5 };
            double[] scores = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            
            // Calculate sum for intArray and doubleArray (valid)
            int intSum = CalculateSum(num);
            double doubleSum = CalculateSum(scores);
            Console.WriteLine($"Sum of integer Array: {intSum}");
            Console.WriteLine($"Sum of doubleArray: {doubleSum}");
            
            Console.WriteLine("------------------------------------------------");
            Dictionary<int, string> studentDatabase = new Dictionary<int, string>();

            // Add student records to the dictionary
            studentDatabase.Add(101, "Alice");
            studentDatabase.Add(102, "Bob");
            studentDatabase.Add(103, "Charlie");
            studentDatabase.Add(104, "David");

            // Display the student records
            Console.WriteLine("Student Database:");
            foreach (var record in studentDatabase)
            {
                Console.WriteLine($"Student ID: {record.Key}, Name: {record.Value}");
            }
        
            Console.WriteLine("------------------------------------------------");
            while (true)
            {
                Console.WriteLine("Student Database Menu:");
                Console.WriteLine("1. View the student database");
                Console.WriteLine("2. Search for a student by ID");
                Console.WriteLine("3. Update a student's name");
                Console.WriteLine("4. Exit the program");

                Console.Write("Please enter your choice (1-4): ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ViewStudentDatabase(studentDatabase);
                            break;
                        case 2:
                            SearchStudentByID(studentDatabase);
                            break;
                        case 3:
                            UpdateStudentName(studentDatabase);
                            break;
                        case 4:
                            Console.WriteLine("Exiting the program. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number (1-4).");
                }

                Console.WriteLine(); // Add a line break for readability
            }

        }

        // function definitions
        static void Greet(string greeting = "Hello", string name = "World")
        {
            Console.WriteLine($"{greeting}, {name}!");
        }
        static double CalculateArea(double length = 1.0, double width = 1.0)
        {
            return length * width;
        }
        static int AddNumbers(int a, int b)
        {
            return a + b;
        }
        static int AddNumbers(int a, int b, int c = 0)
        {
            return a + b + c;
        }
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static T CalculateSum<T>(T[] array) where T : struct, IConvertible
        {
            // checking for possible types for sum
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(double))
            {
                T sum = default(T);
                foreach (T item in array)
                {
                    sum = (T)Convert.ChangeType(Convert.ToDouble(sum) + Convert.ToDouble(item), typeof(T));
                }
                return sum;
            }
            else
            {
                throw new InvalidOperationException("Sum is Only possible for int, long, and double .");
            }
        }
        //---------------------------------------------------------------------------------
        static void ViewStudentDatabase<T>(T  studentDatabase) where T : IDictionary<int, string>
        {
            if (studentDatabase.Count == 0)
            {
                Console.WriteLine("The student database is empty.");
            }
            else
            {
                Console.WriteLine("Student Database:");
                foreach (var kvp in studentDatabase)
                {
                    Console.WriteLine($"Student ID: {kvp.Key}, Name: {kvp.Value}");
                }
            }
        }

        static void SearchStudentByID<T>(T studentDatabase) where T : IDictionary<int, string>
        {
            Console.Write("Enter the student ID to search for: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (studentDatabase.TryGetValue(id, out string name))
                {
                    Console.WriteLine($"Student ID: {id}, Name: {name}");
                }
                else
                {
                    Console.WriteLine($"Student with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }
        }

        static void UpdateStudentName<T>(T studentDatabase) where T : IDictionary<int, string>
        {
            Console.Write("Enter the student ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (studentDatabase.ContainsKey(id))
                {
                    Console.Write("Enter the new name for the student: ");
                    string newName = Console.ReadLine();
                    studentDatabase[id] = newName;
                    Console.WriteLine($"Student with ID {id} updated successfully.");
                }
                else
                {
                    Console.WriteLine($"Student with ID {id} not found. Update failed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }
        }

    }
}
