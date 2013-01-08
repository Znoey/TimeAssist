using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class PieChartControl : UserControl
    {
        float[] angles;
        string[] legendWords;
        Queue<Brush> pieChartBrushes = new Queue<Brush>();
        Queue<Brush> legendBrushes = new Queue<Brush>();

        Rectangle pieRect;
        Rectangle legendRect;

        public PieChartControl()
        {
            InitializeComponent();
            AddPensToList();
        }

        private void AddPensToList()
        {
            pieChartBrushes.Enqueue(Brushes.Red);
            pieChartBrushes.Enqueue(Brushes.Green);
            pieChartBrushes.Enqueue(Brushes.Blue);
            pieChartBrushes.Enqueue(Brushes.Yellow);
            pieChartBrushes.Enqueue(Brushes.Purple);
            pieChartBrushes.Enqueue(Brushes.Pink);
            pieChartBrushes.Enqueue(Brushes.Cyan);
            pieChartBrushes.Enqueue(Brushes.Gray);
            pieChartBrushes.Enqueue(Brushes.Black);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            pieRect = new Rectangle(0, 0, Width / 2, Height / 2);
            legendRect = new Rectangle(pieRect.Width, 0, Width / 2, Height / 2);
            e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, Size.Width, Size.Height));

            if (angles != null && angles.Length > 0)
            {
                float nextAngle = 0;
                float sweepAngle = 0;
                Brush brush;
                for (int i = 0; i < angles.Length; ++i)
                {
                    sweepAngle = angles[i] * 360.0f;
                    brush = GetPieChartBrush();
                    e.Graphics.FillPie(brush, pieRect, nextAngle, sweepAngle);
                    e.Graphics.DrawPie(Pens.Black, pieRect, nextAngle, sweepAngle);
                    nextAngle += angles[i] * 360.0f;
                }
            }
            if (legendWords != null && legendWords.Length > 0)
            {
                int startX = legendRect.X;
                PointF pt = new PointF(legendRect.X, legendRect.Y);
                //e.Graphics.DrawRectangle(Pens.Black, legendRect);
                for (int i = 0; i < legendWords.Length; ++i)
                {
                    e.Graphics.DrawString(legendWords[i], Font, Brushes.Black, new PointF(pt.X + 1, pt.Y + 1));
                    e.Graphics.DrawString(legendWords[i], Font, GetLegendBrush(), pt);
                    pt.Y += Font.SizeInPoints + 2;
                }
            }
        }

        public void SetData(float[] angles, string[] tasks)
        {
            this.angles = angles;
            this.legendWords = tasks;
            Invalidate();
        }

        private Brush GetPieChartBrush()
        {
            Brush pen = pieChartBrushes.Dequeue();
            legendBrushes.Enqueue(pen);
            return pen;
        }

        private Brush GetLegendBrush()
        {
            Brush pen = legendBrushes.Dequeue();
            pieChartBrushes.Enqueue(pen);
            return pen;
        }
    }
}
