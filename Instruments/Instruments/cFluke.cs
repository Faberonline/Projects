using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instruments
{
    class cFluke: Instruments.cDMM
    {
        public cFluke()
        {
            this.Name = "Fluke Instrumentet";
        }
    }
}
