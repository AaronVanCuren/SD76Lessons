using _12_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _12_APIs
{
    class Program
    {
        static void Main(string[] args)
        {
            SWAPIService service = new SWAPIService();
            SWAPIUI UI = new SWAPIUI(service);

            UI.Run();

            // HyperText Transfer Protocol
            // HTML = HyperText Markup Language

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage personResponse = httpClient.GetAsync("http://swapi.dev/api/people/1/").Result;


            // Async means it's happening asynchronously (on another timeline)

            if (personResponse.IsSuccessStatusCode)
            {
                // ReadAsString gives us the raw JSON string
                Console.WriteLine(personResponse.Content.ReadAsStringAsync().Result);
            }

            // ReadAsAsync converts JSON to C# (POCO)
            Person person = personResponse.Content.ReadAsAsync<Person>().Result;
            HttpResponseMessage planetResponse = httpClient.GetAsync(person.Homeworld).Result;

            if(planetResponse.IsSuccessStatusCode)
            {
                // POCO = plain old C# object
                Planet planet = planetResponse.Content.ReadAsAsync<Planet>().Result;

                Console.WriteLine($"\n\n{person.Name} is {person.Height}cm tall and weighs {person.Mass}kg. {person.Name} is from " +
                $"{planet.Name} that has a {planet.Climate} climate.");
            }
            else
            {
                Console.WriteLine($"\n\n{person.Name} is {person.Height}cm tall and weighs {person.Mass}kg.");
            }

            Console.ReadKey(); 
        }
    }
}
