using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Utility
{
    public static class ArrayExtensions
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        public static T[] PrependItem<T>(this T[] array, T itemToPrepend)
        {
            T[] result = new T[array.Length + 1];
            result[0] = itemToPrepend;
            Array.Copy(array, 0, result, 1, array.Length);

            return result;

        }
    }
}
