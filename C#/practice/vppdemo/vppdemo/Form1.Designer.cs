namespace vppdemo
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
            this.cogToolBlockEditV22 = new Cognex.VisionPro.ToolBlock.CogToolBlockEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV22)).BeginInit();
            this.SuspendLayout();
            // 
            // cogToolBlockEditV22
            // 
            this.cogToolBlockEditV22.AllowDrop = true;
            this.cogToolBlockEditV22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cogToolBlockEditV22.AutoSize = true;
            this.cogToolBlockEditV22.ContextMenuCustomizer = null;
            this.cogToolBlockEditV22.Location = new System.Drawing.Point(-2, -3);
            this.cogToolBlockEditV22.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogToolBlockEditV22.Name = "cogToolBlockEditV22";
            this.cogToolBlockEditV22.ShowNodeToolTips = true;
            this.cogToolBlockEditV22.Size = new System.Drawing.Size(951, 517);
            this.cogToolBlockEditV22.SuspendElectricRuns = false;
            this.cogToolBlockEditV22.TabIndex = 3;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(947, 506);
            this.Controls.Add(this.cogToolBlockEditV22);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV22)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Cognex.VisionPro.ToolBlock.CogToolBlockEditV2 cogToolBlockEditV21;
        private Cognex.VisionPro.ToolBlock.CogToolBlockEditV2 cogToolBlockEditV22;
    }
}

