using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2
{
    public static class CyclopeptideSequencing
    {
        public class ArrayComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
            {
                if (x.Length != y.Length) return false;

                for (var i = 0; i < x.Length; i++)
                {
                    if (x[i] != y[i])
                        return false;
                }

                return true;
            }

            public int GetHashCode(int[] obj)
            {
                return obj.Sum();
            }
        }

        public static string[] Generate(string Spectrum)
        {
            var spectrum = Spectrum.Split(' ').Select(p => int.Parse(p)).ToArray();

            List<int[]> l = new List<int[]>();

            l.Add(new [] {0});

            var maxSpectrum = spectrum.Max();

            var res = new List<int[]>();

            while (l.Count() != 0)
            {
                l = Exapnd(l);

                var arr = l.ToArray();

                System.Console.Write(l.Count());
                System.Console.Write("\r\n-------\r\n");

                foreach (var peptide in arr)
                {
                    if (peptide.Sum() == maxSpectrum)
                    {
                        res.Add(peptide);

                        l.Remove(peptide);
                    }
                    else if (Inconsistent(peptide, spectrum))
                    {
                        l.Remove(peptide);
                    }
                }

                l = l.Distinct(new ArrayComparer()).ToList();
            }

            return res.Select(p => string.Join("-", p.Where(s => s != 0))).Distinct().ToArray();
        }

        public static bool Inconsistent(int [] Peptide, int [] Spectrum)
        {
            for (var i = 0; i < Peptide.Length; i++ )
            {
                //each and every subpep must exists in spectrum
                var s = Peptide.Take(i + 1).Sum();

                if (!Spectrum.Contains(s))
                    return true;
            }

            return false;
        }


        private static List<int []> Exapnd(List<int []> List)
        {
            List<int[]> res = new List<int[]>();

            foreach (var i in List)
            {
                foreach (var m in Masses)
                {
                    var r = new List<int>();
                    r.AddRange(i);
                    r.Add(m);

                    res.Add(r.ToArray());
                }
            }

            return res;
        }

        private static string CycloSpectrum(int [] Peptide)
        {
            return null;
        }

        private static int [] _masses;

        private static int [] Masses 
        {
            get
            {
                if (_masses == null){

                    var lines = global::w2.Properties.Resources.integer_mass_table.Split('\n');

                    var res = new List<int>();                   
                    
                    foreach (var line in lines){
                        res.Add(int.Parse(line.Split(' ')[1]));
                    }

                    _masses = res.OrderBy(p => p).ToArray();
                }

                return _masses;
            }
        }

    }
}
