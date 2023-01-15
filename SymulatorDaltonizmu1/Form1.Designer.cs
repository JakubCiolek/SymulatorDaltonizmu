namespace SymulatorDaltonizmu1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.start = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cLibrary = new System.Windows.Forms.RadioButton();
            this.asmLibrary = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.defaultView = new System.Windows.Forms.PictureBox();
            this.colorBlindView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBlindView)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(794, 369);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(130, 69);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(658, 369);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(130, 69);
            this.load.TabIndex = 1;
            this.load.Text = "Wczytaj obraz";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Normalny widok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Deuteranopia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Wybór biblioteki:";
            // 
            // cLibrary
            // 
            this.cLibrary.AutoSize = true;
            this.cLibrary.Checked = true;
            this.cLibrary.Location = new System.Drawing.Point(28, 387);
            this.cLibrary.Name = "cLibrary";
            this.cLibrary.Size = new System.Drawing.Size(40, 19);
            this.cLibrary.TabIndex = 5;
            this.cLibrary.TabStop = true;
            this.cLibrary.Text = "C#";
            this.cLibrary.UseVisualStyleBackColor = true;
            this.cLibrary.CheckedChanged += new System.EventHandler(this.cLibrary_CheckedChanged);
            // 
            // asmLibrary
            // 
            this.asmLibrary.AutoSize = true;
            this.asmLibrary.Location = new System.Drawing.Point(28, 412);
            this.asmLibrary.Name = "asmLibrary";
            this.asmLibrary.Size = new System.Drawing.Size(50, 19);
            this.asmLibrary.TabIndex = 6;
            this.asmLibrary.Text = "ASM";
            this.asmLibrary.UseVisualStyleBackColor = true;
            this.asmLibrary.CheckedChanged += new System.EventHandler(this.asmLibrary_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ilość wątków:";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(208, 387);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(395, 45);
            this.trackBar1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 426);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(590, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "64";
            // 
            // defaultView
            // 
            this.defaultView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.defaultView.Location = new System.Drawing.Point(28, 47);
            this.defaultView.Name = "defaultView";
            this.defaultView.Size = new System.Drawing.Size(444, 308);
            this.defaultView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.defaultView.TabIndex = 11;
            this.defaultView.TabStop = false;
            // 
            // colorBlindView
            // 
            this.colorBlindView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.colorBlindView.Location = new System.Drawing.Point(480, 47);
            this.colorBlindView.Name = "colorBlindView";
            this.colorBlindView.Size = new System.Drawing.Size(444, 308);
            this.colorBlindView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.colorBlindView.TabIndex = 12;
            this.colorBlindView.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 450);
            this.Controls.Add(this.colorBlindView);
            this.Controls.Add(this.defaultView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.asmLibrary);
            this.Controls.Add(this.cLibrary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.load);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "SymulatorDaltonizmu";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBlindView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button start;
        private Button load;
        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton cLibrary;
        private RadioButton asmLibrary;
        private Label label4;
        private TrackBar trackBar1;
        private Label label5;
        private Label label6;
        private PictureBox defaultView;
        private PictureBox colorBlindView;
    }
}