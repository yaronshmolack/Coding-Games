
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TicTac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XOBoard b = new XOBoard(4);
            Random r = new Random();
            int i = 0;

            Console.Clear();
            Console.ResetColor();

            // Determine starting player
            if (r.Next(1, 3) == 1)
            {
                Console.WriteLine("Player number 1 is starting with X:");
                Console.WriteLine("Enter which row and column you want to set the X: ");
                int Srow = int.Parse(Console.ReadLine());
                int Scol = int.Parse(Console.ReadLine());
                b.Add(Srow, Scol, 'X');
                i = 2;
                b.DisplayBoard();
            }
            else
            {
                Console.WriteLine("Player number 2 is starting with O:");
                Console.WriteLine("Enter which row and column you want to set the O: ");
                int Srow = int.Parse(Console.ReadLine());
                int Scol = int.Parse(Console.ReadLine());
                b.Add(Srow, Scol, 'O');
                i = 1;
                b.DisplayBoard();
            }

            string answer = "yes";
            while (answer.ToUpper() != "NO" && answer.ToUpper() == "YES")
            {
                // Player turns
                if (i == 1)
                {
                    Console.WriteLine($"Player number {i} is playing with X:");
                    int row = int.Parse(Console.ReadLine());
                    int col = int.Parse(Console.ReadLine());
                    if (b.IsExist(row, col))
                    {
                        b.Add(row, col, 'X');
                        Console.WriteLine("Set Successfully");
                    }
                    else
                    {
                        while (b.IsExist(row, col) != true)
                        {
                            Console.WriteLine("Try another Cell");
                            row = int.Parse(Console.ReadLine());
                            col = int.Parse(Console.ReadLine());
                        }
                        b.Add(row, col, 'X');
                    }
                    b.DisplayBoard();
                    i = 2;
                }
                else if (i == 2)
                {
                    Console.WriteLine($"Player number {i} is playing with O:");
                    int row = int.Parse(Console.ReadLine());
                    int col = int.Parse(Console.ReadLine());
                    if (b.IsExist(row, col))
                    {
                        b.Add(row, col, 'O');
                        Console.WriteLine("Set Successfully");
                    }
                    else
                    {
                        while (b.IsExist(row, col) != true)
                        {
                            Console.WriteLine("Try another Cell");
                            row = int.Parse(Console.ReadLine());
                            col = int.Parse(Console.ReadLine());
                        }
                        b.Add(row, col, 'O');
                    }
                    b.DisplayBoard();
                    i = 1;
                }

                // Check game status
                int statusCode = b.StatusCode();
                if (statusCode == 1)
                {
                    Console.WriteLine("Player number 1 won");
                    Console.WriteLine("Do you want to play again? (Yes)/(No)");
                    answer = Console.ReadLine();
                    if (answer.ToUpper() == "YES")
                    {
                        b = new XOBoard(4); // Reset the board for a new game
                    }
                }
                else if (statusCode == 2)
                {
                    Console.WriteLine("Player number 2 won");
                    Console.WriteLine("Do you want to play again? (Yes)/(No)");
                    answer = Console.ReadLine();
                    if (answer.ToUpper() == "YES")
                    {
                        b = new XOBoard(4); // Reset the board for a new game
                    }
                }
                else if (statusCode == 0)
                {
                    Console.WriteLine("Draw");
                    Console.WriteLine("Do you want to play again? (Yes)/(No)");
                    answer = Console.ReadLine();
                    if (answer.ToUpper() == "YES")
                    {
                        b = new XOBoard(4); // Reset the board for a new game
                    }
                }
            }
        }
    }
}
