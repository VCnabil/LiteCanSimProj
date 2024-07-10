using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteCanSimProj._MainUIs.DynPosUCs
{
    public partial class UC_360Heading : UserControl
    {
        private double angleValue;
        private bool isDragging = false;
        private PointF blueCircleCenter;
        private readonly int largeDiameter;
        private readonly int blueCircleDiameter;
        private readonly int crosshairSize = 10;
        public double AngleValue
        {
            get { return angleValue; }
            private set
            {
                angleValue = value;
                label1.Text = $"{angleValue:F2}°";
                Invalidate();
            }
        }
        public UC_360Heading()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Enable double buffering
            largeDiameter = Math.Min(Width, Height);
            blueCircleDiameter = largeDiameter / 4;
            ResetUI();
            label1.Click += AngleLabel_Click;
        }
        public void ResetAll()
        {
            ResetUI();
        }
        private void AngleLabel_Click(object sender, EventArgs e)
        {
            ResetUI();
        }
        private void ResetUI()
        {
            blueCircleCenter = new PointF(Width / 2, Height / 2 - (largeDiameter - blueCircleDiameter) / 2);
            AngleValue = 0;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillEllipse(Brushes.White, (Width - largeDiameter) / 2, (Height - largeDiameter) / 2, largeDiameter, largeDiameter);
            g.DrawLine(new Pen(Color.Blue, 6), Width / 2, Height / 2, blueCircleCenter.X, blueCircleCenter.Y);
            g.FillRectangle(Brushes.Black, (Width - crosshairSize) / 2, (Height - crosshairSize) / 2, crosshairSize, crosshairSize);
            Brush circleBrush = isDragging ? Brushes.Green : Brushes.Blue;
            g.FillEllipse(circleBrush, blueCircleCenter.X - blueCircleDiameter / 2, blueCircleCenter.Y - blueCircleDiameter / 2, blueCircleDiameter, blueCircleDiameter);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (IsPointInCircle(e.Location, blueCircleCenter, blueCircleDiameter / 2))
            {
                isDragging = true;
                Cursor = Cursors.Hand;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (isDragging)
            {
                isDragging = false;
                Cursor = Cursors.Default;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging)
            {
                PointF center = new PointF(Width / 2, Height / 2);
                double dx = e.X - center.X;
                double dy = center.Y - e.Y;
                double distance = Math.Sqrt(dx * dx + dy * dy);
                double radius = (largeDiameter - blueCircleDiameter) / 2;
                blueCircleCenter = new PointF((float)(center.X + dx / distance * radius), (float)(center.Y - dy / distance * radius));
                AngleValue = Math.Atan2(dx, dy) * (180 / Math.PI);
                if (AngleValue < 0)
                {
                    AngleValue += 360;
                }
                Invalidate();
            }
        }
        private bool IsPointInCircle(Point point, PointF circleCenter, int radius)
        {
            double dx = point.X - circleCenter.X;
            double dy = point.Y - circleCenter.Y;
            return (dx * dx + dy * dy) <= (radius * radius);
        }
    }
}
