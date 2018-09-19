using System;
namespace Vehicles
{
    class Sportscar : Car
    {

        public Sportscar() { }
        public Sportscar(string make, string model, string year): base(make, model, year) { }

        public new void Drive()
        {
            Console.WriteLine("Dette er objektet Sportscaræææææøøøøøåååå");
            Console.WriteLine("Mærke: " + this.Make + "\n Model: " + this.Model + "\n Årgang: " + this.Year);
            Console.WriteLine("");

            System.Threading.Thread.Sleep(1000);
        }
    }
}