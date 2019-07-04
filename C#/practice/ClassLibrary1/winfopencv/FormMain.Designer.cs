namespace winfopencv
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.RadioAvi = new System.Windows.Forms.RadioButton();
            this.RadioWebCam = new System.Windows.Forms.RadioButton();
            this.pictureBoxIpl1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(32, 226);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "BtnStart";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(184, 226);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStop.TabIndex = 1;
            this.BtnStop.Text = "BtnStop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(32, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 49);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // RadioAvi
            // 
            this.RadioAvi.AutoSize = true;
            this.RadioAvi.Location = new System.Drawing.Point(201, 170);
            this.RadioAvi.Name = "RadioAvi";
            this.RadioAvi.Size = new System.Drawing.Size(71, 16);
            this.RadioAvi.TabIndex = 3;
            this.RadioAvi.TabStop = true;
            this.RadioAvi.Text = "radioavi";
            this.RadioAvi.UseVisualStyleBackColor = true;
            // 
            // RadioWebCam
            // 
            this.RadioWebCam.AutoSize = true;
            this.RadioWebCam.Location = new System.Drawing.Point(201, 204);
            this.RadioWebCam.Name = "RadioWebCam";
            this.RadioWebCam.Size = new System.Drawing.Size(71, 16);
            this.RadioWebCam.TabIndex = 4;
            this.RadioWebCam.TabStop = true;
            this.RadioWebCam.Text = "radioCam";
            this.RadioWebCam.UseVisualStyleBackColor = true;
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(32, 87);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(200, 50);
            this.pictureBoxIpl1.TabIndex = 5;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Controls.Add(this.RadioWebCam);
            this.Controls.Add(this.RadioAvi);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton RadioAvi;
        private System.Windows.Forms.RadioButton RadioWebCam;
        private System.Windows.Forms.PictureBox pictureBoxIpl1;
    }
}

