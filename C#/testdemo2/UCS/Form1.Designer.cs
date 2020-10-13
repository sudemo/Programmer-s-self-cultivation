namespace UCS
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ucSwitch4 = new UCS.UCSwitch();
            this.ucSwitch3 = new UCS.UCSwitch();
            this.ucSwitch1 = new UCS.UCSwitch();
            this.ucSwitch2 = new UCS.UCSwitch();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucSwitch4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ucSwitch3);
            this.panel1.Controls.Add(this.ucSwitch1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ucSwitch2);
            this.panel1.Location = new System.Drawing.Point(588, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 257);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "保存原图";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(4, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "空跑 ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(4, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "屏蔽NG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(4, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Debug";
            // 
            // ucSwitch4
            // 
            this.ucSwitch4.Checked = false;
            this.ucSwitch4.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch4.FalseTextColr = System.Drawing.Color.White;
            this.ucSwitch4.Location = new System.Drawing.Point(116, 152);
            this.ucSwitch4.Name = "ucSwitch4";
            this.ucSwitch4.Size = new System.Drawing.Size(81, 29);
            this.ucSwitch4.SwitchType = UCS.SwitchType.Ellipse;
            this.ucSwitch4.TabIndex = 13;
            this.ucSwitch4.Texts = new string[] {
        "已开启",
        "已关闭"};
            this.ucSwitch4.TrueColor = System.Drawing.Color.Green;
            this.ucSwitch4.TrueTextColr = System.Drawing.Color.White;
            // 
            // ucSwitch3
            // 
            this.ucSwitch3.Checked = false;
            this.ucSwitch3.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch3.FalseTextColr = System.Drawing.Color.White;
            this.ucSwitch3.Location = new System.Drawing.Point(116, 101);
            this.ucSwitch3.Name = "ucSwitch3";
            this.ucSwitch3.Size = new System.Drawing.Size(81, 29);
            this.ucSwitch3.SwitchType = UCS.SwitchType.Ellipse;
            this.ucSwitch3.TabIndex = 11;
            this.ucSwitch3.Texts = new string[] {
        "已开启",
        "已关闭"};
            this.ucSwitch3.TrueColor = System.Drawing.Color.Green;
            this.ucSwitch3.TrueTextColr = System.Drawing.Color.White;
            // 
            // ucSwitch1
            // 
            this.ucSwitch1.Checked = false;
            this.ucSwitch1.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch1.FalseTextColr = System.Drawing.Color.White;
            this.ucSwitch1.Location = new System.Drawing.Point(116, 59);
            this.ucSwitch1.Name = "ucSwitch1";
            this.ucSwitch1.Size = new System.Drawing.Size(81, 29);
            this.ucSwitch1.SwitchType = UCS.SwitchType.Ellipse;
            this.ucSwitch1.TabIndex = 10;
            this.ucSwitch1.Texts = new string[] {
        "已开启",
        "已关闭"};
            this.ucSwitch1.TrueColor = System.Drawing.Color.Green;
            this.ucSwitch1.TrueTextColr = System.Drawing.Color.White;
            // 
            // ucSwitch2
            // 
            this.ucSwitch2.Checked = false;
            this.ucSwitch2.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch2.FalseTextColr = System.Drawing.Color.White;
            this.ucSwitch2.Location = new System.Drawing.Point(116, 12);
            this.ucSwitch2.Name = "ucSwitch2";
            this.ucSwitch2.Size = new System.Drawing.Size(81, 29);
            this.ucSwitch2.SwitchType = UCS.SwitchType.Ellipse;
            this.ucSwitch2.TabIndex = 3;
            this.ucSwitch2.Texts = new string[] {
        "已开启",
        "已关闭"};
            this.ucSwitch2.TrueColor = System.Drawing.Color.Green;
            this.ucSwitch2.TrueTextColr = System.Drawing.Color.White;
            this.ucSwitch2.CheckedChanged += new System.EventHandler(this.ucSwitch2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private UCSwitch ucSwitch2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private UCSwitch ucSwitch4;
        private System.Windows.Forms.Label label5;
        private UCSwitch ucSwitch3;
        private UCSwitch ucSwitch1;
        private System.Windows.Forms.Label label4;
    }
}