using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreqsSelector
{
    class DFTCumputer : FTCoumputer
    {
        public override Complex[] FT(double[] data, RangeIndexes[] ranges)
        {
            Complex[] dft = new Complex[data.Length];
            
            for(int rangeInd = 0; rangeInd < ranges.GetLength(0); rangeInd++)
            {
                int from = ranges[rangeInd].Min;
                int to = ranges[rangeInd].Max;
                for(int m = from; m < to; m++)
                {
                    for(int n = 0; n < data.Length; n++)
                    {
                        double arg = (2*Math.PI * (m+1) * (n+1)) / data.Length;
                        double dt = data[n];
                        double cs = dt * Math.Cos(arg);
                        double sn = dt * Math.Sin(arg);
                        Complex up = cs - Complex.I * sn;
                        dft[m] += up;
                    }
                }
            }
            return dft;
        }

        public override double[] IFT(Complex[] data, RangeIndexes[] ranges)
        {
            double[] idft = new double[data.Length];

            for (int rangeInd = 0; rangeInd < ranges.GetLength(0); rangeInd++)
            {
                int from = ranges[rangeInd].Min;
                int to = ranges[rangeInd].Max;
                for (int m = 0; m < data.Length; m++)
                {
                    for (int n = from; n < to; n++)
                    {
                        double arg = (2*Math.PI * (m+1) * (n+1)) / data.Length;
                        Complex up = (data[n] * (Math.Cos(arg) + Complex.I * Math.Sin(arg)));
                        idft[m] += up.Real;
                    }
                }
            }
            for(int i = 0; i < idft.Length; i++)
            {
                idft[i] /= idft.Length;
            }
            return idft;
        }
    }
}
