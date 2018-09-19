using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleDemo
{
    class Circle
    {
        //Constructors
        //First is general constructor without arguments returns default Circle
        public Circle() { }

        //Second returns named circle with specified radius
        public Circle(String n, double r)
        {
            radius = r;
            name = n;
        }

        //Methods and fields pefa/2018
        private double radius = 0.0;
        private String name = "Default Circle";

        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public String Name() { return name; }
        public double Radius() { return radius; }

        //The method examines whether the argument circle
        // is greater than the present circle
        //pefa 2018
        public bool Is_Greater_Than(Circle other)
        {
            if (this.Radius() > other.Radius())
                return true;
            else  return false; 
        }
    }
}
