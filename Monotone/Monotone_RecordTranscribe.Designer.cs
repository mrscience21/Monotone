namespace Monotone
{
    partial class Monotone_RecordTranscribe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.control_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.audioSourceAndControl_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.browse_button = new System.Windows.Forms.Button();
            this.filePath_label = new System.Windows.Forms.Label();
            this.audioControlData_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.audioControls_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.record_button = new System.Windows.Forms.Button();
            this.play_button = new System.Windows.Forms.Button();
            this.timeIndex_label = new System.Windows.Forms.Label();
            this.rewind_button = new System.Windows.Forms.Button();
            this.fastforward_button = new System.Windows.Forms.Button();
            this.audio_trackBar = new System.Windows.Forms.TrackBar();
            this.audio_waveViewer = new NAudio.Gui.WaveViewer();
            this.entryTitle_textBox = new System.Windows.Forms.TextBox();
            this.newSaveFile_button = new System.Windows.Forms.Button();
            this.entry_dataGridView = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.control_tableLayoutPanel.SuspendLayout();
            this.audioSourceAndControl_tableLayoutPanel.SuspendLayout();
            this.audioControlData_tableLayoutPanel.SuspendLayout();
            this.audioControls_tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audio_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entry_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // control_tableLayoutPanel
            // 
            this.control_tableLayoutPanel.ColumnCount = 1;
            this.control_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.control_tableLayoutPanel.Controls.Add(this.audioSourceAndControl_tableLayoutPanel, 0, 0);
            this.control_tableLayoutPanel.Controls.Add(this.entry_dataGridView, 0, 1);
            this.control_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.control_tableLayoutPanel.Name = "control_tableLayoutPanel";
            this.control_tableLayoutPanel.RowCount = 2;
            this.control_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.control_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.control_tableLayoutPanel.Size = new System.Drawing.Size(500, 700);
            this.control_tableLayoutPanel.TabIndex = 0;
            // 
            // audioSourceAndControl_tableLayoutPanel
            // 
            this.audioSourceAndControl_tableLayoutPanel.ColumnCount = 3;
            this.audioSourceAndControl_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.audioSourceAndControl_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.audioSourceAndControl_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.audioSourceAndControl_tableLayoutPanel.Controls.Add(this.browse_button, 1, 0);
            this.audioSourceAndControl_tableLayoutPanel.Controls.Add(this.filePath_label, 0, 0);
            this.audioSourceAndControl_tableLayoutPanel.Controls.Add(this.audioControlData_tableLayoutPanel, 0, 1);
            this.audioSourceAndControl_tableLayoutPanel.Controls.Add(this.newSaveFile_button, 2, 0);
            this.audioSourceAndControl_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioSourceAndControl_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.audioSourceAndControl_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.audioSourceAndControl_tableLayoutPanel.Name = "audioSourceAndControl_tableLayoutPanel";
            this.audioSourceAndControl_tableLayoutPanel.RowCount = 2;
            this.audioSourceAndControl_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.audioSourceAndControl_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.audioSourceAndControl_tableLayoutPanel.Size = new System.Drawing.Size(500, 150);
            this.audioSourceAndControl_tableLayoutPanel.TabIndex = 1;
            // 
            // browse_button
            // 
            this.browse_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browse_button.Location = new System.Drawing.Point(353, 0);
            this.browse_button.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(72, 25);
            this.browse_button.TabIndex = 0;
            this.browse_button.Text = "Browse";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.browse_button_Click);
            // 
            // filePath_label
            // 
            this.filePath_label.AutoEllipsis = true;
            this.filePath_label.AutoSize = true;
            this.filePath_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.filePath_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePath_label.Location = new System.Drawing.Point(0, 0);
            this.filePath_label.Margin = new System.Windows.Forms.Padding(0);
            this.filePath_label.Name = "filePath_label";
            this.filePath_label.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.filePath_label.Size = new System.Drawing.Size(350, 25);
            this.filePath_label.TabIndex = 1;
            this.filePath_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // audioControlData_tableLayoutPanel
            // 
            this.audioControlData_tableLayoutPanel.ColumnCount = 2;
            this.audioSourceAndControl_tableLayoutPanel.SetColumnSpan(this.audioControlData_tableLayoutPanel, 3);
            this.audioControlData_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.audioControlData_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.audioControlData_tableLayoutPanel.Controls.Add(this.audioControls_tableLayoutPanel, 0, 1);
            this.audioControlData_tableLayoutPanel.Controls.Add(this.entryTitle_textBox, 0, 0);
            this.audioControlData_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioControlData_tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.audioControlData_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.audioControlData_tableLayoutPanel.Name = "audioControlData_tableLayoutPanel";
            this.audioControlData_tableLayoutPanel.RowCount = 2;
            this.audioControlData_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.audioControlData_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.audioControlData_tableLayoutPanel.Size = new System.Drawing.Size(500, 125);
            this.audioControlData_tableLayoutPanel.TabIndex = 2;
            // 
            // audioControls_tableLayoutPanel
            // 
            this.audioControls_tableLayoutPanel.ColumnCount = 5;
            this.audioControlData_tableLayoutPanel.SetColumnSpan(this.audioControls_tableLayoutPanel, 2);
            this.audioControls_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.audioControls_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.audioControls_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.audioControls_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.audioControls_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.audioControls_tableLayoutPanel.Controls.Add(this.record_button, 0, 0);
            this.audioControls_tableLayoutPanel.Controls.Add(this.play_button, 1, 0);
            this.audioControls_tableLayoutPanel.Controls.Add(this.timeIndex_label, 0, 1);
            this.audioControls_tableLayoutPanel.Controls.Add(this.rewind_button, 2, 1);
            this.audioControls_tableLayoutPanel.Controls.Add(this.fastforward_button, 4, 1);
            this.audioControls_tableLayoutPanel.Controls.Add(this.audio_trackBar, 3, 1);
            this.audioControls_tableLayoutPanel.Controls.Add(this.audio_waveViewer, 2, 0);
            this.audioControls_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioControls_tableLayoutPanel.Location = new System.Drawing.Point(0, 30);
            this.audioControls_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.audioControls_tableLayoutPanel.Name = "audioControls_tableLayoutPanel";
            this.audioControls_tableLayoutPanel.RowCount = 2;
            this.audioControls_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.audioControls_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.audioControls_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.audioControls_tableLayoutPanel.Size = new System.Drawing.Size(500, 95);
            this.audioControls_tableLayoutPanel.TabIndex = 0;
            // 
            // record_button
            // 
            this.record_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.record_button.Image = global::Monotone.Properties.Resources.record;
            this.record_button.Location = new System.Drawing.Point(3, 3);
            this.record_button.Name = "record_button";
            this.record_button.Size = new System.Drawing.Size(57, 59);
            this.record_button.TabIndex = 0;
            this.record_button.UseVisualStyleBackColor = true;
            this.record_button.Click += new System.EventHandler(this.record_button_Click);
            // 
            // play_button
            // 
            this.play_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.play_button.Image = global::Monotone.Properties.Resources.play;
            this.play_button.Location = new System.Drawing.Point(66, 3);
            this.play_button.Name = "play_button";
            this.play_button.Size = new System.Drawing.Size(57, 59);
            this.play_button.TabIndex = 1;
            this.play_button.UseVisualStyleBackColor = true;
            this.play_button.Click += new System.EventHandler(this.play_button_Click);
            // 
            // timeIndex_label
            // 
            this.timeIndex_label.AutoSize = true;
            this.timeIndex_label.BackColor = System.Drawing.Color.White;
            this.audioControls_tableLayoutPanel.SetColumnSpan(this.timeIndex_label, 2);
            this.timeIndex_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeIndex_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeIndex_label.Location = new System.Drawing.Point(3, 65);
            this.timeIndex_label.Name = "timeIndex_label";
            this.timeIndex_label.Size = new System.Drawing.Size(120, 30);
            this.timeIndex_label.TabIndex = 2;
            this.timeIndex_label.Text = "00:00:00";
            this.timeIndex_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rewind_button
            // 
            this.rewind_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rewind_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rewind_button.Location = new System.Drawing.Point(126, 65);
            this.rewind_button.Margin = new System.Windows.Forms.Padding(0);
            this.rewind_button.Name = "rewind_button";
            this.rewind_button.Size = new System.Drawing.Size(63, 30);
            this.rewind_button.TabIndex = 3;
            this.rewind_button.Text = "<<";
            this.rewind_button.UseVisualStyleBackColor = true;
            // 
            // fastforward_button
            // 
            this.fastforward_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastforward_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastforward_button.Location = new System.Drawing.Point(437, 65);
            this.fastforward_button.Margin = new System.Windows.Forms.Padding(0);
            this.fastforward_button.Name = "fastforward_button";
            this.fastforward_button.Size = new System.Drawing.Size(63, 30);
            this.fastforward_button.TabIndex = 4;
            this.fastforward_button.Text = ">>";
            this.fastforward_button.UseVisualStyleBackColor = true;
            // 
            // audio_trackBar
            // 
            this.audio_trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audio_trackBar.Location = new System.Drawing.Point(189, 65);
            this.audio_trackBar.Margin = new System.Windows.Forms.Padding(0);
            this.audio_trackBar.Name = "audio_trackBar";
            this.audio_trackBar.Size = new System.Drawing.Size(248, 30);
            this.audio_trackBar.TabIndex = 5;
            // 
            // audio_waveViewer
            // 
            this.audioControls_tableLayoutPanel.SetColumnSpan(this.audio_waveViewer, 3);
            this.audio_waveViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audio_waveViewer.Location = new System.Drawing.Point(126, 0);
            this.audio_waveViewer.Margin = new System.Windows.Forms.Padding(0);
            this.audio_waveViewer.Name = "audio_waveViewer";
            this.audio_waveViewer.SamplesPerPixel = 128;
            this.audio_waveViewer.Size = new System.Drawing.Size(374, 65);
            this.audio_waveViewer.StartPosition = ((long)(0));
            this.audio_waveViewer.TabIndex = 6;
            this.audio_waveViewer.WaveStream = null;
            // 
            // entryTitle_textBox
            // 
            this.entryTitle_textBox.BackColor = System.Drawing.SystemColors.Control;
            this.entryTitle_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.audioControlData_tableLayoutPanel.SetColumnSpan(this.entryTitle_textBox, 2);
            this.entryTitle_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryTitle_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryTitle_textBox.Location = new System.Drawing.Point(0, 0);
            this.entryTitle_textBox.Margin = new System.Windows.Forms.Padding(0);
            this.entryTitle_textBox.Name = "entryTitle_textBox";
            this.entryTitle_textBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.entryTitle_textBox.Size = new System.Drawing.Size(500, 28);
            this.entryTitle_textBox.TabIndex = 1;
            // 
            // newSaveFile_button
            // 
            this.newSaveFile_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newSaveFile_button.Location = new System.Drawing.Point(425, 0);
            this.newSaveFile_button.Margin = new System.Windows.Forms.Padding(0);
            this.newSaveFile_button.Name = "newSaveFile_button";
            this.newSaveFile_button.Size = new System.Drawing.Size(75, 25);
            this.newSaveFile_button.TabIndex = 3;
            this.newSaveFile_button.Text = "New File";
            this.newSaveFile_button.UseVisualStyleBackColor = true;
            this.newSaveFile_button.Click += new System.EventHandler(this.newSaveFile_button_Click);
            // 
            // entry_dataGridView
            // 
            this.entry_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entry_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entry_dataGridView.Location = new System.Drawing.Point(3, 153);
            this.entry_dataGridView.Name = "entry_dataGridView";
            this.entry_dataGridView.Size = new System.Drawing.Size(494, 544);
            this.entry_dataGridView.TabIndex = 2;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "browse_openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.browse_openFileDialog_FileOk);
            // 
            // Monotone_RecordTranscribe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.control_tableLayoutPanel);
            this.Name = "Monotone_RecordTranscribe";
            this.Size = new System.Drawing.Size(500, 700);
            this.control_tableLayoutPanel.ResumeLayout(false);
            this.audioSourceAndControl_tableLayoutPanel.ResumeLayout(false);
            this.audioSourceAndControl_tableLayoutPanel.PerformLayout();
            this.audioControlData_tableLayoutPanel.ResumeLayout(false);
            this.audioControlData_tableLayoutPanel.PerformLayout();
            this.audioControls_tableLayoutPanel.ResumeLayout(false);
            this.audioControls_tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audio_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entry_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel control_tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel audioSourceAndControl_tableLayoutPanel;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.Label filePath_label;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel audioControlData_tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel audioControls_tableLayoutPanel;
        private System.Windows.Forms.Button record_button;
        private System.Windows.Forms.Button play_button;
        private System.Windows.Forms.Label timeIndex_label;
        private System.Windows.Forms.Button newSaveFile_button;
        private System.Windows.Forms.Button rewind_button;
        private System.Windows.Forms.Button fastforward_button;
        private System.Windows.Forms.TrackBar audio_trackBar;
        private System.Windows.Forms.TextBox entryTitle_textBox;
        public NAudio.Gui.WaveViewer audio_waveViewer;
        public System.Windows.Forms.DataGridView entry_dataGridView;
    }
}
