using NAudio.Wave;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Windows.Forms;
using AForge;
//using NAudio.Dsp;
using AForge.Math;
using MathNet.Numerics.IntegralTransforms;
//using System.Numerics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string path;


        public Form1()
        {

            InitializeComponent();
        }

        public void ReverseAudioSignal(string input, string output)
        {
            // Load the audio file
            using (var audioFile = new AudioFileReader(input))
            {
                // Get the number of bytes per sample
                // BitsPerSimple for get number bits per Simple

                int bytesPerSample = audioFile.WaveFormat.BitsPerSample / 8;

                // Calculate the total number of samples in the audio file
                //length return number of bytes in one simple 
                long sampleCount = audioFile.Length / bytesPerSample;

                // Create a buffer to store the reversed audio data
                byte[] reversedBuffer = new byte[audioFile.Length];

                // Read the audio data into the buffer
                audioFile.Read(reversedBuffer, 0, reversedBuffer.Length);

                // Reverse the audio data
                for (long i = 0; i < sampleCount / 2; i++)
                {
                    // Swap bytes at corresponding positions
                    for (int j = 0; j < bytesPerSample; j++)
                    {
                        // 1 2 3 4 5 6 7 8 9 10

                        byte temp = reversedBuffer[i * bytesPerSample + j];// current position from matrix front .
                        reversedBuffer[i * bytesPerSample + j] = reversedBuffer[(sampleCount - i - 1) * bytesPerSample + j];
                        //reversedBuffer[(sampleCount - i - 1) * bytesPerSample + j;forward current from end matrix
                        reversedBuffer[(sampleCount - i - 1) * bytesPerSample + j] = temp;
                    }
                }

                // Write the reversed audio data to a new file

                using (var writer = new WaveFileWriter(output, audioFile.WaveFormat))
                {
                    writer.Write(reversedBuffer, 0, reversedBuffer.Length);
                }
            }
        }

        public void ReverseAudioChannels(string inputFilePath, string outputFilePath)
        {
            using (var reader = new AudioFileReader(inputFilePath))
            {
                var format = reader.WaveFormat;
                var channelCount = format.Channels;

                var buffer = new float[reader.WaveFormat.SampleRate * reader.WaveFormat.Channels];
                //reader.WaveFormat.SampleRate * reader.WaveFormat.Channels

                using (var writer = new WaveFileWriter(outputFilePath, format))
                {
                    while (reader.Read(buffer, 0, buffer.Length) > 0)
                    {
                        for (int i = 0; i < buffer.Length; i += channelCount)
                        {
                            for (int j = 0; j < channelCount / 2; j++)
                            {
                                var temp = buffer[i + j];
               /*left channel */buffer[i + j] = buffer[i + channelCount - 1 - j];
              /*right channel */ buffer[i + channelCount - 1 - j] = temp;
                            }
                        }

                        writer.WriteSamples(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        private void chart1_Click_1(object sender, EventArgs e)
        {
            chart1.Series.Add("x");
            chart1.Series["x"].ChartType = System
                .Windows
                .Forms
                .DataVisualization
                .Charting
                .SeriesChartType
                .FastLine;
            chart1.Series["x"].ChartArea = "ChartArea1";


            WaveFileReader file = new WaveFileReader(path);
            WaveChannel32 wav = new WaveChannel32(file);
            byte[] buffer = new byte[16384];
            int red = 0;
            while (wav.Position < wav.Length)
            {
                red = wav.Read(buffer, 0, buffer.Length);
                for (int i = 0; i < red / 4; i++)
                {
                    chart1.Series["x"].Points.Add(BitConverter.ToSingle(buffer, i * 4));
                }
            }


        }

        public void setDrawPath(string path)
        {
            this.path = path;
        }




    }
}


