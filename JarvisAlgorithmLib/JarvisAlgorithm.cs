using System;
using System.Collections.Generic;
using System.Drawing;

namespace JarvisAlgorithmLib
{
    public struct PlotData : ICloneable
    {
        public LinkedList<Point> points;
        public LinkedList<Point> convexHull;
        //public List<List<Point>> accessOrder;

        public object Clone()
        {
            return new PlotData
            {
                points = points,
                convexHull = convexHull,
                //accessOrder = accessOrder
            };
        }
    }

    public static class JarvisAlgorithm
    {
        // Given three colinear points p, q, r, the function checks if 
        // point q lies on line segment 'pr' 
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
            var oldData = new LinkedList<Point>(plotData.points);

            if (plotData.points.Count <= 3)
            {
                plotData.convexHull = plotData.points;
                return plotData;
            }

            var lastPoint = GetLowestLeftPoint(plotData);
            plotData.convexHull.AddLast(lastPoint);
            // Get the convex loop 
            while (true)
            {
                var currentPoint = plotData.points.First.Value;
                var currentIteration = new List<Point>();

                foreach (var iteratedPoint in plotData.points)
                {
                    if (GetDirection(lastPoint, iteratedPoint, currentPoint) == 2)
                        currentPoint = iteratedPoint;
                    if (GetDirection(lastPoint, iteratedPoint, currentPoint) == 0 &&
                        isColinear(lastPoint, currentPoint, iteratedPoint) &&
                        iteratedPoint != lastPoint)
                        currentPoint = iteratedPoint;
                    currentIteration.Add(iteratedPoint);
                }

                // If current point is the same as the first point of the convex hull, it means we have a circle.
                if (currentPoint == plotData.convexHull.First.Value)
                    break;

                // Add current point to detected convex hull
                plotData.convexHull.AddLast(currentPoint);

                // Remove current point from the general pool of points
                plotData.points.Remove(currentPoint);

                // Update lastPoint for next iteration
                lastPoint = currentPoint;

                // Save current iteration access order 
                //plotData.accessOrder.
                //plotData.accessOrder.Add(currentIteration);
            }

            plotData.points = oldData;
            return plotData;
        }
    }
}