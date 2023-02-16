using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalProject
{
    public class Ticket // Define the public class called Ticket
    {
        private static List<Ticket> Tickets; // Define a private static list of Ticket objects called Tickets

        // Define private fields for the seat number, customer email address, show ID, show information, and customer information
        private int seat_number;
        private string customer_email_address;
        private int show_id;
        private Show show_informations;
        private Customer customer_informations;

        // Define public properties for each of the private fields, with get and set accessors
        public int SeatNumber { get { return this.seat_number; } set { this.seat_number = value; } }
        public string CustomerEmailAddress { get { return this.customer_email_address; } set { this.customer_email_address = value; } }
        public int ShowID { get { return this.show_id; } set { this.show_id = value; } }
        public Show ShowInformations { get { return this.show_informations; } set { this.show_informations = value; } }

        public Customer CustomerInformations { get { return this.customer_informations; } set { this.customer_informations = value; } }

        // Define a static constructor that initializes the Tickets list
        static Ticket() 
        {
            Tickets = new List<Ticket>();
        }

        public void BuyTicket(Customer customer, Ticket ticket, Show show) // Method by which a registered customer buys a ticket
        {
            Console.Clear();
            // Assign the customer and show information to the ticket object
            ticket.CustomerInformations = customer;
            ticket.ShowInformations = show;

            // Check if there are any empty seats in the show, and if so, prompt the user to select a seat number and add the ticket to the list of tickets
            bool checkEmptySeats = Saloon.ShowEmptySeatsAndCheckSeatingCapacity(show);

            if (checkEmptySeats)
            {
                Console.Write("Lütfen koltuk numarası seçiniz : ");
                ticket.SeatNumber = Convert.ToInt32(Console.ReadLine());
                ticket = ControlSeatNumber(ticket);
                show.AddTicketToSaloon(ticket);
                Tickets.Add(ticket);
                Console.Write("Bilet başarıyla alındı.");
                System.Threading.Thread.Sleep(2000);

            }
            else
                Console.WriteLine("Salonda yer kalmadığı için bilet alım işleminiz gerçekleştirilememiştir.");

        }

        public Ticket ControlSeatNumber(Ticket ticket) // Method to check if the selected seat is occupied and exceeds the seat capacity in the saloon
        {
            // Loop through all shows and check if the selected show matches the show information on the ticket
            foreach (Show show in Show.Shows)
            {
                bool checkSeatNumber = false;
                bool checkSaloonSize = false;

                if (show == ticket.ShowInformations)
                {
                    // Loop until a valid seat number is selected, and display the available seats and prompt the user to select a new seat if the selected seat is already taken or not within the saloon's capacity
                    do
                    {
                        Console.Clear();
                        if (ticket.SeatNumber > show.SaloonInformations.saloon_size.Length || ticket.SeatNumber <= 0)
                        {
                            // If the selected seat number is not within the capacity of the saloon, set the checkSaloonSize variable to true and prompt the user to select a new seat.
                            checkSaloonSize = true;
                            Saloon.ShowEmptySeats(show);
                            Console.Write("Almak istediğiniz koltuk numarası salonda mevcut değildir. Lütfen yeni bir koltuk seçiniz : ");
                            ticket.SeatNumber = Convert.ToInt32(Console.ReadLine());
                        }
                        else
                            checkSaloonSize = false;

                        if (show.SaloonInformations.saloon_size[SeatNumber - 1])
                        {
                            // If the selected seat is already taken, set the checkSeatNumber variable to true and prompt the user to select a new seat.
                            checkSeatNumber = true;
                            Saloon.ShowEmptySeats(show);
                            Console.Write("Almak istediğiniz koltuk numarası dolu. Lütfen yeni bir koltuk seçiniz : ");
                            ticket.SeatNumber = Convert.ToInt32(Console.ReadLine());
                        }
                        else
                            checkSeatNumber = false;

                    } while (checkSeatNumber || checkSaloonSize);
                }
            }
            // Return the updated ticket information.
            return ticket;
        }

        public void DisplayCustomersTickets(Customer customer) // Method that prints the ticket information purchased by the selected customer to the screen
        {
            Console.Clear();
            Console.WriteLine(customer.Name.ToUpper() + " " + customer.Surname.ToUpper());
            Console.WriteLine(" ");

            // Loop through all tickets and print the ticket information purchased by the selected customer to the screen.
            foreach (Ticket ticket in Tickets)
            {
                if (ticket.CustomerInformations == customer)
                {
                    Console.Write("Oyun : {0}  ||  ", ticket.ShowInformations.Name);
                    Console.Write(" || ");
                    Console.Write("Salon : {0}", ticket.ShowInformations.SaloonInformations.ID);
                    Console.Write(" || ");
                    Console.Write("Koltuk : {0}", ticket.SeatNumber);
                    Console.Write(" || ");
                    Console.Write("Tarih ve Saat : {0}", ticket.ShowInformations.ShowDate);
                    Console.WriteLine(" ");
                }
            }
            Console.Write("Devam Etmek İçin ENTER Tuşuna Basınız...");
            Console.ReadLine();
        }

        public void AddTicket(Ticket ticket) // Method that adds tickets from incoming data to the list
        {
            Tickets.Add(ticket);
        }
    }
}

