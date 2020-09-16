using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using NAudio.Wave;

namespace Monotone
{
    class TestFile3
    {
        public async void testFunc()
        {
            // Define Output Path and Create a new WaveInEvent
            var outputFilePath = @"C:\Users\Joe\source\repos\Monotone\Monotone\bin\x64\Debug\audio.wav";
            var waveInEvent = new WaveInEvent();

            // Prepare the fileWriter
            WaveFileWriter fileWriter = new WaveFileWriter(outputFilePath, waveInEvent.WaveFormat);

            // Set-up the Azure speech configuration with our subscription info and enable dictation capabilities
            var speechConfig = SpeechConfig.FromSubscription("b8305ebbfce64754a0150547a076a0be", "westus");
            speechConfig.EnableDictation();
            speechConfig.SetProfanity(ProfanityOption.Raw);
            speechConfig.OutputFormat = OutputFormat.Detailed;

            // Set-Up Audio Configuration using Audio Callback method for NAudio Capture
            AudioCallback audioCallback = new AudioCallback(ref waveInEvent, waveInEvent.WaveFormat.BitsPerSample);
            //var audioStreamCallback = AudioInputStream.CreatePullStream(audioCallback, AudioStreamFormat.GetDefaultInputFormat());
            var audioStreamCallback = AudioInputStream.CreatePullStream(audioCallback,
                AudioStreamFormat.GetWaveFormatPCM((uint)waveInEvent.WaveFormat.SampleRate, (byte)waveInEvent.WaveFormat.BitsPerSample, (byte)waveInEvent.WaveFormat.Channels));

            var audioConfig = AudioConfig.FromStreamInput(audioStreamCallback);

            // Initialize the SpeechRecognizer API
            var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            // Declar a TaskCompletionSource to help shutdown the continuous speech processing later
            var stopRecognition = new TaskCompletionSource<int>();

            // Recognizer Event-Based handeling
            #region Recognizer Event-Based Handeling

            recognizer.Recognizing += (s, e) =>
            {
                Console.WriteLine($"RECOGNIZING: Text ={e.Result.Text}");
            };

            recognizer.Recognized += (s, e) =>
            {
                if (e.Result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"RECOGNIZED: Text ={e.Result.Text}");
                }
                else if (e.Result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                    Console.WriteLine($"NOMATCH: Detail ={NoMatchDetails.FromResult(e.Result).Reason}");
                }
            };

            recognizer.Canceled += (s, e) =>
            {
                if (e.Reason == CancellationReason.Error)
                {
                    Console.WriteLine($"CANCELLED: ErrorCode ={e.ErrorCode}");
                    Console.WriteLine($"CANCELLED: ErrorDetails ={e.ErrorDetails}");
                    Console.WriteLine($"CANCELLED: Did you update your subscription info?");
                }

                stopRecognition.TrySetResult(0);
            };

            recognizer.SessionStopped += (s, e) =>
            {
                Console.WriteLine("\n   Session Stopped Event.");
                
                stopRecognition.TrySetResult(0);
            };
            #endregion

            // NAudio WaveInEvent Event-Based Handeling
            #region NAudio WaveInEvent Event-Based Handeling
            waveInEvent.DataAvailable += (s, a) =>
            {
                // Use callback to send recorded data for analysis via Recognizer
                //audioCallback.Read(a.Buffer, (uint)a.BytesRecorded);

                // Then Write the data
                fileWriter.Write(a.Buffer, 0, a.BytesRecorded);

                // Force Stop Recording after 30 seconds
                //if (fileWriter.Position > waveInEvent.WaveFormat.AverageBytesPerSecond * 30)
                //{
                //    waveInEvent.StopRecording();
                //}
            };

            waveInEvent.RecordingStopped += (s, a) =>
            {
                fileWriter?.Dispose();
                fileWriter = null;
            };
            #endregion

            // Start Recording
            waveInEvent.StartRecording();

            Console.WriteLine("Begin Recording... ");
            Console.WriteLine("Press Any Key to Stop Recording.");

            // Start Continuous Recognition
            await recognizer.StartContinuousRecognitionAsync();

            // Waits for completion. Task.WaitAny keeps the task rooted
            Task.WaitAny(new[] { stopRecognition.Task });

            Console.ReadKey();

            // Stops Recognition
            await recognizer.StopContinuousRecognitionAsync();

            // Stop Recording and dispose object
            waveInEvent.StopRecording();
            waveInEvent.Dispose();

            Console.WriteLine("Recording Stopped.");
        }
    }

    public class AudioCallback : PullAudioInputStreamCallback
    {
        WaveInEvent waveInEvent;
        byte[] dataBuffer;
        uint size;

        public AudioCallback(ref WaveInEvent waveInEvent, int bufferSize)
        {
            bufferSize *= 100;

            this.waveInEvent = waveInEvent;
            this.size = (uint)bufferSize;
            this.dataBuffer = new byte[bufferSize];

            Array.Clear(dataBuffer, 0, bufferSize);

            waveInEvent.DataAvailable += (s, a) =>
            {
                dataBuffer = a.Buffer;
                size = (uint)a.BytesRecorded;
            };
        }

        public override int Read(byte[] dataBuffer, uint size)
        {
            dataBuffer = this.dataBuffer;
            size = this.size;

            return dataBuffer.Length;
        }
    }
}
