using ScreenManager;

int cWidth = Console.WindowWidth, cHeight = Console.WindowHeight;

Box.Draw(cWidth - 2, cHeight - 2,0,0, false);
Box.Draw(cWidth - 4, cHeight - 4, 1, 1, false);
Box.Draw(20, 5, 0, 0, true);
Button.Draw(Console.WindowWidth - 20, 2, "Create User", 1);

Console.SetCursorPosition(cWidth - 1, cHeight - 3);