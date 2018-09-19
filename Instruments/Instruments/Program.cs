using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Instruments
{

    class Program
    {
        const bool ON = true;
        const bool OFF = false;

        static void Main(string[] args)
        {
            //cDMM MyDmm = new cDMM();
            //Console.Write(MyDmm.Power);

            Instrument DMM = new Instrument();
            cFluke_45 MyDMM = new cFluke_45("    4.5");
            cFluke fluke = new cFluke();

      
            Console.WriteLine("Navnet på instrument er" + DMM.Name);
            Console.WriteLine("Navnet på cFluke er" + fluke.Name);
            Console.WriteLine("LCD indhold "+ MyDMM.LCD);
            System.Threading.Thread.Sleep(5000);
        }
    }
}
