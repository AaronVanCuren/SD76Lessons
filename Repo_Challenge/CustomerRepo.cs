using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Challenge
{
    public class CustomerRepo
    {
        private readonly List<Customer> _customer;
        // CRUD

        public void AddCustomer(string lastName, DateTime birthDate)
        {
            _customer.Add(new Customer(lastName, birthDate));
        }
        // Works with the above or below...would being last name and birthdate from another source if done like below
        //public void AddCustomer(Customer newCustomer) {_customer.Add(newCustomer);}

        // This is better because the fewer places you have to change your code to add a feauture the better. E.g. if we added a FirstName property wouldn't have to change the second method here.
        public void AddCustomer(Customer customer)
        {
            _customer.Add(customer);
        }

        public List<Customer> GetCustomers()
        {
            return _customer;
        }

        public Customer GetCustomerById(int id)
        {
            foreach (Customer customer in _customer)
            {
                if (customer.CustomerID == id)
                {
                    return customer;
                }
            }

            // OR throw an Exception
            return null;

            // LINQ: does the same as the foreach loop above
            // return _customers.SingleOrDefault(c => c.CustomerId == id);
        }

    }
}
