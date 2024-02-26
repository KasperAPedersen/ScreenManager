using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class TextField
    {
        public static void InsertAt(int left, int top, string text)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(text);
        }
    }
}
