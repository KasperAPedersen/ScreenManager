using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ScreenManager.Box;

namespace ScreenManager
{
    internal class Button : Object
    {
        private readonly int padding = 0;
        private readonly string text = "";

        public int GetPadding { get { return padding; } }
        public string GetText { get { return text; } }

        public Button(int _left, int _top, string _text, int _padding, ConsoleColor _color = ConsoleColor.White) : base(_left, _top, (_text.Length + (_padding * 2) + 2), 3)
        {
            this.padding = _padding;
            this.text = _text;

            InsertAt(this.GetLeft, this.GetTop, (string.Concat(Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Top),this.text.Length + (this.padding * 2))) + Border(Get.TopRight) + "\n")), _color);
            InsertAt(this.GetLeft, this.GetTop + 1, (string.Concat(Border(Get.Left) + Aligner.Align(text,Alignment.Center, (this.text.Length + (this.padding * 2)), " ") + Border(Get.Right))), _color);
            InsertAt(this.GetLeft, this.GetTop + 2, (string.Concat(Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Bottom), this.text.Length + (this.padding * 2))) + Border(Get.BottomRight) + "\n")), _color);
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
