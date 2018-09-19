using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agilent.CommandExpert.ScpiNet.AgInfiniiVision3000_02_35;

namespace Visa_Instrument_Class_Ex
{
    public partial class Form1 : Form
    {
        AgInfiniiVision3000 MSO_X;
        bool bConnected = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!bConnected)
            {
                // In order to use the following driver class, you need to reference this assembly : [C:\ProgramData\Keysight\Command Expert\ScpiNetDrivers\AgInfiniiVision3000_02_35.dll]
                MSO_X = new AgInfiniiVision3000("USB0::0x2A8D::0x1778::MY55440303::0::INSTR");
                bConnected = true;
            }
            else {
                MSO_X = null;
                bConnected = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MSO_X.SCPI.AUToscale.Command(null, null, null, null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show("Fejlen " + error.Message);
            }
        }
    }
}
