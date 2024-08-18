using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int currentPlayer = 1; // 1 - крестики, 2 - нолики

    static void Main()
    {
        int choice;
        bool validInput;

        do
        {
            Console.Clear();
            DrawBoard();

            Console.WriteLine($"Игрок {currentPlayer}, введите номер ячейки:");

            // Проверяем корректность ввода: число от 1 до 9, и ячейка не должна быть занята
            validInput = int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O';

            if (validInput)
            {
                // Заполняем ячейку текущим символом (X или O)
                board[choice - 1] = (currentPlayer == 1) ? 'X' : 'O';

                // Проверяем на наличие выигрышной комбинации
                if (CheckForWin())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine($"Победил игрок {currentPlayer}!");
                    break;
                }

                // Проверяем на наступление ничьей
                if (CheckForDraw())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine("Ничья!");
                    break;
                }

                // Меняем текущего игрока
                currentPlayer = (currentPlayer == 1) ? 2 : 1;
            }
            else
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");

        } while (true);
    }

    // Выводим текущее состояние игрового поля
    static void DrawBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("-----------");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("-----------");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    // Проверяем на выигрыш
    static bool CheckForWin()
    {
        return (board[0] == board[1] && board[1] == board[2]) ||
            (board[3] == board[4] && board[4] == board[5]) ||
            (board[6] == board[7] && board[7] == board[8]) ||
            (board[0] == board[3] && board[3] == board[6]) ||
            (board[1] == board[4] && board[4] == board[7]) ||
            (board[2] == board[5] && board[5] == board[8]) ||
            (board[0] == board[4] && board[4] == board[8]) ||
            (board[2] == board[4] && board[4] == board[6]);
    }

    // Проверяем на ничью
    static bool CheckForDraw()
    {
        // Проверяем, остались ли свободные ячейки
        foreach (char cell in board)
        {
            if (cell != 'X' && cell != 'O')
                return false;
        }
        return true;
    }
}