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
    internal class TableContent : Object
    {
        private static int contentCount = 0;
        private readonly string[] tableContent;
        private readonly int startHeight;

        public static int GetContentCount () { return contentCount; }
        public int GetStartHeight () { return startHeight; }
        public string[] GetTableContent () { return tableContent; }

        public TableContent(int _left, int _top, int _width, int _height, Table table, string[] _tableContent, ConsoleColor _color = ConsoleColor.White) : base(_left, _top, _width, _height)
        {
            this.tableContent = _tableContent;
            startHeight = table.GetStartHeight;

            string text = "";
            for (int i = 0; i < tableContent.Length; i++)
            {
                text += Aligner.Align(this.tableContent[i], Alignment.Center, table.GetDifference, " ");
                text += GetPart(BoxBorderPart.Middle);
            }

            text = text.Remove(text.Length - 1, 1);
            InsertAt(this.GetLeft, this.GetTop + table.GetStartHeight + contentCount, (string.Concat(GetPart(BoxBorderPart.Left) + text + GetPart(BoxBorderPart.Right))), _color);
            contentCount++;
        }
    }
}
