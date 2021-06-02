using System;
using System.Threading;

namespace _06_Inheritance.People
{
    public class User
    {
        private string _firstName;
        private string _lastName;
        
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ID { get; }

        public string Name
        {
            get
            {
                string fullName = $"{_firstName} {_lastName}";
                if (!string.IsNullOrWhiteSpace(fullName))
                {
                    return fullName;
                }
                // else{} is not needed because there is only one possible return if false
                    return "Unnamed";

                //Another way to do this without the IF statement (Ternary expression)
                //return !string.IsNullOrWhiteSpace(fullName) ? fullName : "Unnamed";

                // If it's sunday, isWeekend = true
                // If it's saturday, isWeekend = true
                // If !isWeekend, work!!
            }
        }
        public void SetFirstName(string name)
        {
            _firstName = name;
        }

        public void SetLastName(string name)
        {
            _lastName = name;
        }

        //Do not return type because it just returns the class
        public User(string email)
        {
            Email = email;
            // setter not needed because this is the constructor
        }

        public static string GenerateId()
        {
            // Pseudocode:
            // start with an empty string
            // Create a random generator
            // Create a flag to tell whether or not a number has been selected
            // go from positions 1 through 16
            //     pick a random letter from the array
            //     add that letter to the empty string
            // return the string
            char[] letters = new char[] { 'D', 'B', 'C', 'F', 'G', '1', '2', '3', '4', '5' };
            string id = "";
            Random random = new Random();
            bool hasNumber = false;
            for (int i = 0; i < 16; i++)
            {
                int sleepCount = random.Next(1, 5);
                Thread.Sleep(sleepCount);
                // RandomNumberGenerator rng = RandomNumberGenerator.Create(id);
                int randomNum = random.Next(0, letters.Length);
                if (i == 15 && !hasNumber)
                {
                    randomNum = random.Next(5, letters.Length);
                }
                if (randomNum >= 5)
                {
                    hasNumber = true;
                }
                id += letters[randomNum];
            }
            return id;
        }


    }
}
