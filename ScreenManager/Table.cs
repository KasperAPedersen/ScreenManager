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
        private string[] tableTitles, tableContents;

        public Table(int _left, int _top, int _width, int _height, string[] _tableTitles, string[] _tableContents) : base(_left, _top, _width, _height)
        {
            this.tableTitles = _tableTitles;
            this.tableContents = _tableContents;

            // Get the difference of all the titles and the total width
            int difference = this.GetWidth;
            foreach (string title in tableTitles)
            {
                difference -= title.Length;
            }
            
            // Divide the width difference with the number of titles
            difference /= this.tableTitles.Length;


            // Add the difference in padding to each table title and concat everything into a new string (tmp)
            string tmp = "";
            foreach (string title in tableTitles)
            {
                tmp += string.Concat(string.Concat(Enumerable.Repeat(" ", difference / 2)) + title + string.Concat(Enumerable.Repeat(" ", difference / 2)));
            }



            /*
            InsertAt(this.GetLeft, this.GetTop, (string.Concat(GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top), this.text.Length + (this.padding * 2))) + GetPart(BoxBorderPart.TopRight) + "\n")), _color);
            InsertAt(this.GetLeft, this.GetTop + 1, (string.Concat(GetPart(BoxBorderPart.Left) + Aligner.Align(text, Alignment.Center, (this.text.Length + (this.padding * 2)), " ") + GetPart(BoxBorderPart.Right))), _color);
            InsertAt(this.GetLeft, this.GetTop + 2, (string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), this.text.Length + (this.padding * 2))) + GetPart(BoxBorderPart.BottomRight) + "\n")), _color);
            */
        }
    }
}
