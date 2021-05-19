using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Text.Json;

namespace example_questions_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Question 1

            // Given two arrays of integers, find the common elements between them
            int[] a1 = GetRandomIntArray(-25, 25, 100);
            int[] a2 = GetRandomIntArray(-25, 25, 100);
            // method 1
            FindCommonElements(a1, a2, 0);
            // method 2
            FindCommonElements(a1, a2, 1);

            #endregion

            #region Question 2

            // Given an array of integers, find all pairs of numbers that add to a given value
            int[] a3 = GetRandomIntArray(0, 25, 25);
            // method 1
            FindSumPairs(a3, 25, 0);
            // method 2

            #endregion

            // question 3
            // Given a string, invert the positions of only the vowels

        }

        /// <summary>
        /// Given two arrays of integers, find the common elements between them.
        /// Can use two different algorithms. 0 -> nested looping (inefficient). 1 -> sort, iterate through (efficient).
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <param name="method"></param>
        /// <returns>Integer array of the common elements.</returns>
        static int[] FindCommonElements(int[] a1, int[] a2, int method = 1)
        {
            if (method == 0)
            {
                Console.WriteLine("Finding common elements between two arrays of integers using nested loops (inefficient):");
            }
            else if (method != 0)
            {
                method = 1;
                Console.WriteLine("Finding common elements between two arrays of integers by sorting, then interating through (efficient):");
            }

            // begin measuring elapsed time
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // store the common elements
            List<int> commonElements = new List<int>();

            // Check for null or empty arrays
            if (a1 == null)
            {
                Console.WriteLine("Array 1 is null.");
                return commonElements.ToArray();
            }
            else if (a1.Length == 0)
            {
                Console.WriteLine("Array 1 is empty.");
                return commonElements.ToArray();
            }
            if (a2 == null)
            {
                Console.WriteLine("Array 2 is null.");
                return commonElements.ToArray();
            }
            else if (a2.Length == 0)
            {
                Console.WriteLine("Array 2 is empty.");
                return commonElements.ToArray();
            }
            // print out the arrays
            else
            {
                //Console.Write("Array 1: ");
                //Console.Write(String.Join(", ", a1));
                //Console.WriteLine("");
                //Console.Write("Array 2: ");
                //Console.Write(String.Join(", ", a2));
                //Console.WriteLine("");
            }

            // very inefficient, nested looping method
            if (method == 0)
            {
                // remove duplicates
                List<int> array1 = a1.Distinct().ToList();
                List<int> array2 = a2.Distinct().ToList();

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

                commonElements.Sort();
            }
            // more efficient method
            else if (method == 1)
            {
                // sort
                List<int> list1 = a1.ToList();
                list1.Sort();
                int[] array1 = list1.ToArray<int>();

                List<int> list2 = a2.ToList();
                list2.Sort();
                int[] array2 = list2.ToArray<int>();

                // iterate through the arrays
                int i = 0, j = 0;
                while (i < array1.Length && j < array2.Length)
                {
                    if (array1[i] == array2[j])
                    {
                        commonElements.Add(array1[i]);
                        i++;
                        j++;
                    }
                    else if (array1[i] < array2[j])
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                }

                commonElements = commonElements.Distinct().ToList();
            }

            // end measuring elapsed time
            watch.Stop();
            
            // print out result
            Console.Write("Common elements: ");
            Console.Write(String.Join(", ", commonElements));
            Console.WriteLine("");
            Console.WriteLine("Calculation time: " + watch.ElapsedMilliseconds + "ms");
            Console.WriteLine("");

            return commonElements.ToArray();
        }

        /// <summary>
        /// Given an array of integers, find all pairs that sum to a given total.
        /// Can use two different algorithms. 0 -> nested looping (inefficient). 1 -> PLACEHOLDER (efficient).
        /// </summary>
        /// <param name="a"></param>
        /// <param name="sum"></param>
        /// <param name="method"></param>
        /// <returns>2D integer array containing the pairs.</returns>
        static int[][] FindSumPairs(int[] a, int sum, int method = 1)
        {
            if (method == 0)
            {
                Console.WriteLine("Finding pairs that sum to " + sum + " using nested loops (inefficient):");
            }
            else if (method != 0)
            {
                method = 1;
                Console.WriteLine("Finding pairs that sum to " + sum + " (METHOD 2):");
            }

            // begin measuring elapsed time
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // store the pairs
            List<int[]> sumPairs = new List<int[]>();

            // check for null or empty array
            if (a == null)
            {
                Console.WriteLine("Array is null.");
                return sumPairs.ToArray();
            }
            else if (a.Length == 0)
            {
                Console.WriteLine("Array is empty.");
                return sumPairs.ToArray();
            }
            else
            {
                Console.Write("Array: ");
                Console.Write(String.Join(", ", a));
                Console.WriteLine("");
            }

            // inefficient, nested looping method
            if (method == 0)
            {
                // loop through every element
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < a.Length; j++)
                    {
                        // don't check an element against itself
                        if (i == j)
                        {
                            continue;
                        }
                        else if (a[i] + a[j] == sum)
                        {
                            int[] newPair = { a[i], a[j] };
                            sumPairs.Add(newPair);
                        }
                    }
                }

            }
            else if (method == 1)
            {

            }

            // end measuring elapsed time
            watch.Stop();

            // print out result
            Console.WriteLine("Pairs: ");
            foreach (int[] item in sumPairs)
            {
                Console.WriteLine(String.Join(", ", item));
            }
            Console.WriteLine("");
            Console.WriteLine("Calculation time: " + watch.ElapsedMilliseconds + "ms");
            Console.WriteLine("");

            return sumPairs.ToArray();
        }

        /// <summary>
        /// uses random number API: http://www.randomnumberapi.com/ to get random numbers
        /// </summary>
        /// <param name="pMin">minimum possible number</param>
        /// <param name="pMax">maximum possible number</param>
        /// <param name="pCount">total of results</param>
        /// <returns></returns>
        static int[] GetRandomIntArray(int pMin, int pMax, int pCount)
        {
            int min, max, count;
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
            if (pCount <= 0)
            {
                count = 10;
            }
            else
            {
                count = pCount;
            }

            // complete the URL and request the data from the API
            URL += "min=" + min + "&max=" + max + "&count=" + count;
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(URL);

            // read in the result
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            // parse json to an int array
            try
            {
                string jsonResult = objReader.ReadLine();
                result = JsonSerializer.Deserialize<int[]>(jsonResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return result;
        }
    }
}
