namespace QScaleNew
{
    partial class frmSplash
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
            this.MyProgressBar = new Framework.Controls.XpProgressBar();
            this.bgwPrimaryDataLoader = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MyProgressBar
            // 
            this.MyProgressBar.ColorBackGround = System.Drawing.Color.White;
            this.MyProgressBar.ColorBarBorder = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(240)))), ((int)(((byte)(170)))));
            this.MyProgressBar.ColorBarCenter = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(150)))), ((int)(((byte)(10)))));
            this.MyProgressBar.ColorText = System.Drawing.Color.Black;
            this.MyProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MyProgressBar.Location = new System.Drawing.Point(0, 242);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Position = 50;
            this.MyProgressBar.PositionMax = 100;
            this.MyProgressBar.PositionMin = 0;
            this.MyProgressBar.Size = new System.Drawing.Size(435, 18);
            this.MyProgressBar.TabIndex = 1;
            this.MyProgressBar.Text = "xpProgressBar1";
            // 
            // bgwPrimaryDataLoader
            // 
            this.bgwPrimaryDataLoader.WorkerReportsProgress = true;
            this.bgwPrimaryDataLoader.WorkerSupportsCancellation = true;
            this.bgwPrimaryDataLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPrimaryDataLoader_DoWork);
            this.bgwPrimaryDataLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwPrimaryDataLoader_ProgressChanged);
            this.bgwPrimaryDataLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwPrimaryDataLoader_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 242);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(90, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 10);
            this.label1.TabIndex = 44;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QScaleNew.Properties.Resources.WeighStation;
            this.pictureBox1.Location = new System.Drawing.Point(92, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Impact", 70F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label9.Location = new System.Drawing.Point(54, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(351, 115);
            this.label9.TabIndex = 42;
            this.label9.Text = "WScale";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(435, 260);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MyProgressBar);
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.Load += new System.EventHandler(this.frmSplash_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.Controls.XpProgressBar MyProgressBar;
        private System.ComponentModel.BackgroundWorker bgwPrimaryDataLoader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}