namespace vppdemo2
{
    partial class Form1
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
            this.cogBlobEditV21 = new Cognex.VisionPro.Blob.CogBlobEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogBlobEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogBlobEditV21
            // 
            this.cogBlobEditV21.Location = new System.Drawing.Point(12, 12);
            this.cogBlobEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogBlobEditV21.Name = "cogBlobEditV21";
            this.cogBlobEditV21.Size = new System.Drawing.Size(748, 402);
            this.cogBlobEditV21.SuspendElectricRuns = false;
            this.cogBlobEditV21.TabIndex = 0;
            this.cogBlobEditV21.Load += new System.EventHandler(this.cogBlobEditV21_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 466);
            this.Controls.Add(this.cogBlobEditV21);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogBlobEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.Blob.CogBlobEditV2 cogBlobEditV21;
    }
}

