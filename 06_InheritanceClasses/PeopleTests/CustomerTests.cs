using _06_Inheritance.People;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _06_Inheritance.PeopleTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CustomersAndUsers()
        {
            User User = new User("fake@email.com");
            Customer Customer = new Customer("John Smith");

            User.SetFirstName("Rose");
            User.SetLastName("Denman");

            Console.WriteLine("User:");
            Console.WriteLine(User.Email);
            Console.WriteLine(User.ID);
            Console.WriteLine("Customer:");
            Console.WriteLine(Customer.ID);
            Console.WriteLine(Customer.Email);
        }
    }
}
