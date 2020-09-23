﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monotone
{
    /// <summary>
    /// Control used for controling audio recording and playback, as well as viewing transcriptions
    /// </summary>
    public partial class Monotone_RecordTranscribe : UserControl
    {
        private bool record_button_toggle = false;
        private bool play_button_toggle = false;

        #region Properties
        /// <summary>
        /// Path of selected file or file to be recorded
        /// </summary>
        public string FilePath
        {
            set
            {
                filePath_label.Text = value;
            }
            get
            {
                return filePath_label.Text;
            }
        }

        /// <summary>
        /// Current Time Index For Audio Recording and Playback
        /// </summary>
        public TimeSpan TimeIndex
        {
            set
            {
                timeIndex_label.Text = value.ToString(@"hh\:mm\:ss");
            }
            get
            {
                return TimeSpan.Parse(timeIndex_label.Text);
            }
        }
        #endregion

        #region Event Delegates and Instantiations
        /// <summary>
        /// Defines Event Handeler for <see cref="StartRecording"/>
        /// </summary>
        /// <param name="sender">Object sending the event</param>
        /// <param name="eventArgs"><see cref="EventArgs"/> provided by Sender</param>
        public delegate void StartRecordingHandeler(object sender, EventArgs eventArgs);
        /// <summary>
        /// Defines Event Handeler for <see cref="PauseAudio"/>
        /// </summary>
        /// <param name="sender">Object sending the event</param>
        /// <param name="eventArgs"><see cref="EventArgs"/> provided by Sender</param>
        public delegate void PauseAudioHandeler(object sender, EventArgs eventArgs);
        /// <summary>
        /// Defines Event Handeler for <see cref="StartPlayback"/>
        /// </summary>
        /// <param name="sender">Object sending the event</param>
        /// <param name="eventArgs"><see cref="EventArgs"/> provided by Sender</param>
        public delegate void StartPlaybackHandeler(object sender, EventArgs eventArgs);
        /// <summary>
        /// Defines Event Handeler for <see cref="Rewind"/>
        /// </summary>
        /// <param name="sender">Object sending the event</param>
        /// <param name="eventArgs"><see cref="EventArgs"/> provided by Sender</param>
        public delegate void RewindHandeler(object sender, EventArgs eventArgs);
        /// <summary>
        /// Defines Event Handeler for <see cref="FastForward"/>
        /// </summary>
        /// <param name="sender">Object sending the event</param>
        /// <param name="eventArgs"><see cref="EventArgs"/> provided by Sender</param>
        public delegate void FastFowardHandeler(object sender, EventArgs eventArgs);
        /// <summary>
        /// Defines Event Handeler for <see cref="GoToTimeIndex"/>
        /// </summary>
        /// <param name="sender">Object sending the event</param>
        /// <param name="eventArgs"><see cref="EventArgs"/> provided by Sender</param>
        public delegate void GoToTimeIndexHandeler(object sender, EventArgs eventArgs);
        /// <summary>
        /// Defines Event Handeler for <see cref="StopRecording"/>
        /// </summary>
        /// <param name="sender">Object sending the event</param>
        /// <param name="eventArgs"><see cref="EventArgs"/> provided by Sender</param>
        public delegate void StopRecordingHandeler(object sender, EventArgs eventArgs);

        /// <summary>
        /// Signal from <see cref="Monotone_RecordTranscribe"/> to Start Recording
        /// </summary>
        public event StartRecordingHandeler StartRecording;
        /// <summary>
        /// Signal from <see cref="Monotone_RecordTranscribe"/> to Pause Recording
        /// </summary>
        public event PauseAudioHandeler PauseAudio;
        /// <summary>
        /// Signal from <see cref="Monotone_RecordTranscribe"/> to Start Playback
        /// </summary>
        public event StartPlaybackHandeler StartPlayback;
        /// <summary>
        /// Signal from <see cref="Monotone_RecordTranscribe"/> to Rewind
        /// </summary>
        public event RewindHandeler Rewind;
        /// <summary>
        /// Signal from <see cref="Monotone_RecordTranscribe"/> to Fast-Forward
        /// </summary>
        public event FastFowardHandeler FastForward;
        /// <summary>
        /// Signal from <see cref="Monotone_RecordTranscribe"/> to Go to a specified Time Index
        /// </summary>
        public event GoToTimeIndexHandeler GoToTimeIndex;
        /// <summary>
        /// Signal from <see cref="Monotone_RecordTranscribe"/> to Stop Recording
        /// </summary>
        public event StopRecordingHandeler StopRecording;
        #endregion

        /// <summary>
        /// Instantiates an instance of <see cref="Monotone_RecordTranscribe"/>
        /// </summary>
        public Monotone_RecordTranscribe()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click event handeler for <see cref="browse_button"/>; Launches <see cref="browse_openFileDialog_FileOk(object, CancelEventArgs)"/>
        /// </summary>
        /// <param name="sender">Object triggering the summoning event</param>
        /// <param name="e"><see cref="EventArgs"/> passed from sender</param>
        private void browse_button_Click(object sender, EventArgs e) => openFileDialog.ShowDialog();

        /// <summary>
        /// FileOk event handeler for <see cref="browse_openFileDialog_FileOk(object, CancelEventArgs)"/>
        /// </summary>
        /// <param name="sender">Object triggering the summoning event</param>
        /// <param name="e"><see cref="EventArgs"/> passed from sender</param>
        private void browse_openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FilePath = ((OpenFileDialog)sender).FileName;
        }

        /// <summary>
        /// Click event handeler for Record Button
        /// </summary>
        /// <param name="sender">Object triggering the summoning event</param>
        /// <param name="e"><see cref="EventArgs"/> passed from sender</param>
        private void record_button_Click(object sender, EventArgs e)
        {
            if (!record_button_toggle)
            {
                if (System.IO.File.Exists(FilePath))
                {
                    DialogResult overwriteFileCheck = MessageBox.Show("The specified file already exists!\n\nRecording now will overwrite that file's " + 
                                                                      "contents. Do you want to begin recording anyway?", "Overwrite File Warning", 
                                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }

                // Change button function to Stop Recording and Signals Start Recording
                record_button.Image = Properties.Resources.stop;
                StartRecording?.Invoke(this, new EventArgs());

                timeIndex_label.ForeColor = Color.Firebrick;
                play_button.Enabled = false;
            }
            else
            {
                record_button.Image = Properties.Resources.record;
                StopRecording?.Invoke(this, new EventArgs());

                timeIndex_label.ForeColor = System.Drawing.SystemColors.ControlText;
                play_button.Enabled = true;
            }

            record_button_toggle = !record_button_toggle;
        }

        /// <summary>
        /// Click event handeler for Play Button
        /// </summary>
        /// <param name="sender">Object triggering the summoning event</param>
        /// <param name="e"><see cref="EventArgs"/> passed from sender</param>
        private void play_button_Click(object sender, EventArgs e)
        {
            if (!play_button_toggle)
            {
                play_button.Image = Properties.Resources.pause;
                StartPlayback?.Invoke(this, new EventArgs());

                record_button.Enabled = false;
            }
            else
            {
                play_button.Image = Properties.Resources.play;
                PauseAudio?.Invoke(this, new EventArgs());


                record_button.Enabled = true;
            }

            play_button_toggle = !play_button_toggle;
        }
    }
}