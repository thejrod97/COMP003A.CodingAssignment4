// Author: Justin Rodriguez 
// Course: COMP-003A
// Faculty: Jonathan Cruz 
// Purpose: Inventory management application with a minimum of 10 elements in the collection.
namespace COMP003A.CodingAssignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring an array to store up to 10 elements 
            string[] veggieNames = new string[10];
            int[] veggieQuantities = new int[10];
            string veggieName = "";
            int veggieQuantity = 0;
            int count = 0; // To keep track of how many veggies are in the array
            int input = 0; // Record user input in menu

            Console.WriteLine("Welcome to the Inventory Management System!");

            while (true)
            {
                Console.WriteLine("Inventory Management System Menu:");
                Console.WriteLine("1. Add a Product");
                Console.WriteLine("2. Update Product Quantity");
                Console.WriteLine("3. View Inventory Summary");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                try
                { 
                    input = int.Parse(Console.ReadLine());

                    // Checking if the input is within the valid range
                    if (input < 1 || input >4)
                    {
                        Console.WriteLine("Invalid choice. Please enter a number between 1 through 4.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number. ");
                    continue;
                }

                if (input == 1)
                {
                    Console.Write("Enter product name: ");

                    try
                    {
                        veggieName = Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    Console.Write("Enter product quantity: ");

                    try
                    {
                        veggieQuantity = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    if (count < veggieNames.Length) // This if statement is going to check if there is enough room to hold products/quantities in the array
                    {
                        veggieNames[count] = veggieName;
                        veggieQuantities[count] = veggieQuantity;
                        count++;
                        Console.WriteLine("Product added successfully!");
                    }
                    else // If array is full, a messsage will display saying "Inventory is full!"
                    {
                        Console.WriteLine("Inventory is full. Cannot add more products.");
                    }

                }
                 
            }




        }
    }
}
