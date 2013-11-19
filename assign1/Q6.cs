using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    public static class Q6
    {
        public static void Go()
        {
            var pat = "TGGTTGCCA";
            var gen = new System.IO.StreamReader("../../dataset_8_3.txt").ReadToEnd();
            var k = pat.Length;
            var m = 4;
            var lt = new List<int>();
            for (int x = 0; x < gen.Length - k; x++)
            {
                var kmer = gen.Substring(x, k);
                var matches = 0;
                for (var z = 0; z < k; z++)
                {
                    if (kmer[z] == pat[z])
                        matches++;
                }
                if (matches >= k - m)
                    lt.Add(x);
            }

            System.Diagnostics.Debug.WriteLine(string.Join(" ", lt));
        }
    }
}
