﻿using System;
namespace Modeling.Data
{
    public class SplineSubInterval
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        private readonly Point _p1;
        private readonly Point _p2;

        #region Accessors
        public double GetX1()
        {
            return _p1.X;
        }
        public double GetX2()
        {
            return _p2.X;
        }

        public double GetDf()
        {
            return _p1.df;
        }
        public double GetDdf()
        {
            return _p1.ddf;
        }
        public Point GetPoint()
        {
            return _p1;
        }
        public Point GetLast() { return _p2; }

        #endregion

        public SplineSubInterval(Point p1, Point p2, double df = 0, double ddf = 0)
        {
            _p1 = p1;
            _p2 = p2;

            B = ddf;
            C = df;
            D = p1.Y;
            A = (_p2.Y - B * Math.Pow(_p2.X - _p1.X, 2) - C * (_p2.X - _p1.X) - D) / Math.Pow(_p2.X - _p1.X, 3);
        }

        public double F(double x)
        {
            return A * Math.Pow(x - _p1.X, 3) + B * Math.Pow(x - _p1.X, 2) + C * (x - _p1.X) + D;
        }

        public double Df(double x)
        {
            return 3 * A * Math.Pow(x - _p1.X, 2) + 2 * B * (x - _p1.X) + C;
        }

        public double Ddf(double x)
        {
            return 6 * A * (x - _p1.X) + 2 * B;
        }
    }
}
