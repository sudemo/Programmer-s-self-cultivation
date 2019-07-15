namespace testmethod
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
            this.txtDecoderType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDecoderType
            // 
            this.txtDecoderType.Location = new System.Drawing.Point(65, 27);
            this.txtDecoderType.Multiline = true;
            this.txtDecoderType.Name = "txtDecoderType";
            this.txtDecoderType.Size = new System.Drawing.Size(130, 81);
            this.txtDecoderType.TabIndex = 0;
            //this.txtDecoderType.TextChanged += new System.EventHandler(this.txtDecoderType_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtDecoderType);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDecoderType;
    }
}