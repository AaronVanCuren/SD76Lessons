using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_TypesAndVariables
{
    [TestClass]
    public class ValueTypeExamples
    {
        [TestMethod]
        public void Booleans()
        {
            //declare
            bool isDeclared;
            //initialized (it has value now)
            isDeclared = true;

            //initialized and declared at same time
            bool isDeclaredAndInitialized = true;
            isDeclaredAndInitialized = false;
        }

        [TestMethod]
        public void Characters()
        {
            char character = 'a';
            char anotherChar = ';';
            char specialChar = '\n';
        }

        [TestMethod]
        public void WholeNumbers()
        {
            byte byteExample = 255;
            // sbyte
            int intMin = -214783638;
            int IntMax = 2147483647;

            long longExample = 9223372036854775807;
        }

        [TestMethod]
        public void Decimals()
        {
            float floatExample = 1.04523145634863453783783f;
            double doubleExample = 1.04523145634863453783783d;
            decimal decimalExample = 1.04523145634863453783783m;

            Console.WriteLine(floatExample);
            Console.WriteLine(doubleExample);
            Console.WriteLine(decimalExample);
        }

        enum PastryType { Cake = 20, Cupcake, Exclaire, Croissant, Danish, Baguette}

        [TestMethod]
        public void Enums()
        {
            PastryType pastryType = PastryType.Baguette;
            PastryType antoherOne = PastryType.Cake;

            // Casting = converting one type to another
            Console.WriteLine((int) pastryType);
            Console.WriteLine(antoherOne);
        }

        [TestMethod]
        public void Structs()
        {
            Int32 age = 35;

            DateTime today = DateTime.Now;

            DateTime birthdate = new DateTime(1996, 06, 29);

            Console.WriteLine(birthdate);

            TimeSpan myAge = today - birthdate;

            Console.WriteLine(today - birthdate);
        }
    }
}
