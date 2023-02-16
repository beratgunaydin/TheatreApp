using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalProject
{
    public class Performer : Person // Define a public class called "Performer" that inherits from the "Person" class
    {
        static Performer() // Define a static constructor for the Performer class
        {
            Performers = new List<Performer>(); // Create a new instance of the "List" class and assign it to the "Performers" static field
        }

        // Define two private fields of the "string" and "int" types for storing the role and ID of a show, respectively
        private string role;
        private int show_id;

        private Show show_name; // Define a private field of the "Show" class for storing the name of a show
        public static List<Performer> Performers; // Define a public static field of the "List" class for storing a list of performers

        public string Role { get { return this.role; } set { this.role = value; } } // Define a public property for getting and setting the "role" field
        public int ShowID { get { return this.show_id; } set { this.show_id = value; } } // Define a public property for getting and setting the "show_id" field
        public Show ShowName { get { return this.show_name; } set { this.show_name = value; } } // Define a public property for getting and setting the "show_name" field

        public static void DisplayShowDetailed(Show show) // Method that prints the information and players of the selected show
        {
            Console.Clear(); // Clear the console screen
            Console.WriteLine("OYUN"); // Print the name of the show

            // Print the name, show date, ticket price, and salon ID of the show
            Console.WriteLine("Oyunun İsmi : {0}", show.Name);
            Console.WriteLine("Oyunun Gösterim Tarihi : {0}", show.ShowDate);
            Console.WriteLine("Oyunun Bilet Fiyatı : {0}", show.TicketPrice);
            Console.WriteLine("Oyunun Salonu : {0}", show.SaloonInformations.ID);
            Console.WriteLine(" ");

            // Print the header for the performers section
            Console.WriteLine("OYUNCULAR");

            // Iterate over the list of performers
            foreach (Performer performer in Performers)
            {
                // If the performer's show matches the specified show, print their name, surname, role, and age
                if (performer.ShowName == show)
                {
                    Console.Write("İsim : {0} || Soyisim : {1} || Rol : {2} || Yaş : {3}", performer.Name, performer.Surname, performer.Role, performer.Age);
                    Console.WriteLine(" ");
                }
            }

            // Print a message prompting the user to press the Enter key to continue
            Console.WriteLine(" ");
            Console.Write("Devam etmek için ENTER tuşuna basınız...");
            Console.ReadLine();
        }

        public void AddPerformer(Performer performer) // Method that adds players from incoming data to the list
        {
            Performers.Add(performer);
        }
    }
}
