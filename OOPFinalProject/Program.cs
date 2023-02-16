using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace OOPFinalProject
{
    class Program // The class Program begins here
    {
        static void Main(string[] args) // The Main method is the entry point of the program
        {
            // Instantiate the necessary objects
            Customer customer = new Customer();
            Show show = new Show();
            Ticket ticket = new Ticket();
            Saloon saloon = new Saloon();
            Performer performer = new Performer();

            // Read the saloon information from a JSON file and add them to the saloon list
            using (StreamReader r = new StreamReader("SaloonList.json")) // Read saloons informations from JSON file 
            {
                var json = r.ReadToEnd();
                List<Saloon> saloons = JsonConvert.DeserializeObject<List<Saloon>>(json);

                for (int i = 0; i < saloons.Count; i++)
                {
                    saloon.AddSaloon((Saloon)saloons[i]);
                }
            }

            // Read the show information from a JSON file and add them to the show list
            using (StreamReader r = new StreamReader("ShowList.json")) // // Read shows informations from JSON file
            {
                var json = r.ReadToEnd();
                List<Show> shows = JsonConvert.DeserializeObject<List<Show>>(json);

                for (int i = 0; i < shows.Count; i++)
                {
                    // Link the saloon information of each show by checking their IDs
                    foreach (Saloon s in Saloon.Saloons)
                    {
                        if (shows[i].SaloonID == s.ID)
                        {
                            shows[i].SaloonInformations = s;
                            break;
                        }
                    }
                    show.AddShow((Show)shows[i]);
                }
            }

            // Read the performer information from a JSON file and add them to the performer list
            using (StreamReader r = new StreamReader("PerformerList.json")) // Read performers informations from JSON file
            {
                var json = r.ReadToEnd();
                List<Performer> performers = JsonConvert.DeserializeObject<List<Performer>>(json);

                for (int i = 0; i < performers.Count; i++)
                {
                    // Link the show information of each performer by checking their IDs
                    foreach (Show s in Show.Shows)
                    {
                        if (performers[i].ShowID == s.ID)
                        {
                            performers[i].ShowName = s;
                            break;
                        }
                    }
                    performer.AddPerformer((Performer)performers[i]);
                }
            }

            // Read the customer information from a JSON file and add them to the customer list
            using (StreamReader r = new StreamReader("CustomerList.json")) // Read customers informations from JSON file
            {
                var json = r.ReadToEnd();
                List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);

                for (int i = 0; i < customers.Count; i++)
                {
                    customer.AddCustomer((Customer)customers[i]);
                }
            }

            // Read the ticket information from a JSON file and add them to the ticket list
            using (StreamReader r = new StreamReader("TicketList.json")) // Read tickets informations from JSON file
            {
                var json = r.ReadToEnd();
                List<Ticket> tickets = JsonConvert.DeserializeObject<List<Ticket>>(json);

                for (int i = 0; i < tickets.Count; i++)
                {
                    // Link the show information of each ticket by checking their IDs
                    foreach (Show s in Show.Shows)
                    {
                        if (tickets[i].ShowID == s.ID)
                        {
                            tickets[i].ShowInformations = s;
                            break;
                        }
                    }
                    // Add the ticket to the corresponding customer and show
                    show.AddTicketToSaloon(tickets[i]);
                    tickets[i] = customer.AddTicketToCustomer(tickets[i]);
                    ticket.AddTicket((Ticket)tickets[i]);
                }
            }
            // Declare two string variables "choice" and "choice_login"
            string choice;
            string choice_login;

            // Welcome message for the Istanbul State Theater
            Console.Write("İstanbul Devlet Tiyatrosu'na Hoşgeldiniz");
            // Pause for two seconds to display the welcome message
            System.Threading.Thread.Sleep(2000);
            // Clear the console screen
            Console.Clear();

            do   // Display menu items and receive input from user
            {
                Console.Clear();

                // Display menu options
                Console.WriteLine("*****MENÜ*****");
                Console.WriteLine("1- Giriş Yap");
                Console.WriteLine("2- Kayıt Ol");
                Console.WriteLine("3- Tiyatrodaki Oyunları Listele");
                Console.WriteLine("4- Seçili Bir Oyunun Bilgilerini Listele");
                Console.WriteLine("5- Çıkış");

                Console.WriteLine(" ");
                Console.Write("İşlem seçiniz : ");

                // Receive user input
                choice = Console.ReadLine();

                // Determine user's choice and execute appropriate code
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Eposta adresinizi giriniz : "); // Prompt user to enter their email address
                        string email_address = Console.ReadLine(); // Receive user input for email address

                        Console.Write("Şifrenizi giriniz : "); // Prompt user to enter their password
                        string password = Console.ReadLine(); // Receive user input for password

                        customer = customer.Login(email_address, password); // Call the "Login" method of the "customer" object to check the email and password. Store the resulting object in the "customer" variable.

                        Console.Clear();

                        // Check if the customer's email address is not null
                        if (customer.EmailAddress != null)
                        {
                            // If the email address is not null, then display a menu of options for the logged-in customer and enter into a loop
                            do
                            {
                                // Display menu options for logged-in customers by clearing the console and printing out the available options
                                Console.Clear();
                                Console.WriteLine("1- Şifre Değiştir");
                                Console.WriteLine("2- Bilet Satın Al");
                                Console.WriteLine("3- Satın Alınan Biletleri Görüntüle");
                                Console.WriteLine("4- Bilgilerimi Görüntüle");
                                Console.WriteLine("5- Hesabı Sil");
                                Console.WriteLine("6- Çıkış");
                                Console.WriteLine(" ");

                                // Prompt the user to select an operation by entering a choice number
                                Console.Write("İşlem seçiniz : ");
                                choice_login = Console.ReadLine();

                                // Use a switch statement to perform the selected operation based on the user's choice
                                switch (choice_login)
                                {
                                    case "1":
                                        // If the user selects option 1, clear the console and change the customer's password
                                        Console.Clear();
                                        customer.ChangePassword(customer);
                                        break;

                                    case "2":
                                        // If the user selects option 2, first display a list of available shows
                                        bool checkShowNumber = false;
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Seçilebilecek Oyunlar : ");
                                            Show.DisplayShowsDetailed();
                                            Console.WriteLine(" ");
                                            Console.Write("Oyun numarasını giriniz : ");
                                            int show_number = Convert.ToInt32(Console.ReadLine());

                                            // If the user entered a valid show number, buy a ticket for that show
                                            if (show_number <= Show.Shows.Count && show_number > 0)
                                            {
                                                checkShowNumber = false;
                                                show = Show.Shows[show_number - 1];
                                                ticket.BuyTicket(customer, ticket, show);
                                            }

                                            // If the user entered an invalid show number, prompt them to enter a valid one
                                            else
                                            {
                                                checkShowNumber = true;
                                                Console.WriteLine("Hatalı seçim! Lütfen listedeki bir oyunun numarasını giriniz : ");
                                                show_number = Convert.ToInt32(Console.ReadLine());
                                            }

                                        } while (checkShowNumber);
                                        break;

                                    case "3":
                                        // If the user selects option 3, clear the console and display the customer's purchased tickets
                                        Console.Clear();
                                        ticket.DisplayCustomersTickets(customer);
                                        break;

                                    case "4":
                                        // If the user selects option 4, clear the console and display the customer's information
                                        Console.Clear();
                                        customer.DisplayCustomerInformations(customer);
                                        break;

                                    case "5":
                                        // If the user selects option 5, clear the console and prompt them to confirm the deletion of their account
                                        Console.Clear();
                                        Console.Write("Hesabınızı silmek istediğinize emin misiniz ? [E/H]");
                                        string secim = Console.ReadLine();

                                        // If the user confirms the deletion of their account, remove their account and display a message indicating success
                                        if (secim == "E")
                                        {
                                            customer.RemoveCustomer(customer);
                                            Console.WriteLine("Hesabınız sistemden silinmiştir. Başlangıç ekranına yönlendiriliyorsunuz, lütfen bekleyiniz. ");
                                            System.Threading.Thread.Sleep(2000);
                                        }
                                        break;

                                    case "6":
                                        // If the user selects option 6, sign out of their account
                                        Console.Clear();
                                        Console.WriteLine("Çıkış yapılıyor, lütfen bekleyiniz.");
                                        System.Threading.Thread.Sleep(2000);
                                        break;
                                        

                                    default:
                                        // If the user selects an option that does not exist, the selection screen is returned
                                        Console.Clear(); 
                                        Console.WriteLine("Hatalı işlem seçtiniz. Lütfen tekrar deneyiniz.");
                                        System.Threading.Thread.Sleep(2000);
                                        break;
                                }
                            } while (choice_login != "6" && choice_login != "5");
                        }
                        break;

                    case "2":
                        // If the user selects option 2, a customer object is created and the customer is registered
                        Console.Clear();
                        Customer c = new Customer();
                        c.Register();
                        Console.WriteLine("Kayıt başarıyla tamamlandı. ");
                        break;

                    case "3":
                        // If the user selects option 3, available games are displayed
                        Console.Clear();
                        Console.WriteLine("Mevcut Oyunlar");
                        Show.DisplayShowsDetailed();
                        break;

                    case "4":
                        // If the user selects option 4, the user is allowed to select a show and detailed information of the selected show is shown
                        bool checkShow = true;
                        do
                        {
                            Console.Clear();
                            Show.DisplayShows();
                            Console.WriteLine(" ");
                            Console.Write("Bilgilerini görüntülemek istediğiniz oyunun numarasını giriniz : ");
                            int choice_show = Convert.ToInt32(Console.ReadLine());

                            if (choice_show <= Show.Shows.Count && choice_show > 0)
                            {
                                checkShow = false;
                                show = Show.Shows[choice_show - 1];
                                Performer.DisplayShowDetailed(show);
                            }
                            else
                            {
                                checkShow = true;
                                Console.WriteLine("Hatalı seçim! Lütfen listedeki bir oyunun numarasını giriniz : ");
                                choice_show = Convert.ToInt32(Console.ReadLine());
                            }
                        } while (checkShow);
                        break;

                    case "5":
                        // If the user selects option 5, the program exits
                        Console.Clear();
                        Console.WriteLine("Çıkış yapılıyor. Lütfen bekleyiniz.");
                        System.Threading.Thread.Sleep(2000);
                        break;

                    default:
                        // If the user selects an option that does not exist, an error message is shown to the user when an incorrect selection is made
                        Console.Clear();
                        Console.WriteLine("Hatalı işlem seçtiniz. Lütfen tekrar deneyiniz.");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
            } while (choice != "5");
        }
    }
}
