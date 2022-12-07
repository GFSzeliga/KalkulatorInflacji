using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureConsole.Something
{
    public class ClassA
    {
        protected string name = "A";

        public string Name { get { return name; } }
    }

    public class ClassB : ClassA
    {
        public string name;
        public string zupa;


        public ClassB()
        {
            this.name = "B";
        }
    }

    public class ClassC : ClassB
    {
        public string name = "C";
        public string zupa = "krupnik";

        public ClassC()
        {
            this.name = Name;
        }
    }
    public class BaseC
    {
        public static int x = 55;
        public static int y = 22;
    }

    public class DerivedC : BaseC
    {
        // Hide field 'x'.
        new public static int x = 100;
        public static int y = 100;

        public static void Main()
        {
            // Display the new value of x:
            Console.WriteLine(x);

            // Display the hidden value of x:
            Console.WriteLine(BaseC.x);

            // Display the unhidden member y:
            Console.WriteLine(y);
        }
    }

}
