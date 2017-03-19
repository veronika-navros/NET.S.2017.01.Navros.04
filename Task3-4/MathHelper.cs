using System;

namespace Task3_4
{
    /// <summary>
    /// Provides extended functionality for working woth integer numbers
    /// </summary>
    public static class MathHelper
    {
        #region Public Members

        /// <summary>
        /// Takes a positive integer and returns the next bigger integer consisting of the digits of the source number, and - 1, if such number doesn't exist
        /// </summary>
        /// <param name="number">Source positive integer for calculations</param>
        /// <returns>Next bigger integer number for the source number</returns>
        public static int NextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException();
            }

            if (number < 10)
            {
                return -1;
            }

            return FindNextNumber(number);
        }

        /// <summary>
        /// Finds root of specified degree of the number if it's possible
        /// </summary>
        /// <param name="number">Source number</param>
        /// <param name="rootDegree">Root degree</param>
        /// <param name="eps">Accuracy of calculations</param>
        /// <returns>Root of specified degree of source number</returns>
        public static double SqrtN(double number, int rootDegree, double eps = 0.0001)
        {
            if (rootDegree <= 0)
            {
                throw new ArgumentException();
            }

            if (number < 0 && rootDegree % 2 == 0)
            {
                throw new ArgumentException();
            }

            return FindRootOfNDegree(number, rootDegree, eps);
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Finds the next bigger integer consisting of the digits of the source number
        /// </summary>
        /// <param name="sourceNumber">Source number</param>
        /// <returns>Next bigger integer number for the source number</returns>
        static int FindNextNumber(int sourceNumber)
        {
            int[] array = new int[sourceNumber.ToString().Length];
            ConvertFromIntegerNumberToArray(sourceNumber, array);

            int index = FindIndexOfChangesStart(array);
            if (index == -1)
            {
                return -1;
            }

            if (index != array.Length - 1)
            {
                Array.Sort(array, index, array.Length - index);
            }

            return ConvertFromIntegerArrayToNumber(array);
        }

        /// <summary>
        /// Converts positive integer number to array consisting of its numerals
        /// </summary>
        /// <param name="number">Integer number</param>
        /// <param name="array">Array of numerals of the number</param>
        static void ConvertFromIntegerNumberToArray(int number, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                double temp = Math.Pow(10, array.Length - i - 1);
                array[i] = (int) (number / temp);
                number = (int) (number % temp);
            }
        }

        /// <summary>
        /// Converts array of numerals to the integer number
        /// </summary>
        /// <param name="array">Array of numerals</param>
        /// <returns>Integer number obtained from the array of numerals</returns>
        static int ConvertFromIntegerArrayToNumber(int[] array)
        {
            int result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result += (int) (array[i] * Math.Pow(10,array.Length - i - 1));
            }

            return result;
        }

        /// <summary>
        /// Finds index of the numeral in the number starting with which the number should be changed
        /// </summary>
        /// <param name="array">Array consisting of numerals of the source number</param>
        /// <returns>Index of the numeral in the number starting with which the number should be changed or -1</returns>
        static int FindIndexOfChangesStart(int[] array)
        {
            int i = array.Length - 1;
            int index = -1;

            while (i > 0)
            {
                if (array[i] > array[i - 1])
                {
                    Swap(ref array[i], ref array[i - 1]);
                    index = i;
                    break;
                }
                i--;
            }

            return index;
        }

        /// <summary>
        /// Swaps two elements in the integer array
        /// </summary>
        /// <param name="a">First element</param>
        /// <param name="b">Second element</param>
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Finds root of specified degree of the number
        /// </summary>
        /// <param name="number">Source number</param>
        /// <param name="rootDegree">Root degree</param>
        /// <param name="eps">Accuracy of calculations</param>
        /// <returns>Root of specified degree of source number</returns>
        private static double FindRootOfNDegree(double number, int rootDegree, double eps = 0.0001)
        {
            double temp1 = number / rootDegree;
            double temp2 = (1 / (double)rootDegree) * ((rootDegree - 1) * temp1 + number / Math.Pow(temp1, rootDegree - 1));

            while (Math.Abs(temp2 - temp1) > eps)
            {
                temp1 = temp2;
                temp2 = (1 / (double)rootDegree) * ((rootDegree - 1) * temp1 + number / Math.Pow(temp1, rootDegree - 1));
            }

            return temp2;
        }

        #endregion
    }
}
