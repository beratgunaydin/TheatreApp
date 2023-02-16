using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalProject
{
    // Define a public class called Saloon
    public class Saloon
    {
        static Saloon() // Define a static constructor for the Saloon class
        {
            Saloons = new List<Saloon>(); // Create a new list of Saloon objects
        }

        // Declare two private integer fields: id and seating_capacity
        private int id;
        private int seating_capacity;
        
        public bool[] saloon_size; // Declare a public boolean array called saloon_size
        public static List<Saloon> Saloons; // Declare a public static list called Saloons to hold instances of Saloon objects

        public int ID { get { return this.id; } set { this.id = value; } } // Declare a public property called ID to access the id field

        // Declare a public property called SeatingCapacity to access the seating_capacity field
        public int SeatingCapacity
        {
            // When getting the value, return the seating_capacity field
            get
            {
                return this.seating_capacity;
            }
            // When setting the value, set the seating_capacity field to the value and create a new boolean array with length equal to the value
            // This array will represent the empty and occupied seats in the Saloon object
            set
            {
                this.seating_capacity = value;
                saloon_size = new bool[value];
            }
        }

        // Declare a public static method called ShowEmptySeatsAndCheckSeatingCapacity that takes a Show object as a parameter
        // This method shows the empty seats in the hall for the game and returns a boolean value indicating whether there are any empty seats
        public static bool ShowEmptySeatsAndCheckSeatingCapacity(Show show)
        {
            Console.Clear(); // Clear the console screen
            Console.Write("Boş Koltuklar : "); 
            bool checkSeats = true;  // Declare a boolean variable called checkSeats and set it to true

            // Loop through each Saloon object in the Saloons list
            foreach (Saloon saloon in Saloons)
            {
                // If the current Saloon object is the same as the SaloonInformations property of the Show object passed as a parameter
                if (saloon == show.SaloonInformations)
                {
                    int counter = 0; // Declare an integer variable called counter and set it to 0

                    // Loop through each element in the saloon_size boolean array of the current Saloon object
                    for (int i = 0; i < saloon.saloon_size.Length; i++)
                    {
                        // If the current element is false (i.e., the seat is empty)
                        if (!(show.SaloonInformations.saloon_size[i]))
                        {
                            // Increment the counter variable and write the seat number (i + 1) to the console
                            counter++;
                            Console.Write((i + 1) + " ");
                        }
                    }
                    // If the counter variable is 0, there are no empty seats, so set the checkSeats variable to false
                    if (counter == 0)
                        checkSeats = false;
                }
            }
            // Write a newline to the console and return the checkSeats variable
            Console.WriteLine(" ");
            return checkSeats;
        }

        // Declare a public static method called ShowEmptySeats that takes a Show object as a parameter
        // This method shows the empty seats in the hall for the show
        public static void ShowEmptySeats(Show show)
        {
            Console.Clear();
            Console.Write("Boş Koltuklar : ");

            // Loop through each saloon in the list of saloons
            foreach (Saloon saloon in Saloons)
            {
                // Check if the current saloon is the same as the show's assigned saloon
                if (saloon == show.SaloonInformations)
                {
                    int counter = 0;

                    // Loop through each seat in the current saloon
                    for (int i = 0; i < saloon.saloon_size.Length; i++)
                    {

                        // Check if the current seat is empty
                        if (!(show.SaloonInformations.saloon_size[i]))
                        {
                            counter++;
                            Console.Write((i + 1) + " ");
                        }
                    }
                    Console.WriteLine(" ");
                }
            }
        }

        public void AddSaloon(Saloon saloon) // Method that adds the saloons in the incoming data to the list
        {
            Saloons.Add(saloon);
        }

        public static void DisplaySaloons() // Method to print saloon information
        {
            // Loop through each saloon in the list of saloons
            foreach (Saloon saloon in Saloons)
            {
                Console.WriteLine(saloon.ID);
                Console.WriteLine(saloon.SeatingCapacity);
                Console.WriteLine(" ");
            }
        }
        
    }
}
