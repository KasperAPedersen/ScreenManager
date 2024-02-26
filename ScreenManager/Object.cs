using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class Object
    {
        public static int objectCounter = 0;

        public Object()
        {
            objectCounter++;
        }
        
        public static void ClearArea(int _left, int _top, int _width, int _height)
        {
            Console.SetCursorPosition(_left, _top);

            for(int i = 0; i < _height; i++)
            {
                Console.Write(new string(' ', _width));
                Console.SetCursorPosition(_left, _top + i);
            }
        }

        public static void InsertAt(int _left, int _top, string _text)
        {
            Console.SetCursorPosition(_left, _top);
            Console.Write(_text);
        }
    }
}
