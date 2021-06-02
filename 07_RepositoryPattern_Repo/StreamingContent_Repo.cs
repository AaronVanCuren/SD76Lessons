using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_RepositoryPattern_Repo
{
    public class StreamingContent_Repo
    {
        // Repository Pattern: store a private list of items
        private readonly List<StreamingContent> _directory = new List<StreamingContent>();

        // CRUD methods
        // Create
        // Read
        // Update
        // Delete

        public bool AddContentToDirectory(StreamingContent content)
        {
            int startingCount = _directory.Count;
            // return true or false - did the add method work??
            _directory.Add(content);

            bool wasAdded = _directory.Count > startingCount;
            return wasAdded;
        }

        public List<StreamingContent> GetContents()
        {
            return  _directory;
        }

        public StreamingContent GetContentByTitle(string title)
        {
            foreach (StreamingContent content in _directory)
            {
                if(title.ToLower() == content.Title.ToLower())
                {
                    return content;
                }
            }
            // Really, we would want to throw an error here and then handle it
            throw new Exception("no content with that title exists");
            // return null
        }


        //Challenge
        // Write a method that returns a list of only family-friendly content
        //Correct
        public List<StreamingContent> GetFamilyFriendlyContent()
        {
            List<StreamingContent> familyFriendly = new List<StreamingContent>();
            foreach (StreamingContent content in _directory)
            {
                if (content.IsFamilyFriendly)
                {
                    familyFriendly.Add(content);
                }
            }
            return familyFriendly;
        }


        // Wrong
        //public StreamingContent GetContentbyMaturityRating(string maturityRating)
        //{
        //    foreach(StreamingContent content in _directory)
        //    {
        //        if(maturityRating.ToUpper() == )
        //        {
        //            return content;
        //        }
        //        else
        //        {
        //            return "Content is not family-friendly";
        //        }
        //    }
        //}

        public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        {
            StreamingContent oldContent = GetContentByTitle(originalTitle);

            if (oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.StarRating = newContent.StarRating;
                oldContent.GenreType = newContent.GenreType;

                return true;
            }
            return false;
        }

        public bool DeleteContent(string title)
        {
            int startingCount = _directory.Count;
            StreamingContent contentToDelete = GetContentByTitle(title);
            _directory.Remove(contentToDelete);
            bool wasRemoved = _directory.Count < startingCount;
            return wasRemoved;
        }
    }
}
