using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    public static class Q3
    {
        public static void Go()
        {
            var pat = "GGAAGG";
            //var gen = "GATATATGCATATACTT";
            var gen = new System.IO.StreamReader("../../dataset_3_5.txt").ReadToEnd(); //"AAAACCCGGT";
            var k = pat.Length;
            var lt = new List<int>();
            for (int x = 0; x < gen.Length - k; x++)
            {
                var kmer = gen.Substring(x, k);
                if (kmer == pat)
                    lt.Add(x);
            }

            System.Diagnostics.Debug.WriteLine(string.Join(" ", lt));

        }
    }
}
