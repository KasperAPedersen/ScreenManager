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
                InsertAt(this.GetLeft, this.GetTop, (string.Concat(Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Top), this.GetWidth - 2)) + Border(Get.TopRight) + "\n")), _color);

                for (int i = 1; i < this.GetHeight - 1; i++)
                {
                    InsertAt(this.GetLeft, this.GetTop + i, Border(Get.Left), _color);
                    InsertAt(this.GetLeft + this.GetWidth - 1, this.GetTop + i, Border(Get.Right), _color);
                }

                InsertAt(this.GetLeft, this.GetTop + this.GetHeight - 2, (string.Concat(Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Bottom), this.GetWidth - 2)) + Border(Get.BottomRight) + "\n")), _color);
            }
        }

        internal override string Border(Get _part)
        {
            return _part switch
            {
                Get.TopLeft => "┌",
                Get.Top => "─",
                Get.TopRight => "┐",
                Get.Left => "│",
                Get.Right => "│",
                Get.BottomLeft => "└",
                Get.Bottom => "─",
                Get.BottomRight => "┘",
                _ => throw new InvalidOperationException("Unknown border part."),
            };
        }
    }
}
