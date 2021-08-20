using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.Utility
{
    public static class MathExtensions
    {
        public static ulong Sum(this List<ulong> list)
        {
            return list.Aggregate((ulong)0, (accomulator, current) => accomulator + current);
        }

        public static ulong Multiply(this List<ulong> list)
        {
            return list.Aggregate((ulong)1, (accomulator, current) => accomulator * current);
        }
    }
}
