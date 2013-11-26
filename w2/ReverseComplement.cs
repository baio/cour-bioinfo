using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2
{
    public static class ReverseComplement
    {
        public static string Reverse(string DNA, bool ReverseDirection = true)
        {
            var rev = DNA;//.Reverse().ToArray();

            if (ReverseDirection)
                rev = string.Join("", rev.Reverse());

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
    }
}
