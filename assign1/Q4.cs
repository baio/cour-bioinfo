using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    public static class Q4
    {
        public static void Go()
        {
            var gen = new System.IO.StreamReader("../../dataset_4_4.txt").ReadToEnd();
            var pat = "11 497 19".Split(' ');
            var k = int.Parse(pat[0]);
            var l = int.Parse(pat[1]);
            var t = int.Parse(pat[2]);

            var res = new List<string>();
            
            for (var y = 0; y < gen.Length - l; y++)
            {
                var wd = gen.Substring(y, l);

                var dict = new Dictionary<string, int>();

                for (int x = 0; x < wd.Length - k; x++)
                {
                    var kmer = wd.Substring(x, k);
                    if (dict.ContainsKey(kmer))
                        dict[kmer] += 1;
                    else
                        dict.Add(kmer, 1);
                }

                var max = dict.Max((p) => p.Value);

                if (max >= t)
                {
                    res.AddRange(dict.Where(p => p.Value == max).Select(p => p.Key));
                }
            }

            System.Diagnostics.Debug.WriteLine(string.Join(" ", res.Distinct()));        

            //System.Diagnostics.Debug.WriteLine(string.Join(" ", lt));

        }
    }
}
