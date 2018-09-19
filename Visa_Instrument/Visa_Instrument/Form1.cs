using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agilent.CommandExpert.ScpiNet.AgInfiniiVision3000X_02_10;

namespace Visa_Instrument
{
    public partial class Form1 : Form
    {
        // In order to use below driver class, you need to reference this assembly : [C:\ProgramData\Agilent\Command Expert\ScpiNetDrivers\AgInfiniiVision3000X_02_10.dll]
        AgInfiniiVision3000X Scope; // = new AgInfiniiVision3000X("USB0::0x0957::0x17a9::MY52160359::0::INSTR");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ledBulb1.On = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Scope= new AgInfiniiVision3000X("USB0::0x2A8D::0x1778::MY55440303::0::INSTR");
            Scope.Transport.DefaultTimeout.Set(5000);

            this.ledBulb1.On = true;

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                Scope.SCPI.WGEN.OUTPut.Command(false);
                Scope = null;
            }
            catch (Exception error)
            {

                MessageBox.Show("The Error " + error.Message + " has occured.");
            }

            this.ledBulb1.On = false;

        }

        private void btnAutoScale_Click(object sender, EventArgs e)
        {
            if (ledBulb1.On == true)
            {
                try
                {
                    Scope.SCPI.AUToscale.CHANnels.Command("ALL");
                    Scope.SCPI.AUToscale.Command(null, null, null, null, null);
                }
                catch (Exception error)
                {

                    MessageBox.Show("The Error " + error.Message + " has occured.");
                }

            }
        }

        private void btnOutGen_Click(object sender, EventArgs e)
        {
            if (ledBulb1.On == true)
            {
                try
                {
                    Scope.SCPI.WGEN.VOLTage.Command(2D);
                    Scope.SCPI.WGEN.FREQuency.Command(2000D);
                    Scope.SCPI.WGEN.FUNCtion.Command("SQUare");
                    Scope.SCPI.WGEN.OUTPut.Command(true);

                    //int Frequency;
                }
                catch (Exception error)
                {

                    MessageBox.Show("The Error " + error.Message + " has occured.");
                }

            }
        }
    }
}
