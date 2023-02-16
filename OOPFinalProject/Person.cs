using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalProject
{
    public class Person // Inherited master class
    {
        // Define private fields for name, surname, date of birth, and age
        private string name;
        private string surname;
        private DateTime date_of_birth;
        private int age;

        // Define public properties for name, surname, and date of birth, with getters and setters
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Surname { get { return this.surname; } set { this.surname = value; } }
        public int Age { get { return this.age; } private set { } }
        public DateTime DateOfBirth
        {
            // Getter method returns the date of birth
            get
            {
                return this.date_of_birth;
            }
            // Setter method updates the date of birth and calculates the age based on the current date and time
            set
            {
                this.date_of_birth = value;

                // Check if the birth month is later than the current month
                if (value.Month > DateTime.Now.Month)
                {
                    age = DateTime.Now.Year - value.Year - 1;
                }
                // Check if the birth month is the same as the current month, and the birth day is later than the current day
                else if (value.Month == DateTime.Now.Month)
                {
                    if (value.Day > DateTime.Now.Day)
                    {
                        age = DateTime.Now.Year - value.Year - 1;
                    }
                    else
                        age = DateTime.Now.Year - value.Year;
                }
                // In all other cases, set the age based on the difference between the current year and the birth year
                else
                    age = DateTime.Now.Year - value.Year;
            }
        }
    }
}
