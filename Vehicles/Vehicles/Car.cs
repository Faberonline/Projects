using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Vehicles
{
    class Car : Vehicle
    {
        public Car() { }
        public Car(string make, string model, string year): base(make, model, year) { }
        public new void Drive()
        {
            Console.WriteLine("Dette er objektet Car");
            Console.WriteLine("");
            System.Threading.Thread.Sleep(1000);
        }
    }
}










