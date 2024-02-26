using ScreenManager;

int cWidth = Console.WindowWidth, cHeight = Console.WindowHeight;

Box outerMarginBox = new(cWidth - 2, cHeight - 2, 0, 0, false);
Box innerMarginBox = new(cWidth - 4, cHeight - 4, 1, 1, false);
Button button = new(cWidth - 20, 2, "Create User", 1);

//Box.Draw(cWidth - 2, cHeight - 2,0,0, false);
//Box.Draw(cWidth - 4, cHeight - 4, 1, 1, false);
/*TextField.InsertAt(3, 2, "CRUDapp");
Button.Draw(cWidth - 20, 2, "Create User", 1);*/

Console.SetCursorPosition(cWidth - 1, cHeight - 3);