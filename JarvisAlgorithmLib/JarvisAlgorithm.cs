using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace JarvisAlgorithmLib
{
    public struct PlotData : ICloneable
    {
        public LinkedList<Point> points;
        public LinkedList<Point> convexHull;
        public List<List<Point>> accessOrder;
        public object Clone()
        {
            return new PlotData
            {
                points = this.points,
                convexHull = this.convexHull,
                accessOrder = this.accessOrder
            };
        }
    }

    public static class JarvisAlgorithm
    {



        // Given three colinear points p, q, r, the function checks if 
        // point q lies on line segment 'pr' 
        public static bool isColinear(Point p, Point q, Point r)
        {
            return (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                    q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y));
        }

        public static int GetDirection(Point a, Point b, Point c)
        {
            int val = (b.Y - a.Y) * (c.X - b.X) -
                      (b.X - a.X) * (c.Y - b.Y);

            if (val == 0) return 0; // colinear
            return (val > 0) ? 1 : 2; // clock or counterclockwise
        }

        public static Point GetLowestLeftPoint(PlotData plotData)
        {
            Point l = new Point();
            foreach (var p in plotData.points)
            {
                if (p.Y > l.Y)
                    l = p;
                else if (p.Y == l.Y &&
                         p.X > l.X)
                    l = p;
            }
            return l;
        }
        public static PlotData GetConvexHull(ref PlotData plotData)
        {
            LinkedList<Point> oldData = new LinkedList<Point>(plotData.points);
            
            if (plotData.points.Count <= 3)
            {
                plotData.convexHull = plotData.points;
                return plotData;
            }

            //// Get the lowest left-most point
            //int l = 0;
            //for (int i = 1; i < plotData.points.Count; i++)
            //{
            //    if (plotData.points.ElementAt(i).X < plotData.points.ElementAt(l).X)
            //        l = i;

            //    // For handling leftmost colinear points.
            //    else if (plotData.points.ElementAt(i).X == plotData.points.ElementAt(l).X &&
            //             plotData.points.ElementAt(i).Y < plotData.points.ElementAt(l).Y)
            //        l = i;
            //}

            //int p = l, q;
            var lastPoint = GetLowestLeftPoint(plotData);
            plotData.convexHull.AddLast(lastPoint);
            // Get the convex loop 
                while (true)
                {
                    var currentPoint = plotData.points.First.Value;
                    var currentIteration = new List<Point>();

                    foreach (var iteratedPoint in plotData.points)
                    {
                        if (GetDirection(lastPoint, currentPoint, iteratedPoint) == 2)
                            currentPoint = iteratedPoint;
                        if (GetDirection(lastPoint, currentPoint, iteratedPoint) == 0 &&
                            isColinear(lastPoint , iteratedPoint, currentPoint) &&
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
                    plotData.accessOrder.Add(currentIteration);
                }
            
            //// Get the convex hull
            //do
            //{
            //    plotData.convexHull.AddLast(plotData.points.ElementAt(p)); // Save obtained convex hull point
            //    List<Point> tempList = new List<Point>();
            //    tempList.Add(plotData.points.ElementAt(p));
            //    q = (p + 1) % plotData.points.Count;                       // Next point index
            //    for (int i = 0; i < plotData.points.Count; i++)
            //    {
            //        if (GetDirection(plotData.points.ElementAt(p), plotData.points.ElementAt(i),
            //                plotData.points.ElementAt(q)) == 2)
            //            q = i;
            //        if (p != i && 
            //            GetDirection(plotData.points.ElementAt(p), plotData.points.ElementAt(i), plotData.points.ElementAt(q)) == 0 &&
            //            isColinear(plotData.points.ElementAt(p), plotData.points.ElementAt(q), plotData.points.ElementAt(i)))
            //            q = i;
            //        tempList.Add(plotData.points.ElementAt(q));
            //    }
            //    p = q;
                
            //    plotData.accessOrder.Add(tempList);
            //} while (p != l);
            plotData.points = oldData;
            return plotData;
            
        }
    }
}