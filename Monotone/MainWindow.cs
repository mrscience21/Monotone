﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using NAudio.Wave;

namespace Monotone
{
    public partial class MainWindow : Form
    {
        WaveInEvent EventBasedAudio;
        BufferedWaveProvider BufferedAudioProvider;
        WaveFileWriter AudioFileWriter;
        WaveFileReader AudioFileReader;

        NAudioCompatibileAudioCallback Azure_NAudio_Callback;
        SpeechRecognizer AzureSpeechRecognizer;
        TaskCompletionSource<int> Azure_StopRecognition;

        Thread AzureSpeechAudioThread;

        Stopwatch timeIndex_Stopwatch;

        public MainWindow()
        {
            InitializeComponent();

            Initialize_NAudio();
            Initialize_AzureSpeech("b8305ebbfce64754a0150547a076a0be", "westus", Azure_NAudio_Callback);

            timeIndex_timer.Interval = 500;

            monotone_RecordTranscribe1.StartRecording += StartRecording;
            monotone_RecordTranscribe1.StopRecording += StopRecording;

            AzureSpeechAudioThread = new Thread(new ThreadStart(AzureAudioThreadProcess));
        }

        private void quit_ToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        /// <summary>
        /// Configures NAudio for audio capture from either the default or specified audio device index
        /// </summary>
        /// <param name="deviceNumber">Desired Capture Device Index; Default is 0</param>
        private void Initialize_NAudio(int deviceNumber = 0)
        {
            // If EventBasedAudio is already initialized, dispose
            if(EventBasedAudio != null)
            {
                EventBasedAudio.Dispose();
            }

            EventBasedAudio = new WaveInEvent();
            EventBasedAudio.DeviceNumber = deviceNumber;

            BufferedAudioProvider = new BufferedWaveProvider(EventBasedAudio.WaveFormat);
            //BufferedAudioProvider.BufferDuration = TimeSpan.FromSeconds(8);

            Azure_NAudio_Callback = new NAudioCompatibileAudioCallback(ref BufferedAudioProvider);

            EventBasedAudio.DataAvailable += (s, e) => 
            {
                BufferedAudioProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
            };
        }

