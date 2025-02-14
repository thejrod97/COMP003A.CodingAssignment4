// Author: Justin Rodriguez 
// Course: COMP-003A
// Faculty: Jonathan Cruz 
// Purpose: Inventory management application with a minimum of 10 elements in the collection.
using System.Diagnostics.Metrics;

namespace COMP003A.CodingAssignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring an array to store up to 10 elements 
            string[] veggieNames = new string[10];
            int[] veggieQuantities = new int[10];
            string veggieName = ""; // This variable is used to keep track of new products  
            int veggieQuantity = 0; // This variable is used to keep track of new quantities
            int count = 0; // To keep track of how many veggies are in the array
            int input = 0; // Record user input in menu

            // Called my first method and wanted to start small
            GreetUser();

            while (true)
            {
                // Called a method with multiple strings
                DisplaySystemMenu();

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
                    // Decided to up it up a little and call a method with arguments
                    AddProduct(veggieNames, veggieQuantities, veggieName, veggieQuantity, ref count);
                }
                else if (input == 2)
                {
                    // Same again here, getting used to calling methods with arguments
                    UpdateProduct(veggieNames, veggieQuantities);
                    
                }
                /*
                I'm not going to use a another method here because I want to showcase a value method inside.
                Otherwise I would have in order to keep everything symmetrical with the other input conditions.
                */
                else if (input == 3)
                {
                    int totalveggieNames = 0;
                    int totalveggieQuantities = 0;

                    Console.WriteLine("Inventory Summary:");

                    // Use a for loop to iterate through the arrays
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"- {veggieNames[i]}: {veggieQuantities[i]}");
                        totalveggieNames++;
                        totalveggieQuantities += veggieQuantities[i];
                    }

                    // Here I wanted to show a value method in use
                    double averageQuantity = CalculateAverage(totalveggieNames, totalveggieQuantities);

                    // Display all products, quantities, and average
                    Console.WriteLine($"Total Products: {totalveggieNames}");
                    Console.WriteLine($"Total Quantity: {totalveggieQuantities}");
                    Console.WriteLine($"Average Quantity: {averageQuantity:F2}");
                }
                else
                {
                    Console.WriteLine("Goodbye, Have a nice day!");
                    break;
                }

            }

        }

        static void GreetUser()
        {
            Console.WriteLine("Welcome to the Inventory Management System!");
        }

        static void DisplaySystemMenu()
        {
            Console.WriteLine("Inventory Management System Menu:");
            Console.WriteLine("1. Add a Product");
            Console.WriteLine("2. Update Product Quantity");
            Console.WriteLine("3. View Inventory Summary");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
        }

        static void AddProduct(string[] veggieNames, int[] veggieQuantities, string veggieName, int veggieQuantity, ref int count)
        {
            Console.Write("Enter product name: ");

            try
            {
                veggieName = Console.ReadLine();

                // Checking if the input is a word and not a number
                if (int.TryParse(veggieName, out int parsedNumber))
                {
                    throw new Exception("Invalid input. Please enter a name.");
                }

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

        static void UpdateProduct(string[] veggieNames, int[] veggieQuantities)
        {
            Console.Write("Enter product name: ");
            string productInput = Console.ReadLine();

            // Now we are going to find the index of the product name in the array
            int index = Array.IndexOf(veggieNames, productInput);

            if (index != -1) // This if statement is going to check if the product name was found
            {
                Console.WriteLine($"Current quantity of {productInput}: {veggieQuantities[index]}");
                Console.Write("Enter a new quantity: ");

                try
                {
                    int newveggieQuantity = int.Parse(Console.ReadLine());
                    veggieQuantities[index] = newveggieQuantity; // Updated the quantity 
                    Console.WriteLine("Product quantity updated successfully!");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                Console.WriteLine("Product does not exist.");
            }
        }

        static double CalculateAverage(int totalveggieNames, int totalveggieQuantities)
        {
            return (totalveggieNames > 0 ? (double)totalveggieQuantities / totalveggieNames: 0);
        }
    }
}
