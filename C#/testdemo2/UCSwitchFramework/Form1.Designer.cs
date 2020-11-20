namespace UCSwitchFramework
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
            this.ucSwitchFramewk2 = new UCSwitchFramework.UCSwitchFramewk();
            this.ucSwitchFramewk1 = new UCSwitchFramework.UCSwitchFramewk();
            this.SuspendLayout();
            // 
            // ucSwitchFramewk2
            // 
            this.ucSwitchFramewk2.Checked = false;
            this.ucSwitchFramewk2.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitchFramewk2.FalseTextColr = System.Drawing.Color.White;
            this.ucSwitchFramewk2.Location = new System.Drawing.Point(478, 166);
            this.ucSwitchFramewk2.Name = "ucSwitchFramewk2";
            this.ucSwitchFramewk2.Size = new System.Drawing.Size(107, 42);
            this.ucSwitchFramewk2.SwitchType = UCSwitchFramework.SwitchType.Ellipse;
            this.ucSwitchFramewk2.TabIndex = 3;
            this.ucSwitchFramewk2.Texts = new string[] {
        "已开启",
        "已关闭"};
            this.ucSwitchFramewk2.TrueColor = System.Drawing.Color.Green;
            this.ucSwitchFramewk2.TrueTextColr = System.Drawing.Color.White;
            // 
            // ucSwitchFramewk1
            // 
            this.ucSwitchFramewk1.Checked = false;
            this.ucSwitchFramewk1.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitchFramewk1.FalseTextColr = System.Drawing.Color.White;
            this.ucSwitchFramewk1.Location = new System.Drawing.Point(591, 105);
            this.ucSwitchFramewk1.Name = "ucSwitchFramewk1";
            this.ucSwitchFramewk1.Size = new System.Drawing.Size(107, 42);
            this.ucSwitchFramewk1.SwitchType = UCSwitchFramework.SwitchType.Ellipse;
            this.ucSwitchFramewk1.TabIndex = 4;
            this.ucSwitchFramewk1.Texts = new string[] {
        "已开启",
        "已关闭"};
            this.ucSwitchFramewk1.TrueColor = System.Drawing.Color.Green;
            this.ucSwitchFramewk1.TrueTextColr = System.Drawing.Color.White;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucSwitchFramewk1);
            this.Controls.Add(this.ucSwitchFramewk2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UCSwitchFramewk ucSwitchFramewk2;
        private UCSwitchFramewk ucSwitchFramewk1;
    }
}

