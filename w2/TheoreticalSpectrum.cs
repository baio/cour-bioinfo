using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2
{
    public static class TheoreticalSpectrum
    {
        
        /// <summary>
        /// The theoretical spectrum of a cyclic peptide Peptide, denoted Cyclospectrum(Peptide), 
        /// is the collection of all of the masses of its subpeptides, 
        /// in addition to the mass 0 and the mass of the entire peptide. 
        /// Note that the theoretical spectrum may contain duplicate elements.
        /// https://beta.stepic.org/Bioinformatics-Algorithms-2/Sequencing-Antibiotics-by-Shattering-Them-into-Pieces-98/#step-3
        /// </summary>
        /// <param name="Peptide">An amino acid string Peptide.</param>
        /// <returns>Cyclospectrum(Peptide)</returns>
        public static string Solve(string Peptide)
        {
            //get all subpeptides
                            
            var subpeps = Split2Subpeps(Peptide);

            //subpeps = subpeps.OrderBy(p => p).ToArray;

            var masses = GetMasses(subpeps);

            return string.Join(" ", masses.OrderBy(p => p.Value).Select(p => p.Value));
        }

        private static string[] Split2Subpeps(string Peptide)
        {
            var res = new List<string>();

            res.Add("-");

            for(var i = 1; i < Peptide.Length; i++)
            {
                var s = Split2Subpeps(Peptide, i);

                res.AddRange(s);
            }

            res.Add(Peptide);

            return res.ToArray();
        }

        private static string[] Split2Subpeps(string Peptide, int SubPepLen)
        {
            var res = new List<string>();

            var p = Peptide + Peptide; //Peptide[Peptide.Length - 1] + Peptide + Peptide[0];

            for (var i = 0; i < Peptide.Length ; i++)
            {
                var s = p.Substring(i, SubPepLen);

                res.Add(s);
            }

            return res.ToArray();
        }

        private static List<KeyValuePair<string, int>> GetMasses(string[] SubPeps)
        {
            var mt = GetMassTable();

            var res = new List<KeyValuePair<string, int>>();

            foreach (var s in SubPeps)
            {
                var mas = 0;

                foreach (var c in s)
                {
                    mas += mt[c.ToString()];
                }

                res.Add(new KeyValuePair<string, int>(s, mas));
            }

            return res;
        }

        private static Dictionary<string, int> GetMassTable()
        {
            var res = new Dictionary<string, int>();
            res.Add("-", 0);
            var lines = global::w2.Properties.Resources.integer_mass_table.Split('\n');

            foreach (var line in lines)
            {
                var spts = line.Split(' ');
                var key = spts[0].Trim(new [] {'\n', '\r', ' '});
                var val = spts[1].Trim(new [] {'\n', '\r', ' '});
                res.Add(key, int.Parse(val));
            }

            return res;
        }

    }
}
