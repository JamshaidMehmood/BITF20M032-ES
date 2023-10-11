using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


public class Employee
{
    private const string connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\mahmo\\Desktop\\Assignment 5\\Assignment 5\\AssignmentFive.mdf\";Integrated Security=True";

    public void GetAllEmployees()
    {
        using (SqlConnection connection = new SqlConnection(connStr))
        {
            connection.Open();
            string query = "SELECT * FROM Employees";
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader data = command.ExecuteReader())
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("ID\tFirstName\tLastName\tEmail\t\t\t\tPrimaryPhoneNumber\tSecondaryPhoneNumber\tCreatedBy\tCreatedOn\t\t\tModifiedBy\tModifiedOn");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------");

                while (data.Read())
                {
                    Console.WriteLine($"{data["ID"]}\t{data["FirstName"]}\t{data["LastName"]}\t{data["Email"]}\t{data["PrimaryPhoneNumber"]}\t\t{data["SecondaryPhoneNumber"]}\t{data["CreatedBy"]}\t{data["CreatedOn"]}\t{data["ModifiedBy"]}\t{data["ModifiedOn"]}");
                }
            }
        }
    }


    public void InsertEmployee(string firstName, string lastName, string email, string primaryPhoneNumber, string secondaryPhoneNumber, string createdBy)
    {
        using (SqlConnection connection = new SqlConnection(connStr))
        {
            connection.Open();
            string query = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn) VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @SecondaryPhoneNumber, @CreatedBy, GETDATE())";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                command.Parameters.AddWithValue("@SecondaryPhoneNumber", string.IsNullOrEmpty(secondaryPhoneNumber) ? DBNull.Value : (object)secondaryPhoneNumber);
                command.Parameters.AddWithValue("@CreatedBy", createdBy);

                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteEmployee(long id)
    {
        using (SqlConnection connection = new SqlConnection(connStr))
        {
            connection.Open();
            string query = "DELETE FROM Employees WHERE ID = @ID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
        }
    }

    public void GetEmployeeById(long id)
    {
        using (SqlConnection connection = new SqlConnection(connStr))
        {
            connection.Open();
            string query = "SELECT * FROM Employees WHERE ID = @ID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader data = command.ExecuteReader())
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("ID\tFirstName\tLastName\tEmail\t\t\t\tPrimaryPhoneNumber\tSecondaryPhoneNumber\tCreatedBy\tCreatedOn\t\t\tModifiedBy\tModifiedOn");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------");

                    while (data.Read())
                    {
                        Console.WriteLine($"{data["ID"]}\t{data["FirstName"]}\t{data["LastName"]}\t{data["Email"]}\t{data["PrimaryPhoneNumber"]}\t\t{data["SecondaryPhoneNumber"]}\t{data["CreatedBy"]}\t{data["CreatedOn"]}\t{data["ModifiedBy"]}\t{data["ModifiedOn"]}");
                    }
                }
            }
        }
    }

    public void UpdateEmployee(long id, string firstName, string lastName, string email, string primaryPhoneNumber, string secondaryPhoneNumber, string modifiedBy)
    {
        using (SqlConnection connection = new SqlConnection(connStr))
        {
            connection.Open();
            string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PrimaryPhoneNumber = @PrimaryPhoneNumber, SecondaryPhoneNumber = @SecondaryPhoneNumber, ModifiedBy = @ModifiedBy, ModifiedOn = GETDATE() WHERE ID = @ID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                command.Parameters.AddWithValue("@SecondaryPhoneNumber", string.IsNullOrEmpty(secondaryPhoneNumber) ? DBNull.Value : (object)secondaryPhoneNumber);
                command.Parameters.AddWithValue("@ModifiedBy", modifiedBy);

                command.ExecuteNonQuery();
            }
        }
    }
}

namespace Assignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            while (true)
            {
                Console.WriteLine("1. Get All Employees");
                Console.WriteLine("2. Insert Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Get Employee by ID");
                Console.WriteLine("5. Update Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        emp.GetAllEmployees();
                        break;
                    case 2:
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter Primary Phone Number: ");
                        string primaryPhoneNumber = Console.ReadLine();
                        Console.Write("Enter Secondary Phone Number (optional): ");
                        string secondaryPhoneNumber = Console.ReadLine();
                        Console.Write("Enter Created By: ");
                        string createdBy = Console.ReadLine();

                        emp.InsertEmployee(firstName, lastName, email, primaryPhoneNumber, secondaryPhoneNumber, createdBy);
                        break;
                    case 3:
                        Console.Write("Enter Employee ID to delete: ");
                        long deleteId = long.Parse(Console.ReadLine());
                        emp.DeleteEmployee(deleteId);
                        break;
                    case 4:
                        Console.Write("Enter Employee ID to retrieve: ");
                        long retrieveId = long.Parse(Console.ReadLine());
                        emp.GetEmployeeById(retrieveId);
                        break;
                    case 5:
                        Console.Write("Enter Employee ID to update: ");
                        long updateId = long.Parse(Console.ReadLine());
                        Console.Write("Enter New First Name: ");
                        string newFirstName = Console.ReadLine();
                        Console.Write("Enter New Last Name: ");
                        string newLastName = Console.ReadLine();
                        Console.Write("Enter New Email: ");
                        string newEmail = Console.ReadLine();
                        Console.Write("Enter New Primary Phone Number: ");
                        string newPrimaryPhoneNumber = Console.ReadLine();
                        Console.Write("Enter New Secondary Phone Number (optional): ");
                        string newSecondaryPhoneNumber = Console.ReadLine();
                        Console.Write("Enter Modified By: ");
                        string modifiedBy = Console.ReadLine();

                        emp.UpdateEmployee(updateId, newFirstName, newLastName, newEmail, newPrimaryPhoneNumber, newSecondaryPhoneNumber, modifiedBy);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

}
