using System;
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
            filePath_label.Text = ((OpenFileDialog)sender).FileName;
        }
    }
}
