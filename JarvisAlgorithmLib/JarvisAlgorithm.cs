using System;
using System.Collections.Generic;
using System.Drawing;

namespace JarvisAlgorithmLib
{
    public struct PlotData
    {
        public LinkedList<Point> points;
        public LinkedList<Point> convexHull;
    }

    public static class JarvisAlgorithm
    {
        // Mając 3 współiniowe punkty: p, q, r, funkcja sprawdza czy punkt q
        // leży na odcinku 'pr' 
        public static bool isColinear(Point p, Point q, Point r)
        {
            return q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                   q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y);
        }

        public static int GetDirection(Point a, Point b, Point c)
        {
            var val = (b.Y - a.Y) * (c.X - b.X) -
                      (b.X - a.X) * (c.Y - b.Y);

            if (val == 0) return 0; // colinear
            return val > 0 ? 1 : 2; // clock or counterclockwise
        }

        public static Point GetLowestLeftPoint(PlotData plotData)
        {
            var l = new Point();
            foreach (var p in plotData.points)
                if (p.Y > l.Y)
                    l = p;
                else if (p.Y == l.Y &&
                         p.X > l.X)
                    l = p;
            return l;
        }

        public static PlotData GetConvexHull(ref PlotData plotData)
        {
            //Zapisz dane wejściowe aby ich nie utracić
            LinkedList<Point> oldData = new LinkedList<Point>(plotData.points);
            
            // Jeśli są mniej niż 4 punkty, zwróć te punkty jako otoczkę i nie wykonuj dalej algorytmu
            if (plotData.points.Count <= 3) {
                plotData.convexHull = plotData.points;
                return plotData;
            }

            // Weź punkt położony najniżej po lewej stronie
            var lastPoint = GetLowestLeftPoint(plotData);

            // Dodaj ten punkt jako pierwszy z otoczki
            plotData.convexHull.AddLast(lastPoint);
            while (true)
            {
                // Weź pierwszy punkt ze zbioru jako obecny punkt
                var currentPoint = plotData.points.First.Value; 

                // Dla każdego punktu w zbiorze punktów
                foreach (var iteratedPoint in plotData.points)
                {
                    // Jeśli aktualnie testowany punkt jest na lewo od obecnego punktu
                    // zastąp obecny punkt, punktem z aktualnej iteracji.
                    if (GetDirection(lastPoint, iteratedPoint, currentPoint) == 2)
                        currentPoint = iteratedPoint;
                    // Jeśli aktualnie testowany punkt jest współliniowy z poprzednim i obecnym, oraz
                    // leży na odcinku między punktem z poprzedniej iteracji a obecnym punktem z tej iteracji,
                    // i jeśli aktualnie testowany punkt nie jest punktem z poprzedniej iteracji,
                    // zastąp obecny punkt, punktem z aktualnej iteracji.
                    if (GetDirection(lastPoint, iteratedPoint, currentPoint) == 0 &&
                        isColinear(lastPoint, currentPoint, iteratedPoint) &&
                        iteratedPoint != lastPoint)
                        currentPoint = iteratedPoint;
                }

                // Jeśli obecny punkt jest taki sam jak pierwszy punkt z otoczki, oznacza to że zatoczyliśmy koło, przerwij pętle.
                if (currentPoint == plotData.convexHull.First.Value)
                    break;

                // Dodaj obecny punkt do zbioru dla otoczki
                plotData.convexHull.AddLast(currentPoint);

                // Usuń obecny punkt z puli iterowalnych punktów
                plotData.points.Remove(currentPoint);

                // Zauktualizuj 'stary' punkt
                lastPoint = currentPoint;
            }
            // Przywróć punkty do zbioru punktów
            plotData.points = oldData;
            return plotData;
        }
    }
}