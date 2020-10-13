using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2_v6
{
    class Vector
    {
        private double x, y;
        public Vector(double alpha, double r)
        {
            x = r * Math.Cos(alpha * 180 / 3.1415);
            y = r * Math.Sin(alpha * 180 / 3.1415);
        }

        public string getVector()
        {
            return "{" + getX().ToString() + ";" + getY().ToString() + "}";
        }

        public static double operator *(Vector v1, Vector v2)
        {
            return v1.getX()*v2.getX() + v1.getY()*v2.getY();
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            double alpha = Math.Atan2(v1.getY() - v2.getY(), v1.getX() - v2.getX() * 3.1415 / 180);
            return new Vector(alpha, (v1.getX() - v2.getX())/Math.Cos(alpha*180/3.1415));
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            double alpha = Math.Atan2(v1.getY() + v2.getY(), v1.getX() + v2.getX() * 3.1415 / 180);
            return new Vector(alpha, (v1.getX() + v2.getX()) / Math.Cos(alpha * 180 / 3.1415));
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }
    }
}
