using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Agilent.CommandExpert.ScpiNet.AgInfiniiVision2000X_02_10;
using Agilent.CommandExpert.ScpiNet.AgInfiniiVision3000_02_35;
using System.Windows.Forms.DataVisualization.Charting;


namespace Opgave03._01._01
{
    public partial class Form1 : Form
    {

        //Setup scope object variable
        //pefa/2018
        Agilent.CommandExpert.ScpiNet.AgInfiniiVision3000_02_35.AgInfiniiVision3000 Scope;

        bool IsConnected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
  
        }


        //Method gets address of scope from texbox
        //pefa/2018
        private string getAddress()
        {
            return this.textBox1.Text;
        }

        //Method initiates generator
        //Arguments are initial voltage, frequency and signal type :-)
        //Pefa/2018
        private void startGenerator(double voltage, double frequency, String signal)
        {
            try
            {
                /* FOR TEST CONNECT */
                this.Scope.SCPI.WGEN.VOLTage.Command(voltage);
                this.Scope.SCPI.WGEN.FREQuency.Command(frequency);
                this.Scope.SCPI.WGEN.FUNCtion.Command(signal);
                this.Scope.SCPI.WGEN.OUTPut.Command(true);
                /* END TEST CONNECT */
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void stopGenerator()
        {
            this.Scope.SCPI.WGEN.OUTPut.Command(false);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.IsConnected)
            {
                try
                {
                    Scope = new AgInfiniiVision3000(getAddress());
                    this.IsConnected = true;
                    this.button2.Text = "Disconnect";


                    /* FOR TEST CONNECT & ADJUST */
                    startGenerator(1, 1000, "SINusoid");

                    this.timer1.Enabled = true;

                    //Adjust scope according to signal
                    this.adjustTimeBase();
                    this.adjustMagnitudeBase();


                    stopGenerator();
                    /* END TEST CONNECT & ADJUST*/

                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox8.Enabled = true;
                    textBox6.Enabled = true;
                    button1.Enabled = true;

                }
                catch (Exception error)
                {
                    System.Windows.Forms.MessageBox.Show("Error " + error.Message);
                }
            }
            else
                try
                {
                    stopGenerator();

                    //Kill scope object
                    this.Scope = null;

                    //set unconnected
                    this.IsConnected = false;

                    this.timer1.Enabled = false;

                    //Change button text to connect
                    this.button2.Text = "Connect";

                    this.textBox4.Enabled = false;
                    this.textBox4.Update();
                    this.textBox5.Enabled = false;
                    this.textBox5.Update();
                    this.textBox8.Enabled = false;
                    this.textBox8.Update();
                    this.textBox6.Enabled = false;
                    this.textBox6.Update();
                    button1.Enabled = false;

                }
                catch (Exception error)
                {
                    System.Windows.Forms.MessageBox.Show("Error " + error.Message);
                }
        }
        
        //Method adjusts timebase so 1 cycle of the signal is to be within scope display
        private void adjustTimeBase()
        {
            string channel = "CHANNEL1";
            double frequency = 9.9E+37;
            double timeBase = 0.0001;

            try
            {
                while (frequency >= 5E+37)
                {
                    timeBase = timeBase * 10;
                    this.Scope.SCPI.TIMebase.SCALe.Command((double)timeBase);
                    this.Scope.SCPI.MEASure.FREQuency.Query(channel, out frequency);
                    this.textBox2.Text = timeBase.ToString();
                }
            }
            catch (Exception error)
            {

                System.Windows.Forms.MessageBox.Show("Error " + error.Message);

            }
        }

        //Overloaded method adjust timebase with one argument, Timebase
        private double adjustTimeBase(double Timebase)
        {
            double frequency;
            try
            {
                this.Scope.SCPI.MEASure.FREQuency.Query(null, out frequency);
                while (frequency >= (double)5E+37)
                {
                    Timebase = Timebase * 10;
                    this.Scope.SCPI.TIMebase.SCALe.Command((double)Timebase);
                    this.Scope.SCPI.MEASure.FREQuency.Query(null, out frequency);
                    this.textBox2.Text = Timebase.ToString();
                }
            }
            catch (Exception error)
            {

                System.Windows.Forms.MessageBox.Show("Error " + error.Message);

            }
            return Timebase;
        }

        //Adjust range of scope so signal are within scope display
        private void adjustMagnitudeBase()
        {
            string channel = "CHANNEL1";
            double overshoot = 5E+20;
            double range = 10.0;

            //Scope.SCPI.CHANnel.RANGe.Query(1, out range);//DSO_X_2002A_2.SCPI.CHANnel.RANGe.Query(CHANnel_n_, out rangeArgument);
            while(overshoot != 0.0)
            {
                range+=10.0;
                this.textBox3.Text = (range/8).ToString();
                Scope.SCPI.CHANnel.RANGe.Command(1, range);
                Scope.SCPI.MEASure.OVERshoot.Query(channel, out overshoot);
            }
        }

        //Timer function that reads scope range, and sets textbox
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.IsConnected)
            {
                double range;
                Scope.SCPI.CHANnel.RANGe.Query(1, out range);

                this.textBox3.Text = (range / 8).ToString();
                this.textBox3.Update();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Disable buttons that cannot be used without connection
            textBox4.Enabled = false;
            this.textBox4.Update();
            textBox5.Enabled = false;
            this.textBox5.Update();
            textBox8.Enabled = false;
            this.textBox8.Update();
            textBox6.Enabled = false;
            this.textBox6.Update();
            button1.Enabled = false;
            setupChart();
            
        }

