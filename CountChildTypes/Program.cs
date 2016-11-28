using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CountChildTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseClass = typeof(BaseClass);
            var count = 0;

            var sampleAssembly = Assembly.GetAssembly(baseClass);
            foreach (var t in sampleAssembly.GetTypes())
            {
                var derived = t;

                do
                {
                    derived = derived.BaseType;
                    if (derived != null && derived.Name == baseClass.Name)
                    {
                        count++;
                        break;
                    }
                        

                } while (derived != null);                               
            }

            Console.WriteLine($"{baseClass.Name}: {count}");

            Console.ReadKey();
        }
    }
}
