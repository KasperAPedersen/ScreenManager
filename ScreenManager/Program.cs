using ScreenManager;

int cWidth = Console.WindowWidth, cHeight = Console.WindowHeight;

Box outerMarginBox = new(cWidth - 3, cHeight - 2, 0, 0, false);
Box innerMarginBox = new(cWidth - 5, cHeight - 4, 1, 1, false);
Button button = new(cWidth - 21, 2, "Create User", 1);
TextField innerMarginTitle = new(3, 2, "CRUDapp", ConsoleColor.Red);
string[] titles = ["ID", "Fornavn", "Efternavn", "EmailAdr", "Mobil", "Addresse", "Titel", "Slet", "Edit"];
Table testTable = new(2, 5, cWidth - 6, 30, titles);
List<TableContent> content = [];

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
            //ScreenManager.Object.ClearArea(button.GetLeft, button.GetTop, button.GetWidth, button.GetHeight);
            //button = new(cWidth - 21, 2, "Create User", 1, !bToggleCreateUserButton ? ConsoleColor.Red : ConsoleColor.White);
            content.Add(new(testTable.GetLeft, testTable.GetTop, cWidth - 6, 0, testTable, ["abc", "def", "ghi", "jkl", "opq", "a", "a", "a", "a"], content.Count <= 0 ? ConsoleColor.Red : ConsoleColor.White));
            Table.UpdateTableBottom(testTable);
            bToggleCreateUserButton = !bToggleCreateUserButton;
            break;
        default:
            break;
    }
    Console.ForegroundColor = ConsoleColor.White;
}