using _07_RepositoryPattern_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09StreamingContent_Console.UI
{
    public class ProgramUI
    {
        private readonly StreamingContent_Repo _repo = new StreamingContent_Repo();

        public void Run()
        {
            SeedContentList();
            RunMenu();
            Console.WriteLine(DateTime.Now - new DateTime(1985, 9, 22));
            Console.ReadKey();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Show all streaming\n" +
                    "2. Find streaming content by title\n" +
                    "3. Add new streaming content\n" +
                    "4. Remove streaming content\n" +
                    "5. Update streaming content\n" +
                    "6. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //-- Show all content
                        /*Console.WriteLine("Star Wars");
                        Console.ReadKey();*/
                        ShowAllContent();
                        break;
                    case "2":
                        //-- Find content by title
                        ShowAllContentByTitle();
                        break;
                    case "3":
                        //-- Add new content
                        CreateNewContent();
                        break;
                    case "4":
                        //-- Remove content
                        RemoveContentFromList();
                        break;
                    case "5":
                        //-- Update Content
                        UpdateContent();
                        break;
                    case "0":
                        //-- Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5.\n");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CreateNewContent()
        {
            Console.Clear();

            StreamingContent content = new StreamingContent();

            // Title
            Console.WriteLine("Please enter a title: ");
            content.Title = Console.ReadLine();

            // Description
            Console.WriteLine("Please enter a description: ");
            content.Description = Console.ReadLine();

            // Star Rating
            Console.WriteLine("Please enter a star rating (1-5): ");
            content.StarRating = double.Parse(Console.ReadLine());


            // Maturity
            Console.WriteLine("Select a Maturity Rating:\n" +
                "1. G\n" +
                "2. PG\n" +
                "3. TVPG\n" +
                "4. TVY\n" +
                "5. TVY7\n" +
                "6. R\n" +
                "7. NC17");

            string maturityString = Console.ReadLine();

            int maturityId = int.Parse(maturityString);

            content.MaturityRating = (Maturity)maturityId;

            // Genre

            Console.WriteLine("Select a Genre:\n" +
                "1. Horror\n" +
                "2. Comedy\n" +
                "3. SciFi\n" +
                "4. Romance\n" +
                "5. Romans\n" +
                "6. Action\n" +
                "7. International\n" +
                "8. Drama");

            string genreInput = Console.ReadLine();
            int genreId = int.Parse(genreInput);

            content.GenreType = (GenreType)genreId;

            _repo.AddContentToDirectory(content);
        }

        private void ShowAllContent()
        {
            Console.Clear();

            List<StreamingContent> listOfContent = _repo.GetContents();

            foreach (StreamingContent content in listOfContent)
            {
                DisplayContent(content);
            }
            Console.ReadKey();
        }

        private void DisplayContent(StreamingContent content)
        {
            Console.WriteLine($"Title: {content.Title}\n" +
                $"$Description: {content.Description}\n" +
                $"Genre: {content.GenreType}\n" +
                $"Stars: {content.StarRating}\n" +
                $"Family Friendly: {content.IsFamilyFriendly}\n" +
                $"Rating: {content.MaturityRating}\n");
        }

        private void ShowAllContentByTitle()
        {
            string title = GetTitleFromUser();

            StreamingContent content = _repo.GetContentByTitle(title);

            if (content != null)
            {
                DisplayContent(content);
            }
            else
            {
                Console.WriteLine("Invalid title. Could not find any results.");
            }

            Console.ReadKey();
        }

        private void UpdateContent()
        {
            StreamingContent content;
            do
            {
                // Console.WriteLine("Type \"cancel\" to go back to the menu");
                string title = GetTitleFromUser();
                content = _repo.GetContentByTitle(title);
                if (title == "cancel" || title == "\"cancel\"")
                {
                    return;
                }
            } while (content == null);

            Console.WriteLine("What would you like to update?\n" +
                "1. Title\n" +
                "2. Description\n" +
                "3. Maturity Rating\n" +
                "4. Star Rating\n" +
                "5. Genre");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    // Change Title
                    Console.WriteLine("Enter a new title:");
                    string newTitle = Console.ReadLine();
                    content.Title = newTitle;
                    break;
                case "2":
                    // Change Description
                    Console.WriteLine("Enter a new description:");
                    string newDescription = Console.ReadLine();
                    content.Title = newDescription;
                    break;
                case "3":
                    // Change Maturity Rating
                    Console.WriteLine("Enter a new Maturity Rating:");
                    string newMaturityRating = Console.ReadLine();
                    content.Title = newMaturityRating;
                    break;
                case "4":
                    // Change Star Rating
                    Console.WriteLine("Enter a new Star Rating:");
                    string newStarRating = Console.ReadLine();
                    content.Title = newStarRating;
                    break;
                case "5":
                    // Change Genre
                    Console.WriteLine("What is the new genre?\n" +
                        "1. Horror\n" +
                        "2. Comedy\n" +
                        "3. SciFi\n" +
                        "4. Romance\n" +
                        "5. Romans\n" +
                        "6. Action\n" +
                        "7. International\n" +
                        "8. Drama");
                    string newGenre = Console.ReadLine();
                    switch(newGenre)
                    {
                        case "1":                            
                        case "2":                           
                        case "3":                           
                        case "4":                           
                        case "5":                           
                        case "6":                           
                        case "7":
                        case "8":
                            int genreNumber = Convert.ToInt32(newGenre);
                            content.GenreType = (GenreType)genreNumber;
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine("INVALID GENRE!!");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.ReadKey();
                            break;
                    }
                    break;
            }
        }

        private void RemoveContentFromList()
        {
            Console.Clear();

            Console.WriteLine("Which item would you like to remove?");

            List<StreamingContent> contentList = _repo.GetContents();

            int count = 0;

            foreach (StreamingContent content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.Title}");
            }

            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;

            if (targetIndex >= 0 && targetIndex < contentList.Count)
            {
                StreamingContent desiredContent = contentList[targetIndex];

                if (_repo.DeleteContent(desiredContent.Title))
                {
                    Console.WriteLine($"{desiredContent.Title} successfully removed.");
                }
                else
                {
                    Console.WriteLine("I'm sorry, I can't do that.");
                }
            }
            else
            {
                Console.WriteLine("No content has that ID.");
            }
            Console.ReadKey();
        }

        private void SeedContentList()
        {
            StreamingContent starwar = new StreamingContent("Star Wars", "space <3", Maturity.R, 5.0, GenreType.Action);
            StreamingContent startrek = new StreamingContent("Star Trek", "space </3", Maturity.R, 3.0, GenreType.Action);

            _repo.AddContentToDirectory(starwar);
            _repo.AddContentToDirectory(startrek);
        }

        private string GetTitleFromUser()
        {
            Console.Clear();
            Console.WriteLine("Enter a title: \n");
            string title = Console.ReadLine();
            return title;
        }
    }
}
