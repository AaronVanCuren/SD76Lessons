using _12_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_APIs
{
    public class SWAPIUI
    {
        private SWAPIService _service;

        // Dependency injection example:\
        public SWAPIUI(SWAPIService service)
        {
            _service = service;
        }

        public void Run()
        {
            //_service = new SWAPIService();

            bool continueToRun = true;
            while(continueToRun)
            {
                Console.Clear();
                Console.WriteLine("What would you like to look up?\n" +
                    "1. Person\n" +
                    "2. Planet\n" +
                    "3. Starship\n" +
                    "4. Search People\n" +
                    "5. Search Planets\n" +
                    "0. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        GetPerson();
                        break;
                    case "2":
                        GetPlanet();
                        break;
                    case "3":
                        GetStarship();
                        break;
                    case "4":
                        SearchPeople();
                        break;
                    case "5":
                        SearchPlanets();
                        break;
                    case "0":
                        continueToRun = false;
                        break;
                }
            }
        }

        public void GetPerson()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the person you want to see?");
            string id = Console.ReadLine();

            Console.WriteLine("Loading...");
            Thread.Sleep(50);
            Person person = _service.GetAsync<Person>($"http://swapi.dev/api/people/{id}/").Result;
            Console.Clear();

            Console.WriteLine($"{person.Name} is {person.Height}cm tall and weighs {person.Mass}kg.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void GetPlanet()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the planet you want to see?");
            string id = Console.ReadLine();

            Console.WriteLine("Loading...");
            Thread.Sleep(50);
            Planet planet = _service.GetAsync<Planet>($"http://swapi.dev/api/planets/{id}/").Result;
            Console.Clear();

            Console.WriteLine($"{planet.Name}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void GetStarship()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the ship you want to see?");
            string id = Console.ReadLine();

            Console.WriteLine("Loading...");
            Thread.Sleep(50);
            Starship starship = _service.GetAsync<Starship>($"http://swapi.dev/api/starships/{id}/").Result;
            Console.Clear();

            if (starship == null)
            {
                Console.WriteLine("Starship does not exist. Press any key to continue... ");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"{starship.Name} is a {starship.Passenger}-passenger {starship.Model} {starship.Class}. Cost: {starship.Cost} credits.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void SearchPeople()
        {
            Console.Clear();
            Console.WriteLine("What name are you searching for?");
            string query = Console.ReadLine();

            SearchResult<Person> results = _service.SearchPeopleAsync(query).Result;
            Console.Clear();
            Console.WriteLine($"Found {results.Count} results\n");

            foreach(Person person in results.Results)
            {
                Console.WriteLine($"{person.Name} - {person.Height}cm, {person.Eye_Color}eyes");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void SearchPlanets()
        {
            Console.Clear();
            Console.WriteLine("What planet are you searching for?");
            string query = Console.ReadLine();

            SearchResult<Planet> results = _service.SearchPlanetAsync(query).Result;
            Console.Clear();
            Console.WriteLine($"Found {results.Count} results\n");

            foreach (Planet planet in results.Results)
            {
                Console.WriteLine($"{planet.Name} - {planet.Climate} climate, {planet.Population} people");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
