﻿using System;
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
        
        float totalHours;

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
            // rainbow
            pieChartBrushes.Add(Brushes.Red);
            pieChartBrushes.Add(Brushes.Orange);
            pieChartBrushes.Add(Brushes.Yellow);
            pieChartBrushes.Add(Brushes.Green);
            pieChartBrushes.Add(Brushes.Blue);
            pieChartBrushes.Add(Brushes.Indigo);
            pieChartBrushes.Add(Brushes.Violet);

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
                sweepAngle = recordsToDraw[i].Duration * HourAngleSize;
                e.Graphics.FillPie(GetPieChartBrush(i), pieRect, startAngle, sweepAngle);
                startAngle += sweepAngle;

                e.Graphics.DrawString(recordsToDraw[i].Task, Font, Brushes.Black, new PointF(pt.X + 1, pt.Y + 1));
                e.Graphics.DrawString(recordsToDraw[i].Task, Font, GetPieChartBrush(i), pt);
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
                totalHours += item.Duration;
            }
            this.Invalidate();
        }

        private Brush GetPieChartBrush(int i)
        {
            return pieChartBrushes[i % pieChartBrushes.Count];
        }

        private float GetRecordPercentageAngle(Record r)
        {
            return r.Duration / (float)totalHours;
        }
    }
}
