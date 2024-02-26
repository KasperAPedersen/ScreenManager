using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ScreenManager.Box;
using static System.Net.Mime.MediaTypeNames;

namespace ScreenManager
{
    internal class InputField : Object
    {
        private int left = 0, top = 0;

        public int GetLeft { get { return left; } }
        public int GetTop { get { return top; } }

        public InputField(int _left, int _top)
        {
            this.left = _left;
            this.top = _top;

        }
    }
}
