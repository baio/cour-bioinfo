using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace w2
{
    class Program
    {
        //Allow copy text to clipboard
        [STAThread]
        static void Main(string[] args)
        {
            //1
            /*
            var res = RNA2AA.Translate("AUGGCCAUGGCGCCCAGAACUGAGAUCAAUAGUACCCGUAUUAACGGGUGA");
            System.Diagnostics.Debug.Assert(res == "MAMAPRTEINSTRING");
             */
            /*
            var data = Utils.Reader.ReadTest("Extra/protein_translate_data.txt");
            var res = RNA2AA.Translate(data[0]);
            System.Diagnostics.Debug.Assert(res == data[1]);
             */
            /*
            var data = Utils.Reader.ReadTest("Quiz/dataset_18_3.txt");
            var res = RNA2AA.Translate(data[0]);
            Utils.Clipboard.Copy(res);
             */
            
            //2
            /*
            var res = DNAPeptide.Encode("ATGGCCATGGCCCCCAGAACTGAGATCAATAGTACCCGTATTAACGGGTGA", "MA");
            System.Diagnostics.Debug.Assert(Utils.Reader.CompareArrays(res, new[] { "ATGGCC", "GGCCAT", "ATGGCC" }));
             */
            /*
            var data = Utils.Reader.ReadTest("Extra/peptide_encoding_data.txt");
            var res = DNAPeptide.Encode(data[0].Split('\n')[0], data[0].Split('\n')[1]);
            System.Diagnostics.Debug.Assert(Utils.Reader.CompareArrays(res, Utils.Reader.AsArray(data[1])));
             */
            /*
            var data = Reader.ReadTest("Quiz/dataset_18_6_1.txt");
            var res = DNAPeptide.Encode(Reader.Split(data[0])[0], Reader.Split(data[0])[1]);
            Utils.Clipboard.Copy(string.Join("\n", res));
             */

            //3

            /*
            var peptide = "NQEL";
            var res = TheoreticalSpectrum.Solve(peptide);
            System.Diagnostics.Debug.Assert(res == "0 113 114 128 129 227 242 242 257 355 356 370 371 484");
             */            
            /*
            var data = Utils.Reader.ReadTest("Extra/theoretical_spectrum_data.txt");
            var res = TheoreticalSpectrum.Solve(data[0]);
            System.Diagnostics.Debug.Assert(res == data[1]);
             */
            /*
            var data = Reader.ReadTest("Quiz/dataset_20_3.txt");
            var res = TheoreticalSpectrum.Solve(data[0]);
            Utils.Clipboard.Copy(res);
             */

            //4
            /*
            var spectrum = "0 113 128 186 241 299 314 427";
            var res = CyclopeptideSequencing.Generate(spectrum);
            System.Diagnostics.Debug.Assert(Reader.CompareArrays(res, Utils.Reader.AsArray("186-128-113 186-113-128 128-186-113 128-113-186 113-186-128 113-128-186", ' ')));         
             */

            
            var data = Utils.Reader.ReadTest("Extra/cycloseq_data.txt");
            var res = CyclopeptideSequencing.Generate(data[0]);
            System.Diagnostics.Debug.Assert(Reader.CompareArrays(res, Utils.Reader.AsArray(data[1], ' ')));


            System.Diagnostics.Debug.WriteLine("success");

        }
    }
}
