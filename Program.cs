using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace example_questions_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Question 1

            // Example data
            //int[] a1 = new int[] { 1, 2, 3, 4, 5, 9, 10 };
            //int[] a2 = new int[] { 1, 5, 6, 7, 8, 9, 10 };
            int[] a1 = GetRandomIntArray(-50, 50, 100);
            int[] a2 = GetRandomIntArray(-50, 50, 100);

            // Given two arrays of integers, find the common elements between them
            FindCommonElements1(a1, a2);

            #endregion

            // question 2
            // Given an array of integers, find all pairs of numbers that add to a given value

            // question 3
            // Given a string, invert the positions of only the vowels

        }

        // question 1
        // Given two arrays of integers, find the common elements between them
        static int[] FindCommonElements1(int[] a1, int[] a2)
        {
            // begin measuring elapsed time
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<int> commonElements = new List<int>();
            Console.WriteLine("Finding common elements between two arrays of integers using nested loops:");

            // check for null or empty arrays
            if (!ValidateIntArrays(a1, a2))
            {
                return commonElements.ToArray();
            }
            // print out the arrays
            else
            {
                Console.Write("Array 1: ");
                Console.Write(String.Join(", ", a1));
                Console.WriteLine("");
                Console.Write("Array 2: ");
                Console.Write(String.Join(", ", a2));
                Console.WriteLine("");
            }

            // remove duplicates from the arrays
            int[] array1 = a1.Distinct().ToArray();
            int[] array2 = a2.Distinct().ToArray();

            // loop through the first array
            foreach (int i in array1)
            {
                // loop through the second array
                foreach (int j in array2)
                {
                    if (i == j)
                    {
                        commonElements.Add(i);
                        continue;
                    }
                }
            }

            Console.Write("Common elements: ");
            Console.Write(String.Join(", ", commonElements));
            Console.WriteLine("");

            // end measuring elapsed time
            watch.Stop();
            Console.WriteLine("Calculation time: " + watch.ElapsedMilliseconds + "ms");
            Console.WriteLine("");

            return commonElements.ToArray();
        }

        static bool ValidateIntArrays(int[] a1, int[] a2)
        {
            int[] array1 = a1;
            int[] array2 = a2;

            // Check for null or empty arrays
            if (array1 == null)
            {
                Console.WriteLine("Array 1 is null");
                return false;
            }
            else if (array1.Length == 0)
            {
                Console.WriteLine("Array 1 is empty");
                return false;
            }
            if (array2 == null)
            {
                Console.WriteLine("Array 2 is null");
                return false;
            }
            else if (array2.Length == 0)
            {
                Console.WriteLine("Array 2 is empty");
                return false;
            }
            return true;
        }

        static int[] GetRandomIntArray(int pMin, int pMax, int pCount)
        {
            int min;
            int max;
            int count;
            string URL = "http://www.randomnumberapi.com/api/v1.0/random?";
            int[] result = { };

            // validate values, set defaults if necessary
            if (pMin > pMax && pMin >= 0 && pMax <= 100)
            {
                min = pMax;
                max = pMin;
            }
            else if (pMin == pMax)
            {
                min = 0;
                max = 100;
            }
            else
            {
                min = pMin;
                max = pMax;
            }
            if (pCount <= 0 || pCount > 100)
            {
                count = 50;
            }
            else
            {
                count = pCount;
            }

            // complete the URL
            URL += min + "&max=" + max + "&count=" + count;

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(URL);

            WebProxy myProxy = new WebProxy("myproxy", 80);
            myProxy.BypassProxyOnLocal = true;

            // wrGETURL.Proxy = WebProxy.GetDefaultProxy();

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    Console.WriteLine("{0}:{1}", i, sLine);
            }

            return result;
        }
    }
}
