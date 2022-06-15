using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace JarvisAlgorithmLib
{
    public struct PlotData
    {
        public LinkedList<Point> points;
        public LinkedList<Point> convexHull;
        public List<LinkedList<Point>> accessOrder;
    }
    public static class JarvisAlgorithm{
        public enum Direction { Left, Right, Straight }

        //private static LinkedList<Point> _points;
        //private static LinkedList<Point> _convexHull;
        //private static List<List<Point>> _accessOrder; 
        
        private static Point GetBottomPoint(PlotData plotData)
        {
            // Idea is to iterate through whole list to get the lowest point possible. Needs at least 2 points.
            var currentPoint = plotData.points.First;
            var nextPoint = currentPoint.Next;
            while (nextPoint != null)
            {
                if (currentPoint.Value.Y < nextPoint.Value.Y)
                {
                    currentPoint = nextPoint;
                }
                // Go to next point on the list 
                nextPoint = nextPoint.Next;
            }
            return currentPoint.Value;
        }
        
        public static Direction GetDirection(Point a, Point b, Point c)
        {
            // Move points b and c to origin to get vector
            var nB = new Point(b.X - a.X, b.Y - a.Y);
            var nC = new Point(c.X - a.X, c.Y - a.Y);

            // Calculate 2D cross product
            var prod = (nC.Y * nB.X) - (nB.Y * nC.X);

            // 
            if (prod > 0)
                return Direction.Left;

            if (prod < 0)
                return Direction.Right;

            return Direction.Straight;
        }

        public static PlotData GetConvexHull(PlotData plotData)
        {

            // Don't calculate, it does not make sense (output is either line or a point)
            if (plotData.points.Count <= 2)
            {
                plotData.convexHull = plotData.points;
                plotData.accessOrder.Add(plotData.points);
                return plotData;
            }

            //_points = new LinkedList<Point>(points);
            //_accessOrder = new List<List<Point>>();
            //_convexHull = new LinkedList<Point>();

            var lastPoint = GetBottomPoint(plotData);
            plotData.convexHull.AddLast(lastPoint);
            // Get the convex loop 
            while (true)
            {
                var currentPoint = plotData.points.First.Value;
                var currentIteration = new LinkedList<Point>();

                foreach (var iteratedPoint in plotData.points)
                {
                    if (GetDirection(lastPoint, currentPoint, iteratedPoint) == Direction.Left)
                        currentPoint = iteratedPoint;
                    currentIteration.AddLast(iteratedPoint);
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
            
            return plotData;
        }
    }
}