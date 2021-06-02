using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _04_Loops
{
    [TestClass]
    public class Loops
    {
        [TestMethod]
        public void WhileLoops()
        {
            int total = 0;

            while (total < 100)
            {
                //total = total + 1;
                //total += 1;
                total++;
                Console.WriteLine("Total: " + total);
            }

            //int number = 5;
            //prints 5
            //Console.WriteLine(number++);
            //print 6
            //Console.WriteLine(++number);

            Random randy = new Random();
            int somenumber = randy.Next(0, 21);

            while (true)
            {
                somenumber = randy.Next(0, 21);
                Console.WriteLine(somenumber);
                if (somenumber ==7)
                {
                    break;
                }
                Console.WriteLine("out of the loop!");

                //Do while loops

            }

            do
            {
                Console.WriteLine("keep going");
            } while (somenumber < 5);
        }

        [TestMethod]
        public void ForLoops()
        {
            string greeting = "Hello World!";

            foreach (char letter in greeting)
            {
                Console.WriteLine(letter);
            }

            List<string> stringList = new List<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            stringList.Add("Banana");

            foreach(string word in stringList)
            {
                Console.WriteLine(word);
            }

            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
