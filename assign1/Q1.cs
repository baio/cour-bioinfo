using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    public static class Q1
    {
        public static void Go()
        {
            int k = 14;

            var str = new System.IO.StreamReader("../../dataset_2_4.txt").ReadToEnd();

            var dict = new Dictionary<string, int>();

            //collect all kmers

            for (int x = 0; x < str.Length - k; x++)
            {
                var kmer = str.Substring(x, k);

                if (dict.ContainsKey(kmer))
                    dict[kmer] += 1;
                else
                    dict.Add(kmer, 1);
            }

            //find max enconterd quantity of kmers
            var mx = dict.Max((p) => p.Value);

            var r = dict.Where(p => p.Value == mx);

            System.Diagnostics.Debug.WriteLine(string.Join(" ", r.Select(p => p.Key).ToArray()));        
        }
    }
}
