namespace vppdemo2
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cogDisplay1 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay2 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay3 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay4 = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相机1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相机2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay4)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.54773F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.45227F));
            this.tableLayoutPanel1.Controls.Add(this.cogDisplay1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cogDisplay2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cogDisplay3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cogDisplay4, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-1, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(639, 371);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cogDisplay1
            // 
            this.cogDisplay1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cogDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay1.Location = new System.Drawing.Point(3, 3);
            this.cogDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay1.MouseWheelSensitivity = 1D;
            this.cogDisplay1.Name = "cogDisplay1";
            this.cogDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay1.OcxState")));
            this.cogDisplay1.Size = new System.Drawing.Size(316, 179);
            this.cogDisplay1.TabIndex = 0;
            this.cogDisplay1.DoubleClick += new System.EventHandler(this.cogDisplay1_DoubleClick);
            this.cogDisplay1.Enter += new System.EventHandler(this.cogDisplay1_Enter_1);
            // 
            // cogDisplay2
            // 
            this.cogDisplay2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cogDisplay2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay2.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay2.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay2.DoubleTapZoomCycleLength = 2;
            this.cogDisplay2.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay2.Location = new System.Drawing.Point(325, 3);
            this.cogDisplay2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay2.MouseWheelSensitivity = 1D;
            this.cogDisplay2.Name = "cogDisplay2";
            this.cogDisplay2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay2.OcxState")));
            this.cogDisplay2.Size = new System.Drawing.Size(311, 179);
            this.cogDisplay2.TabIndex = 1;
            this.cogDisplay2.Enter += new System.EventHandler(this.cogDisplay2_Enter);
            // 
            // cogDisplay3
            // 
            this.cogDisplay3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cogDisplay3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay3.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay3.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay3.DoubleTapZoomCycleLength = 2;
            this.cogDisplay3.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay3.Location = new System.Drawing.Point(3, 188);
            this.cogDisplay3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay3.MouseWheelSensitivity = 1D;
            this.cogDisplay3.Name = "cogDisplay3";
            this.cogDisplay3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay3.OcxState")));
            this.cogDisplay3.Size = new System.Drawing.Size(316, 180);
            this.cogDisplay3.TabIndex = 2;
            // 
            // cogDisplay4
            // 
            this.cogDisplay4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cogDisplay4.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay4.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay4.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay4.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay4.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay4.DoubleTapZoomCycleLength = 2;
            this.cogDisplay4.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay4.Location = new System.Drawing.Point(325, 188);
            this.cogDisplay4.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay4.MouseWheelSensitivity = 1D;
            this.cogDisplay4.Name = "cogDisplay4";
            this.cogDisplay4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay4.OcxState")));
            this.cogDisplay4.Size = new System.Drawing.Size(311, 180);
            this.cogDisplay4.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_start, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_stop, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(106, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(445, 50);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(109, 3);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(100, 44);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "btn_start";
            this.btn_start.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(215, 3);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(102, 44);
            this.btn_stop.TabIndex = 0;
            this.btn_stop.Text = "btn_stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.相机1ToolStripMenuItem,
            this.相机2ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 相机1ToolStripMenuItem
            // 
            this.相机1ToolStripMenuItem.Name = "相机1ToolStripMenuItem";
            this.相机1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.相机1ToolStripMenuItem.Text = "相机1";
            this.相机1ToolStripMenuItem.Click += new System.EventHandler(this.相机1ToolStripMenuItem_Click);
            // 
            // 相机2ToolStripMenuItem
            // 
            this.相机2ToolStripMenuItem.Name = "相机2ToolStripMenuItem";
            this.相机2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.相机2ToolStripMenuItem.Text = "相机2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 410);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay4)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay1;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay2;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay3;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 相机1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 相机2ToolStripMenuItem;


    }
}