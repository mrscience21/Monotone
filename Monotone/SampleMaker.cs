using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Monotone
{
    class SampleMaker
    {
        private WaveFileWriter fileWriter;

        public void testFunc()
        {
            // Define Output Path and Create a new WaveInEvent
            var outputFilePath = @"C:\Users\Joe\source\repos\Monotone\Monotone\bin\x86\Debug x86\Samples\";
            var filename = "sample";
            var index = 0;
            var waveInEvent = new WaveInEvent();

            // NAudio WaveInEvent Event-Based Handeling
            #region NAudio WaveInEvent Event-Based Handeling
            waveInEvent.DataAvailable += (s, a) =>
            {
                fileWriter.Write(a.Buffer, 0, a.BytesRecorded);

                // Force Stop Recording after 30 seconds
                if (fileWriter.Position > waveInEvent.WaveFormat.AverageBytesPerSecond * 30)
                {
                    waveInEvent.StopRecording();
                }
            };
            #endregion

            Console.WriteLine("This file will make new samples at each keypress.");
            Console.WriteLine("To actually end the program, you must press the \"q\" key\n");
            Console.WriteLine("Press any key to begin.");

            Console.ReadKey();

            Console.WriteLine("-------------------------------------\n\n");

            while (true)
            {
                fileWriter = new WaveFileWriter(outputFilePath + $"{filename}_{index}.wav", waveInEvent.WaveFormat);
                waveInEvent.StartRecording();

                Console.WriteLine($"Recording {filename}_{index}.wav ... ");
                Console.WriteLine("Press Any Key continue to next file");

                var answr = Console.ReadKey();


                waveInEvent.StopRecording();
                fileWriter?.Dispose();
                fileWriter = null;

                index++;

                if (answr.Key == ConsoleKey.Q) break;
            }

            // Stop Recording and dispose object
            
            waveInEvent.Dispose();

            Console.WriteLine("\n\nRecording Stopped.");
        }
    }
}
