using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    public static class Q7
    {
        public static bool IsMatch(string str1, string str2, int m)
        {
            var k = str1.Length;
            var matches = 0;
            for (var z = 0; z < k; z++)
            {
                if (str1[z] == str2[z])
                    matches++;
            }

            return matches >= k - m;
        }

        public static string FindMatch(IEnumerable<string> lt, string str, int m)
        {
            foreach (var s in lt)
            {
                if (IsMatch(s, str, m))
                    return s;
            }

            return null;
        }

        public static IEnumerable<string> GenMismatchedKmers(string kmer, int m)
        {
            var g = new [] {'G', 'T', 'C', 'A'};
            var kmr = kmer.ToArray();
            var res = new List<string>();

            for (var i = 0; i < kmr.Length; i++)
            {                
                for (var k = 0; k < g.Length; k++)
                {
                    var cln = (char[])kmr.Clone();

                    cln[i] = g[k];

                    res.Add(string.Join("", cln));
                }
            }

            return res.Distinct();
        }

        public static IEnumerable<string> GetMissForIdx(string str, int idx)
        {
            var g = new[] { 'G', 'T', 'C', 'A' };
            var kmr = str.ToArray();
            var res = new List<string>();

            for (var k = 0; k < g.Length; k++)
            {
                var cln = (char[])kmr.Clone();

                cln[idx] = g[k];

                res.Add(string.Join("", cln));
            }

            return res.Distinct();        
        }

        public static IEnumerable<string> GenMiss(string kmer)
        {
            var res = new List<string>();

            for (var i = 0; i < kmer.Length; i++)
            {
                res.AddRange(GetMissForIdx(kmer, i));
            }


            return res.Distinct();
        }

        public static IEnumerable<string> GenMisses(string kmer, int m)
        {
            var res = new List<string>();

            IEnumerable<string> prev = new string[] { };

            for (var i = 0; i < m; i++)
            {
                //multiply error
                foreach(var p in prev)
                {
                    res.AddRange(GenMiss(p));
                }

                prev = GenMiss(kmer);

                res.AddRange(prev);
            }

            return res.Distinct();
        }


        public static void Go()
        {

            var gen = new System.IO.StreamReader("../../dataset_8_4.txt").ReadToEnd();//"ACGTTGCATGTCGCATGATGCATGAGAGCT";//new System.IO.StreamReader("../../dataset_4_4.txt").ReadToEnd();
            var k = 9;
            var m = 3;
            /*
            var gen = "ACGTTGCATGTCGCATGATGCATGAGAGCT";//new System.IO.StreamReader("../../dataset_4_4.txt").ReadToEnd();
            var k = 4;
            var m = 2;
             */
            
            var dict = new Dictionary<string, int>();

            for (int x = 0; x < gen.Length - k; x++)
            {
                var kmer = gen.Substring(x, k);

                //var kmrs = GenMismatchedKmers(kmer, m);
                var kmrs = GenMisses(kmer, m);

                foreach (var kmr in kmrs)
                {
                    if (dict.ContainsKey(kmr))
                        dict[kmr] += 1;
                    else
                        dict.Add(kmr, 1);
                }

            }

            var max = dict.Max((p) => p.Value);

            var res = dict.Where(p => p.Value == max).Select(p => p.Key);

            System.Diagnostics.Debug.WriteLine(string.Join(" ", res.Distinct()));        


        }
    }
}
