using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class Aligner
    {
        public static string Align(string text, Alignment? alignment, int maxWidth, string pattern)
        {
            if (text == null) return "";
            if (text.Length > maxWidth) return text;

            int diff = maxWidth - text.Length, remainder = (maxWidth - text.Length) % 2;
            string right, left;

            switch (alignment)
            {
                case Alignment.Right:
                    left = string.Concat(Enumerable.Repeat(pattern, (diff / pattern.Length)));

                    if (remainder != 0) left += string.Concat(pattern[0]);

                    return left + text;
                case Alignment.Center:
                    diff /= 2;
                    right = left = string.Concat(Enumerable.Repeat(pattern, (diff / pattern.Length)));

                    if (remainder != 0) right += string.Concat(pattern[0]);

                    return left + text + right;
                default:
                    right = string.Concat(Enumerable.Repeat(pattern, diff / pattern.Length));
                    if (remainder != 0) right += string.Concat(pattern[0]);

                    return text + right;
            }
        }
    }

    public enum Alignment
    {
        Left = 0,
        Center = 1,
        Right = 2
    }
}
