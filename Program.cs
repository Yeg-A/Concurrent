using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Concurrent
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> ans = new HashSet<int>();
            List<int> startEnd = new List<int>();

            List<List<object>> rawData = new List<List<object>>()
            { new List<object>() { 'A', 4, 1 }, new List<object>() { 'B', 5, 2 }, new List<object>() { 'C', 6, 3 }, new List<object>() { 'D', 7, 4 }, new List<object>() { 'E', 8, 5 } };
            
            foreach (var x in rawData)
            {
                int end = Convert.ToInt32(x[1]);
                int duration = Convert.ToInt32(x[2]);
                int start = end - duration;

                //generate all numbers within the start - end window
                startEnd.AddRange(Enumerable.Range(start, duration));
            }

      //      var most = list.GroupBy(i => i).OrderByDescending(grp => grp.Count())
      //.Select(grp => grp.Key).First();

            //count the occurence of the most common ints
            int maxCount = startEnd.GroupBy(x => x).Max(z => z.Count());

            //filter the ints that occur as many times as the maxCount
            List<int> maxItems = startEnd.GroupBy(i => i).Where(grp => grp.Count() == maxCount)
         .Select(grp => grp.Key).ToList();

            for(int i = 0; i < maxItems.Count(); i++)
            {
                HashSet<int> temp = new HashSet<int>();
                int j = maxItems[i];

                //check if consecutive 
                while (maxItems.Contains(j))
                {
                    temp.Add(j);
                    j++;
                }

                if (temp.Count() > ans.Count())
                    ans = temp;
            }

            foreach (var x in ans)
                Console.WriteLine(x);
        }
    }
}
