using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace TimeAssist.Controls
{
    public partial class PieChartControl : UserControl
    {
        public const float HourAngleSize = 30;

        List<Brush> pieChartBrushes = new List<Brush>();

        float[] angles;
        string[] legendWords;

        double totalHours;

        List<Record> recordsToDraw = new List<Record>();


        System.Drawing.Rectangle pieRect;
        System.Drawing.Rectangle legendRect;

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
                //AngleAndWordData(e);
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
            pieRect = new System.Drawing.Rectangle(0, 0, Width / 2, Height / 2);
            legendRect = new System.Drawing.Rectangle(pieRect.Width, 0, Width / 2, Height / 2);
            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(0, 0, Size.Width, Size.Height));

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

            DrawClock(e, pieRect);

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

        private void DrawClock(PaintEventArgs e, System.Drawing.Rectangle r )
        {
            // TODO: Draw the clock around the pie chart.
            float startAngle = 0;
            for (int i = 0; i < 12; i++)
            {
                e.Graphics.DrawPie(Pens.Black, r, startAngle, HourAngleSize);
                startAngle += HourAngleSize;
            }
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
            // start at 8 o'clock
            float startAngle = (HourAngleSize * 8) - (HourAngleSize * 3);
            float sweepAngle = 0;
            pieRect = new System.Drawing.Rectangle(0, 0, Width / 2, Height / 2);
            legendRect = new System.Drawing.Rectangle(pieRect.Width, 0, Width / 2, Height / 2);

            PointF pt = new PointF(legendRect.X, legendRect.Y);

            for (int i = 0; i < recordsToDraw.Count; i++ )
            {
                sweepAngle = Math.Abs((float)recordsToDraw[i].Duration.TotalHours * HourAngleSize);
                e.Graphics.FillPie(GetPieChartBrush(i), pieRect, startAngle, sweepAngle);
                startAngle += sweepAngle;

                e.Graphics.DrawString(legendWords[i], Font, Brushes.Black, new PointF(pt.X + 1, pt.Y + 1));
                e.Graphics.DrawString(legendWords[i], Font, GetPieChartBrush(i), pt);
                pt.Y += Font.SizeInPoints + 2;
            }
            DrawClock(e, pieRect);
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
