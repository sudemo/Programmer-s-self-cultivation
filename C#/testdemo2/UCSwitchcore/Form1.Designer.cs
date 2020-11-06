namespace UCSwitchcore
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
            this.ucSwitch1 = new UCS.UCSwitch();
            this.ucSwitch2 = new UCS.UCSwitch();
            this.SuspendLayout();
            // 
            // ucSwitch1
            // 
            this.ucSwitch1.Checked = false;
            this.ucSwitch1.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch1.FalseTextColr = System.Drawing.Color.White;
            this.ucSwitch1.Location = new System.Drawing.Point(426, 210);
            this.ucSwitch1.Margin = new System.Windows.Forms.Padding(4);
            this.ucSwitch1.Name = "ucSwitch1";
            this.ucSwitch1.Size = new System.Drawing.Size(114, 46);
            this.ucSwitch1.SwitchType = UCS.SwitchType.Quadrilateral;
            this.ucSwitch1.TabIndex = 0;
            this.ucSwitch1.Texts = new string[] {
        "已开启",
        "已关闭"};
            this.ucSwitch1.TrueColor = System.Drawing.Color.Green;
            this.ucSwitch1.TrueTextColr = System.Drawing.Color.White;
            this.ucSwitch1.CheckedChanged += new System.EventHandler(this.ucSwitch1_CheckedChanged);
            // 
            // ucSwitch2
            // 
            this.ucSwitch2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucSwitch2.Checked = false;
            this.ucSwitch2.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch2.FalseTextColr = System.Drawing.Color.White;
            this.ucSwitch2.Location = new System.Drawing.Point(351, 13);
            this.ucSwitch2.Margin = new System.Windows.Forms.Padding(4);
            this.ucSwitch2.Name = "ucSwitch2";
            this.ucSwitch2.Size = new System.Drawing.Size(57, 67);
            this.ucSwitch2.SwitchType = UCS.SwitchType.Line1;
            this.ucSwitch2.TabIndex = 1;
            this.ucSwitch2.Texts = new string[] {
        "已开启",
        "已关闭"};
            this.ucSwitch2.TrueColor = System.Drawing.Color.Green;
            this.ucSwitch2.TrueTextColr = System.Drawing.Color.White;
            this.ucSwitch2.CheckedChanged += new System.EventHandler(this.ucSwitch2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucSwitch2);
            this.Controls.Add(this.ucSwitch1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UCS.UCSwitch ucSwitch1;
        private UCS.UCSwitch ucSwitch2;
    }
}

