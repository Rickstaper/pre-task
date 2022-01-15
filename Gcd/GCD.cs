using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Gcd
{
    /// <summary>
    /// Class for calculate GCD differences algorithms and parameters
    /// </summary>
    public static class GCD
    {
        private static string BaseDirectory { get; set; }

        /// <summary>
        /// Calculates GCD with two parameters by Euclidean
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns></returns>
        public static int GetGcdByEuclidean(int a, int b, out TimeSpan spendTime)
        {
            Stopwatch time = Stopwatch.StartNew();
            
            if (a == 0 || b == 0)
            {
                throw new ArgumentException(nameof(GetGcdByEuclidean));
            }

            a = (a < 0) ? a * (-1) : a;

            b = (b < 0) ? b * (-1) : b;

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            time.Stop();
            spendTime = time.Elapsed;

            return a + b;
        }

        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if (a == 0 || b == 0 || c == 0)
            {
                throw new ArgumentException(nameof(GetGcdByEuclidean));
            }

            a = (a < 0) ? a * (-1) : a;

            b = (b < 0) ? b * (-1) : b;

            c = (c < 0) ? c * (-1) : c;

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            int result = a + b;

            while(result !=0 && c != 0)
            {
                if (result > c)
                {
                    result %= c;
                }
                else
                {
                    c %= result;
                }
            }

            return result + c;
        }

        /// <summary>
        /// Calculates GCD by Euclidean with three and more parameters
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="other">Other numbers</param>
        /// <returns></returns>
        public static int GetGcdByEuclidean(int a, int b, params int[] other)
        {
            if (a == 0 || b == 0 || other.All(i => i == 0))
            {
                throw new ArgumentException(nameof(GetGcdByEuclidean));
            }

            a = (a < 0) ? a * (-1) : a;

            b = (b < 0) ? b * (-1) : b;

            for (var i = 0; i < other.Length; i++)
            {
                other[i] = (other[i] < 0) ? other[i] * (-1) : other[i];
            }

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            int firstResult = a + b;
            int otherResult = 0;
            for (var i = 1; i < other.Length; i++)
            {
                if (other[i - 1] == 0 || other[i] == 0)
                {
                    continue;
                }

                if (other[i - 1] > other[i])
                {
                    other[i - 1] %= other[i];
                }
                else
                {
                    other[i] %= other[i - 1];

                }

                otherResult += other[i - 1] + other[i];
            }

            while(firstResult != 0 && otherResult != 0)
            {
                if (firstResult > otherResult)
                {
                    firstResult %= otherResult;
                }
                else
                {
                    otherResult %= firstResult;
                }
            }

            return firstResult + otherResult;
        }

        public static int GetGcdByStein(int a, int b, out TimeSpan spendTime)
        {
            Stopwatch time = Stopwatch.StartNew();

            if (a == 0 || b == 0)
            {
                throw new ArgumentException(nameof(GetGcdByEuclidean));
            }

            a = (a < 0) ? a * (-1) : a;

            b = (b < 0) ? b * (-1) : b;

            if (a == b)
            {
                time.Stop();
                spendTime = time.Elapsed;
                return a;
            }

            int iterations = 1;

            while(a != 0 && b != 0)
            {
                while (a % 2 == 0 && b % 2 == 0)
                {
                    a /= 2;
                    b /= 2;
                    iterations *= 2;
                }

                while(a % 2 == 0 && b % 2 != 0)
                {
                    a /= 2;
                }

                while(a % 2 != 0 && b % 2 == 0)
                {
                    b /= 2;
                }

                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            time.Stop();
            spendTime = time.Elapsed;

            return (a + b) * iterations;
        }

        public static string CrateJsonData(List<Data> data)
        {
            string jsonData = JsonConvert.SerializeObject(data);

            File.AppendAllText(GetPath("data.json"), jsonData);

            return jsonData;
        }

        private static string GetPath(string path)
        {
            BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(BaseDirectory, path);
        }
    }
}
