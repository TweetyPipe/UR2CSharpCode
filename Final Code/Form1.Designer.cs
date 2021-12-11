
namespace Final_Code
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
            this.coloredPictureBox = new System.Windows.Forms.PictureBox();
            this.rawPictureBox = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.coordLabel = new System.Windows.Forms.Label();
            this.estopButton = new System.Windows.Forms.Button();
            this.contourPictureBox = new System.Windows.Forms.PictureBox();
            this.xCoordBox = new System.Windows.Forms.TextBox();
            this.yCoordBox = new System.Windows.Forms.TextBox();
            this.returnedPointLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lockStateToolStripStatusLabel = new System.Windows.Forms.ToolStripLabel();
            this.sendBtn = new System.Windows.Forms.Button();
            this.debugLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.coloredPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rawPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourPictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // coloredPictureBox
            // 
            this.coloredPictureBox.Location = new System.Drawing.Point(1082, 12);
            this.coloredPictureBox.Name = "coloredPictureBox";
            this.coloredPictureBox.Size = new System.Drawing.Size(420, 400);
            this.coloredPictureBox.TabIndex = 0;
            this.coloredPictureBox.TabStop = false;
            // 
            // rawPictureBox
            // 
            this.rawPictureBox.Location = new System.Drawing.Point(12, 12);
            this.rawPictureBox.Name = "rawPictureBox";
            this.rawPictureBox.Size = new System.Drawing.Size(420, 400);
            this.rawPictureBox.TabIndex = 1;
            this.rawPictureBox.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Lime;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.startButton.Location = new System.Drawing.Point(177, 523);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(128, 75);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start Sorting";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(979, 569);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Coordinates of Shape to Grab:";
            // 
            // coordLabel
            // 
            this.coordLabel.AutoSize = true;
            this.coordLabel.Location = new System.Drawing.Point(1255, 569);
            this.coordLabel.Name = "coordLabel";
            this.coordLabel.Size = new System.Drawing.Size(46, 17);
            this.coordLabel.TabIndex = 4;
            this.coordLabel.Text = "label2";
            // 
            // estopButton
            // 
            this.estopButton.BackColor = System.Drawing.Color.Red;
            this.estopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.estopButton.Location = new System.Drawing.Point(634, 533);
            this.estopButton.Name = "estopButton";
            this.estopButton.Size = new System.Drawing.Size(194, 81);
            this.estopButton.TabIndex = 5;
            this.estopButton.Text = "STOP";
            this.estopButton.UseVisualStyleBackColor = false;
            this.estopButton.Click += new System.EventHandler(this.estopButton_Click);
            // 
            // contourPictureBox
            // 
            this.contourPictureBox.Location = new System.Drawing.Point(554, 12);
            this.contourPictureBox.Name = "contourPictureBox";
            this.contourPictureBox.Size = new System.Drawing.Size(420, 400);
            this.contourPictureBox.TabIndex = 6;
            this.contourPictureBox.TabStop = false;
            // 
            // xCoordBox
            // 
            this.xCoordBox.Location = new System.Drawing.Point(346, 523);
            this.xCoordBox.Name = "xCoordBox";
            this.xCoordBox.Size = new System.Drawing.Size(53, 22);
            this.xCoordBox.TabIndex = 7;
            // 
            // yCoordBox
            // 
            this.yCoordBox.Location = new System.Drawing.Point(346, 576);
            this.yCoordBox.Name = "yCoordBox";
            this.yCoordBox.Size = new System.Drawing.Size(53, 22);
            this.yCoordBox.TabIndex = 8;
            // 
            // returnedPointLabel
            // 
            this.returnedPointLabel.AutoSize = true;
            this.returnedPointLabel.Location = new System.Drawing.Point(533, 563);
            this.returnedPointLabel.Name = "returnedPointLabel";
            this.returnedPointLabel.Size = new System.Drawing.Size(46, 17);
            this.returnedPointLabel.TabIndex = 10;
            this.returnedPointLabel.Text = "label2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lockStateToolStripStatusLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 705);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1554, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lockStateToolStripStatusLabel
            // 
            this.lockStateToolStripStatusLabel.Name = "lockStateToolStripStatusLabel";
            this.lockStateToolStripStatusLabel.Size = new System.Drawing.Size(107, 22);
            this.lockStateToolStripStatusLabel.Text = "Lock Tool Strip";
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(421, 555);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(65, 21);
            this.sendBtn.TabIndex = 12;
            this.sendBtn.Text = "button1";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.Location = new System.Drawing.Point(1003, 460);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(46, 17);
            this.debugLabel.TabIndex = 13;
            this.debugLabel.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 730);
            this.Controls.Add(this.debugLabel);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.returnedPointLabel);
            this.Controls.Add(this.yCoordBox);
            this.Controls.Add(this.xCoordBox);
            this.Controls.Add(this.contourPictureBox);
            this.Controls.Add(this.estopButton);
            this.Controls.Add(this.coordLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.rawPictureBox);
            this.Controls.Add(this.coloredPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coloredPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rawPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourPictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox coloredPictureBox;
        private System.Windows.Forms.PictureBox rawPictureBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label coordLabel;
        private System.Windows.Forms.Button estopButton;
        private System.Windows.Forms.PictureBox contourPictureBox;
        private System.Windows.Forms.TextBox xCoordBox;
        private System.Windows.Forms.TextBox yCoordBox;
        private System.Windows.Forms.Label returnedPointLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lockStateToolStripStatusLabel;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label debugLabel;
    }
}

