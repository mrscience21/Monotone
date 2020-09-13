using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Monotone
{
    /// <summary>
    /// Test class to try out Microsoft Speech Recognizer
    /// </summary>
    public class TestFile1
    {
        public TestFile1()
        {

        }

        public async void testFunc()
        {
            // Set-up the Azure speech configuration with our subscription info and enable dictation capabilities
            var speechConfig = SpeechConfig.FromSubscription("b8305ebbfce64754a0150547a076a0be", "westus");
            speechConfig.EnableDictation();

            // Set-up the microphone using AudioConfig and initialize the SpeechRecognizer API
            var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
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
                if(e.Result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"RECOGNIZED: Text ={e.Result.Text}");
                }
                else if (e.Result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                }
            };

            recognizer.Canceled += (s, e) => 
            {
                if(e.Reason == CancellationReason.Error)
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

            // Start Continuous Recognition
            await recognizer.StartContinuousRecognitionAsync();

            // Waits for completion. Task.WaitAny keeps the task rooted
            Task.WaitAny(new[] { stopRecognition.Task });

            // Stops Recognition
            await recognizer.StopContinuousRecognitionAsync();
        }
    }
}
