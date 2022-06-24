using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Threading;
using JarvisAlgorithmLib;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks; 
using Timer = System.Threading.Timer;

namespace WSB_Jarvis_Gift_Wrap
{
    public partial class MainForm : Form
    {
        private Graphics _graphics;
        
        private Brush _convexHullBrush;
        private Pen _convexHullPen;

        private Brush _pointBrush;

        private Brush _searchBrush;
        private Pen _searchPen;

        private Font _font;
        private bool _isCalculated;
        private bool _drawText;
        private int _drawIndex;

        private PlotData _plotData;
        private LinkedList<Point> _oldPoints;

        public MainForm()
        {
            InitializeComponent();
            _convexHullPen = new Pen(Color.Crimson, width: 2);
            _convexHullBrush = new SolidBrush(Color.Crimson);

            _searchBrush= new SolidBrush(Color.Yellow);
            _searchPen = new Pen(Color.Yellow, width: 1);

            _pointBrush = new SolidBrush(Color.White);

            _font = new Font("Arial", 10);

            _isCalculated = false;
            _drawText = true;
            _drawIndex = 0;

            _plotData = new PlotData();
            _plotData.convexHull = new LinkedList<Point>();
            _plotData.points = new LinkedList<Point>();
            _plotData.accessOrder = new List<List<Point>>();

            _oldPoints = new LinkedList<Point>();


        }
        private async Task DrawSolution(
            PlotData plotData,
            Brush pointBrush,
            Brush chPointBrush,
            Pen chLinePen,
            Brush sPointBrush,
            Pen sLinePen)
        {
            if (plotData.points.Count > 0)
            {
                WipePictureBox();
                if (ckh_vizualization.Checked == false)
                {
                    var firstPoint = plotData.convexHull.First;

                    // Narysuj wszystkie punkty 
                    foreach (var p in plotData.points)
                    {
                        _graphics.FillCircle(pointBrush, p.X, p.Y, 5);
                        if (_drawText)
                            _graphics.DrawString("(" + p.X + " , " + p.Y + ")", _font, _pointBrush, p.X + 5, p.Y + 5);
                    }

                    //Rysuj otoczkę
                    if (plotData.convexHull.Count > 0)
                    {
                        while (firstPoint.Next != null)
                        {
                            _graphics.DrawLine(_convexHullPen, firstPoint.Value, firstPoint.Next.Value);
                            firstPoint = firstPoint.Next;
                        }

                        _graphics.DrawLine(chLinePen, firstPoint.Value, plotData.convexHull.First.Value);

                        // Rysuj punkty z otoczki
                        foreach (var p in plotData.convexHull)
                            _graphics.FillCircle(chPointBrush, p.X, p.Y, 5);
                        pictureBox.Invalidate();
                    }
                }

                else // Włączona wizualizacja
                {
                    // Rysuj normalne punkty
                    foreach (var p in plotData.points)
                    {
                        _graphics.FillCircle(pointBrush, p.X, p.Y, 5);
                        if (_drawText)
                            _graphics.DrawString("(" + p.X + " , " + p.Y + ")", _font, _pointBrush, p.X + 5, p.Y + 5);
                    }

                    // Rysuj otoczkę
                    _graphics.FillCircle(chPointBrush, plotData.convexHull.First.Value.X,
                        plotData.convexHull.First.Value.Y, 5);
                    var firstPoint = plotData.convexHull.First;
                    while (firstPoint.Next != null)
                    {
                        _graphics.DrawLine(chLinePen, firstPoint.Value, firstPoint.Next.Value);
                        _graphics.FillCircle(chPointBrush, firstPoint.Next.Value.X, firstPoint.Next.Value.Y, 5);
                        firstPoint = firstPoint.Next;
                        pictureBox.Invalidate();

                        if (_drawIndex < plotData.accessOrder.Count)
                        {
                            await Task.Delay((int)(10 * (20 - s_vizualization_speed.Value)));
                            _drawIndex++;
                        }
                    }
                    _graphics.DrawLine(chLinePen, firstPoint.Value, plotData.convexHull.First.Value); // Zamknij otoczkę
                    pictureBox.Invalidate();
                }
            }
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
        private async void b_Start_Click(object sender, EventArgs e)
        {   
            LinkedList<Point> backupPoints = new LinkedList<Point>(_plotData.points);
            _plotData.convexHull.Clear();
            _plotData.accessOrder.Clear();
            _plotData.points = backupPoints;
            if (_isCalculated == false && _plotData.points.Count > 0)
            {
                _drawIndex = 0;
                _isCalculated = true;

                var timer = new Stopwatch(); 
                timer.Start();
                await Task.Run(() => _plotData = JarvisAlgorithm.GetConvexHull(ref _plotData));
                timer.Stop(); 
                var timeElapsed = timer.Elapsed.TotalMilliseconds;

                txt_solutionDescription.Text = "";
                txt_solutionDescription.AppendText("Obliczono w: "+timeElapsed+" ms");
                await DrawSolution(
                    plotData: _plotData,
                    pointBrush: _pointBrush,
                    chPointBrush: _convexHullBrush,
                    chLinePen: _convexHullPen,
                    sPointBrush: _searchBrush,
                    sLinePen: _searchPen);
                txt_solutionDescription.AppendText("\r\nPunkty należące do otoczki:");
                foreach (var p in _plotData.convexHull)
                {
                    txt_solutionDescription.AppendText("\r\n("+ p.X +" , " + p.Y +")"); 
                }

                switch (_plotData.convexHull.Count)
                {
                    case 1:
                        txt_solutionDescription.AppendText("\r\nOtoczka jest punktem");
                        break;
                    case 2:
                        txt_solutionDescription.AppendText("\r\nOtoczka jest prostą");
                        break;
                    case 3:
                        txt_solutionDescription.AppendText("\r\nOtoczka jest trójkątem");
                        break;
                    case 4:
                        txt_solutionDescription.AppendText("\r\nOtoczka jest czworokątem");
                        break;
                    case 5:
                        txt_solutionDescription.AppendText("\r\nOtoczka jest pięciokątem");
                        break;
                    default:
                        txt_solutionDescription.AppendText("\r\nOtoczka jest " + _plotData.convexHull.Count + "-kątem");
                        break;
                }
                pictureBox.Invalidate();
            }
        }

        // Przycisk "Reset wizualizacji"
        private void b_Reset_Click(object sender, EventArgs e)
        {
            RedrawPoints(true);
            _drawIndex = 0;
        }

        // Przycisk "Restart"
        private void b_Wipe_Click(object sender, EventArgs e)
        {
            WipePictureBox();
            _plotData.points.Clear();
            _plotData.convexHull.Clear();
            _plotData.accessOrder.Clear();
            txt_solutionDescription.Text = "";
            _isCalculated = false;
        }

        // Punkty, przycisk "generuj"
        private void b_GeneratePts_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            b_Wipe_Click(sender,e);

            for (int i = 0; i < e_pointsCount.Value; i++)
            {
                _plotData.points.AddLast(new Point(r.Next(0, pictureBox.Width), r.Next(0, pictureBox.Height)));
            }
            RedrawPoints(true);
        }

