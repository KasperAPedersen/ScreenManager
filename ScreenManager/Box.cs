using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class Box : Object
    {
        private int left = 0, top = 0, width = 0, height = 0;

        public int GetLeft { get { return left; } }
        public int GetTop { get { return top; } }
        public int GetWidth { get { return width; } }
        public int GetHeight { get { return height; } }

        public Box(int _width, int _height, int _left, int _top, bool _erase)
        {
            this.left = _left;
            this.top = _top;
            this.width = _width;
            this.height = _height;

            if (_erase)
            {
                ClearArea(this.left, this.top, this.width, this.height);
            }
            else
            {
                InsertAt(left, this.top, (string.Concat(GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top), this.width - 2)) + GetPart(BoxBorderPart.TopRight) + "\n")));

                for (int i = 1; i < this.height - 1; i++)
                {
                    InsertAt(left, this.top + i, GetPart(BoxBorderPart.Left));
                    InsertAt(left + this.width - 1, _top + i, GetPart(BoxBorderPart.Right));
                }

                InsertAt(left, this.top + this.height - 2, (string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.width - 2)) + GetPart(BoxBorderPart.BottomRight) + "\n")));
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
