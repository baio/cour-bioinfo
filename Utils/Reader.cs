using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Reader
    {
        public static string[] ReadTest(string FilePath)
        {
            var line = System.IO.File.ReadAllText("../../" + FilePath);

            var spts = line.Split(new [] {"Input"}, StringSplitOptions.RemoveEmptyEntries);

            spts = spts[0].Split(new[] { "Output" }, StringSplitOptions.RemoveEmptyEntries);

            spts = spts.Select(p => p.Trim(new[] { '\r', '\n', ' ' })).ToArray();

            return spts;

        }

        public static string[] Split(string Str)
        {
            return Str.Split('\n').Select(p => p.Trim(new[] { '\r', '\n', ' ' })).ToArray();
        }

        public static string[] AsArray(string str, char separ = '\n')
        {
            return str.Split(separ).Select(p => p.Trim(new[] { '\r', '\n', ' ' })).ToArray();
        }

        public static bool CompareArrays(string[] str1, string[] str2)
        {
            var r1 = str1.OrderBy(p => p).ToArray();
            var r2 = str2.OrderBy(p => p).ToArray();

            if (r1.Length != r2.Length)
                return false;

            for (var i = 0; i < r1.Length; i++)
            {
                if (r1[i] != r2[i]) return false;
            }

            return true;
        }

    }
}
