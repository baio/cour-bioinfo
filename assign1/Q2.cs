using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    public static class Q2
    {
        public static void Go()
        {
            //A and T are complements of each other, as are G and C.

            var str = new System.IO.StreamReader("../../dataset_3_2.txt").ReadToEnd(); //"AAAACCCGGT";
            //var str = new System.IO.StreamReader("../../q2_extra.txt").ReadToEnd(); //"AAAACCCGGT";
            //var str = "AAAACCCGGT";
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

            System.Diagnostics.Debug.WriteLine(string.Join("", l));
        }
    }
}
