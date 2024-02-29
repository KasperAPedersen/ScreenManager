using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager
{
    internal class InputField
    {
        internal static string[] Run(int _inputFields, int _left, int _top, int cWidth, int cHeight)
        {
            List<string> newUserContent = [];
            newUserContent.Add((Table.GetIdCounter() + 1).ToString());

            for (int i = 0; i < _inputFields; i++)
            {
                Console.SetCursorPosition(_left, _top + (i * 3));
                string tmp = "";
                bool keepRunning = true;
                while (keepRunning)
                {
                    if (tmp.Length < 15)
                    {
                        ConsoleKeyInfo input = Console.ReadKey();
                        switch (input.Key)
                        {
                            case ConsoleKey.Enter:
                                keepRunning = false;
                                break;
                            case ConsoleKey.Backspace:
                                if (tmp.Length > 0)
                                {
                                    tmp = tmp.Remove(tmp.Length - 1, 1);
                                    Object.ClearArea(Console.CursorLeft, Console.CursorTop, 1, 1);
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                }
                                else
                                {
                                    Console.SetCursorPosition(_left, _top + (i * 3));
                                }
                                break;
                            default:
                                tmp += input.KeyChar;
                                break;
                        }
                    }
                    else
                    {
                        keepRunning = false;
                    }
                }
                _ = new TextField(_left, _top + (i * 3), tmp);
                newUserContent.Add(tmp);
            }

            newUserContent.Add("tmp");
            newUserContent.Add("tmp");

            string[] aUserContent = new string[9];
            for (int i = 0; i < newUserContent.Count; i++)
            {
                aUserContent[i] = newUserContent[i];
            }

            ScreenManager.Object.ClearArea(cWidth / 2 - 25, cHeight / 2 - 10, 50, 21);
            return aUserContent;
        }
    }
}
