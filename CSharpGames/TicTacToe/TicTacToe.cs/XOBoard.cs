sing System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTac
{
    internal class XOBoard
    {
        private char[,] board;

        public XOBoard(int length)
        {
            this.board = new char[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    this.board[i, j] = ' ';
                }
            }
        }


        public void DisplayBoard()
        {
            int boardWidth = board.GetLength(1) * 2 + (board.GetLength(1) - 1);
            int boardHeight = board.GetLength(0) * 2 - 1;
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;
            int startX = (consoleWidth - boardWidth) / 2;
            int startY = (consoleHeight - boardHeight) / 2;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.SetCursorPosition(startX, startY + i * 2);

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                    if (j < board.GetLength(1) - 1)
                    {
                        Console.Write("|");
                    }
                }

                if (i < board.GetLength(0) - 1)
                {
                    Console.SetCursorPosition(startX, startY + i * 2 + 1);
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        Console.Write("-");
                        if (j < board.GetLength(1) - 1)
                        {
                            Console.Write("+");
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            DisplayBoard();
            return string.Empty;
        }
    

    public bool IsExist(int row, int col)
        {
            if(row < this.board.GetLength(0) && row >=0 && col < this.board.GetLength(0) && col >= 0)
            {
                return board[row, col] == ' ';
            }
            return false;
        }

        public bool Add(int row, int col, char c)
        {
            if (IsExist(row, col))
            {
                this.board[row, col] = c;
                return true;
            }
            return false;
        }
        public int StatusCode()
        {
            int rows = this.board.GetLength(0);
            int cols = this.board.GetLength(1);
            bool hasEmpty = false;

            // Check for row and column winners, and look for empty spaces
            for (int i = 0; i < rows; i++)
            {
                bool rowO = true;
                bool rowX = true;
                bool colO = true;
                bool colX = true;

                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        hasEmpty = true;
                    }
                    if (board[i, j] != 'O')
                    {
                        rowO = false;
                    }
                    if (board[i, j] != 'X')
                    {
                        rowX = false;
                    }
                    if (board[j, i] != 'O')
                    {
                        colO = false;
                    }
                    if (board[j, i] != 'X')
                    {
                        colX = false;
                    }
                }

                if (rowO || colO)
                {
                    return 2; // 'O' wins
                }
                if (rowX || colX)
                {
                    return 1; // 'X' wins
                }
            }

            bool diag1O = true;
            bool diag1X = true;
            bool diag2O = true;
            bool diag2X = true;

            for (int i = 0; i < rows; i++)
            {
                if (board[i, i] != 'O')
                {
                    diag1O = false;
                }
                if (board[i, i] != 'X')
                {
                    diag1X = false;
                }
                if (board[i, rows - i - 1] != 'O')
                {
                    diag2O = false;
                }
                if (board[i, rows - i - 1] != 'X')
                {
                    diag2X = false;
                }
            }

            if (diag1O || diag2O)
            {
                return 2; // 'O' wins
            }
            if (diag1X || diag2X)
            {
                return 1; // 'X' wins
            }

            if (hasEmpty)
            {
                return -1;
            }

            return 0;
        }


    }
}

