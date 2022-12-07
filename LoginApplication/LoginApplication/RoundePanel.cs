using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LoginApplication
{
    internal class RoundePanel : MoveablePanel
    {
        private float borderWidth = 5;
        private Color _borderColor = Color.Transparent;
        private int _radius = 20;
        private Pen _pen;

        public RoundePanel() : base()
        {
            _pen = new Pen(BorderColor, BorderWidth);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        public float BorderWidth { get => borderWidth; set => borderWidth = value; }
        public Color BorderColor { get => _borderColor; set => _borderColor = value; }
        public int Radius { get => _radius; set => _radius = value; }

        private Rectangle GetLeftUpper(int e)
        {
            return new Rectangle(0, 0, e, e);
        }
        private Rectangle GetRightUpper(int e)
        {
            return new Rectangle(Width - e, 0, e, e);
        }
        private Rectangle GetRightLower(int e)
        {
            return new Rectangle(Width - e, Height - e, e, e);
        }
        private Rectangle GetLeftLower(int e)
        {
            return new Rectangle(0, Height - e, e, e);
        }
        private void ExtendedDraw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(GetLeftUpper(Radius), 180, 90);
            path.AddLine(Radius, 0, Width - Radius, 0);
            path.AddArc(GetRightUpper(Radius), 270, 90);
            path.AddLine(Width, Radius, Width, Height - Radius);
            path.AddArc(GetRightLower(Radius), 0, 90);
            path.AddLine(Width - Radius, Height, Radius, Height);
            path.AddArc(GetLeftLower(Radius), 90, 90);
            path.AddLine(0, Height - Radius, 0, Radius);
            path.CloseFigure();
            Region = new Region(path);
        }
        private void DrawSingleBorder(Graphics graphics)
        {
            graphics.DrawArc(_pen, new Rectangle(0, 0, Radius, Radius), 180, 90);
            graphics.DrawArc(_pen, new Rectangle(Width - Radius - 1, -1, Radius, Radius), 270, 90);
            graphics.DrawArc(_pen, new Rectangle(Width - Radius - 1, Height - Radius - 1, Radius, Radius), 0, 90);
            graphics.DrawArc(_pen, new Rectangle(0, Height - Radius - 1, Radius, Radius), 90, 90);
            graphics.DrawRectangle(_pen, 0.0f, 0.0f, (float)Width - 1.0f, (float)Height - 1.0f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ExtendedDraw(e);
            DrawSingleBorder(e.Graphics);
        }
    }
}
