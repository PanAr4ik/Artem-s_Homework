namespace ex3
{
    internal class Program
    {
        static char[,] board = { { ' ', ' ', ' ', }, { ' ', ' ', ' ', }, { ' ', ' ', ' ', } };
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            short winX = 0;
            short winY = 0;
            short draw = 0;
            while (true)
            {
                while (true)
                {
                    PrintBoard();
                    PlayerMove();

                    if (CheckWin())
                    {
                        PrintBoard();
                        Console.WriteLine($"Игрок {currentPlayer} победил!");
                        if (currentPlayer == 'X')
                            winX++;
                        else winY++;
                        
                        Console.WriteLine("Если вы хотите остановить игру нажмите дважды кнопку Е ");
                        var Akey = Console.ReadKey(true).Key;
                        if (Akey == ConsoleKey.E)
                            break;


                    }
                    if (CheckDraw())
                    {
                        PrintBoard();
                        Console.WriteLine("Ничья");
                        draw++;
                        Console.WriteLine("Если вы хотите остановить игру нажмите дважды кнопку Е ");
                        var Akey = Console.ReadKey(true).Key;
                        if (Akey == ConsoleKey.E)
                            break;
                    }

                    SwitchPlaye();
                    


                }
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.E)
                    break;                
            }
            Console.Write($"X побелдили {winX} раз " +
                    $"\nO победили {winY} раз" +
                    $"\nВ ничью сыграли {draw} раз");
        }

        static void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            { for (int j = 0; j < 3; j++)
                { Console.Write(board[i, j]);
                    if (j < 2) Console.Write("|"); }

                Console.WriteLine();
                if (i < 2) Console.WriteLine("-----"); }
        }

        static void PlayerMove()
        {
            int row, col = 0;
            bool validMove = false;
            while (!validMove)
            {
                Console.WriteLine($"Ход игрока {currentPlayer}. Введите координаты (строка и столбец):");
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');
                row = int.Parse(parts[0]) - 1;
                col = int.Parse(parts[1]) - 1;

                if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
                {
                    board[row, col] = currentPlayer;
                    validMove = true;
                }
                else Console.WriteLine("У вас ошибка, введите правильное значение и попробуйте еще.");
            }
        }

        static void SwitchPlaye()
        { currentPlayer = (currentPlayer == 'X') ? 'O' : 'X'; }

        static bool CheckWin()
        {

            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                    return true;
            }

            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
                return true;

            return false;
        }
        static bool CheckDraw()
        {
            foreach (char cell in board)
            {
                if (cell == ' ')
                    return false;
            }
            return true;
        }
    }
}
