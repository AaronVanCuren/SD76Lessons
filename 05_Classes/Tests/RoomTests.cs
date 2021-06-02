using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _05_Classes.Classes;

namespace _05_Classes.Tests
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        public void Volume()
        {
            Room livingroom = new Room(10, 20, 8);
            Console.WriteLine("Living Room Volume: " + livingroom.Volume);
            Console.WriteLine("Living Room SA: " + livingroom.SA);
        }
    }
}
