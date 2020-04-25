using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreqsSelector
{
    public abstract class FTCoumputer
    {
        public class Result
        {
            public Result(Complex[] dft, double[] idft, int[] minsDiffs, int[] maxsDiffs, RangeIndexes[] ranges)
            {
                DFT = dft;
                IDFT = idft;
                MinsDiffs = minsDiffs;
                MaxsDiffs = maxsDiffs;
                Ranges = ranges;
            }
            public Complex[] DFT
            {
                get; private set;
            }

            public double[] IDFT
            {
                get; private set;
            }
            public int[] MinsDiffs
            {
                get; private set;
            }
            public int[] MaxsDiffs
            {
                get; private set;
            }
            public RangeIndexes[] Ranges
            {
                get; private set;
            }
        }
        

        public abstract Complex[] FT(double[] data, RangeIndexes[] ranges);
        public abstract double[] IFT(Complex[] data, RangeIndexes[] ranges);

        public static RangeHz[] CollapseRangesHzIntersections(RangeHz[] ranges)
        {
            List<RangeHz> rngs = new List<RangeHz>(ranges);
            rngs = rngs.FindAll((r) => { return r.Min != r.Max; });
            rngs.Sort((r1, r2) =>
            {
                if (r1.MinOpen)
                {
                    return -1;
                }
                if (r2.MinOpen)
                {
                    return 1;
                }
                if (r1.MaxOpen)
                {
                    return 1;
                }
                if (r2.MaxOpen)
                {
                    return -1;
                }
                return r1.Min.CompareTo(r2.Min);
            });

            double start = rngs.Count > 0 ? rngs[0].Min : 0;
            double end = rngs.Count > 0 ? rngs[0].Max : 0;

            List<RangeHz> results = new List<RangeHz>();
            
            for(int i = 0; i < rngs.Count; i++)
            {
                RangeHz r = rngs[i];
                
                if(r.Min > end)
                {
                    results.Add(new RangeHz(start, end));
                    start = r.Min;
                    end = r.Max;
                }
                else
                {
                    end = Math.Max(end, r.Max);
                }
            }
            if (rngs.Count > 0)
            {
                results.Add(new RangeHz(start, end));
            }

            return results.ToArray();
        }
        public static RangeIndexes[] CollapseRangesIndexesIntersections(RangeIndexes[] ranges)
        {
            List<RangeIndexes> rngs = new List<RangeIndexes>(ranges);
            rngs.Sort((r1, r2) =>
            {
                return r1.Min.CompareTo(r2.Min);
            });

            rngs = rngs.FindAll((r) => { return r.Min != r.Max; });

            int start = rngs.Count > 0 ? rngs[0].Min : 0;
            int end = rngs.Count > 0 ? rngs[0].Max : 0;

            List<RangeIndexes> results = new List<RangeIndexes>();

            for (int i = 0; i < rngs.Count; i++)
            {
                RangeIndexes r = rngs[i];

                if (r.Min > end)
                {
                    results.Add(new RangeIndexes(start, end));
                    start = r.Min;
                    end = r.Max;
                }
                else
                {
                    end = Math.Max(end, r.Max);
                }
            }
            if (rngs.Count > 0)
            {
                results.Add(new RangeIndexes(start, end));
            }

            return results.ToArray();
        }
        public static RangeIndexes GetDataIndexesRange(int dataLen, double discretization, RangeHz range)
        {
            int start = (int)(dataLen * 1.0 / discretization * range.Min);
            double end_d = Math.Min(dataLen, (dataLen * 1.0 / discretization * range.Max));

            if((int)end_d == start)
            {
                end_d+=1;
            }
            return new RangeIndexes(start, (int)end_d);
        }

        public int[] GetLocalMinsIndexes(double[] data)
        {
            List<int> indexes = new List<int>();
            for(int i = 2; i < data.Length; i++)
            {
                if(data[i - 1]<data[i] && data[i-1] < data[i-2])
                {
                    indexes.Add(i-1);
                }
            }
            return indexes.ToArray();
        }

        public int[] GetLocalMaxsIndexes(double[] data)
        {
            List<int> indexes = new List<int>();
            for (int i = 2; i < data.Length; i++)
            {
                if (data[i - 1] > data[i] && data[i - 1] > data[i - 2])
                {
                    indexes.Add(i-1);
                }
            }
            return indexes.ToArray();
        }

        public int[] GetDiffs(int[] data)
        {
            if(data.Length == 0)
            {
                return new int[0];
            }
            int[] diffs = new int[data.Length - 1];
            if (data.Length == 0)
                return diffs;
            for(int i = 1; i < data.Length; i++)
            {
                diffs[i - 1] = data[i] - data[i-1];
            }
            return diffs;
        }

        public static RangeIndexes[] GetRangesForArrOfLen(int dataLen, double discretization,RangeHz[] ranges)
        {
            RangeHz[] _ranges = CollapseRangesHzIntersections(ranges);
            RangeIndexes[] data_ranges = new RangeIndexes[_ranges.Length];
            for (int i = 0; i < _ranges.Length; i++)
            {
                data_ranges[i] = GetDataIndexesRange(dataLen, discretization, _ranges[i]);
            }

            data_ranges = CollapseRangesIndexesIntersections(data_ranges);

            return data_ranges;
        }

        public Result Compute(double[] data, double discretization, RangeHz[] ranges)
        {
            RangeIndexes[] data_ranges = GetRangesForArrOfLen(data.Length, discretization, ranges);

            Complex[] dft = FT(data, data_ranges);
            double[] idft = IFT(dft, data_ranges);

            int[] localMins = GetLocalMinsIndexes(idft);
            int[] localMaxs = GetLocalMaxsIndexes(idft);

            int[] localMinsDiffs = GetDiffs(localMins);
            int[] localMaxsDiffs = GetDiffs(localMaxs);

            return new Result(dft, idft, localMinsDiffs, localMaxsDiffs, data_ranges);
        }
    }
}
