using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class MorningChallenge
    {
        [TestMethod]
        public void ForLoops()
        {
            string sillyWord = "Supercalifragilisticexpialidocious";
            int count = 0;
            foreach (char letter in sillyWord)
            {
                if (letter == 'i' || letter == 'l')
                {
                    Console.WriteLine(letter);
                }
                else if (letter == 'l')
                {
                    Console.WriteLine("L");
                }
                else
                {
                    Console.WriteLine("Not 'i', said the Console");
                }
                count++;
            }
            Console.WriteLine(sillyWord.Length);
            for (int i = 0; i < sillyWord.Length; i++)
            {
                char letter = sillyWord[i];
                // "" same as foreach from here
            }
        }
    }
}
