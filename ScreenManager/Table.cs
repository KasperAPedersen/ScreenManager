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
        private string[] tableTitles;

        public string[] GetTitles { get { return tableTitles; } }

        public Table(int _left, int _top, int _width, int _height, string[] _tableTitles, ConsoleColor _color = ConsoleColor.White) : base(_left, _top, _width, _height)
        {
            /////////////////////////////////////////////////////
            /// TODO: Correct the width & height for base object
            /// TODO: Create the contentlines
            ///´/////////////////////////////////////////////////

            this.tableTitles = _tableTitles;

            // Get the difference of all the titles and the total width
            int difference = this.GetWidth;
            foreach (string title in tableTitles)
            {
                difference -= title.Length;
            }
            
            // Divide the width difference with the number of titles
            difference /= this.tableTitles.Length;

            // Add the difference in padding to each table title and concat everything into a new string (tmp)
            string text = "";
            foreach (string title in tableTitles)
            {
                text += string.Concat(string.Concat(Enumerable.Repeat(" ", difference / 2)) + title + string.Concat(Enumerable.Repeat(" ", difference / 2)));
                if (tableTitles.Last() != title) text += "|";
            }

            // Building table header
            InsertAt(this.GetLeft, this.GetTop, (string.Concat(GetPart(BoxBorderPart.TopLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Top), text.Length)) + GetPart(BoxBorderPart.TopRight) + "\n")), _color);
            InsertAt(this.GetLeft, this.GetTop + 1, (string.Concat(GetPart(BoxBorderPart.Left) + text + GetPart(BoxBorderPart.Right))), _color);
            InsertAt(this.GetLeft, this.GetTop + 2, (string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), text.Length)) + GetPart(BoxBorderPart.BottomRight) + "\n")), _color);

            // Generate content lines here

            // Building table bottom
            InsertAt(this.GetLeft, this.GetTop + 3, (string.Concat(GetPart(BoxBorderPart.BottomLeft) + string.Concat(Enumerable.Repeat(GetPart(BoxBorderPart.Bottom), text.Length)) + GetPart(BoxBorderPart.BottomRight) + "\n")), _color);
        }
    }
}
