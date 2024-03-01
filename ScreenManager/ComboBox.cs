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
            InsertAt(this.GetLeft, this.GetTop + currentHeight++, string.Concat(Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Top), this.GetWidth - 5)) + Border(Get.TopRight) + Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Top), 3)) + Border(Get.TopRight)));
            InsertAt(this.GetLeft, this.GetTop + currentHeight++, Border(Get.Left) + Aligner.Align("", Alignment.Center, this.GetWidth - 5, " ") + Border(Get.Right) + Border(Get.Left) + Aligner.Align(Border(Get.DownArrow), Alignment.Center, 3, " ") + Border(Get.Right));
            InsertAt(this.GetLeft, this.GetTop + currentHeight++, string.Concat(Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Bottom), this.GetWidth - 5)) + Border(Get.BottomRight)) + Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Bottom), 3)) + Border(Get.BottomRight));
        }

        internal void OpenComboBox()
        {
            InsertAt(this.GetLeft, this.GetTop + 1, Border(Get.Left) + Aligner.Align("", Alignment.Center, this.GetWidth - 5, " ") + Border(Get.Right) + Border(Get.Left) + Aligner.Align(Border(Get.UpArrow), Alignment.Center, 3, " ") + Border(Get.Right));
            Object.ClearArea(this.GetLeft, this.GetTop + currentHeight, this.GetWidth - 5, currentHeight + 3);
            InsertAt(this.GetLeft, this.GetTop + currentHeight++ -1, string.Concat(Border(Get.TopLeft)) + string.Concat(Enumerable.Repeat(Border(Get.Top), this.GetWidth - 5)) + Border(Get.TopRight));

            for (int i = 0; i < options.Length; i++)
            {
                InsertAt(this.GetLeft, this.GetTop + currentHeight++ - 1, Border(Get.Left) + Aligner.Align(options[i], Alignment.Center, this.GetWidth - 5, " ") + Border(Get.Right), i == this.active? ConsoleColor.Red : ConsoleColor.White);
                
            }
            InsertAt(this.GetLeft, this.GetTop + currentHeight++ - 1, string.Concat(Border(Get.BottomLeft)) + string.Concat(Enumerable.Repeat(Border(Get.Bottom), this.GetWidth - 5)) + Border(Get.BottomRight));
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

        internal override string Border(Get _part)
        {
            return _part switch
            {
                Get.TopLeft => "┌",
                Get.Top => "─",
                Get.TopRight => "┐",
                Get.Left => "│",
                Get.Right => "│",
                Get.BottomLeft => "└",
                Get.Bottom => "─",
                Get.BottomRight => "┘",
                Get.LeftMiddle => "├",
                Get.RightMiddle => "┤",
                Get.DownArrow => "\u2193",
                Get.UpArrow => "\u2191",
                _ => throw new InvalidOperationException("Unknown border part."),
            };
        }
    }
}
