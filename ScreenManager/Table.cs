using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ScreenManager.Box;

namespace ScreenManager
{
    internal class Table : Object
    {
        private readonly static int MaxHeight = 36;
        private static int id = 0;

        public static int GetIdCounter () { return id; }

        private int active, heightCounter = 0;
        private readonly int paddingDifference = 0;
        private readonly string[] headerTitle = ["ID", "Fornavn", "Efternavn", "EmailAdr", "Mobil", "Addresse", "Titel", "Slet", "Edit"];
        private readonly List<string[]> content = [];

        public int GetActive() { return active; }

        public Table(int _left, int _top, int _width, int _height, int _active = 0) : base(_left, _top, _width, _height > MaxHeight ? MaxHeight : _height)
        {
            active = _active;
            this.paddingDifference = this.GetWidth / this.headerTitle.Length - 1;

            CreateTableHeader();
            CreateTableContent();
            CreateTableBottom();
            this.SetHeight = heightCounter;
        }

        internal void CreateTableHeader(ConsoleColor _color = ConsoleColor.White)
        {
            // top border
            string topBorder = GetPart(BoxBorderPart.TopLeft);
            foreach (string title in headerTitle)
            {
                topBorder += string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.paddingDifference));
                if (headerTitle.Last() != title) topBorder += GetPart(BoxBorderPart.TopMiddle);
            }
            this.SetWidth = topBorder.Length + 1;
            InsertAt(this.GetLeft, this.GetTop + this.heightCounter++, string.Concat(topBorder + GetPart(BoxBorderPart.TopRight)), _color);

            // header content
            string headerContent = GetPart(BoxBorderPart.Middle);
            foreach (string title in headerTitle)
            {
                headerContent += Aligner.Align(title, Alignment.Center, this.paddingDifference, " ");
                headerContent += GetPart(BoxBorderPart.Middle);
            }

            InsertAt(this.GetLeft, this.GetTop + this.heightCounter++, headerContent, _color);

            // bottom border
            string bottomBorder = GetPart(BoxBorderPart.LeftMiddle);
            foreach (string title in headerTitle)
            {
                bottomBorder += string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.paddingDifference));
                if (headerTitle.Last() != title) bottomBorder += GetPart(BoxBorderPart.Cross);
            }
            InsertAt(this.GetLeft, this.GetTop + this.heightCounter++, string.Concat(bottomBorder + GetPart(BoxBorderPart.RightMiddle)), _color);
        }

        internal void CreateTableContent(ConsoleColor _color = ConsoleColor.White)
        {
            if(content != null)
            {
                for (int i = 0; i < content.Count; i++)
                {
                    string text = "";
                    for (int o = 0; o < 9; o++)
                    {
                        text += Aligner.Align(content[i][o], Alignment.Center, this.paddingDifference, " ");
                        text += GetPart(BoxBorderPart.Middle);
                    }
                    text = text.Remove(text.Length - 1, 1);
                    InsertAt(this.GetLeft, this.GetTop + this.heightCounter++, (string.Concat(GetPart(BoxBorderPart.Left) + text + GetPart(BoxBorderPart.Right))), this.active == i ? ConsoleColor.Red : _color);

                }
            }
        }

        internal void CreateTableBottom(ConsoleColor _color = ConsoleColor.White)
        {
            string bottomBorder = GetPart(BoxBorderPart.BottomLeft);
            foreach (string title in this.headerTitle)
            {
                bottomBorder += string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.paddingDifference));
                if (this.headerTitle.Last() != title) bottomBorder += GetPart(BoxBorderPart.BottomMiddle);
            }
            InsertAt(this.GetLeft, this.GetTop + this.heightCounter++, string.Concat(bottomBorder + GetPart(BoxBorderPart.BottomRight)), _color);
        }

        internal void UpdateTable(int _active, string[]? contentLine = null)
        {

            Object.ClearArea(this.GetLeft, this.GetTop, this.GetWidth, this.GetHeight);

            if (contentLine != null && (this.GetHeight + 1) < MaxHeight)
            {
                id++;
                content.Add(contentLine);
            }
            if (_active != this.active) this.active = _active > content.Count - 1 ? 0 : (_active < 0 ? content.Count - 1 : _active);

            this.heightCounter = 0;

            CreateTableHeader();
            CreateTableContent();
            CreateTableBottom();

            this.SetHeight = heightCounter;
            
        }

        internal void RemoveTableRow(int _active)
        {
            if(content != null && content.Count > 0)
            {
                content.RemoveAt(_active);
                if ((_active - 1) > 0) this.active = --_active;
                UpdateTable(this.active);
                id--;
            }
        }
    }
}
