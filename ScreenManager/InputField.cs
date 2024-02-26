using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ScreenManager.Box;
using static System.Net.Mime.MediaTypeNames;

namespace ScreenManager
{
    internal class InputField
    {
        public static void InsertAt(int left, int top, int padding)
        {

            Object.InsertAt(left, top, (string.Concat(GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top), 20)) + GetPart(BoxBorderPart.TopRight) + "\n")));
            Object.InsertAt(left, top + 1, (string.Concat(GetPart(BoxBorderPart.Left) + string.Concat(Enumerable.Repeat(" ", 20)) + GetPart(BoxBorderPart.Right))));
            Object.InsertAt(left, top + 2, (string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), 20)) + GetPart(BoxBorderPart.BottomRight) + "\n")));

            Console.SetCursorPosition(left + padding + 1, top + 1);
            string tmp = Console.ReadLine();
            
            if (tmp.Length > 20) tmp = "Invalid";
            Console.SetCursorPosition(left, top + 1);
            Object.InsertAt(left, top + 1, (string.Concat(GetPart(BoxBorderPart.Left) + Aligner.Align(tmp, Alignment.Center, 20, " ") + GetPart(BoxBorderPart.Right))));

        }
    }
}
