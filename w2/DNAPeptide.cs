using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2
{
    public class DNAPeptide
    {
        /// <summary>
        /// Find substrings of a genome encoding a given amino acid sequence.
        /// </summary>
        /// <param name="DNA"> A DNA string </param>
        /// <param name="Peoptide">amino acid string Peptide</param>
        /// <returns> All substrings of Text encoding Peptide (if any such substrings exist).</returns>
        public static string[] Encode(string DNA, string Peptide)
        {
            //Get reverse DNA
            var DNA_RC = ReverseComplement.Reverse(DNA);

            //Get RNA
            //https://beta.stepic.org/Bioinformatics-Algorithms-2/How-Do-Bacteria-Make-Antibiotics-96/#step-2
            var RNA = DNA2RNA(DNA);
            var RNA_RC = DNA2RNA(DNA_RC);

            //RNA give us 6 variants of amino acids
            //https://beta.stepic.org/Bioinformatics-Algorithms-2/How-Do-Bacteria-Make-Antibiotics-96/#step-5
            //Collect rna - aa variants, for all possible cases
            var aas = new Dictionary<string, string>();
            for (var i = 0; i < RNA2AA.CODON_LEN; i++)
            {
                var rna = RNA.Substring(i);
                var aa = RNA2AA.Translate(rna);
                if (!aas.ContainsKey(rna))
                    aas.Add(rna, aa);

                rna = RNA_RC.Substring(i);
                aa = RNA2AA.Translate(rna);
                rna = "-" + rna;
                if (!aas.ContainsKey(rna))
                    aas.Add(rna, aa);
            }

            var res = new List<string>();

            foreach (var rna_aa in aas)
            {                
                var rna = rna_aa.Key;
                var aa = rna_aa.Value;
                bool isRevC = rna.StartsWith("-");
                if (isRevC)
                    rna = rna.Remove(0, 1);

                for (var i = 0; i <= aa.Length - Peptide.Length; i++)
                {
                    var aaSub = aa.Substring(i, Peptide.Length);

                    if (aaSub == Peptide)
                    {
                        var rnaSub = rna.Substring(i * RNA2AA.CODON_LEN, Peptide.Length * RNA2AA.CODON_LEN);

                        var dnaSub = RNA2DNA(rnaSub);

                        if (isRevC)
                            dnaSub = ReverseComplement.Reverse(dnaSub);

                        res.Add(dnaSub);
                    }
                }
            }

            return res.ToArray();
        }
        
        public static string DNA2RNA(string DNA)
        { 
            var res = new List<char>();
            foreach(var r in DNA)
            {
                if (r == 'T')
                    res.Add('U');
                else
                    res.Add(r);
            }

            return string.Join("", res);
        }

        public static string RNA2DNA(string RNA)
        {
            var res = new List<char>();
            foreach (var r in RNA)
            {
                if (r == 'U')
                    res.Add('T');
                else
                    res.Add(r);
            }

            return string.Join("", res);
        }

    }
}
