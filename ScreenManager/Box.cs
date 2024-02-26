using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class Box
    {
        internal static void Draw(int width, int height, int left, int top, bool erase)
        {
            if (erase)
            {
                Object.ClearArea(left, top, width, height);
            }
            else
            {
                Object.InsertAt(left, top, (string.Concat(GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top), width - 2)) + GetPart(BoxBorderPart.TopRight) + "\n")));

                for (int i = 1; i < height - 1; i++)
                {
                    Object.InsertAt(left, top + i, GetPart(BoxBorderPart.Left));
                    Object.InsertAt(left + width - 1, top + i, GetPart(BoxBorderPart.Right));
                }

                Object.InsertAt(left, top + height - 2, (string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), width - 2)) + GetPart(BoxBorderPart.BottomRight) + "\n")));
            }
        }

        internal enum BoxBorderPart
        {
            TopLeft,
            Top,
            TopRight,
            Left,
            Right,
            BottomLeft,
            Bottom,
            BottomRight
        }

        static public string GetPart(BoxBorderPart part)
        {
            return part switch
            {
                BoxBorderPart.TopLeft => "┌",
                BoxBorderPart.Top => "─",
                BoxBorderPart.TopRight => "┐",
                BoxBorderPart.Left => "│",
                BoxBorderPart.Right => "│",
                BoxBorderPart.BottomLeft => "└",
                BoxBorderPart.Bottom => "─",
                BoxBorderPart.BottomRight => "┘",
                _ => throw new InvalidOperationException("Unknown border part."),
            };
        }
    }
}
