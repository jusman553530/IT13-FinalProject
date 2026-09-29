using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CRM.winforms.UI
{
    public class RoundedPanel : Panel
    {
        [Category("Appearance")]
        [DefaultValue(10)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius { get; set; } = 10;

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor { get; set; } = Color.LightGray;

        [Category("Appearance")]
        [DefaultValue(1)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderThickness { get; set; } = 1;

        public RoundedPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent?.BackColor ?? BackColor);

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var path = GetRoundedPath(rect, CornerRadius))
            {
                using (var brush = new SolidBrush(BackColor))
                    e.Graphics.FillPath(brush, path);

                if (BorderThickness > 0)
                {
                    using (var pen = new Pen(BorderColor, BorderThickness))
                        e.Graphics.DrawPath(pen, path);
                }
            }

            base.OnPaint(e);
        }

        private static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}