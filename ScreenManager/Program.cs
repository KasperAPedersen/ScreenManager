using ScreenManager;

Console.OutputEncoding = System.Text.Encoding.UTF8;

int cWidth = Console.WindowWidth, cHeight = Console.WindowHeight;

_ = new Box(cWidth - 3, cHeight - 2, 0, 0, false);
_ = new Box(cWidth - 5, cHeight - 4, 1, 1, false);
_ = new Button(cWidth - 21, 2, "Create User", 1);
_ = new TextField(3, 2, "CRUDapp", ConsoleColor.Red);
Table tt = new(2, 5, cWidth - 6, 20);

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
            Console.CursorVisible= true;
            _ = new Button(cWidth - 21, 2, "Create User", 1, ConsoleColor.Red);

            string[] labels = ["Fornavn", "Efternavn", "EmailAdr", "Mobil", "Adresse", "Titel"];
            ScreenManager.Object.ClearArea(cWidth / 2 - 25, cHeight / 2 - 10, 50, 21);
            Box tt1 = new(50, 21, cWidth / 2 - 25, cHeight / 2 - 10, false);
            for(int i = 0; i < 5; i++)
            {
                _ = new Box(25, 4, tt1.GetLeft + tt1.GetWidth - 26, cHeight / 2 - 9 + (i*3), false);
                _ = new TextField(tt1.GetLeft + 1, cHeight / 2 - 8 + (i*3), Aligner.Align(labels[i], Alignment.Center, tt1.GetWidth - 27, " "));
            }

            _ = new TextField(tt1.GetLeft + 1, cHeight / 2 - 8 + 15, Aligner.Align("Titel", Alignment.Center, tt1.GetWidth - 27, " "));
            ComboBox cb = new(tt1.GetLeft + tt1.GetWidth - 26, cHeight / 2 + 6, 23, 4);
            InputField.Run(6, tt1.GetLeft + tt1.GetWidth - 24, cHeight / 2 - 8);
            Console.CursorVisible = false;
            cb.Run();
            
            _ = new TextField(tt1.GetLeft + tt1.GetWidth - 25, cHeight / 2 + 6, Aligner.Align(cb.GetChosen, Alignment.Center, tt1.GetWidth - 32, " "));

            string[] inputFieldResult = InputField.Get(cWidth, cHeight, cb.GetChosen);
            

            tt.UpdateTable(tt.GetActive(), inputFieldResult);

            _ = new Button(cWidth - 21, 2, "Create User", 1);
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
        default:
            break;
    }
    Console.ForegroundColor = ConsoleColor.White;
}