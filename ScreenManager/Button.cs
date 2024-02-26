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
        private int left = 0, top = 0, padding = 0;
        private string text = "";

        public int GetLeft { get { return left; } }
        public int GetTop { get { return top; } }
        public int GetPadding { get { return padding; } }
        public string GetText { get { return text; } }


        public Button(int _left, int _top, string _text, int _padding)
        {
            this.left = _left;
            this.top = _top;
            this.padding = _padding;
            this.text = _text;

            InsertAt(this.left, this.top, (string.Concat(GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top),this.text.Length + (this.padding * 2))) + GetPart(BoxBorderPart.TopRight) + "\n")));
            InsertAt(this.left, this.top + 1, (string.Concat(GetPart(BoxBorderPart.Left) + Aligner.Align(text,Alignment.Center, (this.text.Length + (this.padding * 2)), " ") + GetPart(BoxBorderPart.Right))));
            InsertAt(this.left, this.top + 2, (string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.text.Length + (this.padding * 2))) + GetPart(BoxBorderPart.BottomRight) + "\n")));

        }
    }
}
