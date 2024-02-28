using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ScreenManager.Box;
using static System.Net.Mime.MediaTypeNames;

namespace ScreenManager
{
    internal class Table : Object
    {
        private readonly int difference = 0;
        private readonly string[] tableTitles;
        private int startHeight = 0;

        public string[] GetTitles { get { return tableTitles; } }
        public int GetStartHeight { get { return startHeight; } }
        public int GetDifference { get { return difference; } }

        internal Table(int _left, int _top, int _width, int _height, string[] _tableTitles, ConsoleColor _color = ConsoleColor.White) : base(_left, _top, _width, _height)
        {
            this.tableTitles = _tableTitles;
            this.difference = this.GetWidth / this.tableTitles.Length - 1;

            // Build header
            CreateTableHeader(_color);

            // Build content
            CreateTableContent(_height);

            // Building bottom
            CreateTableBottom(_color);
        }

        internal void CreateTableContent(int _height, ConsoleColor _color = ConsoleColor.White)
        {
            for(int i = 0; i < _height; i++)
            {
                string text = "";

                for (int o = 0; i < this.tableTitles.Length; o++)
                {
                    text += Aligner.Align(" ", Alignment.Center, this.GetDifference, " ");
                    text += GetPart(BoxBorderPart.Middle);
                }

                text = text.Remove(text.Length - 1, 1);
                InsertAt(this.GetLeft, this.GetTop + 3 + i, (string.Concat(GetPart(BoxBorderPart.Left) + text + GetPart(BoxBorderPart.Right))), _color);
            }
        }

        internal void CreateTableHeader(ConsoleColor _color = ConsoleColor.White) 
        {
            // top border
            string topBorder = GetPart(BoxBorderPart.TopLeft);
            foreach (string title in tableTitles)
            {
                topBorder += string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.difference));
                if(tableTitles.Last() != title)topBorder += GetPart(BoxBorderPart.TopMiddle);
            }
            InsertAt(this.GetLeft, this.GetTop, string.Concat(topBorder + GetPart(BoxBorderPart.TopRight)), _color);

            // header content
            string headerContent = GetPart(BoxBorderPart.Middle);
            foreach (string title in tableTitles)
            {
                headerContent += Aligner.Align(title, Alignment.Center, this.difference, " ");
                headerContent += GetPart(BoxBorderPart.Middle);
            }

            InsertAt(this.GetLeft, this.GetTop + 1, headerContent, _color);

            // bottom border
            string bottomBorder = GetPart(BoxBorderPart.LeftMiddle);
            foreach (string title in tableTitles)
            {
                bottomBorder += string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.difference));
                if (tableTitles.Last() != title) bottomBorder += GetPart(BoxBorderPart.Cross);
            }
            InsertAt(this.GetLeft, this.GetTop + 2, string.Concat(bottomBorder + GetPart(BoxBorderPart.RightMiddle)), _color);
            startHeight = this.GetHeight + 3;
            this.SetHeight = this.GetHeight + 3;
        }

        internal void CreateTableBottom(ConsoleColor _color = ConsoleColor.White)
        {
            string bottomBorder = GetPart(BoxBorderPart.BottomLeft);
            foreach (string title in tableTitles)
            {
                bottomBorder += string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.difference));
                if (tableTitles.Last() != title) bottomBorder += GetPart(BoxBorderPart.BottomMiddle);
            }
            InsertAt(this.GetLeft, this.GetTop + this.GetHeight, string.Concat(bottomBorder + GetPart(BoxBorderPart.BottomRight)), _color);
            this.SetHeight = this.GetHeight + 1;
        }

        internal static void UpdateTableBottom(Table _table)
        {
            ClearArea(_table.GetLeft, _table.GetTop + _table.GetHeight, _table.GetWidth - _table.GetLeft, 3);
            _table.CreateTableBottom();
        }
    }
}
