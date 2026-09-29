using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CRM.winforms.UI
{
    public class RoundedButton : Button
    {
        [Category("Appearance")]
        [DefaultValue(10)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius { get; set; } = 10;

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color NormalColor { get; set; } = Color.SteelBlue;

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HoverColor { get; set; } = Color.DarkBlue;

        [Category("Appearance")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool LeftAlign { get; set; } = false;

        private bool _hovering;

        public RoundedButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = NormalColor;
            ForeColor = Color.White;
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            _hovering = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            _hovering = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent?.BackColor ?? BackColor);

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var path = GetRoundedPath(rect, CornerRadius))
            {
                var fill = _hovering ? HoverColor : NormalColor;
                using (var brush = new SolidBrush(fill))
                    e.Graphics.FillPath(brush, path);
            }

            TextRenderer.DrawText(
                e.Graphics,
                Text,
                Font,
                ClientRectangle,
                ForeColor,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter);
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