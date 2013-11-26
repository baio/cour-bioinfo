using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Utils
{
    public static class Clipboard
    {
        public static void Copy(string Text)
        {
            System.Windows.Forms.Clipboard.SetText(Text);
        }
    }
}
