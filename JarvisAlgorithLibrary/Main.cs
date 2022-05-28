using System.Drawing;

namespace JarvisAlgorithmLibrary
{
    public static class JarvisAlgorithm
    {
        public enum Direction { Left, Right, Straight}

        private static LinkedList<Point> _points;
        private static LinkedList<Point> _convexHull;

        private static Point getBottomPoint()
        {
            // Idea is to iterate through whole list to get the lowest point possible. Needs at least 2 points.
            var currentPoint =_points.First;
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

        public static Direction getDirection(Point a, Point b, Point c)
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
        public static LinkedList<Point> getConvexHull(LinkedList<Point> points)
        {
            if(points.Count <= 2)
                return points;

            _points = new LinkedList<Point>(points);
            _convexHull = new LinkedList<Point>();
            var lastPoint = getBottomPoint();

            // Get the convex loop 
            while (true)
            {
                var currentPoint = _points.First.Value;
                foreach (var iteratedPoint in _points)
                    if (getDirection(lastPoint, currentPoint, iteratedPoint) == Direction.Left)
                        currentPoint = iteratedPoint;

                    // If current point is the same as the first point of the convex hull, it means we have a circle.
                if (currentPoint == _convexHull.First.Value)
                    break;
                
                // Add current point to detected convex hull
                _convexHull.AddLast(currentPoint);

                // Remove current point from the general pool of points
                _points.Remove(currentPoint);

                // Update lastPoint for next iteration
                lastPoint = currentPoint;
            }
            return _convexHull;
        }
    }
}