using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleWriteLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pi = {0:N4}", Math.PI);
            Console.ReadKey();
        }
    }
}
