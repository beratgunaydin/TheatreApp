using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalProject
{
    public class Customer : Person // defines a class named "Customer" that inherits from "Person" class
    {
        static Customer() // a static constructor of the class to initialize the list of customers
        {
            Customers = new List<Customer>();
        }

        static List<Customer> Customers; // defines a static list of customers
        private string password; // defines a private string variable for customer's password
        private string email_address; // defines a private string variable for customer's email address
        private string gender; // E:Male  K:Woman // defines a private string variable for customer's gender
        public string Password { private get { return this.password; } set { this.password = value; } } // defines a public property for customer's password
        public string EmailAddress { get { return this.email_address; } set { this.email_address = value; } } // defines a public property for customer's email address
        public string Gender // defines a public property for customer's gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value.ToUpper(); // converts the gender value to uppercase and sets it to the private variable
            }
        }

        public void Register() // Customer registration method
        {
            Customer customer = new Customer(); // creates a new customer object

            Console.Write("İsminizi giriniz : "); // prints a message to get the name of the customer
            customer.Name = Console.ReadLine(); // reads the name of the customer from the console and sets it to the customer object

            Console.Write("Soyisminizi giriniz : "); // prints a message to get the surname of the customer
            customer.Surname = Console.ReadLine(); // reads the surname of the customer from the console and sets it to the customer object

            Console.Write("Email adresinizi giriniz : "); // prints a message to get the email address of the customer
            customer.EmailAddress = Console.ReadLine(); // reads the email address of the customer from the console and sets it to the customer object

            bool checkEmailAddress; // defines a bool variable to check the format of the email address
            do
            {
                checkEmailAddress = false; // initializes the variable with false

                if (!(customer.EmailAddress.Contains('@'))) // checks whether the email address contains "@" character
                {
                    checkEmailAddress = true; // sets the variable to true if the email address format is incorrect
                    Console.Write("Lütfen email adresinizi doğru formatta giriniz : "); // prints a message to get the correct email address
                    customer.EmailAddress = Console.ReadLine(); // reads the correct email address from the console and sets it to the customer object
                }

                foreach (Customer c in Customers) // iterates through the list of customers
                {
                    if (c.EmailAddress == customer.EmailAddress) // checks whether the email address is already registered or not
                    {
                        checkEmailAddress = true; // sets the variable to true if the email address is already registered
                        Console.Write("Girilen email adresi ile kayıtlı hesap mevcut. Lütfen yeni bir email adresi giriniz : "); // prints a message to get a new email address
                        customer.EmailAddress = Console.ReadLine(); // reads a new email address from the console and sets it to the customer object
                    }
                }

            } while (checkEmailAddress); // continues until the email address is in the correct format and not registered before

            // Prompts the user to enter their date of birth and assigns it to the customer's DateOfBirth property
            Console.Write("Doğum tarihinizi giriniz (GG.AA.YYYY) : ");
            customer.DateOfBirth = Convert.ToDateTime(Console.ReadLine());

            // Prompts the user to enter their password and assigns it to the customer's Password property
            Console.Write("Belirlediğiniz parolayı giriniz : ");
            customer.Password = Console.ReadLine();

            // Prompts the user to enter their gender and assigns it to the customer's Gender property
            Console.Write("Cinsiyetinizi giriniz (Erkek : E, Kadın : K, Belirtmek İstemiyorum : E veya K dışında herhangi bir değer) : ");
            customer.Gender = Console.ReadLine();

            Customers.Add(customer); // Adds the newly created customer to the Customers list

            // Displays a message to inform the user that their registration was successful and waits for 2 seconds before continuing
            Console.WriteLine(" ");
            Console.WriteLine("Kayıt başarılı giriş ekranına yönlendiriliyorsunuz. Lütfen bekleyiniz...");
            System.Threading.Thread.Sleep(2000);
        }

        public Customer Login(string email_address, string password) // Login method for registered customers
        {
            Customer c = new Customer(); // Creates a new Customer object
            c.EmailAddress = null; // Initializes the EmailAddress property of the Customer object to null

            // Initializes two boolean variables to false
            bool checkCustomerInList = false; 
            bool checkCustomerInformation = false;

            // Loops through the Customers list to find a matching email address and password
            foreach (Customer customer in Customers)
            {
                checkCustomerInList = false;
                checkCustomerInformation = false;

                if (customer.EmailAddress == email_address && customer.Password == password)
                {
                    checkCustomerInList = false;
                    c = customer; // Assigns the matching Customer object to the c variable

                    // Displays a message that greets the customer based on their gender
                    if (customer.Gender == "E")
                    {
                        Console.WriteLine("Hoşgeldiniz {0} {1} Bey", customer.Name, customer.Surname);
                    }
                    else if (customer.Gender == "K")
                    {
                        Console.WriteLine("Hoşgeldiniz {0} {1} Hanım", customer.Name, customer.Surname);
                    }
                    else if (customer.Gender != "K" || customer.Gender != "E")
                    {
                        Console.WriteLine("Hoşgeldiniz {0} {1}", customer.Name, customer.Surname);
                    }
                    break; // Breaks out of the loop once a match is found
                }

                else if (customer.EmailAddress == email_address && customer.Password != password)
                {
                    checkCustomerInList = true;
                    break;
                }
                    
                else
                    checkCustomerInformation = true;
            }
            // Displays a message if the password is incorrect
            if (checkCustomerInList)
                Console.WriteLine("Parola yanlış. Giriş yapılamadı.");

            // Displays a message if the email address is not found in the Customers list
            else if (checkCustomerInformation)
                Console.WriteLine("Böyle bir hesap mevcut değildir. ");

            System.Threading.Thread.Sleep(2000); // Waits for 2 seconds before continuing
            return c; // Returns the Customer object
        }

        public void RemoveCustomer(Customer customer) // Method to delete the customer from the system
        {
            // iterate over the list of customers
            foreach (Customer c in Customers)
            {
                if (customer == c) // check if the incoming customer is in the list of customers
                {
                    Customers.Remove(c); // remove the customer from the list
                    break;
                }
            }
        }

        public void ChangePassword(Customer customer) // Method to change registered customer's password
        {
            bool check = true;
            do
            {
                Console.Clear();
                Console.Write("Mevcut şifrenizi giriniz : ");
                string old_password = Console.ReadLine();

                // check if the old password entered by the user matches the customer's current password
                if (customer.Password == old_password)
                {
                    check = false;
                    Console.Write("Yeni şifrenizi oluşturunuz : ");
                    string new_password = Console.ReadLine();

                    // iterate over the list of customers to find the customer whose password needs to be changed
                    foreach (Customer c in Customers)
                    {
                        if (c == customer)
                        {
                            // set the customer's new password
                            c.Password = new_password;
                            Console.WriteLine("Yeni parola başarıyla oluşturuldu. ");
                        }
                    }
                }
                else
                    Console.WriteLine("Yanlış şifre girişi. Lütfen tekrar deneyiniz.");
            } while (check);
            System.Threading.Thread.Sleep(2000);
        }

        public void DisplayCustomerInformations(Customer customer) // Method to print customer information
        {
            Console.WriteLine("İsim : {0} Soyisim : {1} ", customer.Name, customer.Surname);
            Console.WriteLine("Eposta Adresi : {0}", customer.EmailAddress);
            Console.WriteLine("Doğum Tarihi : {0} ", customer.DateOfBirth.Date);
            Console.WriteLine("Yaş : {0}", customer.Age);
            if (customer.Gender == "E")
                Console.WriteLine("Cinsiyet : Erkek");
            else if (customer.Gender == "K")
                Console.WriteLine("Cinsiyet : Kadın");

            Console.WriteLine(" ");
            Console.Write("Devam etmek için ENTER tuşuna basınız...");
            Console.ReadLine();
        }

        public void AddCustomer(Customer customer) // Method that adds customers from incoming data to the list
        {
            Customers.Add(customer);
        }

        public Ticket AddTicketToCustomer(Ticket ticket) // Method to add customer information to ticket
        {
            // iterate over the list of customers to find the customer whose email address matches the one on the ticket
            foreach (Customer customer in Customers)
            {
                if (ticket.CustomerEmailAddress == customer.EmailAddress)
                {
                    // set the customer information for the ticket
                    ticket.CustomerInformations = customer;
                    break;
                }
            }
            return ticket;
        }
    }
}
