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

            InsertAt(this.GetLeft, this.GetTop, (string.Concat(GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top),this.text.Length + (this.padding * 2))) + GetPart(BoxBorderPart.TopRight) + "\n")), _color);
            InsertAt(this.GetLeft, this.GetTop + 1, (string.Concat(GetPart(BoxBorderPart.Left) + Aligner.Align(text,Alignment.Center, (this.text.Length + (this.padding * 2)), " ") + GetPart(BoxBorderPart.Right))), _color);
            InsertAt(this.GetLeft, this.GetTop + 2, (string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.text.Length + (this.padding * 2))) + GetPart(BoxBorderPart.BottomRight) + "\n")), _color);
        }
    }
}
