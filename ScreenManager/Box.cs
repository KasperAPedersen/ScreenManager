using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class Box : Object
    {
        public Box(int _width, int _height, int _left, int _top, bool _erase, ConsoleColor _color = ConsoleColor.White) : base(_left, _top, _width, _height)
        {
            if (_erase)
            {
                ClearArea(this.GetLeft, this.GetTop, this.GetWidth, this.GetHeight);
            }
            else
            {
                InsertAt(this.GetLeft, this.GetTop, (string.Concat(GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top), this.GetWidth - 2)) + GetPart(BoxBorderPart.TopRight) + "\n")), _color);

                for (int i = 1; i < this.GetHeight - 1; i++)
                {
                    InsertAt(this.GetLeft, this.GetTop + i, GetPart(BoxBorderPart.Left), _color);
                    InsertAt(this.GetLeft + this.GetWidth - 1, this.GetTop + i, GetPart(BoxBorderPart.Right), _color);
                }

                InsertAt(this.GetLeft, this.GetTop + this.GetHeight - 2, (string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.GetWidth - 2)) + GetPart(BoxBorderPart.BottomRight) + "\n")), _color);
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

        static public string GetPart(BoxBorderPart _part)
        {
            return _part switch
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
