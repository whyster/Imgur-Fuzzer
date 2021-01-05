namespace ImgurFuzzerProject {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.imgurPreview = new System.Windows.Forms.PictureBox();
            this.containerControl1 = new System.Windows.Forms.ContainerControl();
            this.saveFileLabel = new System.Windows.Forms.Label();
            this.saveFileLocation = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.startButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.stopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.imgurPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // imgurPreview
            // 
            this.imgurPreview.Location = new System.Drawing.Point(12, 35);
            this.imgurPreview.Name = "imgurPreview";
            this.imgurPreview.Size = new System.Drawing.Size(205, 169);
            this.imgurPreview.TabIndex = 0;
            this.imgurPreview.TabStop = false;
            // 
            // containerControl1
            // 
            this.containerControl1.Location = new System.Drawing.Point(0, 0);
            this.containerControl1.Name = "containerControl1";
            this.containerControl1.Size = new System.Drawing.Size(0, 0);
            this.containerControl1.TabIndex = 0;
            this.containerControl1.Text = "containerControl1";
            // 
            // saveFileLabel
            // 
            this.saveFileLabel.Location = new System.Drawing.Point(12, 9);
            this.saveFileLabel.Name = "saveFileLabel";
            this.saveFileLabel.Size = new System.Drawing.Size(99, 23);
            this.saveFileLabel.TabIndex = 2;
            this.saveFileLabel.Text = "Save File Location:";
            this.saveFileLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // saveFileLocation
            // 
            this.saveFileLocation.Location = new System.Drawing.Point(117, 6);
            this.saveFileLocation.Name = "saveFileLocation";
            this.saveFileLocation.ReadOnly = true;
            this.saveFileLocation.Size = new System.Drawing.Size(284, 20);
            this.saveFileLocation.TabIndex = 1;
            this.saveFileLocation.Click += new System.EventHandler(this.OpenSaveFileDialog);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*;";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.startButton.Location = new System.Drawing.Point(223, 35);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(178, 29);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start Fuzzing";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartFuzzing);
            // 
            // logBox
            // 
            this.logBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.logBox.Location = new System.Drawing.Point(223, 70);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(178, 42);
            this.logBox.TabIndex = 4;
            this.logBox.Text = "AAAAAAA";
            this.logBox.TextChanged += new System.EventHandler(this.TextScroll);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.StartFuzzingBackground);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.stopButton.Location = new System.Drawing.Point(223, 118);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(178, 29);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop Fuzzing";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopFuzzingWorker);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 221);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.saveFileLabel);
            this.Controls.Add(this.saveFileLocation);
            this.Controls.Add(this.imgurPreview);
            this.MaximumSize = new System.Drawing.Size(429, 260);
            this.MinimumSize = new System.Drawing.Size(429, 260);
            this.Name = "Form1";
            this.Text = "I.Imgur Fuzzer";
            ((System.ComponentModel.ISupportInitialize) (this.imgurPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button stopButton;

        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        private System.Windows.Forms.ErrorProvider errorProvider1;

        private System.Windows.Forms.PictureBox imgurPreview;
        private System.Windows.Forms.Label saveFileLabel;

        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.TextBox saveFileLocation;
        private System.Windows.Forms.Button startButton;

        private System.Windows.Forms.SaveFileDialog saveFileDialog;

        private System.Windows.Forms.ContainerControl containerControl1;

        #endregion
    }
}