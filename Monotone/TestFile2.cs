using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Monotone
{
    class TestFile2
    {
        private WaveFileWriter fileWriter;

        public void testFunc()
        {
            // Define Output Path and Create a new WaveInEvent
            var outputFilePath = @"C:\Users\Joe\source\repos\Monotone\Monotone\bin\x64\Debug\audio.wav";
            var waveInEvent = new WaveInEvent();

            // Prepare the fileWriter
            fileWriter = new WaveFileWriter(outputFilePath, waveInEvent.WaveFormat);

            // Start Recording
            waveInEvent.StartRecording();

            Console.WriteLine("Begin Recording... ");
            Console.WriteLine("Press Any Key to Stop Recording.");

            // NAudio WaveInEvent Event-Based Handeling
            #region NAudio WaveInEvent Event-Based Handeling
            waveInEvent.DataAvailable += (s, a) => 
            {
                fileWriter.Write(a.Buffer, 0, a.BytesRecorded);

                // Force Stop Recording after 30 seconds
                if(fileWriter.Position > waveInEvent.WaveFormat.AverageBytesPerSecond * 30)
                {
                    waveInEvent.StopRecording();
                }
            };

            waveInEvent.RecordingStopped += (s, a) => 
            {
                Console.WriteLine($"Sampling Rate: {waveInEvent.WaveFormat.SampleRate}");
                Console.WriteLine($"Bits Per Sample: {waveInEvent.WaveFormat.BitsPerSample}");
                Console.WriteLine($"Channels: {waveInEvent.WaveFormat.Channels}");
                Console.WriteLine($"Encoding: {waveInEvent.WaveFormat.Encoding}");

                fileWriter?.Dispose();
                fileWriter = null;
            };
            #endregion

            Console.ReadKey();

            // Stop Recording and dispose object
            waveInEvent.StopRecording();
            waveInEvent.Dispose();

            Console.WriteLine("Recording Stopped.");
        }
    }
}
