using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    public static class Q5
    {
        public static void Go()
        {
            var gen = new System.IO.StreamReader("../../dataset_7_6.txt").ReadToEnd();
                //"TAAAGACTGCCGAGAGGCCAACACGAGTGCTAGAACGAGGGGCGTAAACGCGGGTCCGAT";

            var res = new List<int>();

            var i = 0;

            res.Add(0);
            for (var k = 0; k < gen.Length; k++)
            {
                if (gen[k] == 'G')
                    i++;
                else if (gen[k] == 'C')
                    i--;

                res.Add(i);
            }

            var min = res.Min();

            for (i = 0; i < res.Count(); i++)
            {
                if (res.ElementAt(i) == min)
                {
                    System.Diagnostics.Debug.Write(i + " ");
                }
            }
        }
    }
}
