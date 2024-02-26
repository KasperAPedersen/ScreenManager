using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class Object
    {
        
        public static void ClearArea(int left, int top, int width, int height)
        {
            Console.SetCursorPosition(left, top);

            for(int i = 0; i < height; i++)
            {
                Console.Write(new string(' ', width));
                Console.SetCursorPosition(left, top + i);
            }
        }

        public static void InsertAt(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
