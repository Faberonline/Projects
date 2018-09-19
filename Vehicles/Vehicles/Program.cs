using System;

namespace Vehicles
{

    class TestVehicles
    {
        static void Main()
        {
            /* Vehicle myVehicle = new Vehicle();*/
            Car myCar = new Car();
            Sportscar mySportsCar = new Sportscar("Audi", "TT", "2015");
            Van myVan = new Van();
            Minivan myMiniVan = new Minivan();
            ExcursionVan myExcursionVan = new ExcursionVan();
            while (true)
            {
                myCar.Drive();

                mySportsCar.Drive();

                myVan.Drive();

                myMiniVan.Drive();

                myExcursionVan.Drive();


                //myVehicle.Drive();

                myCar.Drive();

                Console.ReadKey();
                System.Threading.Thread.Sleep(20000);
                System.Console.Clear();
            }

        }
    }

}




