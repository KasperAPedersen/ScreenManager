using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ScreenManager.Box;

namespace ScreenManager
{
    internal class Button
    {
        public static void Draw(int left, int top, string text, int padding)
        {
            Object.InsertAt(left, top, (string.Concat(GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top), text.Length + (padding * 2))) + GetPart(BoxBorderPart.TopRight) + "\n")));
            Object.InsertAt(left, top + 1, (string.Concat(GetPart(BoxBorderPart.Left) + Aligner.Align(text,Alignment.Center, (text.Length + (padding * 2)), " ") + GetPart(BoxBorderPart.Right))));
            Object.InsertAt(left, top + 2, (string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), text.Length + (padding * 2))) + GetPart(BoxBorderPart.BottomRight) + "\n")));

        }
    }
}
