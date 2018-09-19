using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Instruments
{
    /***********************************************
     * The Instruments class is to be inherited
     * by the specific instrument class that is 
     * to be used.
     * Only attribute on the super class is
     * 'Power'
     *                  Mercantec, february 2017
     *                  Peter Faber
    ************************************************/
    class Instrument
    {
        private static bool _power = false;
        private string _name = "Instrument";

        const bool ON =true;
        const bool OFF = false;
        public bool Power {
            get {
                return (_power);
            }
            set {
                _power = value;
            }
        }

        public string Name
        {
            get
            {
                return (_name);
            }
            set
            {
                _name = value;
            }

        }

    }
}
