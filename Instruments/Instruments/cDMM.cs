using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instruments
{
    class cDMM: Instruments.Instrument
    {
        private string _lcd = "";

        public string LCD
        {
            get { return _lcd; }
            set { _lcd = value; }
        }

        public cDMM()
        {
            this.Name = "cDMM";
        }


    }
}
