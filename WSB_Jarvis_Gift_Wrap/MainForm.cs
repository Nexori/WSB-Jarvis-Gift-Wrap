﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Threading;
using JarvisAlgorithmLib;

namespace WSB_Jarvis_Gift_Wrap
{
    public partial class MainForm : Form
    {
        private Graphics _graphics;
        private LinkedList<Point> _points;
        private LinkedList<Point> _convexHullPoints;
        private LinkedList<Point> _convexHulltoDraw;
        private Pen _convexHullPen;
        private Pen _pointPen;
        private Pen _searchPen;
        private Brush _pointBrush;

        private int _pointCount;

        public MainForm()
        {
            InitializeComponent();
            _convexHullPen = new Pen(Color.Crimson, width: 5);
            _pointBrush = new SolidBrush(Color.Black);
            _searchPen = new Pen(Color.Blue, width: 10);
            _pointCount = (int)e_pointsCount.Value;
            _points = new LinkedList<Point>(); 
            
        }

        private void WipePictureBox()
        {
            using (var b = new SolidBrush(Color.White))
            {
                _graphics.FillRectangle(
                    b, 0, 0, pictureBox.Width, pictureBox.Height);
            }

            pictureBox.Invalidate(); //Redraw
        }

        private void RedrawPoints(bool wipe)
        {
            if (wipe == true)
                WipePictureBox();
            foreach (var p in _points) 
                _graphics.FillCircle(_pointBrush,p.X,p.Y,5);
            pictureBox.Invalidate();
        }

        private void b_Start_Click(object sender, EventArgs e)
        {
            if (_points.Count < 3)
                return;

            var convexHullPts =  JarvisAlgorithm.getConvexHull(_points);
            var firstPoint = convexHullPts.First;
            
            // Draw everything if step by step is disabled
            while (firstPoint.Next != null)
            {
                _graphics.DrawLine(_convexHullPen, firstPoint.Value, firstPoint.Next.Value);
                firstPoint = firstPoint.Next;
            }
            _graphics.DrawLine(_convexHullPen, firstPoint.Value, convexHullPts.First.Value);
            RedrawPoints(false);
            pictureBox.Invalidate();
            
        }

        private void b_Reset_Click(object sender, EventArgs e)
        {
            RedrawPoints(true);
        }

        private void b_Wipe_Click(object sender, EventArgs e)
        {
            WipePictureBox();
            _points.Clear();
        }

        private void b_GeneratePts_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            _points.Clear();
            for (int i = 0; i < _pointCount; i++)
            {
                _points.AddLast(new Point(r.Next(0, pictureBox.Width), r.Next(0, pictureBox.Height)));
            }
            RedrawPoints(true);
        }



        private void chk_step_by_step_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_step_by_step.Checked)
            {
                slidebar_vizualization_speed.Enabled = false;
            }
        
            else 
            {
                slidebar_vizualization_speed.Enabled = true;
            }
        }

        private void b_NextStep_Click(object sender, EventArgs e)
        {
        }

        private void b_prevStep_Click(object sender, EventArgs e)
        {

        }
        private void chk_speed_ctrl_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void slidebar_sim_speed_Scroll(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            var newPoint = new Point(e.X, e.Y);
            if (_points.Contains(newPoint)) //Stop if point already exists at that place
                return;

            _points.AddLast(newPoint);

            _graphics.FillCircle(_pointBrush, newPoint.X, newPoint.Y,5);
            pictureBox.Invalidate();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            pictureBox.BackColor = Color.White;
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            _graphics = Graphics.FromImage(pictureBox.Image);
            _graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
        }

        private void e_pointsCount_ValueChanged(object sender, EventArgs e)
        {
            if (e_pointsCount.Value != _pointCount)
            {
                _pointCount = (int)e_pointsCount.Value;
            }
        }

        private void chk_speed_ctrl_CheckStateChanged(object sender, EventArgs e)
        {

        }
    }
}