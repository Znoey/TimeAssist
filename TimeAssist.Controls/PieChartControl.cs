using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeAssist.Controls
{
    public partial class PieChartControl : UserControl
    {
        List<Brush> pieChartBrushes = new List<Brush>();

        float[] angles;
        string[] legendWords;

        double totalHours;

        List<Record> recordsToDraw = new List<Record>();

        public const float HourAngleSize = 30;

        Rectangle pieRect;
        Rectangle legendRect;

        public PieChartControl()
        {
            InitializeComponent();
            ResetPens();
        }

        private void ResetPens()
        {
            pieChartBrushes.Add(Brushes.Red);
            pieChartBrushes.Add(Brushes.Green);
            pieChartBrushes.Add(Brushes.Blue);
            pieChartBrushes.Add(Brushes.Yellow);
            pieChartBrushes.Add(Brushes.Purple);
            pieChartBrushes.Add(Brushes.Pink);
            pieChartBrushes.Add(Brushes.Cyan);
            pieChartBrushes.Add(Brushes.Gray);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                AngleAndWordData(e);
                DrawRecordChart(e);
            }
            catch (Exception exc)
            {
                e.Graphics.DrawString(exc.Message, Font, Brushes.Black, PointF.Empty);
                ResetPens();
            }
        }

        private void AngleAndWordData(PaintEventArgs e)
        {
            pieRect = new Rectangle(0, 0, Width / 2, Height / 2);
            legendRect = new Rectangle(pieRect.Width, 0, Width / 2, Height / 2);
            e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, Size.Width, Size.Height));

            if (angles != null && angles.Length > 0)
            {
                // start at 8 o'clock
                float startAngle = (HourAngleSize * 8) - (HourAngleSize * 3);
                float nextAngle = startAngle;
                float sweepAngle = 0;
                float totalAngle = (360) - (HourAngleSize * 4);
                Brush brush;
                for (int i = 0; i < angles.Length; ++i)
                {
                    sweepAngle = angles[i] * totalAngle;
                    brush = GetPieChartBrush(i);
                    e.Graphics.FillPie(brush, pieRect, nextAngle, sweepAngle);
                    e.Graphics.DrawPie(Pens.Black, pieRect, nextAngle, sweepAngle);
                    nextAngle += angles[i] * totalAngle;
                }
                e.Graphics.FillPie(Brushes.Black, pieRect, nextAngle, sweepAngle);
            }

            DrawClock(e);

            if (legendWords != null && legendWords.Length > 0)
            {
                int startX = legendRect.X;
                PointF pt = new PointF(legendRect.X, legendRect.Y);
                //e.Graphics.DrawRectangle(Pens.Black, legendRect);
                for (int i = 0; i < legendWords.Length; ++i)
                {
                    e.Graphics.DrawString(legendWords[i], Font, Brushes.Black, new PointF(pt.X + 1, pt.Y + 1));
                    e.Graphics.DrawString(legendWords[i], Font, GetPieChartBrush(i), pt);
                    pt.Y += Font.SizeInPoints + 2;
                }
            }
        }

        private void DrawClock(PaintEventArgs e)
        {
            // TODO: Draw the clock around the pie chart.
        }

        public void SetData(float[] angles, string[] tasks)
        {
            if (angles.Count() != tasks.Count())
            {
                throw new Exception("Cannot set angles without matching tasks");
            }
            this.angles = angles;
            this.legendWords = tasks;
            Invalidate();
        }

        private void DrawRecordChart(PaintEventArgs e)
        {

        }

        public void SetData(List<Record> records)
        {
            recordsToDraw = records;

            totalHours = 0;
            foreach (var item in records)
            {
                totalHours += Math.Abs(item.Duration.TotalHours);
            }
        }

        private Brush GetPieChartBrush(int i)
        {
            return pieChartBrushes[i % pieChartBrushes.Count];
        }

        private float GetRecordPercentageAngle(Record r)
        {
            return (float)(Math.Abs(r.Duration.TotalHours) / totalHours);
        }
    }
}
