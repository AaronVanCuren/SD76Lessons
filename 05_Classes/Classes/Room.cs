using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes.Classes
{
    public enum RoomType { LivingRoom, BedRoom, Bathroom, DiningRoom, Kitchen}
     public class Room
    {
        // Give the class properties of length, width, height
        // surface area and volume(getters only)
        //empty and full constructor

        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double SA
        {
            get
            {
                double topAndBottom = 2 * Length * Width;
                return (
                    2 * Length * Width +
                    2 * Length * Height +
                    2 * Width * Height
                    );
            }
        }
        public double Volume
        {
            get
            {
                return (Length * Width * Height);
            }
        }

        public Room() { }

        public Room (double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

    }
}
