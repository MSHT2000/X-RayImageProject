using NAudio.Gui;
using NAudio.Wave;
using OxyPlot;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot.WindowsForms;
using System.Drawing;
using OxyPlot.Series;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;


namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string input = "D:\\Various Files\\multimedia";
            string output = "C:\\Users\\ABC\\Desktop";



            Form1 form1 = new Form1();
            //Reverse Audio (test1) Signal:
            form1.ReverseAudioSignal(input + "\\test1.wav", output + "\\reverseAudio1.wav");
            //Reverse Audio (test1) Channels:
            form1.ReverseAudioChannels(input + "\\left-right.wav", output + "\\reverseChannels1.wav");

            //Reverse Audio (test2) Signal:
            form1.ReverseAudioSignal(input + "\\test2.wav", output + "\\reverseAudio2.wav");
            //Reverse Audio (test2) Channels:
            form1.ReverseAudioSignal(input + "\\test2.wav", output + "\\reverseChannels2.wav");

            form1.setDrawPath(output + "\\reverseAudio1.wav");

           Application.Run(form1);


        }


    }
}
    

