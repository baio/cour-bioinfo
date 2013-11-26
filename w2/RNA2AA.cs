using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2
{
    /// <summary>
    /// Translate an RNA string into an amino acid string.
    /// </summary>
    public static class RNA2AA
    {
        public const int CODON_LEN = 3;

        /// <summary>
        /// Translate an RNA string into an amino acid string.
        /// </summary>
        /// <param name="RNA">An RNA string Pattern.</param>
        /// <param name="Reverse"> Read codon in reverse order </param>
        /// <returns>The translation of Pattern into an amino acid string Peptide.</returns>
        public static string Translate(string RNA, bool Reverse = false)
        {
            var rnaLen = RNA.Length;

            List<string> aminos = new List<string>();

            for (var i = 0; i <= rnaLen - CODON_LEN; i += CODON_LEN)
            {
                var codon = RNA.Substring(i, CODON_LEN);

                if (Reverse)
                    codon = string.Join("", codon.Reverse());

                var amino = Codon2Amino(codon);

                aminos.Add(amino);
            }

            return string.Join("", aminos);
        }

        private static string Codon2Amino(string Codon)
        {
            var lines = global::w2.Properties.Resources.RNA_codon_table.Split('\n');

            foreach (var line in lines)
            {
                var spts = line.Split(' ');
                var key = spts[0].Trim();
                var val = string.IsNullOrEmpty(spts[1]) ? "*" : spts[1].Trim();

                if (key == Codon)
                    return val;
            }

            throw new ArgumentOutOfRangeException(string.Format("Codon [{0}] not found", Codon));
        }

        /// <summary>
        /// Convert short represntation of amino acid in medium one
        /// </summary>
        /// <param name="Amino">FW*</param>
        /// <returns>PheTrpSTP</returns>
        public static string AminoShort2Med(string Amino)
        {
            var lines = global::w2.Properties.Resources.RNA_codon_ext.Split('\n');
            var pairs = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var spts = line.Split(' ');
                var key = spts[0].Trim();
                var val = spts.Length == 1 ? "*" : spts[1].Trim();
                if (!pairs.ContainsKey(key))
                    pairs.Add(key, val);
            }

            var res = new List<string>();

            foreach (var a in Amino)
            {
                res.Add(pairs[a.ToString()]);
            }

            return string.Join("", res);            
        }

    }
}
