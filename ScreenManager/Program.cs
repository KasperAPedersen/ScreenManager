using ScreenManager;

int cWidth = Console.WindowWidth, cHeight = Console.WindowHeight;

Box outerMarginBox = new(cWidth - 3, cHeight - 2, 0, 0, false);
Box innerMarginBox = new(cWidth - 5, cHeight - 4, 1, 1, false);
Button button = new(cWidth - 21, 2, "Create User", 1);
TextField innerMarginTitle = new(3, 2, "CRUDapp", ConsoleColor.Red);
//Table testTable = new(2, 5, cWidth - 6, 30, titles);
Table tt = new(2, 5, cWidth - 6, 20);

//ScreenManager.Object.ClearArea(button.GetLeft, button.GetTop, button.GetWidth, button.GetHeight);
bool bKeepRunning = true, bToggleCreateUserButton = false;
while(bKeepRunning)
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.SetCursorPosition(cWidth - 1, cHeight - 3);
    Console.CursorVisible = false;
    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.F1:
            bKeepRunning = false;
            break;
        case ConsoleKey.C:
            Box tt1 = new(50, 20, cWidth / 2 - 25, cHeight / 2 - 10, false);
            new Box(25, 4, tt1.GetLeft + tt1.GetWidth - 26, cHeight / 2 - 9, false);
            new Box(25, 4, tt1.GetLeft + tt1.GetWidth - 26, cHeight / 2 - 8, false);
            

            bToggleCreateUserButton = !bToggleCreateUserButton;
            break;
        case ConsoleKey.DownArrow:
            tt.UpdateTable(tt.GetActive() + 1);
            break;
        case ConsoleKey.UpArrow:
            tt.UpdateTable(tt.GetActive() - 1);
            break;
        case ConsoleKey.Delete:
            tt.RemoveTableRow(tt.GetActive());
            break;
        case ConsoleKey.I:
            tt.UpdateTable(tt.GetActive(), ["a", "aa", "aaa", "aaaa", "aaaaa", "aaaa", "aaa", "aa", "a"]);
            break;
        default:
            break;
    }
    Console.ForegroundColor = ConsoleColor.White;
}