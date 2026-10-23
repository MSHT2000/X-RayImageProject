using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private string path;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void chart1_Click(object sender, EventArgs e)
        {



            if (chart1.Series.IsUniqueName("wav1")) 
            {
                chart1.Series.Add("wav1");
            }
            else
            {
                return;
            }
            chart1.Series["wav1"].ChartType = System
                .Windows
                .Forms
                .DataVisualization
                .Charting
                .SeriesChartType
                .FastLine;
            chart1.Series["wav1"].ChartArea = "ChartArea1";


            WaveFileReader file = new WaveFileReader(path);
            WaveChannel32 wav = new WaveChannel32(file);
            byte[] buffer = new byte[16384];
            int red = 0;
            while (wav.Position < wav.Length)
            {
                red = wav.Read(buffer, 0, buffer.Length);
                for (int i = 0; i < red / 4; i++)
                {
                    chart1.Series["wav1"].Points.Add(BitConverter.ToSingle(buffer, i * 4));
                }
            }
            
        }
        public void SetPath(string path)
        {
            this.path = path;

        }
    }
}
