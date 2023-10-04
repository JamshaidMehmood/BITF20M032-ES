using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calling the method to get user input and display full name
            ConcatinateStrings();

            Console.WriteLine("------------------------------------------------------------------------");
            // Calling the method to get user input and display last 5 characters
            DisplayLastFiveCharacters();

            Console.WriteLine("------------------------------------------------------------------------");
            // calling method to show temperature of a city
            ShowTemperature();

            Console.WriteLine("------------------------------------------------------------------------");
            // calling method to show array
            ShowArray();

            Console.WriteLine("------------------------------------------------------------------------");
            // Array of strings containing fruit names
            string[] fruits = { "Apple", "Banana", "Orange", "Mango", "Grapes" };
            ShowFruits(fruits);

            Console.WriteLine("------------------------------------------------------------------------");
            // Array of strings containing color names
            string[] colors = { "Red", "Blue", "Green", "Yellow", "Orange" };
            DisplayColors(colors);

            Console.WriteLine("------------------------------------------------------------------------");
            // Array of integers containing test scores
            int[] scores = { 85, 92, 78, 95, 89, 88, 94, 87, 91, 96 };
            DisplaySum(scores);

            Console.WriteLine("------------------------------------------------------------------------");
            // an array of values
            int[] values = { 1,2,3,4,5,6 };
            DisplayMax(values);

            Console.WriteLine("------------------------------------------------------------------------");
            // working with reverse array
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Actual Array:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            // Call the method to reverse the array
            ReverseArray(numbers);
            Console.WriteLine("Reversed Array:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            Console.WriteLine("------------------------------------------------------------------------");
            // method for boxing and unboxing an integer
            BoxingUnboxingInteger();

            Console.WriteLine("------------------------------------------------------------------------");
            // method for boxing and unboxing a double
            BoxingUnboxingDouble();

            Console.WriteLine("------------------------------------------------------------------------");
            // method for boxing and unboxing each element of an array
            BoxingUnboxingArray();

            Console.WriteLine("------------------------------------------------------------------------");
            // method for boxing and unboxing each element of an array
            ListBoxingUnboxing();

            Console.WriteLine("------------------------------------------------------------------------");
            // method for working with dynamic variables
            DynamicVariables();

        }

        // Method for concatinating two strings
        static void ConcatinateStrings()
        {
            Console.Write("Enter your first name:");
            string firstName = Console.ReadLine();

            Console.Write("Enter your last name:");
            string lastName = Console.ReadLine();

            // Concatenate process
            string fullName = firstName + " " + lastName;

            // Displaying the full name
            Console.WriteLine("Your full name is  " + fullName);
        }

        // String fetching method this method will fetch the string from the user and display the last 5 characters
        static void DisplayLastFiveCharacters()
        {
            Console.Write("Enter a sentence:");
            string sentence = Console.ReadLine();

            // if length is less than 5 characters
            if (sentence.Length >= 5)
            {
                // Extract the last 5 characters 
                string lastFiveCharacters = sentence.Substring(sentence.Length - 5);

                // Display the extracted substring
                Console.WriteLine("Last 5 characters of the sentence are: " + lastFiveCharacters);
            }
            else
            {
                Console.WriteLine("The sentence is less than 5 characters: " + sentence);
            }
        }

        // function to show temperature 
        static void ShowTemperature()
        {
            double temperatur;
            string city;
            Console.Write("Enter the City Name: ");
            city = Console.ReadLine();
            Console.Write("Enter the Temperature of your City: ");
            temperatur = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Temperature in {city} is {temperatur} degrees Celsius." );
        }   
        // function for initializzing an array and show on console
        static void ShowArray()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            // Printing the elements of the array to the console
            Console.WriteLine("Elements of the 'numbers' array are as :");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        // function for showing fruits
        static void ShowFruits(string[] fruits)
        {
            Console.WriteLine("Fruit Names are as:");
            for (int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine(fruits[i]);
            }
        }
        static void DisplayColors(string[] colors)
        {
            Console.WriteLine("Color Names with Comma and Space:");
            // Iterate through the array using a foreach loop
            int i = 0;
            foreach (string color in colors)
            {
                if (i < colors.Length - 1)
                {
                    // Display each color's name followed by a comma and a space
                    Console.Write(color + ", ");
                }
                else
                {
                    // Display the last color's name without a comma and a space
                    Console.Write(color);
                }   
                i++;
            }
            Console.WriteLine(); // Move to the next line after printing all colors
        }
        // function for displaying sum using do whilee lopp
        static void DisplaySum(int[] scores)
        {
            int sum = 0;
            int i = 0;
            do
            {
                sum += scores[i];
                i++;
            } while (i < scores.Length);
            Console.WriteLine("Sum of the scores are: " + sum);
        }

        // function for displaying maximum number
        static void DisplayMax(int[] values)
        {
            int max = values[0];
            for (int i=1; i< values.Length; i++)
            {
                if (max < values[i])
                {
                    max = values[i];
                }
            }
            Console.WriteLine("Maximum number is :" + max); // Move to the next line after printing all colors
        }
        // Method to reverse the elements of the 'numbers' array in place using foreach loop
        static void ReverseArray(int[] numbers)
        {

            // Calculate the midpoint of the array
            int midpoint = numbers.Length / 2;
            
            // Swap elements of first half with the seecond half
            for (int i = 0; i < midpoint; i++)
            {
                // index to swap with
                int swapIndex = (numbers.Length - 1) - i;

                // Swaping elements
                int temp = numbers[i];
                numbers[i] = numbers[swapIndex];
                numbers[swapIndex] = temp;
            }
        }
        // method for boxing and un boxing a integer
        static void BoxingUnboxingInteger()
        {
            //initializing an integer x
            int x = 42;
            // converting x into an object
            object obj = x;

            // stating it into an integer again(unboxing)
            int y = (int)obj;

            // Display the value of 'y' to the console
            Console.WriteLine("Value of 'y': " + y);
        }
        // method for boxing and un boxing a double
        static void BoxingUnboxingDouble()
        {
            //initializing an double doubleValue
            double doubleValue = 3.14159;
            // converting x into an object
            object obj = doubleValue;

            // stating it into an double again(unboxing)
            double unboxedValue = (double)obj;

            // Display the value of 'y' to the console
            Console.WriteLine("Value after unboxing is: " + unboxedValue);
        }
        // method for boxing and un boxing each element of an array
        static void BoxingUnboxingArray()
        {
            // Define an array of integers called 'numbers'
            int[] numbers = { 1, 2, 3, 4, 5 };

            // Iterate through the array using a loop
            for (int i = 0; i<numbers.Length; i++)
            {
                // Boxing the current integer value
                object boxedNumber = numbers[i];

                // Unboxing
                int unboxedNumber = (int)boxedNumber;

                // Calculate the square
                int squaredNumber = unboxedNumber * unboxedNumber;

                // Displaying the both original integer and its squared value
                Console.WriteLine($"Original Integer: {unboxedNumber}, Squared Value: {squaredNumber}");
            }

        }
        // method for boxing and unboxing a list
        static void ListBoxingUnboxing()
        {
            // Create a generic List
            List<object> mixedList = new List<object>();

            // Add elements of different data types to the list
            mixedList.Add(42);            
            mixedList.Add(3.14);          
            mixedList.Add('A');           
            foreach (var item in mixedList)
            {
                // Unbox and display the element along with its data type
                Console.WriteLine($"Element: {item}\t\t Type: {item.GetType()}");
            }
        }
        // method for working with dynami variables
        static void DynamicVariables()
        {
            // Declare a dynamic variable 

            dynamic myVariable = 990;

            // Displaying the value 
            Console.WriteLine("Value of myVariable is : " + myVariable);

            // Assign a string
            myVariable = "Jamshaid Mehmood";
            Console.WriteLine("Value of myVariable is : " + myVariable);

            Console.WriteLine("-----------------------------------------------------------------------------");
            
            // Declare another dynamic variable 'myVariable2'
            dynamic myVariable2 = 999;

            // Use GetType() method to display the type of the variable
            Console.WriteLine("Type of myVariable2 is : " + myVariable2.GetType());

            // Assigning a double value 
            myVariable2 = 3.14;
            Console.WriteLine("Type of myVariable2 is : " + myVariable2.GetType());

            // Assigning a DateTime value
            myVariable2 = DateTime.Now;
            Console.WriteLine("Type of myVariable2 is : " + myVariable2.GetType());

            // Assigning a string value
            myVariable2 = "Jamshaid Mehmood";
            Console.WriteLine("Type of myVariable2 is : " + myVariable2.GetType());

        }
    }
    
}
