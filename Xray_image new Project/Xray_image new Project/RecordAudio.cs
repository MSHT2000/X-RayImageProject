using System;

using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.Diagnostics;
using NAudio.Wave.Compression;
using NAudio.Wave;
using NAudio.Lame;
using VisioForge.Core.GStreamer.Sources;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
namespace Xray_image_new_Project
{
    public partial class RecordAudio : Form
    {
        string path;
        private WaveInEvent waveSource;
        private WaveFileWriter waveFile;
        Stopwatch Count = new Stopwatch();


        public RecordAudio()
        {
            InitializeComponent();
           
        }

        public string pathSave()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "wave files|*.wav";


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }
            return"";
        }
     
        private void Record_Button_Click(object sender, EventArgs e)
        {
            Count.Reset();
            path = pathSave();
            timer1.Start();
            Count.Start();
            StartRecording(path);

        }

        private void Stop_Button_Click(object sender, EventArgs e)
        {
            if (waveSource != null)
            {
            StopRecording();
            timer1.Stop();
            Count.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = Count.Elapsed;
            labelTimer.Text = string.Format("{0:00}:{1:00}:{2:00}", elapsed.TotalHours, elapsed.TotalMinutes, elapsed.TotalSeconds);
        }

        public void StartRecording(string outputPath)
        {
            waveSource = new WaveInEvent();
            waveSource.WaveFormat = new WaveFormat(44100, 1); // Adjust format as needed

            waveFile = new WaveFileWriter(outputPath, waveSource.WaveFormat);

            waveSource.DataAvailable += (sender, args) =>
            {
                waveFile.Write(args.Buffer, 0, args.BytesRecorded);
            };

            waveSource.StartRecording();

        }

        public void StopRecording()
        {
            this.waveSource.StopRecording();
            this.waveSource.Dispose();
            this.waveFile.Close();
            this.waveFile.Dispose(); 
        }

        public void CompressAudio(string inputFilePath, string outputFilePath)
        {
            if(File.Exists(inputFilePath) && outputFilePath != null) ;
            { 

            var reader = new WaveFileReader(inputFilePath);
            var writer = new LameMP3FileWriter(outputFilePath, reader.WaveFormat, LAMEPreset.STANDARD);
                
            reader.CopyTo(writer);
            reader.Close();
            reader.Dispose();
            writer.Dispose();
            writer.Close();                
           
            } 
        }
        
        private  void Compress_Button_Click(object sender, EventArgs e)
        {
           
            CompressAudio(path, pathSave());
           
           
        }  
    }

}



