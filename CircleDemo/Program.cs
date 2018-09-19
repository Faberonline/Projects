using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = Create_Circle();
            Console.Write("Circle " + c1.Name());
            Console.WriteLine(" created with radius " + c1.Radius());
            Console.WriteLine("Its area is " + c1.Area());

            Circle c2 = Create_Circle();
            Console.Write("Circle " + c2.Name());
            Console.WriteLine(" created with radius " + c2.Radius());
            Console.WriteLine("Its area is " + c2.Area());

            if (c1.Is_Greater_Than(c2))
            {
                Console.Write("Circle " + c1.Name() + " is greater than ");
                Console.WriteLine("Circle " + c2.Name());
            }
            else if (c2.Is_Greater_Than(c1))
            {
                Console.Write("Circle " + c2.Name() + " is greater than ");
                Console.WriteLine("Circle " + c1.Name());
            }
            else
            {
                Console.WriteLine("Circle " + c1.Name() + " and Circle " + c2.Name() + " are the same size");
            }

            Console.ReadKey();
        }

        static Circle Create_Circle()
        {
            String name, temp;
            double radius;
            Console.Write("Please enter namefor new Circle: ");
            name = Console.ReadLine();
            Console.Write("Please enter radius: ");
            temp = Console.ReadLine();
            radius = double.Parse(temp);
            return new CircleDemo.Circle(name, radius);
        }
    }
}
