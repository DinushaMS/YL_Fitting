namespace YL_Final
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tbR = new System.Windows.Forms.TrackBar();
            this.tbq = new System.Windows.Forms.TrackBar();
            this.tbH = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbH)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(659, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Find Edges";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(660, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 84);
            this.label1.TabIndex = 2;
            this.label1.Text = "X: 0.00   Y:0.00\r\nRed     :000\r\nGreen  :000\r\nBlue     :000";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(740, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Fit YL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbR
            // 
            this.tbR.LargeChange = 2;
            this.tbR.Location = new System.Drawing.Point(58, 499);
            this.tbR.Maximum = 1500;
            this.tbR.Minimum = 500;
            this.tbR.Name = "tbR";
            this.tbR.Size = new System.Drawing.Size(641, 45);
            this.tbR.TabIndex = 4;
            this.tbR.Value = 1000;
            this.tbR.Scroll += new System.EventHandler(this.tbR_Scroll);
            // 
            // tbq
            // 
            this.tbq.LargeChange = 2;
            this.tbq.Location = new System.Drawing.Point(58, 550);
            this.tbq.Maximum = 1500;
            this.tbq.Minimum = 500;
            this.tbq.Name = "tbq";
            this.tbq.Size = new System.Drawing.Size(641, 45);
            this.tbq.TabIndex = 4;
            this.tbq.Value = 1000;
            this.tbq.Scroll += new System.EventHandler(this.tbq_Scroll);
            // 
            // tbH
            // 
            this.tbH.Location = new System.Drawing.Point(670, 202);
            this.tbH.Maximum = 1200;
            this.tbH.Minimum = 800;
            this.tbH.Name = "tbH";
            this.tbH.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbH.Size = new System.Drawing.Size(45, 300);
            this.tbH.TabIndex = 5;
            this.tbH.Value = 1000;
            this.tbH.Scroll += new System.EventHandler(this.tbH_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(740, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 105);
            this.label2.TabIndex = 6;
            this.label2.Text = "CA  :0.00°\r\nR     :0.00 mm\r\nq     :0.00 cm⁻²\r\nh     :0.00 mm\r\nSE   :0.00 mN/m";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(659, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(670, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "h %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(10, 499);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "R %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(13, 550);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 30);
            this.label5.TabIndex = 8;
            this.label5.Text = "q %";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 601);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbH);
            this.Controls.Add(this.tbq);
            this.Controls.Add(this.tbR);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Young Laplace Curve Fit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar tbR;
        private System.Windows.Forms.TrackBar tbq;
        private System.Windows.Forms.TrackBar tbH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

