using ScreenManager;

int cWidth = Console.WindowWidth, cHeight = Console.WindowHeight;

Box outerMarginBox = new(cWidth - 2, cHeight - 2, 0, 0, false);
Box innerMarginBox = new(cWidth - 4, cHeight - 4, 1, 1, false);
Button button = new(cWidth - 20, 2, "Create User", 1);
TextField innerMarginTitle = new(3, 2, "CRUDapp", ConsoleColor.Red);

//ScreenManager.Object.ClearArea(button.GetLeft, button.GetTop, button.GetWidth, button.GetHeight);
bool bKeepRunning = true, bToggleCreateUserButton = false;
while(bKeepRunning)
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.SetCursorPosition(cWidth - 1, cHeight - 3);

    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.F1:
            bKeepRunning = false;
            break;
        case ConsoleKey.C:
            if (bToggleCreateUserButton)
            {
                ScreenManager.Object.ClearArea(button.GetLeft, button.GetTop, button.GetWidth, button.GetHeight);
                button = new(cWidth - 20, 2, "Create User", 1);
            } else
            {
                ScreenManager.Object.ClearArea(button.GetLeft, button.GetTop, button.GetWidth, button.GetHeight);
                button = new(cWidth - 20, 2, "Create User", 1, ConsoleColor.Red);
            }
            bToggleCreateUserButton = !bToggleCreateUserButton;
            break;
        default:
            break;
    }
    Console.ForegroundColor = ConsoleColor.White;
}