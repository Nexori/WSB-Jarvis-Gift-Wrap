using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using JarvisAlgorithmLib;
 

namespace WSB_Jarvis_Gift_Wrap
{
    public partial class MainForm : Form
    {
        private PlotData _plotData;

        private Graphics _graphics;
        private bool _isCalculated;
        private bool _drawText;

        private readonly Brush _convexHullBrush;
        private readonly Pen _convexHullPen;
        private readonly Brush _pointBrush;
        private readonly Font _font;

        public MainForm()
        {
            InitializeComponent();
            _font = new Font("Arial", 10);

            _convexHullPen = new Pen(Color.Crimson, 2);
            _convexHullBrush = new SolidBrush(Color.Crimson);
            
            _pointBrush = new SolidBrush(Color.White);

            _isCalculated = false;
            _drawText = true;

            _plotData = new PlotData
            {
                convexHull = new LinkedList<Point>(),
                points = new LinkedList<Point>()
            };
        }
        private void DrawPoint(Point p, Brush pointBrush)
        {
            _graphics.FillCircle(pointBrush, p.X, 595 - p.Y, 5);
            if (_drawText)
                _graphics.DrawString("(" + p.X + " , " + p.Y + ")", _font, _pointBrush, p.X + 5, 595 - p.Y);
        }
        
        private void DrawSolution(
            PlotData plotData,
            Brush pointBrush,
            Brush chPointBrush,
            Pen chLinePen)
        {
            if (plotData.points.Count > 0)
            {
                WipePictureBox();
                var firstPoint = plotData.convexHull.First;

                // Narysuj wszystkie punkty 
                foreach (var p in plotData.points)
                    DrawPoint(p, pointBrush);

                //Rysuj otoczkę
                if (plotData.convexHull.Count > 0)
                {
                    while (firstPoint.Next != null)
                    {
                        _graphics.DrawLine(chLinePen,
                            firstPoint.Value.X, 595 - firstPoint.Value.Y,
                            firstPoint.Next.Value.X, 595 - firstPoint.Next.Value.Y);
                        firstPoint = firstPoint.Next;
                    }

                    _graphics.DrawLine(chLinePen,
                        firstPoint.Value.X, 595 - firstPoint.Value.Y,
                        plotData.convexHull.First.Value.X, 595 - plotData.convexHull.First.Value.Y);

                    // Rysuj punkty z otoczki
                    foreach (var p in plotData.convexHull)
                        DrawPoint(p, chPointBrush);
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
            if (wipe)
                WipePictureBox();
            foreach (var p in _plotData.points)
                DrawPoint(p,_pointBrush);
            pictureBox.Invalidate();
        }

        // Przycisk "Uruchom"
        private async void b_Start_Click(object sender, EventArgs e)
        {
            var backupPoints = new LinkedList<Point>(_plotData.points);
            _plotData.convexHull.Clear();
            //_plotData.accessOrder.Clear();
            _plotData.points = backupPoints;
            if (_isCalculated == false && _plotData.points.Count > 0)
            {
                _isCalculated = true;

                var timer = new Stopwatch();
                timer.Start();
                await Task.Run(() => _plotData = JarvisAlgorithm.GetConvexHull(ref _plotData));
                timer.Stop();
                var timeElapsed = timer.Elapsed.TotalMilliseconds;

                txt_solutionDescription.Text = "";
                txt_solutionDescription.AppendText("Obliczono w: " + timeElapsed + " ms");
                DrawSolution(
                    _plotData,
                    _pointBrush,
                    _convexHullBrush,
                    _convexHullPen);
                txt_solutionDescription.AppendText("\r\nPunkty należące do otoczki:");
                foreach (var p in _plotData.convexHull)
                    txt_solutionDescription.AppendText("\r\n(" + p.X + " , " + (p.Y) + ")");

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
        }

        // Przycisk "Restart"
        private void b_Wipe_Click(object sender, EventArgs e)
        {
            WipePictureBox();
            _plotData.points.Clear();
            _plotData.convexHull.Clear();
            txt_solutionDescription.Text = "";
            _isCalculated = false;
        }

        // Punkty, przycisk "generuj"
        private void b_GeneratePts_Click(object sender, EventArgs e)
        {
            var r = new Random();
            b_Wipe_Click(sender, e);
            for (var i = 0; i < e_pointsCount.Value; i++)
                _plotData.points.AddLast(new Point(r.Next(50, pictureBox.Width - 50),
                    r.Next(50, pictureBox.Height - 50)));
            RedrawPoints(true);
        }

        // Przycisk "utwórz punkt"
        private void b_createPoint_Click(object sender, EventArgs e)
        {
            var newPoint = new Point((int)e_pCreate_X.Value, (int)e_pCreate_Y.Value);
            if (_plotData.points.Contains(newPoint)) // Przerwij jeśli punkt już istnieje 
                return;
            _isCalculated = false;
            _plotData.points.AddLast(newPoint); // Dodaj i dorysuj ten punkt

            DrawPoint(newPoint, _pointBrush);
            pictureBox.Invalidate();
        }

        // Przerysuj wszystko jeszcze raz jeśli zmieniono boxa
        private void chk_drawCoords_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_drawCoords.Checked)
            {
                _drawText = true;
                DrawSolution(
                    _plotData,
                    _pointBrush,
                    _convexHullBrush,
                    _convexHullPen);
            }
            else
            {
                _drawText = false;
                DrawSolution(
                    _plotData,
                    _pointBrush,
                    _convexHullBrush,
                    _convexHullPen);
            }
        }

        // Akcja przy kliknięciu w płutno
        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            var newPoint = new Point(e.X, 595-e.Y);
            if (_plotData.points.Contains(newPoint)) //Stop if point already exists at that place
                return;
            _plotData.points.AddLast(newPoint);
            _isCalculated = false;
            DrawPoint(newPoint, _pointBrush);
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
    }
}