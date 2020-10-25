using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace YL_Final
{
    public class CircleFit
    {
        public static void Fit(Point[] points, out double radius, out Point center)
        {
            //Code//
            Point a = points[0];
            Point b = points[1];
            Point c = points[2];

            double x1 = (a.X + b.X) / 2;
            double y1 = (a.Y + b.Y) / 2;
            double x2 = (c.X + b.X) / 2;
            double y2 = (c.Y + b.Y) / 2;

            double dx1 = (a.X - b.X) / 2;
            double dy1 = (a.Y - b.Y) / 2;
            double dx2 = (b.X - c.X) / 2;
            double dy2 = (b.Y - c.Y) / 2;

            Point p1 = new Point((int)x1, (int)y1);
            Point p2 = new Point((int)x2, (int)y2);

            double m1 = dy1 / dx1;
            double m2 = dy2 / dx2;
            double c1 = y1 - (m1 * x1);
            double c2 = y2 - (m2 * x2);

            double mp1 = -1 * 1 / m1;
            double mp2 = -1 * 1 / m2;
            double cp1 = y1 - (mp1 * x1);
            double cp2 = y2 - (mp2 * x2);

            double x, y;
            double[] val = { 1 / m1, 1, cp1, 1 / m2, 1, cp2 };
            EqSolver(val, out x, out y);

            center = new Point((int)x, (int)y);
            radius = Math.Sqrt(Math.Pow((x - a.X), 2) + Math.Pow((y - a.Y), 2));
        }

        public static void EqSolver(double[] values, out double x, out double y)
        {
            // a1x+b1y=c1 and a2x+b2y=c2
            //values = {a1,b1,c1,a2,b2,c2}
            double[,] arrA = { { values[0], values[1] }, { values[3], values[4] } };
            double[,] arrB = { { values[2] }, { values[5] } };

            Matrix<double> A = Matrix<double>.Build.DenseOfArray(arrA);
            Matrix<double> B = Matrix<double>.Build.DenseOfArray(arrB);

            var C = A.Inverse().Multiply(B);

            x = C[0, 0];
            y = C[1, 0];
        }
    }
}
