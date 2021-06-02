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
        public DateTime BirthDate { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public int Age
        {
            get
            {
                TimeSpan age = DateTime.Now - BirthDate;
                return (int)Math.Floor(age.TotalDays / 365.24);
            }
        }

        public int YearsWithCompany
        {
            get
            {
                TimeSpan employmentSpan = DateTime.Now - EnrollmentDate;
                return (int)Math.Floor(employmentSpan.TotalDays / 365.24);
            }
        }

        public Customer(string lastName, DateTime birthDate)
        {
            Random random = new Random();
            LastName = lastName;
            BirthDate = birthDate;
            EnrollmentDate = DateTime.Now;
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
