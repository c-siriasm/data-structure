using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dynamic_Array
{
    class Result
    {

        /*
         * Complete the 'dynamicArray' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. 2D_INTEGER_ARRAY queries
         */

        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            ArrayList al = new ArrayList(n);
            int lastAnswer = 0;
            List<int> lastAnswersResult = new List<int>();
            for (int i = 0; i < n; i++)
                al.Add(new List<int>());

            foreach (var item in queries)
            {
                int[] currentRow = item.ToArray();
                int queryType = currentRow[0], x = currentRow[1], y = currentRow[2];

                if (queryType == 1)
                {
                    var idx = ((x ^ lastAnswer) % n);
                    List<int> currentData = (List<int>)al[idx];
                    currentData.Add(y);
                    al[idx] = currentData;
                }
                else if (queryType == 2)
                {
                    var idx = ((x ^ lastAnswer) % n);
                    List<int> currentData = (List<int>)al[idx];
                    lastAnswer = currentData.ElementAt(y % currentData.Count());
                    lastAnswersResult.Add(lastAnswer);
                }

            }

            return lastAnswersResult;
        }
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }
            List<int> result = Result.dynamicArray(n, queries);
            Console.WriteLine(result);
        }
    }
}
