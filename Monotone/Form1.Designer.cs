namespace Monotone
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.window_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.window_menuStrip = new System.Windows.Forms.MenuStrip();
            this.file_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.window_splitContainer = new System.Windows.Forms.SplitContainer();
            this.monotone_RecordTranscribe1 = new Monotone.Monotone_RecordTranscribe();
            this.window_tableLayoutPanel.SuspendLayout();
            this.window_menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.window_splitContainer)).BeginInit();
            this.window_splitContainer.Panel1.SuspendLayout();
            this.window_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // window_tableLayoutPanel
            // 
            this.window_tableLayoutPanel.ColumnCount = 1;
            this.window_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.window_tableLayoutPanel.Controls.Add(this.window_menuStrip, 0, 0);
            this.window_tableLayoutPanel.Controls.Add(this.window_splitContainer, 0, 1);
            this.window_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.window_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.window_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.window_tableLayoutPanel.Name = "window_tableLayoutPanel";
            this.window_tableLayoutPanel.RowCount = 2;
            this.window_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.window_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.window_tableLayoutPanel.Size = new System.Drawing.Size(800, 461);
            this.window_tableLayoutPanel.TabIndex = 0;
            // 
            // window_menuStrip
            // 
            this.window_menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.window_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_ToolStripMenuItem});
            this.window_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.window_menuStrip.Name = "window_menuStrip";
            this.window_menuStrip.Size = new System.Drawing.Size(800, 25);
            this.window_menuStrip.TabIndex = 0;
            this.window_menuStrip.Text = "menuStrip1";
            // 
            // file_ToolStripMenuItem
            // 
            this.file_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quit_ToolStripMenuItem});
            this.file_ToolStripMenuItem.Name = "file_ToolStripMenuItem";
            this.file_ToolStripMenuItem.Size = new System.Drawing.Size(37, 21);
            this.file_ToolStripMenuItem.Text = "File";
            // 
            // quit_ToolStripMenuItem
            // 
            this.quit_ToolStripMenuItem.Name = "quit_ToolStripMenuItem";
            this.quit_ToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quit_ToolStripMenuItem.Text = "Quit";
            this.quit_ToolStripMenuItem.ToolTipText = "Exit the application";
            // 
            // window_splitContainer
            // 
            this.window_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.window_splitContainer.Location = new System.Drawing.Point(3, 28);
            this.window_splitContainer.Name = "window_splitContainer";
            // 
            // window_splitContainer.Panel1
            // 
            this.window_splitContainer.Panel1.Controls.Add(this.monotone_RecordTranscribe1);
            this.window_splitContainer.Size = new System.Drawing.Size(794, 430);
            this.window_splitContainer.SplitterDistance = 500;
            this.window_splitContainer.TabIndex = 1;
            // 
            // monotone_RecordTranscribe1
            // 
            this.monotone_RecordTranscribe1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monotone_RecordTranscribe1.Location = new System.Drawing.Point(0, 0);
            this.monotone_RecordTranscribe1.Name = "monotone_RecordTranscribe1";
            this.monotone_RecordTranscribe1.Size = new System.Drawing.Size(500, 430);
            this.monotone_RecordTranscribe1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.window_tableLayoutPanel);
            this.MainMenuStrip = this.window_menuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.window_tableLayoutPanel.ResumeLayout(false);
            this.window_tableLayoutPanel.PerformLayout();
            this.window_menuStrip.ResumeLayout(false);
            this.window_menuStrip.PerformLayout();
            this.window_splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.window_splitContainer)).EndInit();
            this.window_splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel window_tableLayoutPanel;
        private System.Windows.Forms.MenuStrip window_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem file_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quit_ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer window_splitContainer;
        private Monotone_RecordTranscribe monotone_RecordTranscribe1;
    }
}

