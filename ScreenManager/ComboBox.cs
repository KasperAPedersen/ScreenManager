using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class ComboBox : Object
    {
        private int currentHeight = 0, active = 0;
        private string[] options = ["Mr.", "Mrs.", "Ms."];
        private string chosenOption = "Mr.";

        public string GetChosen { get { return chosenOption; } }

        public ComboBox(int _left, int _top, int _width, int _height) : base(_left, _top, _width, _height)
        {
            CreateComboBox();
        }

        internal void Run()
        {
            OpenComboBox();
            UpdateComboBox();
        }

        internal void CreateComboBox()
        {
            InsertAt(this.GetLeft, this.GetTop + currentHeight++, string.Concat(GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top), this.GetWidth - 5)) + GetPart(BoxBorderPart.TopRight) + GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top), 3)) + GetPart(BoxBorderPart.TopRight)));
            InsertAt(this.GetLeft, this.GetTop + currentHeight++, GetPart(BoxBorderPart.Left) + Aligner.Align("", Alignment.Center, this.GetWidth - 5, " ") + GetPart(BoxBorderPart.Right) + GetPart(BoxBorderPart.Left) + Aligner.Align(GetPart(BoxBorderPart.DownArrow), Alignment.Center, 3, " ") + GetPart(BoxBorderPart.Right));
            InsertAt(this.GetLeft, this.GetTop + currentHeight++, string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.GetWidth - 5)) + GetPart(BoxBorderPart.BottomRight)) + GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), 3)) + GetPart(BoxBorderPart.BottomRight));
        }

        internal void OpenComboBox()
        {
            InsertAt(this.GetLeft, this.GetTop + 1, GetPart(BoxBorderPart.Left) + Aligner.Align("", Alignment.Center, this.GetWidth - 5, " ") + GetPart(BoxBorderPart.Right) + GetPart(BoxBorderPart.Left) + Aligner.Align(GetPart(BoxBorderPart.UpArrow), Alignment.Center, 3, " ") + GetPart(BoxBorderPart.Right));
            Object.ClearArea(this.GetLeft, this.GetTop + currentHeight, this.GetWidth - 5, currentHeight + 3);
            InsertAt(this.GetLeft, this.GetTop + currentHeight++ -1, string.Concat(GetPart(BoxBorderPart.TopLeft)) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top), this.GetWidth - 5)) + GetPart(BoxBorderPart.TopRight));

            for (int i = 0; i < options.Length; i++)
            {
                InsertAt(this.GetLeft, this.GetTop + currentHeight++ - 1, GetPart(BoxBorderPart.Left) + Aligner.Align(options[i], Alignment.Center, this.GetWidth - 5, " ") + GetPart(BoxBorderPart.Right), i == this.active? ConsoleColor.Red : ConsoleColor.White);
                
            }
            InsertAt(this.GetLeft, this.GetTop + currentHeight++ - 1, string.Concat(GetPart(BoxBorderPart.BottomLeft)) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.GetWidth - 5)) + GetPart(BoxBorderPart.BottomRight));
        }

        internal void RemoveComboBox()
        {
            Object.ClearArea(this.GetLeft, this.GetTop + currentHeight + 1, this.GetWidth - 3, options.Length);
        }

        internal void UpdateComboBox()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                ConsoleKey input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.Enter:
                        chosenOption = options[active];
                        keepRunning = false;
                        break;
                    case ConsoleKey.UpArrow:
                        this.active = this.active <= 0 ? this.options.Length - 1: this.active - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        this.active = this.active >= options.Length - 1 ? 0 : this.active + 1;
                        break;
                    default:
                        break;
                }
                
                currentHeight = currentHeight - options.Length - 2;
                if (!keepRunning)
                {
                    RemoveComboBox();
                } else
                {
                    OpenComboBox();
                }
            }
        }

        internal enum BoxBorderPart
        {
            TopLeft,
            Top,
            TopRight,
            Left,
            Right,
            BottomLeft,
            Bottom,
            BottomRight,
            LeftMiddle,
            RightMiddle,
            Cross,
            Middle,
            TopMiddle,
            BottomMiddle,
            DownArrow,
            UpArrow
        }

        static public string GetPart(BoxBorderPart _part)
        {
            return _part switch
            {
                BoxBorderPart.TopLeft => "┌",
                BoxBorderPart.Top => "─",
                BoxBorderPart.TopRight => "┐",
                BoxBorderPart.Left => "│",
                BoxBorderPart.Right => "│",
                BoxBorderPart.BottomLeft => "└",
                BoxBorderPart.Bottom => "─",
                BoxBorderPart.BottomRight => "┘",
                BoxBorderPart.LeftMiddle => "├",
                BoxBorderPart.RightMiddle => "┤",
                BoxBorderPart.Cross => "┼",
                BoxBorderPart.Middle => "│",
                BoxBorderPart.TopMiddle => "┬",
                BoxBorderPart.BottomMiddle => "┴",
                BoxBorderPart.DownArrow => "\u2193",
                BoxBorderPart.UpArrow => "\u2191",
                _ => throw new InvalidOperationException("Unknown border part."),
            };
        }
    }
}
