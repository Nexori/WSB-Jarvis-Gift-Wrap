using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Threading;
using JarvisAlgorithmLib;
using System.Diagnostics;
using System.Linq;

namespace WSB_Jarvis_Gift_Wrap
{
    public partial class MainForm : Form
    {
        private Graphics _graphics;
        private LinkedList<Point> _convexHulltoDraw;
        
        private Brush _convexHullBrush;
        private Pen _convexHullPen;

        private Brush _pointBrush;

        private Brush _searchBrush;
        private Pen _searchPen;

        private Brush _csearchBrush;
        private Pen _csearchPen;

        private int _vizualizationIteration;
        private int _speedDivider;

        private PlotData _plotData;

        public MainForm()
        {
            InitializeComponent();
            _convexHullPen = new Pen(Color.Crimson, width: 5);
            _convexHullBrush = new SolidBrush(Color.Crimson);

            _searchBrush= new SolidBrush(Color.LimeGreen);
            _searchPen = new Pen(Color.LimeGreen, width: 2);

            _csearchBrush = new SolidBrush(Color.Yellow);
            _csearchPen = new Pen(Color.Yellow, width: 1);

            _pointBrush = new SolidBrush(Color.White);
            
            _plotData = new PlotData();
            _plotData.convexHull = new LinkedList<Point>();
            _plotData.points = new LinkedList<Point>();
            _plotData.accessOrder = new List<LinkedList<Point>>();
            _vizualizationIteration = 0;


        }
        private void DrawSolution(
            PlotData plotData, 
            Brush chPointBrush, 
            Brush pointBrush, 
            Pen chLinePen, 
            int currentStep, 
            Brush sPointBrush,
            Pen sLinePen,
            Brush csPointBrush,
            Pen csLinePen)
        {
            WipePictureBox(); // Wyczyść płutno
            // Jeśli wizualizacja jest wyłączona, rysuj normalnie, to rysuj krok po kroku.
            if (ckh_vizualization.Checked == false){
                // Rysowanie linii z otoczki:
                var firstPoint = plotData.convexHull.First;
                while (firstPoint.Next != null)     // Dopóki nie natkenliśmy się na ostatni punkt, rysuj
                {
                    _graphics.DrawLine(_convexHullPen, firstPoint.Value, firstPoint.Next.Value);
                    firstPoint = firstPoint.Next;
                }
                _graphics.DrawLine(chLinePen, firstPoint.Value, plotData.convexHull.First.Value); //Dorysuj ostatnią linię
                
                // Narysuj punkty i punkty z otoczki
                foreach (var p in plotData.points)
                    _graphics.FillCircle(pointBrush, p.X, p.Y, 5); // Rysuj normalne punkty
                foreach (var p in plotData.convexHull)
                    _graphics.FillCircle(chPointBrush, p.X, p.Y, 5); // Rysuj punkty należące do otoczki
            }
            else if (slidebar_anim_speed.Value == 0) // Tryb manualny, "krok po kroku".
            {
                var currentIteration = plotData.accessOrder.First().First;
                var currentPoint = plotData.convexHull.First;

                for (int i = 0; i < currentIteration.List.Count; i++)
                {
                    for (int j = 0; j < currentPoint.List.Count; j++)
                    {
                        _graphics.DrawLine(sLinePen, currentIteration.Value, currentPoint.Value);
                        _graphics.FillCircle(sPointBrush, currentPoint.Value.X, currentPoint.Value.Y, 5);
                        if (currentPoint.Next != null)
                            currentPoint = currentPoint.Next;
                        else break;
                    }
                    currentIteration = currentIteration.Next;
                    if (currentIteration.Next != null)
                        currentIteration = currentIteration.Next;
                    else break;
                }
                
            }
            else // Tryb automatyczny, działający z użyciem opóźnienia
            {

            }
            pictureBox.Invalidate(); 
        }

