using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    public static class Q8
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

        public static string GetInverse(string str)
        {
            var rev = str.Reverse().ToArray();

            //extract sequence ACGT
            var l = new List<char>();
            for (var i = 0; i < rev.Length; i++)
            {
                var c = ' ';
                switch (rev[i])
                {
                    case 'A':
                        c = 'T';
                        break;
                    case 'T':
                        c = 'A';
                        break;
                    case 'G':
                        c = 'C';
                        break;
                    case 'C':
                        c = 'G';
                        break;
                }
                l.Add(c);
            }

            return string.Join("", l);        
        }

        public static Dictionary<string, int> CountD(string text, string pattern, int d)
        {
            var dict = new Dictionary<string, int>();

            var kmrs = GenMisses(pattern, d);
            //var kmrs_inv = GenMisses(GetInverse(pattern), d);

            //kmrs = kmrs.Union(kmrs_inv);

            foreach (var kmr in kmrs)
            {
                var k = kmr.Length;

                for (int i = 0; i < text.Length - k; i++)
                {
                    var kmer = text.Substring(i, k);

                    if (kmer == kmr)
                    {
                        if (dict.ContainsKey(kmr))
                            dict[kmr] += 1;
                        else
                            dict.Add(kmr, 1);
                    }
                }
            }

            return dict;
            
        }

        public static Dictionary<string, int> GetPatterns(string gen, int k, int m)
        {

            var dict = new Dictionary<string, int>();

            for (int x = 0; x < gen.Length - k; x++)
            {
                var pattern = gen.Substring(x, k);
                var inv_pattern = GetInverse(pattern);

                foreach (var kmr in CountD(gen, pattern, m))
                {
                    if (dict.ContainsKey(kmr.Key))
                        dict[kmr.Key] += kmr.Value;
                    else
                        dict.Add(kmr.Key, kmr.Value);                
                }
                
                foreach (var kmr in CountD(gen, inv_pattern, m))
                {
                    if (dict.ContainsKey(kmr.Key))
                        dict[kmr.Key] += kmr.Value;
                    else
                        dict.Add(kmr.Key, kmr.Value);
                }
                

                /*
                var kmer = gen.Substring(x, k);
                var kmer_inv = GetInverse(kmer);

                var kmrs = GenMisses(kmer, m);
                var kmrs_inv = GenMisses(kmer_inv, m);

                foreach (var kmr in kmrs)
                {
                    if (dict.ContainsKey(kmr))
                        dict[kmr] += 1;
                    else
                        dict.Add(kmr, 1);
                }
                foreach (var kmr in kmrs_inv)
                {
                    if (dict.ContainsKey(kmr))
                        dict[kmr] += 1;
                    else
                        dict.Add(kmr, 1);
                }
                 */

            }

            return dict;
        
        }

        public static void Go()
        {

            
            /*
            var gen = new System.IO.StreamReader("../../dataset_8_5.txt").ReadToEnd();//"ACGTTGCATGTCGCATGATGCATGAGAGCT";//new System.IO.StreamReader("../../dataset_4_4.txt").ReadToEnd();
            var k = 9;
            var m = 3;
             */
            
            

            
            var gen = "ACGTTGCATGTCGCATGATGCATGAGAGCT";//new System.IO.StreamReader("../../dataset_4_4.txt").ReadToEnd();
            var k = 4;
            var m = 1;
            
            

            /*
            var inv = GetInverse(gen);

            gen = gen + inv;
             */

            var dict = GetPatterns(gen, k, m);
            /*
            foreach (var kvp in GetPatterns(inv, k, m))
            {
                if (dict.ContainsKey(kvp.Key))
                    dict[kvp.Key] += kvp.Value;
                else
                    dict.Add(kvp.Key, kvp.Value);                
            }
             */
            /*
                        
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
             */

            var max = dict.Max((p) => p.Value);

            var res = dict.Where(p => p.Value == max).Select(p => p.Key);

            System.Diagnostics.Debug.WriteLine(string.Join(" ", res.Distinct()));        


        }
    }
}
