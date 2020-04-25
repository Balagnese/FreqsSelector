using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreqsSelector
{
    public class cl<T>
    {

    } 
    public struct Complex
    {
        public Complex(double real =0, double imag = 0)
        {
            Real = real;
            Imag = imag;
        }
        public readonly double Real, Imag;

        public override string ToString()
        {
            string ret = "<"+Real;
            if(Imag < 0)
            {
                ret += "-"+Math.Abs(Imag)+"j>";
            }
            else
            {
                ret += "+" + Math.Abs(Imag) + "j>";
            }
            return ret;
        }
        public Complex Conjugate()
        {
            return new Complex(Real, -Imag);
        }
        public double Abs
        {
            get
            {
                return Math.Sqrt((double)(Real * Real + Imag * Imag));
            }
        }
        public static Complex I
        {
            get
            {
                return new Complex(0, 1);
            }
        }
        public static Complex operator+(Complex v)
        {
            return v;
        }
        public static Complex operator +(Complex v1, Complex v2)
        {
            return new Complex(v1.Real+v2.Real, v1.Imag+v2.Imag);
        }
        public static Complex operator +(Complex v1, double v2)
        {
            return new Complex(v1.Real + v2, v1.Imag);
        }
        public static Complex operator +(double v1, Complex v2)
        {
            return v2 + v1;
        }
        public static Complex operator +(Complex v1, int v2)
        {
            return new Complex(v1.Real + v2, v1.Imag);
        }
        public static Complex operator +(int v1, Complex v2)
        {
            return v2 + v1;
        }
        public static Complex operator +(Complex v1, float v2)
        {
            return new Complex(v1.Real + v2, v1.Imag);
        }
        public static Complex operator +(float v1, Complex v2)
        {
            return v2 + v1;
        }
        public static Complex operator-(Complex v)
        {
            return new Complex(-v.Real, -v.Imag);
;       }
        public static Complex operator-(Complex v1, Complex v2)
        {
            return new Complex(v1.Real - v2.Real, v1.Imag - v2.Imag);
        }
        public static Complex operator -(Complex v1, double v2)
        {
            return new Complex(v1.Real - v2, v1.Imag);
        }
        public static Complex operator -(double v1, Complex v2)
        {
            return -(v2 - v1);
        }
        public static Complex operator -(Complex v1, int v2)
        {
            return new Complex(v1.Real - v2, v1.Imag);
        }
        public static Complex operator -(int v1, Complex v2)
        {
            return -(v2 - v1);
        }
        public static Complex operator -(Complex v1, float v2)
        {
            return new Complex(v1.Real - v2, v1.Imag);
        }
        public static Complex operator -(float v1, Complex v2)
        {
            return -(v2 - v1);
        }
        public static Complex operator *(Complex v1, Complex v2)
        {
            double real = v1.Real * v2.Real - v1.Imag * v2.Imag;
            double imag = v1.Real * v2.Imag + v1.Imag * v2.Real;
            return new Complex(real, imag);
        }
        
        public static Complex operator *(Complex v1, double v2)
        {
            return new Complex(v1.Real * v2, v1.Imag * v2);
        }
        public static Complex operator *(double v1, Complex v2)
        {
            return v2 * v1;
        }
        public static Complex operator *(Complex v1, int v2)
        {
            return new Complex(v1.Real * v2, v1.Imag * v2);
        }
        public static Complex operator *(int v1, Complex v2)
        {
            return v2 * v1;
        }
        public static Complex operator *(Complex v1, float v2)
        {
            return new Complex(v1.Real * v2, v1.Imag * v2);
        }
        public static Complex operator *(float v1, Complex v2)
        {
            return v2 * v1;
        }
        public static Complex operator /(Complex v1, Complex v2)
        {
            Complex downConj = v2.Conjugate();
            Complex up = v1 * downConj;
            double down = (v2 * downConj).Real;
            return new Complex(up.Real / down, up.Imag / down);
        }
        public static Complex operator /(Complex v1, double v2)
        {
            return new Complex(v1.Real / v2, v1.Imag / v2);
        }
        public static Complex operator /(double v1, Complex v2)
        {
            return  new Complex(v1)/v2;
        }
        public static Complex operator /(Complex v1, float v2)
        {
            return new Complex(v1.Real / v2, v1.Imag / v2);
        }
        public static Complex operator /(float v1, Complex v2)
        {
            return new Complex(v1) / v2;
        }
        public static Complex operator /(Complex v1, int v2)
        {
            return new Complex(v1.Real / v2, v1.Imag / v2);
        }
        public static Complex operator /(int v1, Complex v2)
        {
            return new Complex(v1) / v2;
        }
    }
}