        private void chk_viz_enable(object sender, EventArgs e)
        {
            if (ckh_vizualization.Checked)
            { 
                s_vizualization_speed.Enabled = true;
                b_Reset_Viz.Enabled = true;
            }
            else
            {
                s_vizualization_speed.Enabled = false;
                b_Reset_Viz.Enabled = false;
            }
        }

        private async void chk_drawCoords_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_drawCoords.Checked)
            {
                _drawText = true;
                await DrawSolution(
                    plotData: _plotData,
                    pointBrush: _pointBrush,
                    chPointBrush: _convexHullBrush,
                    chLinePen: _convexHullPen,
                    sPointBrush: _searchBrush,
                    sLinePen: _searchPen);
            }
            else
            {
                _drawText = false;
                await DrawSolution(
                    plotData: _plotData,
                    pointBrush: _pointBrush,
                    chPointBrush: _convexHullBrush,
                    chLinePen: _convexHullPen,
                    sPointBrush: _searchBrush,
                    sLinePen: _searchPen);
            }
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
            _isCalculated = false;
            _graphics.FillCircle(_pointBrush, newPoint.X, newPoint.Y,5);

            if (_drawText)
                _graphics.DrawString("(" + newPoint.X + " , " + newPoint.Y + ")", _font, _pointBrush, newPoint.X + 5, newPoint.Y + 5);
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
            _isCalculated = false;
            _plotData.points.AddLast(newPoint);         // Dodaj i dorysuj ten punkt
            _graphics.FillCircle(_pointBrush, newPoint.X, newPoint.Y, 5);
            if (_drawText)
                    _graphics.DrawString("(" + newPoint.X + " , " + newPoint.Y + ")", _font, _pointBrush, newPoint.X + 5, newPoint.Y + 5);
            pictureBox.Invalidate();
        }

    }
}