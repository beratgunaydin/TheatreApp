using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPFinalProject
{
    public class Show // Definition of a public class named "Show"
    {
        static Show() // Static constructor of the class, initializing the list of shows
        {

            Shows = new List<Show>();
        }

        // Private fields of the class
        private int id;
        private string name;
        private string author;
        private string director;
        private DateTime show_date;
        private double ticket_price;
        private int saloon_id;
        private Saloon saloon_informations;

        // Public static field of the class, containing a list of shows
        public static List<Show> Shows;

        // Public properties of the class, with getter and setter methods
        public int ID { get { return this.id; } set { this.id = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Author { get { return this.author; } set { this.author = value; } }
        public string Director { get { return this.director; } set { this.director = value; } }
        public DateTime ShowDate { get { return this.show_date; } set { this.show_date = value; } }
        public double TicketPrice { get { return this.ticket_price; } set { this.ticket_price = value; } }
        public int SaloonID { get { return this.saloon_id; } set { this.saloon_id = value; } }
        public Saloon SaloonInformations { get { return this.saloon_informations; } set { this.saloon_informations = value; } }

        public static void DisplayShowsDetailed() // The method that prints the detailed information of all the shows on the screen
        {
            foreach (Show show in Shows)
            {
                Console.WriteLine("{0}. Oyun", show.ID);
                Console.WriteLine("Oyunun İsmi : {0}", show.Name);
                Console.WriteLine("Oyunun Yazarı : {0}", show.Author);
                Console.WriteLine("Oyunun Yönetmeni : {0}", show.Director);
                Console.WriteLine("Oyunun Gösterim Tarihi : {0}", show.ShowDate);
                Console.WriteLine("Oyunun Bilet Fiyatı : {0}", show.TicketPrice);
                Console.WriteLine("Oyunun Salonu : {0}", show.SaloonInformations.ID);
                Console.WriteLine("Salonun Toplam Koltuk Sayısı : {0}", show.SaloonInformations.SeatingCapacity);
                Console.WriteLine(" ");

            }
            Console.Write("Devam Etmek İçin ENTER Tuşuna Basınız...");
            Console.ReadLine();
        }

        public static void DisplayShows() // Method for sorting the numbers and names of shows
        {
            foreach(Show show in Shows)
            {
                Console.WriteLine("{0}. {1}",show.ID,show.Name);
            }
        }

        public void AddShow(Show show) // The method that adds the shows in the incoming data to the list
        {
            Shows.Add(show);
        }

        public void AddTicketToSaloon(Ticket ticket) // The method that turns that seat in the saloon into a full one when a ticket to the show is bought
        {
            foreach (Show show in Shows)
            {
                if (ticket.ShowInformations == show)
                {
                    show.SaloonInformations.saloon_size[ticket.SeatNumber - 1] = true;
                }
            }
        }
    }
}