        // Wyczyść płutno
        private void WipePictureBox()
        {
            using (var b = new SolidBrush(Color.Black))
            {
                _graphics.FillRectangle(
                    b, 0, 0, pictureBox.Width, pictureBox.Height);
            }
            pictureBox.Invalidate(); //Redraw
        }

        // Przerysuj punkty
        private void RedrawPoints(bool wipe)
        {
            if (wipe == true)
                WipePictureBox();
            foreach (var p in _plotData.points) 
                _graphics.FillCircle(_pointBrush,p.X,p.Y,5);
            pictureBox.Invalidate(); 
        }


        // Przycisk "Uruchom"
        private void b_Start_Click(object sender, EventArgs e)
        {

            var timer = new Stopwatch();
                timer.Start();
                if (_plotData.points.Count <= 0)
                    return;
                _plotData = JarvisAlgorithm.GetConvexHull(_plotData);
            timer.Stop();
            var timeElapsed = timer.Elapsed.TotalMilliseconds; 
            label_timeTaken.Text = (double)timeElapsed + " ms";
            _vizualizationIteration = _plotData.convexHull.Count;
            DrawSolution(
                plotData: _plotData, 
                chPointBrush: _convexHullBrush, 
                pointBrush: _pointBrush, 
                chLinePen: _convexHullPen,
                currentStep: _vizualizationIteration, 
                sPointBrush: _searchBrush, 
                sLinePen: _searchPen,
                csPointBrush: _csearchBrush,
                csLinePen: _csearchPen);

            pictureBox.Invalidate();
            
        }

        // Przycisk "Reset"
        private void b_Reset_Click(object sender, EventArgs e)
        {
            RedrawPoints(true);
        }

        // Przycisk "Wyczyść"
        private void b_Wipe_Click(object sender, EventArgs e)
        {
            WipePictureBox();
            _plotData.points.Clear();
            _plotData.convexHull.Clear();
            _plotData.accessOrder.Clear();
        }

        // Punkty, przycisk "generuj"
        private void b_GeneratePts_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            _plotData.points.Clear();
            for (int i = 0; i < e_pointsCount.Value; i++)
            {
                _plotData.points.AddLast(new Point(r.Next(0, pictureBox.Width), r.Next(0, pictureBox.Height)));
            }
            RedrawPoints(true);
        }

        // Wizualizcja, przycisk "następny krok"
        private void b_NextStep_Click(object sender, EventArgs e)
        {
            if (_plotData.convexHull.Count < _vizualizationIteration)
            {
                _vizualizationIteration++;
            }
        }

        // Wizualizcja, przycisk "poprzedni krok"
        private void b_prevStep_Click(object sender, EventArgs e)
        {
            if (_plotData.convexHull.Count > 0)
            {
                _vizualizationIteration--;
            }
        }

        private void chk_viz_enable(object sender, EventArgs e)
        {

        }

        private void slidebar_viz_speed(object sender, EventArgs e)
        {

        }

        // Akcja przy kliknięciu w płutno
        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            var newPoint = new Point(e.X, e.Y);
            if (_plotData.points.Contains(newPoint)) //Stop if point already exists at that place
                return;

            _plotData.points.AddLast(newPoint);

            _graphics.FillCircle(_pointBrush, newPoint.X, newPoint.Y,5);
            pictureBox.Invalidate();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            pictureBox.BackColor = Color.Black;
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            _graphics = Graphics.FromImage(pictureBox.Image);
            _graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
        }


        // Przycisk "utwórz punkt"
        private void b_createPoint_Click(object sender, EventArgs e)
        {
            var newPoint = new Point((int)e_pCreate_X.Value, (int)e_pCreate_Y.Value);
            if (_plotData.points.Contains(newPoint))    // Przerwij jeśli punkt już istnieje 
                return;

            _plotData.points.AddLast(newPoint);         // Dodaj i dorysuj ten punkt
            _graphics.FillCircle(_pointBrush, newPoint.X, newPoint.Y, 5);
            pictureBox.Invalidate();
        }

    }
}