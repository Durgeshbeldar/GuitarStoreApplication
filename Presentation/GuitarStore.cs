using GuitarStoreApplication.Controller;
using GuitarStoreApplication.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStoreApplication.Presentation
{
    internal class GuitarStore
    {
        public static void ShowMenu()
        {
            GuitarManager manager = new GuitarManager();
            Console.WriteLine("\n**************** WELCOME TO GUITAR STORE MANAGEMENT ****************\n\n");
            while (true)
            {
                Console.WriteLine($"Choose Your Operation :" +
                    $"\n1. Add Guitar\n2. Search Guitar" +
                    $"\n3. Get Guitar Info" +
                    $"\n4. Show All Guitars" +
                    $"\n5. Delete Guitar" +
                    $"\n6. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddGuitar(manager);
                        break;
                    case 2:
                        SearchGuitar(manager);
                        break;
                    case 3:
                        GetGuitarInfo(manager);
                        break;
                    case 4:
                        ShowAllGuitars(manager);
                        break;
                    case 5:
                        DeleteGuitar(manager);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddGuitar(GuitarManager manager)
        {
            Console.WriteLine("Enter Price:");
            string priceInput = Console.ReadLine();
            if (!double.TryParse(priceInput, out double price))
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
                return;
            }

            Builder builder = SelectEnumValue<Builder>("Select Builder :");

            Console.WriteLine("Enter Model:");
            string model = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(model))
            {
                Console.WriteLine("Model cannot be empty.");
                return;
            }

            GuitarType type = SelectEnumValue<GuitarType>("Select Guitar Type:");

            Wood backWood = SelectEnumValue<Wood>("Select Back Wood:");

            Wood topWood = SelectEnumValue<Wood>("Select Top Wood:");

            manager.AddGuitar(price, builder, model, type, backWood, topWood);
            Console.WriteLine("Guitar added successfully!");
        }

        // Method to display enum options and handle selection
        static T SelectEnumValue<T>(string prompt) where T : Enum
        {
            Console.WriteLine(prompt);

            // Get enum values
            var values = Enum.GetValues(typeof(T));
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {values.GetValue(i)}");
            }

            // Get user selection
            string input = Console.ReadLine();
            if (int.TryParse(input, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= values.Length)
            {
                return (T)values.GetValue(selectedIndex - 1);
            }

            Console.WriteLine("Invalid selection. Please try again.");
            return SelectEnumValue<T>(prompt); // Recurse until valid input is received
        }

        static void SearchGuitar(GuitarManager manager)
        {
            Console.WriteLine("Select Builder (Fender, Martin, etc.):");
            Builder builder = (Builder)Enum.Parse(typeof(Builder), Console.ReadLine());

            Console.WriteLine("Select Back Wood (Alder, Cedar, etc.):");
            Wood backWood = (Wood)Enum.Parse(typeof(Wood), Console.ReadLine());

            Console.WriteLine("Select Guitar Type (Acoustic, Electric):");
            GuitarType type = (GuitarType)Enum.Parse(typeof(GuitarType), Console.ReadLine());

            var matchingGuitars = manager.SearchGuitars(builder, backWood, type);
            if (matchingGuitars.Count > 0)
            {
                Console.WriteLine("Matched Found\n");
                foreach (var guitar in matchingGuitars)
                {
                    Console.WriteLine(guitar);
                    return;
                }
            }

            Console.WriteLine("No matching guitars found.");
           
        }

        static void GetGuitarInfo(GuitarManager manager)
        {
            Console.WriteLine("Enter Serial Number:");
            string serialNumber = Console.ReadLine();

            var guitar = manager.GetGuitarBySerialNumber(serialNumber);
            if (guitar == null)
            {
                Console.WriteLine("Guitar not found.");
                return;
            }

            Console.WriteLine(guitar);    
        }

         static void ShowAllGuitars(GuitarManager manager)
        {
            var allGuitars = manager.GetAllGuitars();
            if (allGuitars.Count > 0)
            {
                foreach (var guitar in allGuitars)
                {
                    Console.WriteLine(guitar);
                }
                return;
            }
            Console.WriteLine("\n Sorry ... No guitars in inventory. Please Add Guitars to Inventory");
        }


        static void DeleteGuitar(GuitarManager manager)
        {
            Console.WriteLine("Enter Serial Number of Guitar to Delete:");
            string serialNumber = Console.ReadLine();

            bool isDeleted = manager.DeleteGuitar(serialNumber);
            if (isDeleted)
            {
                Console.WriteLine("Guitar deleted successfully.");
                return ;
            }
            Console.WriteLine("Guitar not found.");
        }








    }
}