        //sets up chart
        private void setupChart()
        {
            chart1.Series.Clear();

            try
            {
                var series = new Series("Frequency Sweep");

                chart1.Titles.Add("Frequency Sweep DB versus Frequency");
                chart1.Series.Add(series);

                chart1.ChartAreas["ChartArea1"].AxisX.Maximum = double.Parse(textBox5.Text);
                chart1.ChartAreas["ChartArea1"].AxisX.Minimum = double.Parse(textBox4.Text);

                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 4;
                chart1.ChartAreas["ChartArea1"].AxisY.Minimum = -20;

                chart1.Series["Frequency Sweep"].Points.AddXY(1.0, 0.0);

                chart1.ChartAreas["ChartArea1"].AxisX.IsLogarithmic = true;

                chart1.Legends[0].Enabled = false;

                chart1.Series["Frequency Sweep"].BorderWidth = 1;
                chart1.Series["Frequency Sweep"].BorderColor = Color.Black;


                chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = false;
                chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = false;

                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 1;
                chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 1;

                chart1.Series["Frequency Sweep"].ChartType = SeriesChartType.Spline;


            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }


        //Clears default chart for points
        private void clearChart()
        {
            chart1.Series["Frequency Sweep"].Points.Clear();
        }

        //Method starts measure sweep
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (this.IsConnected)
            {

                long FrequencyStart = long.Parse(textBox4.Text);
                long FrequencyStop = long.Parse(textBox5.Text);
                long FrequencyStep = long.Parse(textBox8.Text);
                double Voltage = double.Parse(textBox6.Text);
                double measValue = 0.0;

                textBox4.Enabled = false;
                this.textBox4.Update();
                textBox5.Enabled = false;
                this.textBox5.Update();
                textBox8.Enabled = false;
                this.textBox8.Update();
                textBox6.Enabled = false;
                this.textBox6.Update();
                button1.Enabled = false;
                button1.Update();
                //setupChart();
                clearChart();

                startGenerator(Voltage, (double)FrequencyStart, "SINUSOID");
                adjustTimeBase(double.Parse(textBox2.Text));

                for (long i = FrequencyStart; i < FrequencyStop; i += FrequencyStep)
                {
                    try
                    {
                        this.textBox9.Text = i.ToString();
                        this.textBox9.Update();

                        adjustTimeBase(double.Parse(textBox2.Text));

                        this.Scope.SCPI.MEASure.VAMPlitude.Query(null, out measValue);
                        this.textBox7.Text = measValue.ToString();
                        this.textBox7.Update();

                        addToChart((double)i, measValue);

                        this.Scope.SCPI.WGEN.FREQuency.Command((double)i);
                        System.Threading.Thread.Sleep(10);

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                }

                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox8.Enabled = true;
                textBox6.Enabled = true;
                button1.Enabled = true;
            }
        }

        //Method adds points to chart
        private void addToChart(double frequency, double value)
        {
            
            try
            {
                //Add points as XY points (takes doubles as arguments)

                chart1.Series["Frequency Sweep"].Points.AddXY((double)frequency, (double)20 * Math.Log10(value / double.Parse(textBox6.Text)));
                chart1.Update();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }

 
}