        /// <summary>
        /// Configures and Instantiates the Azure Speech-To-Text API; <seealso cref="Initialize_NAudio"/> must be called before using this function
        /// </summary>
        /// <param name="subscriptionKey">Valid Azure Subscription Key</param>
        /// <param name="subscriptionRegion">Valid Azure Subscription Region</param>
        /// <param name="CallbackFunction">Audio Source Callback Function</param>
        private void Initialize_AzureSpeech(string subscriptionKey, string subscriptionRegion, NAudioCompatibileAudioCallback CallbackFunction)
        {
            // If SpeechRecognizer is already initialized, dispose
            if(AzureSpeechRecognizer != null)
            {
                AzureSpeechRecognizer.Dispose();
            }

            // Configure SpeechConfig
            SpeechConfig AzureSpeechConfig = SpeechConfig.FromSubscription(subscriptionKey, subscriptionRegion);
            AzureSpeechConfig.SpeechRecognitionLanguage = "en-US";
            AzureSpeechConfig.EnableDictation();
            AzureSpeechConfig.EnableAudioLogging();
            AzureSpeechConfig.SetProperty(PropertyId.Speech_LogFilename, @"C:\Users\Joe\source\repos\Monotone\Monotone\bin\x86\Debug x86\log.txt");
            AzureSpeechConfig.SetProfanity(ProfanityOption.Raw);
            AzureSpeechConfig.OutputFormat = OutputFormat.Detailed;

            // Configure AudioConfig
            AudioConfig AzureAudioConfig = AudioConfig.FromStreamInput(CallbackFunction, 
                                                                       AudioStreamFormat.GetWaveFormatPCM((uint)EventBasedAudio.WaveFormat.SampleRate,
                                                                                                          (byte)EventBasedAudio.WaveFormat.BitsPerSample,
                                                                                                          (byte)EventBasedAudio.WaveFormat.Channels));

            // Initialize SpeechRecognizer
            AzureSpeechRecognizer = new SpeechRecognizer(AzureSpeechConfig, AzureAudioConfig);

            // Configure Recognizer Events
            Azure_StopRecognition = new TaskCompletionSource<int>();

            //AzureSpeechRecognizer.Recognizing += (s, e) =>
            //{
            //    Debug.WriteLine($"RECOGNIZING: Text ={e.Result.Text}");
            //};

            AzureSpeechRecognizer.Recognized += (s, e) =>
            {
                if (e.Result.Reason == ResultReason.RecognizedSpeech)
                {
                    var bar = SpeechRecognitionResultExtensions.Best(e.Result);
                    var bar_select = bar.Where(q => q.Confidence == bar.Select(t => t.Confidence).Max()).First();
                    //RichTextBoxAppend(bar_select.NormalizedForm + $"({bar_select.Confidence})");

                    foreach (DetailedSpeechRecognitionResult rslt in bar)
                    {
                        RichTextBoxAppend(rslt.Text + $"({rslt.Confidence})\n");
                    }
                    RichTextBoxAppend("\n" + bar_select.Text + $"({bar_select.Confidence})\n");
                    RichTextBoxAppend(e.Result.Text + "\n\n\n");
                }
            };

            AzureSpeechRecognizer.Canceled += (s, e) =>
            {
                if (e.Reason == CancellationReason.Error)
                {
                    MessageBox.Show($"Azure Speech Recognition Error {e.ErrorCode}",
                                    $"Canceled due to Error {e.ErrorCode}\n\n" + $"Details: {e.ErrorDetails}\n\n" + $"Did you update your subscription info?",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                StopRecording(this, new EventArgs());
            };

            AzureSpeechRecognizer.SessionStopped += (s, e) =>
            {
                Debug.WriteLine("Session Stopped");

                StopRecording(this, new EventArgs());
            };

            AzureSpeechRecognizer.SessionStarted += (s, e) =>
            {
                Debug.WriteLine("Session Start");
            };

            AzureSpeechRecognizer.SessionStopped += (s, e) =>
            {
                Debug.WriteLine("Session Stopped");
            };
        }

        private void StartRecording(object sender, EventArgs eventArgs)
        {
            // Prepare TimeIndex Publication
            monotone_RecordTranscribe1.TimeIndex = TimeSpan.Zero;

            timeIndex_Stopwatch = new Stopwatch();
            timeIndex_timer.Tick += new EventHandler((object s, EventArgs e) => 
            {
                monotone_RecordTranscribe1.TimeIndex = timeIndex_Stopwatch.Elapsed;
            });

            // Start Recording
            EventBasedAudio.StartRecording();

            // Prepare, then launch Azure Speech Audio Thread
            if (AzureSpeechAudioThread.ThreadState == System.Threading.ThreadState.Aborted ||
               AzureSpeechAudioThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                AzureSpeechAudioThread = new Thread(new ThreadStart(AzureAudioThreadProcess));
            }
            AzureSpeechAudioThread.Start();

            // Initiate TimeIndex Publication
            timeIndex_Stopwatch.Start();
            timeIndex_timer.Start();
        }

        private void StopRecording(object sender, EventArgs eventArgs)
        {
            Azure_StopRecognition.TrySetResult(0);

            EventBasedAudio.StopRecording();

            timeIndex_timer.Stop();

            timeIndex_Stopwatch.Stop();
            timeIndex_Stopwatch.Reset();
        }

        private async void AzureAudioThreadProcess()
        {
            // Start Continuous Recognition
            await AzureSpeechRecognizer.StartContinuousRecognitionAsync();

            // Waits for completion. Task.WaitAny keeps the task rooted
            Task.WaitAny(new[] { Azure_StopRecognition.Task });
        }

        private void RichTextBoxAppend(string text)
        {
            if (monotone_RecordTranscribe1.transcript_richTextBox.InvokeRequired)
            {
                monotone_RecordTranscribe1.transcript_richTextBox.Invoke(new Action<string>(RichTextBoxAppend), text);
            }
            else
            {
                monotone_RecordTranscribe1.transcript_richTextBox.AppendText(text);
            }
        }
    }
}