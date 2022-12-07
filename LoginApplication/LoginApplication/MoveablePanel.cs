using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApplication
{
    internal class MoveablePanel : Panel
    {
        private Form mainForm = null;
        private Point offset;
        private bool dragging;

        public MoveablePanel() : base()
        {
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveablePanel_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveablePanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveablePanel_MouseMove);
        }
        public Form MainForm { get => mainForm; set => mainForm = value; }

        private void MoveablePanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void MoveablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            offset.X = e.X;
            offset.Y = e.Y;
        }

        private void MoveablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && MainForm != null)
            {
                Point currentPoint = PointToScreen(e.Location);
                MainForm.Location = Point.Subtract(currentPoint,
                    new Size(totalLocation_of_Parent(this, new Point(offset.X + Location.X, offset.Y + Location.Y))));
            }
        }

        private Point totalLocation_of_Parent(Control panel, Point point)
        {
            if (panel.Parent is Form)
            {
                return point;
            }
            return totalLocation_of_Parent(panel.Parent, Point.Add(point, new Size(panel.Parent.Location)));
        }
    }
}
