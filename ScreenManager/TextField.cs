using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class TextField : Object
    {
        private int left = 0, top = 0;
        private string text = "";

        public int GetLeft { get { return left; } }
        public int GetTop { get { return top; } }
        public string GetText { get { return text; } }

        public TextField(int _left, int _top, string _text)
        {
            this.left = _left;
            this.top = _top;
            this.text = _text;

            InsertAt(this.left, this.top, this.text);
        }
    }
}
