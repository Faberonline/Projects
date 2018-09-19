using System;
namespace Vehicles
{
    class Vehicle: Object
    {
        protected string make;
        protected string model;
        protected string year;
        
        /* Constructor
         */
        public Vehicle()
        {
        }
        public Vehicle(string make, string model, string year)
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }

        public string Make
        {
            set { make = value; }
            get { return make; }
        }
        public string Model
        {
            set { model = value; }
            get { return model; }
        }
        public string Year
        {
            set { year = value; }
            get { return year; }
        }

        //Method Accelerate is to be overridden by subclass
        public  void Accelerate()
        {
        }

        //Method Decelerate is to be overridden by subclass
        public void Decelerate()
        {
 
        }
        public void Drive()
        {
            Type type1 = this.GetType();
            Console.WriteLine("Object af typen Vehicle");
            // Object class output
            Console.Write("i typen: ");
            Console.WriteLine(type1.Name);
            Console.Write("Med det fulde navn: ");
            Console.WriteLine(type1.FullName);
            Console.Write("I namespace: ");
            Console.WriteLine(type1.Namespace);
            Console.WriteLine("");

            System.Threading.Thread.Sleep(1000);
        }
        public void Start()
        {
        }
        public void Stop()
        {
        }
    }
}
