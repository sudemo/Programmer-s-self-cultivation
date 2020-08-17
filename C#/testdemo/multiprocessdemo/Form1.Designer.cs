namespace multiprocessdemo
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
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.process1 = new System.Diagnostics.Process();
            this.button3_open_socketprocess = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GreypictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4_open_socketprocess = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GreypictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(345, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "open2#";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 139);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(794, 114);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            this.process1.Exited += new System.EventHandler(this.process1_Exited);
            // 
            // button3_open_socketprocess
            // 
            this.button3_open_socketprocess.BackColor = System.Drawing.Color.LimeGreen;
            this.button3_open_socketprocess.Location = new System.Drawing.Point(3, 12);
            this.button3_open_socketprocess.Name = "button3_open_socketprocess";
            this.button3_open_socketprocess.Size = new System.Drawing.Size(104, 73);
            this.button3_open_socketprocess.TabIndex = 5;
            this.button3_open_socketprocess.Text = "开启数据进程";
            this.button3_open_socketprocess.UseVisualStyleBackColor = false;
            this.button3_open_socketprocess.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(630, 415);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(435, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "open1#";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GreypictureBox1
            // 
            this.GreypictureBox1.Image = global::multiprocessdemo.Properties.Resources.red;
            this.GreypictureBox1.Location = new System.Drawing.Point(722, 12);
            this.GreypictureBox1.Name = "GreypictureBox1";
            this.GreypictureBox1.Size = new System.Drawing.Size(66, 55);
            this.GreypictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GreypictureBox1.TabIndex = 8;
            this.GreypictureBox1.TabStop = false;
            this.GreypictureBox1.BindingContextChanged += new System.EventHandler(this.button1_Click);
            // 
            // button4_open_socketprocess
            // 
            this.button4_open_socketprocess.BackColor = System.Drawing.Color.Red;
            this.button4_open_socketprocess.Location = new System.Drawing.Point(113, 14);
            this.button4_open_socketprocess.Name = "button4_open_socketprocess";
            this.button4_open_socketprocess.Size = new System.Drawing.Size(104, 68);
            this.button4_open_socketprocess.TabIndex = 6;
            this.button4_open_socketprocess.Text = "关闭数据进程";
            this.button4_open_socketprocess.UseVisualStyleBackColor = false;
            this.button4_open_socketprocess.Click += new System.EventHandler(this.button4_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(3, 286);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(794, 114);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "接收数据";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(1, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 27);
            this.label2.TabIndex = 13;
            this.label2.Text = "发送命令";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GreypictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4_open_socketprocess);
            this.Controls.Add(this.button3_open_socketprocess);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GreypictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Button button3_open_socketprocess;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox GreypictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4_open_socketprocess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

