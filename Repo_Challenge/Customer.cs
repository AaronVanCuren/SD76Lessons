using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Challenge
{
    public class Customer
    {
        public int CustomerID { get; }
        public string LastName { get; set; }
        public int BirthDate { get; set; }
        public int EnrollmentDate { get; set; }

        public int Age
        {
            get
            {
                TimeSpan ageSpan = DateTime.Now - BirthDate;
                return (int)Math.Floor(ageSpan.TotalDays / 365.24);
            }
        }

        public int YearsWithCompany
        {
            get
            {
                TimeSpan ageSpan = DateTime.Now - EnrollmentDate;
                return (int)Math.Floor(ageSpan.TotalDays / 365.24);
            }
        }

        public Customer(string lastName, DateTime birthDate)
        {
            Random random = new Random();
            lastName = lastName;
            birthDate = birthDate;
            EnrollmentDate = DateTime.Now;
            // In real like 
            CustomerID = random.Next(0, 999999999);
        }

        public string SendThankYouMessage()
        {
            if (YearsWithCompany >= 1 && YearsWithCompany <=5)
            {
                return "Thank you for being loyal to this company!";
            } else if (YearsWithCompany > 5)
            {
                return "Thank you for being a gold member!";
            }
            else
            {
                return "Thank you for sticking around!";
            }
        }
    }
}
