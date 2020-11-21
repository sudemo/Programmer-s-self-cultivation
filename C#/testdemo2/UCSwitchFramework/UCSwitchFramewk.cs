using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace UCSwitchFramework
{
    public partial class UCSwitchFramewk : UserControl
    {
        public UCSwitchFramewk()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MouseDown += UCSwitch_MouseDown;
        }
        /// <summary>
        /// Occurs when [checked changed].
        /// </summary>
        [Description("选中改变事件"), Category("自定义")]
        public event EventHandler CheckedChanged;
        /// <summary>
        /// The m true color
        /// </summary>
        //private Color m_trueColor = Color.FromArgb(255, 77, 59);// 橙红
        private Color m_trueColor = Color.Green;
        /// <summary>
        /// Gets or sets the color of the true.
        /// </summary>
        /// <value>The color of the true.</value>
        [Description("选中时颜色"), Category("自定义")]
        public Color TrueColor
        {
            get { return m_trueColor; }
            set
            {
                m_trueColor = value;
                Refresh();
            }
        }
        private Color m_trueTextColr = Color.White;

        [Description("选中时文本颜色"), Category("自定义")]
        public Color TrueTextColr
        {
            get { return m_trueTextColr; }
            set
            {
                m_trueTextColr = value;
                Refresh();
            }
        }

        /// <summary>
        /// The m false color
        /// </summary>
        private Color m_falseColor = Color.FromArgb(189, 189, 189);

        /// <summary>
        /// Gets or sets the color of the false.
        /// </summary>
        /// <value>The color of the false.</value>
        [Description("没有选中时颜色"), Category("自定义")]
        public Color FalseColor
        {
            get { return m_falseColor; }
            set
            {
                m_falseColor = value;
                Refresh();
            }
        }

        private Color m_falseTextColr = Color.White;
        [Description("没有选中时文本颜色"), Category("自定义")]

        public Color FalseTextColr
        {
            get { return m_falseTextColr; }
            set
            {
                m_falseTextColr = value;
                Refresh();
            }
        }

        /// <summary>
        /// The m checked
        /// </summary>
        private bool m_checked;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UCSwitch" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        [Description("是否选中"), Category("自定义")]
        public bool Checked
        {
            get { return m_checked; }
            set
            {
                m_checked = value;
                Refresh();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this, null);
                }
            }
        }

        /// <summary>
        /// The m texts
        /// </summary>
        string[] aa = new string[] { "已开启", "已关闭" };
        private string[] m_texts;
        //private string m_texts;

        /// <summary>
        /// Gets or sets the texts.
        /// </summary>
        /// <value>The texts.</value>
        [Description("文本值，当选中或没有选中时显示，必须是长度为2的数组"), Category("自定义")]
        //public string[] Texts
        //{
        //    get { return m_texts_L; }
        //    set
        //    {
        //        m_texts_L = value;
        //        Refresh();
        //    }
        //}
        public string[] Texts
        {
            get
            {
                if (m_texts == null)
                {
                    return m_texts = this.aa;
                }
                return m_texts;
            }
            set
            {

                m_texts = value;
                Refresh();
            }
        }

        /// <summary>
        /// The m switch type
        /// </summary>
        private SwitchType m_switchType = SwitchType.Ellipse;

        /// <summary>
        /// Gets or sets the type of the switch.
        /// </summary>
        /// <value>The type of the switch.</value>
        [Description("显示类型"), Category("自定义")]
        public SwitchType SwitchType
        {
            get { return m_switchType; }
            set
            {
                m_switchType = value;
                Refresh();
            }
        }

        /// <summary>
        /// 获取或设置控件显示的文字的字体。
        /// </summary>
        /// <value>The font.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Refresh();
            }
        }


        /// <summary>
        /// Handles the MouseDown event of the UCSwitch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void UCSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            Checked = !Checked;
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            //g.SetGDIHigh();
            switch (m_switchType)
            {
                case SwitchType.Ellipse:
                    {
                        var fillColor = m_checked ? m_trueColor : m_falseColor;
                        GraphicsPath path = new GraphicsPath();
                        path.AddLine(new Point(Height / 2, 1), new Point(Width - Height / 2, 1));
                        path.AddArc(new Rectangle(Width - Height - 1, 1, Height - 2, Height - 2), -90, 180);
                        path.AddLine(new Point(Width - Height / 2, Height - 1), new Point(Height / 2, Height - 1));
                        path.AddArc(new Rectangle(1, 1, Height - 2, Height - 2), 90, 180);
                        g.FillPath(new SolidBrush(fillColor), path);

                        string strText = string.Empty;
                        if (m_texts != null && m_texts.Length == 2)
                        //if (m_texts != null )
                        {
                            if (m_checked)
                            {
                                strText = m_texts[0];//已打开
                            }
                            else
                            {
                                strText = m_texts[1]; //已关闭
                            }
                        }

                        if (m_checked)
                        {
                            g.FillEllipse(Brushes.White, new Rectangle(Width - Height - 1 + 2, 1 + 2, Height - 2 - 4, Height - 2 - 4));
                            if (string.IsNullOrEmpty(strText))
                            {
                                //没字 空白
                                g.DrawEllipse(new Pen(Color.White, 2), new Rectangle((Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                            }
                            else
                            {   //已打开 显示位置。x,y
                                SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                                int intTextY = (Height - (int)sizeF.Height) / 2 + 2;//
                                g.DrawString(strText, Font, new SolidBrush(m_trueTextColr), new Point((Height - 2 - 4 - 10) / 2, intTextY));
                            }
                        }
                        else
                        {
                            g.FillEllipse(Brushes.White, new Rectangle(1 + 2, 1 + 2, Height - 2 - 4, Height - 2 - 4));
                            if (string.IsNullOrEmpty(strText))
                            {
                                g.DrawEllipse(new Pen(Color.White, 2), new Rectangle(Width - 2 - (Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                            }
                            else
                            {    //已关闭 显示位置。x,y
                                SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                                int intTextY = (Height - (int)sizeF.Height) / 2 + 2;
                                g.DrawString(strText, Font, new SolidBrush(m_falseTextColr), new Point(Width - 20 - (Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2 - (int)sizeF.Width / 2, intTextY));
                            }
                        }

                        break;
                    }

                case SwitchType.Quadrilateral:
                    {
                        var fillColor = m_checked ? m_trueColor : m_falseColor;
                        GraphicsPath path = new GraphicsPath();
                        int intRadius = 5;
                        path.AddArc(0, 0, intRadius, intRadius, 180f, 90f);
                        path.AddArc(Width - intRadius - 1, 0, intRadius, intRadius, 270f, 90f);
                        path.AddArc(Width - intRadius - 1, Height - intRadius - 1, intRadius, intRadius, 0f, 90f);
                        path.AddArc(0, Height - intRadius - 1, intRadius, intRadius, 90f, 90f);

                        g.FillPath(new SolidBrush(fillColor), path);

                        string strText = string.Empty;
                        if (m_texts != null && m_texts.Length == 2)
                        {
                            if (m_checked)
                            {
                                strText = m_texts[0];
                            }
                            else
                            {
                                strText = m_texts[1];
                            }
                        }

                        if (m_checked)
                        {
                            GraphicsPath path2 = new GraphicsPath();
                            path2.AddArc(Width - Height - 1 + 2, 1 + 2, intRadius, intRadius, 180f, 90f);
                            path2.AddArc(Width - 1 - 2 - intRadius, 1 + 2, intRadius, intRadius, 270f, 90f);
                            path2.AddArc(Width - 1 - 2 - intRadius, Height - 2 - intRadius - 1, intRadius, intRadius, 0f, 90f);
                            path2.AddArc(Width - Height - 1 + 2, Height - 2 - intRadius - 1, intRadius, intRadius, 90f, 90f);
                            g.FillPath(Brushes.White, path2);

                            if (string.IsNullOrEmpty(strText))
                            {
                                g.DrawEllipse(new Pen(Color.White, 2), new Rectangle((Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                            }
                            else
                            {
                                SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                                int intTextY = (Height - (int)sizeF.Height) / 2 + 2;
                                g.DrawString(strText, Font, new SolidBrush(m_trueTextColr), new Point((Height - 2 - 4) / 2, intTextY));
                            }
                        }
                        else
                        {
                            GraphicsPath path2 = new GraphicsPath();
                            path2.AddArc(1 + 2, 1 + 2, intRadius, intRadius, 180f, 90f);
                            path2.AddArc(Height - 2 - intRadius, 1 + 2, intRadius, intRadius, 270f, 90f);
                            path2.AddArc(Height - 2 - intRadius, Height - 2 - intRadius - 1, intRadius, intRadius, 0f, 90f);
                            path2.AddArc(1 + 2, Height - 2 - intRadius - 1, intRadius, intRadius, 90f, 90f);
                            g.FillPath(Brushes.White, path2);

                            //g.FillEllipse(Brushes.White, new Rectangle(1 + 2, 1 + 2, this.Height - 2 - 4, this.Height - 2 - 4));
                            if (string.IsNullOrEmpty(strText))
                            {
                                g.DrawEllipse(new Pen(Color.White, 2), new Rectangle(Width - 2 - (Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                            }
                            else
                            {
                                SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                                int intTextY = (Height - (int)sizeF.Height) / 2 + 2;
                                g.DrawString(strText, Font, new SolidBrush(m_falseTextColr), new Point(Width - 2 - (Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2 - (int)sizeF.Width / 2, intTextY));
                            }
                        }

                        break;
                    }
                #region line abort
                case SwitchType.Triangle:
                    {
                        var fillColor = m_checked ? m_trueColor : m_falseColor;
                        //Point point1 = new Point(50, 20);
                        //Point point2 = new Point(75, 50);
                        //Point point3 = new Point(100, 20);
                        //Point point1 = new Point(10, 10);
                        //Point point2 = new Point(10, 70);
                        //Point point3 = new Point(50, 40);
                        //等腰三角形 左下 上，右中三点
                        Point point1 = new Point(((Width - Height) / 4) + 4, 4);
                        Point point2 = new Point(((Width - Height) / 4) + 4, Height - 4);
                        //Point point3 = new Point(Height-2, Height/2);
                        Point point3 = new Point(Width - 4, Height / 2);
                        Point[] pntArr = { point1, point2, point3 };
                        byte[] bytes = { (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line };
                        GraphicsPath path = new GraphicsPath(pntArr, bytes);
                        g.FillPath(new SolidBrush(fillColor), path);
                        #region MyRegion line
                        //        var fillColor = m_checked ? m_trueColor : m_falseColor;
                        //        int intLineHeight = (Height - 2 - 4) / 2;

                        //        GraphicsPath path = new GraphicsPath();
                        //        path.AddLine(new Point(Height / 2, (Height - intLineHeight) / 2), new Point(Width - Height / 2, (Height - intLineHeight) / 2));
                        //        path.AddArc(new Rectangle(Width - Height / 2 - intLineHeight - 1, (Height - intLineHeight) / 2, intLineHeight, intLineHeight), -90, 180);
                        //        path.AddLine(new Point(Width - Height / 2, (Height - intLineHeight) / 2 + intLineHeight), new Point(Width - Height / 2, (Height - intLineHeight) / 2 + intLineHeight));
                        //        path.AddArc(new Rectangle(Height / 2, (Height - intLineHeight) / 2, intLineHeight, intLineHeight), 90, 180);
                        //        g.FillPath(new SolidBrush(fillColor), path);

                        //        if (m_checked)
                        //        {
                        //            g.FillEllipse(new SolidBrush(fillColor), new Rectangle(Width - Height - 1 + 2, 1 + 2, Height - 2 - 4, Height - 2 - 4));
                        //            g.FillEllipse(Brushes.White, new Rectangle(Width - 2 - (Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2 - 4, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                        //        }
                        //        else
                        //        {
                        //            g.FillEllipse(new SolidBrush(fillColor), new Rectangle(1 + 2, 1 + 2, Height - 2 - 4, Height - 2 - 4));
                        //            g.FillEllipse(Brushes.White, new Rectangle((Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2 + 4, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                        //        }

                        #endregion
                        break;
                    }
                #endregion



                default:
                    {
                        #region default ellipse
                        var fillColor = m_checked ? m_trueColor : m_falseColor;
                        GraphicsPath path = new GraphicsPath();
                        path.AddLine(new Point(Height / 2, 1), new Point(Width - Height / 2, 1));
                        path.AddArc(new Rectangle(Width - Height - 1, 1, Height - 2, Height - 2), -90, 180);
                        path.AddLine(new Point(Width - Height / 2, Height - 1), new Point(Height / 2, Height - 1));
                        path.AddArc(new Rectangle(1, 1, Height - 2, Height - 2), 90, 180);
                        g.FillPath(new SolidBrush(fillColor), path);



                        string strText = string.Empty;
                        //if (m_texts != null && m_texts.Length == 2)
                        if (m_texts != null && m_texts.Length == 2)
                        {
                            if (m_checked)
                            {
                                strText = m_texts[0];//已打开
                            }
                            else
                            {
                                strText = m_texts[1]; //已关闭
                            }
                        }

                        if (m_checked)
                        {
                            g.FillEllipse(Brushes.White, new Rectangle(Width - Height - 1 + 2, 1 + 2, Height - 2 - 4, Height - 2 - 4));
                            if (string.IsNullOrEmpty(strText))
                            {
                                //没字 空白
                                g.DrawEllipse(new Pen(Color.White, 2), new Rectangle((Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                            }
                            else
                            {   //已打开 显示位置。x,y
                                SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                                int intTextY = (Height - (int)sizeF.Height) / 2 + 2;//
                                g.DrawString(strText, Font, new SolidBrush(m_trueTextColr), new Point((Height - 2 - 4 - 10) / 2, intTextY));
                            }
                        }
                        else
                        {
                            g.FillEllipse(Brushes.White, new Rectangle(1 + 2, 1 + 2, Height - 2 - 4, Height - 2 - 4));
                            if (string.IsNullOrEmpty(strText))
                            {
                                g.DrawEllipse(new Pen(Color.White, 2), new Rectangle(Width - 2 - (Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                            }
                            else
                            {    //已关闭 显示位置。x,y
                                SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                                int intTextY = (Height - (int)sizeF.Height) / 2 + 2;
                                g.DrawString(strText, Font, new SolidBrush(m_falseTextColr), new Point(Width - 20 - (Height - 2 - 4) / 2 - (Height - 2 - 4) / 2 / 2 - (int)sizeF.Width / 2, intTextY));
                            }
                        }
                        #endregion

                        break;
                    }
            }
        }


    }

    /// <summary>
    /// Enum SwitchType
    /// </summary>
    public enum SwitchType
    {
        /// <summary>
        /// 椭圆
        /// </summary>
        Ellipse,
        /// <summary>
        /// 四边形
        /// </summary>
        Quadrilateral,
        /// <summary>
        /// 横线
        /// </summary>
        Triangle

    }

}

