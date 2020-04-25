using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreqsSelector
{
    public struct RangeHz
    {
        public RangeHz(double start = 0, double end = 0, bool minOpen = false, bool maxOpen = false)
        {
            if (start < 0 || end < 0)
            {
                throw new ArgumentException("start and end should be non negative");
            }

            min = Math.Min(start, end);
            max = Math.Max(start, end);
            MinOpen = minOpen;
            MaxOpen = maxOpen;
        }
        public override string ToString()
        {
            string ret = "";
            if (MinOpen)
            {
                ret += "(0.0";
            }
            else
            {
                ret += "[" + Min;
            }
            ret += "->";
            if (MaxOpen)
            {
                ret += "+Inf)";
            }
            else
            {
                ret += Max + "]";
            }
            return ret;
        }

        public RangeHz(double start, double end) : this(start, end, false, false)
        { }

        private double min;
        public double Min
        {
            get
            {
                if (MinOpen)
                {
                    return 0;
                }
                return min;
            }
            set
            {
                min = value;
            }
        }
        public bool MinOpen { get; set; }
        private double max;
        public double Max
        {
            get
            {
                if (MaxOpen)
                {
                    return double.MaxValue;
                }
                return max;
            }
            set
            {
                max = value;
            }
        }
        public bool MaxOpen { get; set; }
    }

    public struct RangeIndexes
    {
        public RangeIndexes(int start, int end)
        {
            if (start < 0 || end < 0)
            {
                throw new ArgumentException("start and end should be non negative");
            }

            Min = Math.Min(start, end);
            Max = Math.Max(start, end);
        }
        public override string ToString()
        {
            return "[" + Min + "->" + Max + "]";
        }
        public int Min { get; private set; }
        public int Max { get; private set; }

    }
}
