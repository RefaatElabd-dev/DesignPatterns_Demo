﻿using System;

namespace DotNetDesignPatternDemos.Creational.Factories
{
    public class Point
    {
        private double x, y;

        protected Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(double a,
          double b, // names do not communicate intent
          CoordinateSystem cs = CoordinateSystem.Cartesian)
        {
            switch (cs)
            {
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    x = a;
                    y = b;
                    break;
            }

            // steps to add a new system
            // 1. augment CoordinateSystem
            // 2. change ctor
        }

        // factory property

        public static Point Origin => new Point(0, 0);

        // singleton field
        public static Point Origin2 = new Point(0, 0);

        // factory method

        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            //...
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }

        // make it lazy
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }

    class PointFactory
    {
        public static Point NewCartesianPoint(float x, float y)
        {
            return new Point(x, y); // needs to be public
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
}
