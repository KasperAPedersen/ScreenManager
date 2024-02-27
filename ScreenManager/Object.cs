﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class Object
    {
        public static int objectCounter = 0;
        private readonly int left = 0, top = 0, width = 0, height = 0;

        public int GetLeft { get { return left; } }
        public int GetTop { get { return top; } }
        public int GetWidth { get { return width; } }
        public int GetHeight { get { return height; } }

        public Object(int _left, int _top, int _width, int _height)
        {
            objectCounter++;
            left = _left;
            top = _top;
            width = _width;
            height = _height;
        }
        
        public static void ClearArea(int _left, int _top, int _width, int _height)
        {
            for(int i = 0; i < _height; i++)
            {
                InsertAt(_left, _top + i, string.Concat(Enumerable.Repeat(" ", _width)), ConsoleColor.White);
            }
        }

        public static void InsertAt(int _left, int _top, string _text, ConsoleColor _color = ConsoleColor.White)
        {
            Console.SetCursorPosition(_left, _top);
            Console.ForegroundColor = _color;
            Console.Write(_text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
