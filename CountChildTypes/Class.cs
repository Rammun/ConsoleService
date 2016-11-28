using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountChildTypes
{
    public class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("BaseClass");
        }
    }

    public class ClassA : BaseClass
    {
        public ClassA()
        {
            Console.WriteLine("ClassA");
        }
    }

    public class ClassB : BaseClass
    {
        public ClassB()
        {
            Console.WriteLine("ClassB");
        }
    }

    public class ClassC : ClassA
    {
        public ClassC()
        {
            Console.WriteLine("ClassC");
        }
    }
}
