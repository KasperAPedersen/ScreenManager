using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class TextField : Object
    {
        private readonly string text = "";

        public string GetText { get { return text; } }

        public TextField(int _left, int _top, string _text, ConsoleColor _color = ConsoleColor.White) : base(_left, _top, _text.Length, 1)
        {
            this.text = _text;
            InsertAt(this.GetLeft, this.GetTop, this.text, _color);
        }
    }
}
