using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Interfaces.Fruits
{
    public class Banana : IFruit
    {
        // Arrow notation - super shorthand for returning a value like in a mthod that you can use in a few specific places
        public string Name => "Banana";
        // public string Name {get;} - "Banana"
        public bool IsPeeled { get; private set; } = false;

        public string Peel()
        {
            IsPeeled = true;
            return "You peel the banana";
        }
    }

    public class Orange : IFruit
    {
        public bool IsPeeled { get; private set; }
        public string Name
        {
            get
            {
                return "Orange";
            }
        }
        // Does the same thing as above
        // public string Name => "Orange";
        // public string Name {get;} = "Orange";

        public Orange(bool isPeeled)
        {
            IsPeeled = isPeeled;
        }

        public string Peel()
        {
            if (IsPeeled)
            {
                // throw new Exception("It's already been peeled");
                // passes test but still returns the string and stops code
                return "It's already been peeled!";
            }
            IsPeeled = true;
            return $"You peel the {GetType().Name}";
        }

        public string Squeeze()
        {
            return "You get orange juice!";
        }
    }

    public class Mandarin : Orange
    {
        public Mandarin(bool isPeeled) : base(isPeeled) { }
    }

    public class Grape : IFruit
    {
        public string Name => "Grape";
        public bool IsPeeled { get; } = false;

        public string Peel()
        {
            throw new Exception("what are you, a toddler?");
            // return "who the heck peels grapes?";
        }
    }
}
