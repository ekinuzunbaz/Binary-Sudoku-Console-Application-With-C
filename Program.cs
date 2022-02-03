using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sudoku
{
    class Program
    {
        static void Main(string[] args)
        {

            string keepGaming = "y";

            while (keepGaming == "y")   //play game while user enters y, when he/she wants to play game again
            {
                string[,] board = new string[23, 23];   //declare two dimensional string array size of 23*23

                ConsoleKeyInfo cki;

                double score = 0;

                //CREATING BOARD
                for (int i = 0; i < board.GetLength(0); i++)    //loop for rows
                {
                    for (int j = 0; j < board.GetLength(1); j++)    //loop for columns
                    {
                        if (i < board.GetLength(0) - 3 && j < board.GetLength(1) - 3 && i != 0 && j != 0 && i % 2 == 0 && j % 2 == 0)
                        {
                            board[i, j] = ".";
                        }
                        else if (i % 6 == 1 && j % 6 == 1)
                        {
                            board[i, j] = "+";
                        }
                        else if (j < board.GetLength(0) - 3 && j != 0 && i % 6 == 1 && j % 6 != 1)
                        {
                            board[i, j] = "-";
                        }
                        else if (i < board.GetLength(1) - 3 && i != 0 && i % 6 != 1 && j % 6 == 1)
                        {
                            board[i, j] = "|";
                        }
                        else if (j < board.GetLength(0) - 3 && i == 0 && j % 2 == 0)
                        {
                            board[0, j] = Convert.ToString(j / 2);
                        }
                        else if (i < board.GetLength(1) - 3 && j == 0 && i % 2 == 0)
                        {
                            board[i, 0] = Convert.ToString(i / 2);
                        }
                        else
                        {
                            board[i, j] = " ";
                        }
                    }
                }
                board[0, 0] = " ";

                int piece_counter = 0;  //piece counter to follow-up number of pieces

                while (true)
                {

                    Console.SetCursorPosition(2, 0);
                    for (int m = 0; m < board.GetLength(0); m++)    //display the board by using for loops
                    {
                        Console.WriteLine();
                        for (int n = 0; n < board.GetLength(1); n++)
                        {
                            Console.Write(board[m, n]);
                        }
                    }
                    Console.SetCursorPosition(0, 25);
                    Console.ForegroundColor = ConsoleColor.Blue;    //sets the foreground color to blue
                    Console.WriteLine("---------------------------------BINARY SUDOKU---------------------------------");
                    Console.ResetColor();                          //resets the console’s foreground and background colors

                    Console.SetCursorPosition(50, 1);
                    Console.Write("Score: {0}", score); //display the score

                    Console.SetCursorPosition(50, 3);
                    Console.Write("Piece: {0}", piece_counter + 1); //display the number of pieces


                    //GENERATING RANDOM PIECES
                    Random rnd = new Random();
                    int randomPiece = rnd.Next(1, 11);  //generate random number within range [1,11) for probabilities of random pieces

                    string[,] piece = new string[3, 3] { {".", ".", ".", },     //string array to hold pieces size of 3*3
                                                         {".", ".", ".", },     //we use "." (dots) to hold empty places
                                                         {".", ".", ".", } };
                    //we begin to assign the elements of piece array from top left corner

                    if (randomPiece == 1)   //if generated number is 1 
                    {
                        for (int k = 0; k <= 0; k++) //for generating pieces according to Board Elements(Project 2 - Binary Sudoku.doc) 1-1 --> X
                        {
                            Random rnd1 = new Random();
                            int randomNumber = rnd1.Next(0, 2);    //generate random number within range [0,2) for elements of pieces  (0 or 1 generator)
                            piece[k, k] = Convert.ToString(randomNumber);   //convert the generated random number to string and assisgn to related location of piece array
                        }
                    }
                    else if (randomPiece == 2) //for generating pieces according to Board Elements(Project 2 - Binary Sudoku.doc) 2-1 --> 1 row, 2 columns X  (XX)
                    {
                        for (int k = 0; k <= 0; k++)
                        {
                            for (int m = 0; m <= 1; m++)
                            {
                                Random rnd1 = new Random();
                                int randomNumber = rnd1.Next(0, 2); //generate random number within range [0,2) for elements of pieces  (0 or 1 generator)
                                piece[k, m] = Convert.ToString(randomNumber);   //convert the generated random number to string and assisgn to related location of piece array
                            }
                        }
                    }
                    else if (randomPiece == 3) //for generating pieces according to Board Elements(Project 2 - Binary Sudoku.doc) 2-2 --> 2 rows, 1 column X 
                    {
                        for (int k = 0; k <= 1; k++)    //loop for rows
                        {
                            for (int m = 0; m <= 0; m++)    //loop for columns
                            {
                                Random rnd1 = new Random();
                                int randomNumber = rnd1.Next(0, 2);
                                piece[k, m] = Convert.ToString(randomNumber);
                            }
                        }
                    }
                    else if (randomPiece == 4) //1 row,3 columns (XXX)
                    {
                        for (int k = 0; k <= 0; k++)
                        {
                            for (int m = 0; m <= 2; m++)
                            {
                                Random rnd1 = new Random();
                                int randomNumber = rnd1.Next(0, 2);
                                piece[k, m] = Convert.ToString(randomNumber);
                            }
                        }
                    }
                    else if (randomPiece == 5)
                    {
                        for (int k = 0; k <= 2; k++) //3 rows, 1 column
                        {
                            for (int m = 0; m <= 0; m++)
                            {
                                Random rnd1 = new Random();
                                int randomNumber = rnd1.Next(0, 2);
                                piece[k, m] = Convert.ToString(randomNumber);
                            }
                        }
                    }
                    else if (randomPiece == 6)
                    {
                        for (int k = 0; k <= 1; k++) //2 rows, 2 columns, THERE IS NO X in coordinate 1,1 (we used "." (dots) to hold empty places)
                        {
                            for (int m = 0; m <= 1; m++)
                            {
                                Random rnd1 = new Random();
                                int randomNumber = rnd1.Next(0, 2);
                                piece[k, m] = Convert.ToString(randomNumber);
                                piece[1, 1] = ".";
                            }
                        }
                    }
                    else if (randomPiece == 7)
                    {
                        for (int k = 0; k <= 1; k++) //2 rows, 2 columns, THERE IS NO X in coordinate 1,0 (we used "." (dots) to hold empty places)
                        {
                            for (int m = 0; m <= 1; m++)
                            {
                                Random rnd1 = new Random();
                                int randomNumber = rnd1.Next(0, 2);
                                piece[k, m] = Convert.ToString(randomNumber);
                                piece[1, 0] = ".";
                            }
                        }
                    }
                    else if (randomPiece == 8)
                    {
                        for (int k = 0; k <= 1; k++) //2 rows, 2 columns, THERE IS NO X in coordinate 0,1 (we used "." (dots) to hold empty places)
                        {
                            for (int m = 0; m <= 1; m++)
                            {
                                Random rnd1 = new Random();
                                int randomNumber = rnd1.Next(0, 2);
                                piece[k, m] = Convert.ToString(randomNumber);
                                piece[0, 1] = ".";
                            }
                        }
                    }
                    else if (randomPiece == 9)
                    {
                        for (int k = 0; k <= 1; k++) //2 rows, 2 columns, THERE IS NO X in coordinate 0,0 (we used "." (dots) to hold empty places)
                        {
                            for (int m = 0; m <= 1; m++)
                            {
                                Random rnd1 = new Random();
                                int randomNumber = rnd1.Next(0, 2);
                                piece[k, m] = Convert.ToString(randomNumber);
                                piece[0, 0] = ".";
                            }
                        }
                    }
                    else if (randomPiece == 10) //2 rows, 2 columns
                    {
                        for (int k = 0; k <= 1; k++)
                        {
                            for (int m = 0; m <= 1; m++)
                            {
                                Random rnd1 = new Random();
                                int randomNumber = rnd1.Next(0, 2);
                                piece[k, m] = Convert.ToString(randomNumber);
                            }
                        }
                    }

                    Console.SetCursorPosition(30, 1);
                    Console.Write("New Piece ");

                    for (int k = 0; k <= 2; k++)    //display the generated new piece
                    {
                        Console.SetCursorPosition(30, (3 + k));
                        for (int m = 0; m <= 2; m++)
                        {
                            if (piece[k, m] == ".") //we used "." (dots) to hold empty places.If it is "." , display space at there
                            {
                                Console.Write("  ");
                            }
                            else   //else, display the element of piece array with space after it
                            {
                                Console.Write(piece[k, m] + " ");
                            }
                        }
                    }

                    //CONTROLLING THE BOARD WHETHER THERE EXIST ANY SPACE THAT CAN BE PLACED GENERATED PIECE
                    int spaceCounter = 0; //counter to hold usable spaces which we can place piece there
                    if (randomPiece == 1)   //if our piece is type 1 -> 1 row 1 column (X)
                    {
                        for (int i = 2; i < board.GetLength(0) - 3; i = i + 2) //loop for rows
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2) //loop for columns
                            {
                                if (board[i, j] == ".") //if there exist suitable space on board for that piece
                                {
                                    spaceCounter++;     //increment for spaceCounter
                                }
                            }
                        }
                    }
                    else if (randomPiece == 2)  //if our piece is type 2 -> 1 row 2 columns (XX)
                    {
                        for (int i = 2; i < board.GetLength(0) - 3; i = i + 2) //loop for rows
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2) //loop for columns
                            {
                                if (board[i, j] == "." && board[i, j + 2] == ".") //if there exist suitable space on board for that piece
                                {
                                    spaceCounter++;     //increment for spaceCounter
                                }
                            }
                        }
                    }
                    else if (randomPiece == 3)  //if our piece is type 3 -> 2 rows, 1 column 
                    {
                        for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                            {
                                if (board[i, j] == "." && board[i + 2, j] == ".") //if there exist suitable space on board for that piece
                                {
                                    spaceCounter++;     //increment for spaceCounter
                                }
                            }
                        }
                    }
                    else if (randomPiece == 4)  //if our piece is type 4 -> 1 row,3 columns (XXX)
                    {
                        for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                            {
                                if (board[i, j] == "." && board[i, j + 2] == "." && board[i, j + 4] == ".") //if there exist suitable space on board for that piece
                                {
                                    spaceCounter++;     //increment for spaceCounter
                                }
                            }
                        }
                    }
                    else if (randomPiece == 5)  //if our piece is type 5 -> 3 rows, 1 column
                    {
                        for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                            {
                                if (board[i, j] == "." && board[i + 2, j] == "." && board[i + 4, j] == ".") //if there exist suitable space on board for that piece
                                {
                                    spaceCounter++;     //increment for spaceCounter
                                }
                            }
                        }
                    }
                    else if (randomPiece == 6)  //if our piece is type 6 -> 2 rows, 2 columns, THERE IS NO X in coordinate 1,1
                    {
                        for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                            {
                                if (board[i, j] == "." && board[i + 2, j] == "." && board[i, j + 2] == ".") //if there exist suitable space on board for that piece
                                {
                                    spaceCounter++;     //increment for spaceCounter
                                }
                            }
                        }
                    }
                    else if (randomPiece == 7)  //if our piece is type 7 -> 2 rows, 2 columns, THERE IS NO X in coordinate 1,0 
                    {
                        for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                            {
                                if (board[i, j] == "." && board[i, j + 2] == "." && board[i + 2, j + 2] == ".") //if there exist suitable space on board for that piece
                                {
                                    spaceCounter++;
                                }
                            }
                        }
                    }
                    else if (randomPiece == 8)  //if our piece is type 8 -> 2 rows, 2 columns, THERE IS NO X in coordinate 0,1
                    {
                        for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                            {
                                if (board[i, j] == "." && board[i + 2, j] == "." && board[i + 2, j + 2] == ".") //if there exist suitable space on board for that piece
                                {
                                    spaceCounter++;
                                }
                            }
                        }
                    }
                    else if (randomPiece == 9)  //if our piece is type 9 -> 2 rows, 2 columns, THERE IS NO X in coordinate 0,0
                    {
                        for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                            {
                                if (board[i + 2, j] == "." && board[i, j + 2] == "." && board[i + 2, j + 2] == ".") //if there exist suitable space on board for that piece
                                {
                                    spaceCounter++;
                                }
                            }
                        }
                    }
                    else if (randomPiece == 10)  //if our piece is type 10 -> 2 rows, 2 columns
                    {
                        for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                            {
                                if (board[i, j] == "." && board[i, j + 2] == "." && board[i + 2, j] == "." && board[i + 2, j + 2] == ".") //if there exist suitable space on board for that piece
                                {
                                    spaceCounter++;
                                }
                            }
                        }
                    }

                    if (spaceCounter == 0) break; //there is no enough space to place that generated random piece, then break the outer while loop and finish the game

                    int cursor_x = 10, cursor_y = 11;   // position of cursor
                    int cursor_boardrow = 10, cursor_boardcolumn = 10; //indexs of board array where cursor is located

                    Console.SetCursorPosition(cursor_x, cursor_y);

                    while (true)
                    {
                        if (Console.KeyAvailable)   //check whether you can press a button and use it, if you can then it returns 1(true)
                        {
                            cki = Console.ReadKey(true);

                            if (cki.Key == ConsoleKey.RightArrow && cursor_x < 18 && cursor_boardcolumn < 18)   //move to right
                            {   // key and boundary control
                                cursor_x = cursor_x + 2;                        //increment for cursor_x
                                Console.SetCursorPosition(cursor_x, cursor_y);
                                cursor_boardcolumn = cursor_boardcolumn + 2;    //increment for column index of board (position of cursor is indexs of board, too)
                            }
                            if (cki.Key == ConsoleKey.LeftArrow && cursor_x > 2 && cursor_boardcolumn > 2)    //move to left
                            {
                                cursor_x = cursor_x - 2;                        //decrement for cursor_x
                                Console.SetCursorPosition(cursor_x, cursor_y);
                                cursor_boardcolumn = cursor_boardcolumn - 2;    //decrement for column index of board (position of cursor is indexs of board, too)
                            }
                            if (cki.Key == ConsoleKey.UpArrow && cursor_y > 4 && cursor_boardrow > 3)  //move to up
                            {
                                cursor_y = cursor_y - 2;                        //decrement for cursor_y
                                Console.SetCursorPosition(cursor_x, cursor_y);
                                cursor_boardrow = cursor_boardrow - 2;          //decrement for row index of board (position of cursor is indexs of board, too)
                            }
                            if (cki.Key == ConsoleKey.DownArrow && cursor_y < 18 && cursor_boardrow < 17)   //move to down
                            {
                                cursor_y = cursor_y + 2;                        //increment for cursor_y
                                Console.SetCursorPosition(cursor_x, cursor_y);
                                cursor_boardrow = cursor_boardrow + 2;          //increment for row index of board (position of cursor is indexs of board, too)
                            }

                            if (cki.Key == ConsoleKey.Enter)    //user press ENTER to place pieces onto board
                            {
                                if (randomPiece == 1)   //if our piece is type 1 (as created and explained previously, above)
                                {
                                    if (board[cursor_boardrow, cursor_boardcolumn] == ".")  //if the location that you want to place piece is empty
                                    {
                                        board[cursor_boardrow, cursor_boardcolumn] = piece[0, 0];   //place piece's elements onto board
                                        piece_counter++;    //increment for piece counter
                                        break;    //break the loop to create a new random piece
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 6);
                                        Console.ForegroundColor = ConsoleColor.Red;    //sets the foreground color to red
                                        Console.WriteLine("Please choose another place for your piece!");
                                        Console.ResetColor();                          //resets the console’s foreground and background colors
                                        Thread.Sleep(1400);
                                        Console.SetCursorPosition(30, 6);
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(cursor_x, cursor_y);
                                    }
                                }
                                else if (randomPiece == 2)  //else if our piece is tpye 2 (as created and explained previously, above)
                                {
                                    if (board[cursor_boardrow, cursor_boardcolumn] == "." && board[cursor_boardrow, cursor_boardcolumn + 2] == ".")
                                    {
                                        board[cursor_boardrow, cursor_boardcolumn] = piece[0, 0];      //place piece's elements onto board
                                        board[cursor_boardrow, cursor_boardcolumn + 2] = piece[0, 1];
                                        piece_counter++;    //increment for piece counter
                                        break;    //break the loop to create a new random piece
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 6);
                                        Console.ForegroundColor = ConsoleColor.Red;    //sets the foreground color to red
                                        Console.WriteLine("Please choose another place for your piece!");
                                        Console.ResetColor();                          //resets the console’s foreground and background colors
                                        Thread.Sleep(1400);
                                        Console.SetCursorPosition(30, 6);
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(cursor_x, cursor_y);
                                    }
                                }
                                else if (randomPiece == 3)
                                {
                                    if (board[cursor_boardrow, cursor_boardcolumn] == "." && board[cursor_boardrow + 2, cursor_boardcolumn] == ".")   //if the location that you want to place piece is empty
                                    {
                                        board[cursor_boardrow, cursor_boardcolumn] = piece[0, 0];
                                        board[cursor_boardrow + 2, cursor_boardcolumn] = piece[1, 0];
                                        piece_counter++;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 6);
                                        Console.ForegroundColor = ConsoleColor.Red;    //sets the foreground color to red
                                        Console.WriteLine("Please choose another place for your piece!");
                                        Console.ResetColor();                          //resets the console’s foreground and background colors
                                        Thread.Sleep(1400);
                                        Console.SetCursorPosition(30, 6);
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(cursor_x, cursor_y);
                                    }
                                }
                                else if (randomPiece == 4)
                                {
                                    if (board[cursor_boardrow, cursor_boardcolumn] == "." && board[cursor_boardrow, cursor_boardcolumn + 2] == "." && board[cursor_boardrow, cursor_boardcolumn + 4] == ".")
                                    {
                                        board[cursor_boardrow, cursor_boardcolumn] = piece[0, 0];
                                        board[cursor_boardrow, cursor_boardcolumn + 2] = piece[0, 1];
                                        board[cursor_boardrow, cursor_boardcolumn + 4] = piece[0, 2];
                                        piece_counter++;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 6);
                                        Console.ForegroundColor = ConsoleColor.Red;    //sets the foreground color to red
                                        Console.WriteLine("Please choose another place for your piece!");
                                        Console.ResetColor();                          //resets the console’s foreground and background colors
                                        Thread.Sleep(1400);
                                        Console.SetCursorPosition(30, 6);
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(cursor_x, cursor_y);
                                    }
                                }
                                else if (randomPiece == 5)
                                {
                                    if (board[cursor_boardrow, cursor_boardcolumn] == "." && board[cursor_boardrow + 2, cursor_boardcolumn] == "." && board[cursor_boardrow + 4, cursor_boardcolumn] == ".")
                                    {
                                        board[cursor_boardrow, cursor_boardcolumn] = piece[0, 0];
                                        board[cursor_boardrow + 2, cursor_boardcolumn] = piece[1, 0];
                                        board[cursor_boardrow + 4, cursor_boardcolumn] = piece[2, 0];
                                        piece_counter++;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 6);
                                        Console.ForegroundColor = ConsoleColor.Red;    //sets the foreground color to red
                                        Console.WriteLine("Please choose another place for your piece!");
                                        Console.ResetColor();                          //resets the console’s foreground and background colors
                                        Thread.Sleep(1400);
                                        Console.SetCursorPosition(30, 6);
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(cursor_x, cursor_y);
                                    }
                                }
                                else if (randomPiece == 6)
                                {
                                    if (board[cursor_boardrow, cursor_boardcolumn] == "." && board[cursor_boardrow + 2, cursor_boardcolumn] == "." && board[cursor_boardrow, cursor_boardcolumn + 2] == ".")
                                    {
                                        board[cursor_boardrow, cursor_boardcolumn] = piece[0, 0];
                                        board[cursor_boardrow + 2, cursor_boardcolumn] = piece[1, 0];
                                        board[cursor_boardrow, cursor_boardcolumn + 2] = piece[0, 1];
                                        piece_counter++;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 6);
                                        Console.ForegroundColor = ConsoleColor.Red;    //sets the foreground color to red
                                        Console.WriteLine("Please choose another place for your piece!");
                                        Console.ResetColor();                          //resets the console’s foreground and background colors
                                        Thread.Sleep(1400);
                                        Console.SetCursorPosition(30, 6);
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(cursor_x, cursor_y);
                                    }
                                }
                                else if (randomPiece == 7)
                                {
                                    if (board[cursor_boardrow, cursor_boardcolumn] == "." && board[cursor_boardrow, cursor_boardcolumn + 2] == "." && board[cursor_boardrow + 2, cursor_boardcolumn + 2] == ".")
                                    {
                                        board[cursor_boardrow, cursor_boardcolumn] = piece[0, 0];
                                        board[cursor_boardrow, cursor_boardcolumn + 2] = piece[0, 1];
                                        board[cursor_boardrow + 2, cursor_boardcolumn + 2] = piece[1, 1];
                                        piece_counter++;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 6);
                                        Console.ForegroundColor = ConsoleColor.Red;    //sets the foreground color to red
                                        Console.WriteLine("Please choose another place for your piece!");
                                        Console.ResetColor();                          //resets the console’s foreground and background colors
                                        Thread.Sleep(1400);
                                        Console.SetCursorPosition(30, 6);
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(cursor_x, cursor_y);
                                    }
                                }
                                else if (randomPiece == 8)
                                {
                                    if (board[cursor_boardrow, cursor_boardcolumn] == "." && board[cursor_boardrow + 2, cursor_boardcolumn] == "." && board[cursor_boardrow + 2, cursor_boardcolumn + 2] == ".")
                                    {
                                        board[cursor_boardrow, cursor_boardcolumn] = piece[0, 0];
                                        board[cursor_boardrow + 2, cursor_boardcolumn] = piece[1, 0];
                                        board[cursor_boardrow + 2, cursor_boardcolumn + 2] = piece[1, 1];
                                        piece_counter++;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 6);
                                        Console.ForegroundColor = ConsoleColor.Red;    //sets the foreground color to red
                                        Console.WriteLine("Please choose another place for your piece!");
                                        Console.ResetColor();                          //resets the console’s foreground and background colors
                                        Thread.Sleep(1400);
                                        Console.SetCursorPosition(30, 6);
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(cursor_x, cursor_y);
                                    }
                                }
                                else if (randomPiece == 9)
                                {
                                    if (board[cursor_boardrow + 2, cursor_boardcolumn] == "." && board[cursor_boardrow, cursor_boardcolumn + 2] == "." && board[cursor_boardrow + 2, cursor_boardcolumn + 2] == ".")
                                    {
                                        board[cursor_boardrow + 2, cursor_boardcolumn] = piece[1, 0];
                                        board[cursor_boardrow, cursor_boardcolumn + 2] = piece[0, 1];
                                        board[cursor_boardrow + 2, cursor_boardcolumn + 2] = piece[1, 1];
                                        piece_counter++;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 6);
                                        Console.ForegroundColor = ConsoleColor.Red;    //sets the foreground color to red
                                        Console.WriteLine("Please choose another place for your piece!");
                                        Console.ResetColor();                          //resets the console’s foreground and background colors
                                        Thread.Sleep(1400);
                                        Console.SetCursorPosition(30, 6);
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(cursor_x, cursor_y);
                                    }
                                }
                                else if (randomPiece == 10)
                                {
                                    if (board[cursor_boardrow, cursor_boardcolumn] == "." && board[cursor_boardrow + 2, cursor_boardcolumn] == "." && board[cursor_boardrow, cursor_boardcolumn + 2] == "." && board[cursor_boardrow + 2, cursor_boardcolumn + 2] == ".")
                                    {
                                        board[cursor_boardrow, cursor_boardcolumn] = piece[0, 0];
                                        board[cursor_boardrow + 2, cursor_boardcolumn] = piece[1, 0];
                                        board[cursor_boardrow, cursor_boardcolumn + 2] = piece[0, 1];
                                        board[cursor_boardrow + 2, cursor_boardcolumn + 2] = piece[1, 1];
                                        piece_counter++;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 6);
                                        Console.ForegroundColor = ConsoleColor.Red;    //sets the foreground color to red
                                        Console.WriteLine("Please choose another place for your piece!");
                                        Console.ResetColor();                          //resets the console’s foreground and background colors
                                        Thread.Sleep(1400);
                                        Console.SetCursorPosition(30, 6);
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(cursor_x, cursor_y);
                                    }
                                }
                            }
                        }
                    }

                    double point = 0;
                    int filledPlaces = 0;
                    double single_point = 0;

                    //controlling rows are filled or not.
                    //If it is filled, do the binary to decimal calculation
                    for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                    {
                        single_point = 0;
                        if (board[i, 2] != "." && board[i, 4] != "." && board[i, 6] != "." && board[i, 8] != "." && board[i, 10] != "." && board[i, 12] != "." && board[i, 14] != "." && board[i, 16] != "." && board[i, 18] != ".")
                        {
                            filledPlaces++;
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                            {
                                single_point = single_point + Math.Pow(2, 9 - j / 2) * Convert.ToInt16(board[i, j]);
                                point = point + Math.Pow(2, 9 - j / 2) * Convert.ToInt16(board[i, j]);
                            }

                            Console.SetCursorPosition(30, 10 + filledPlaces);
                            Console.Write("                                                                                                ");
                            Console.SetCursorPosition(30, 11 + filledPlaces);
                            Console.Write("                                                                                                ");
                            Console.SetCursorPosition(30, 12 + filledPlaces);
                            Console.Write("                                                                                                ");
                            Console.SetCursorPosition(30, 13 + filledPlaces);
                            Console.Write("                                                                                                ");
                            Console.SetCursorPosition(30, 14 + filledPlaces);
                            Console.Write("                                                                                                ");
                            Console.SetCursorPosition(30, 10 + filledPlaces);
                            Console.Write("You earned {0} points from filled row --> ", single_point);
                            for (int j = 2; j < 20; j++)
                            {
                                if (board[i, j] == "1" || board[i, j] == "0")
                                {
                                    Console.Write(board[i, j]);
                                }
                            }
                        }
                    }

                    //controlling columns are filled or not.
                    //If it is filled, do the binary to decimal calculation
                    for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                    {
                        single_point = 0;
                        if (board[2, j] != "." && board[4, j] != "." && board[6, j] != "." && board[8, j] != "." && board[10, j] != "." && board[12, j] != "." && board[14, j] != "." && board[16, j] != "." && board[18, j] != ".")
                        {
                            filledPlaces++;
                            for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                            {
                                single_point = single_point + Math.Pow(2, 9 - i / 2) * Convert.ToInt16(board[i, j]);
                                point = point + Math.Pow(2, 9 - i / 2) * Convert.ToInt16(board[i, j]);
                            }
                            Console.SetCursorPosition(30, 10 + filledPlaces);
                            Console.Write("                                                                                                ");
                            Console.SetCursorPosition(30, 11 + filledPlaces);
                            Console.Write("                                                                                                ");
                            Console.SetCursorPosition(30, 12 + filledPlaces);
                            Console.Write("                                                                                                ");
                            Console.SetCursorPosition(30, 13 + filledPlaces);
                            Console.Write("                                                                                                ");
                            Console.SetCursorPosition(30, 14 + filledPlaces);
                            Console.Write("                                                                                                ");
                            Console.SetCursorPosition(30, 10 + filledPlaces);
                            Console.Write("You earned {0} points from filled column --> ", single_point);
                            for (int i = 2; i < 20; i++)
                            {
                                if (board[i, j] == "1" || board[i, j] == "0")
                                {
                                    Console.Write(board[i, j]);
                                }
                            }
                        }
                    }

                    //controlling little 3*3 squares are filled or not.
                    //If it is filled, do the binary to decimal calculation
                    for (int i = 2; i < board.GetLength(0) - 3; i = i + 6)
                    {
                        for (int j = 2; j < board.GetLength(1) - 3; j = j + 6)
                        {
                            if (board[i, j] != "." && board[i + 2, j] != "." && board[i + 4, j] != "." && board[i + 2, j + 2] != "." && board[i + 4, j + 2] != "." && board[i + 2, j + 4] != "." && board[i, j + 2] != "." && board[i, j + 4] != "." && board[i + 4, j + 4] != ".")
                            {
                                filledPlaces++;
                                single_point = 0;
                                int powercounter = 8;
                                //row coordinates for 3*3 squares 
                                for (int m = i; m < i + 6; m = m + 2)
                                {
                                    //column coordinates for 3*3 squares
                                    for (int n = j; n < j + 6; n = n + 2)
                                    {
                                        single_point = single_point + Math.Pow(2, powercounter) * Convert.ToInt16(board[m, n]);
                                        point = point + Math.Pow(2, powercounter) * Convert.ToInt16(board[m, n]);
                                        powercounter--;
                                    }
                                }
                                Console.SetCursorPosition(30, 10 + filledPlaces);
                                Console.Write("                                                                                                ");
                                Console.SetCursorPosition(30, 11 + filledPlaces);
                                Console.Write("                                                                                                ");
                                Console.SetCursorPosition(30, 12 + filledPlaces);
                                Console.Write("                                                                                                ");
                                Console.SetCursorPosition(30, 13 + filledPlaces);
                                Console.Write("                                                                                                ");
                                Console.SetCursorPosition(30, 14 + filledPlaces);
                                Console.Write("                                                                                                ");
                                Console.SetCursorPosition(30, 10 + filledPlaces);
                                Console.Write("You earned {0} points from filled block --> ", single_point);
                                for (int m = i; m < i + 6; m = m + 2)
                                {
                                    for (int n = j; n < j + 6; n = n + 2)
                                    {
                                        if (board[m, n] == "1" || board[m, n] == "0")
                                        {
                                            Console.Write(board[m, n]);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    score = score + point * filledPlaces;
                    if (filledPlaces > 1)
                    {
                        Console.SetCursorPosition(30, 20);
                        Console.Write("You filled row(s)/column(s)/block(s) more than 1!");
                        Console.SetCursorPosition(30, 21);
                        Console.Write("The total earned points will be multiplied by {0}!", filledPlaces);
                        Console.SetCursorPosition(30, 22);
                        Console.Write("You earned {0} * {1} = {2} points totally!", point, filledPlaces, point * filledPlaces);
                    }
                    else if (filledPlaces == 1)
                    {
                        Console.SetCursorPosition(30, 20);
                        Console.Write("                                                                                                ");
                        Console.SetCursorPosition(30, 21);
                        Console.Write("                                                                                                ");
                        Console.SetCursorPosition(30, 22);
                        Console.Write("                                                                                                ");
                    }


                    string[,] delete_array = new string[23, 23];  //declare two dimensional string array size of 23*23

                    for (int i = 2; i < delete_array.GetLength(0); i = i + 2)
                    {
                        for (int j = 2; j < delete_array.GetLength(1); j = j + 2)
                        {
                            delete_array[i, j] = "0";
                        }
                    }
                    //DELETING FILLED ROWS/COLUMNS/BOARDS
                    //Hold the locations that will be deleted in delete_array. Then, delete them.
                    //deleting filled rows
                    for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                    {
                        if (board[i, 2] != "." && board[i, 4] != "." && board[i, 6] != "." && board[i, 8] != "." && board[i, 10] != "." && board[i, 12] != "." && board[i, 14] != "." && board[i, 16] != "." && board[i, 18] != ".")
                        {
                            for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                            {
                                delete_array[i, j] = ".";
                            }
                        }
                    }

                    //deleting filled columns.
                    for (int j = 2; j < board.GetLength(1) - 3; j = j + 2)
                    {
                        if (board[2, j] != "." && board[4, j] != "." && board[6, j] != "." && board[8, j] != "." && board[10, j] != "." && board[12, j] != "." && board[14, j] != "." && board[16, j] != "." && board[18, j] != ".")
                        {
                            for (int i = 2; i < board.GetLength(0) - 3; i = i + 2)
                            {
                                delete_array[i, j] = ".";
                            }
                        }
                    }

                    //deleting filled little 3*3 squares
                    for (int i = 2; i < board.GetLength(0) - 3; i = i + 6)
                    {
                        for (int j = 2; j < board.GetLength(1) - 3; j = j + 6)
                        {
                            if (board[i, j] != "." && board[i + 2, j] != "." && board[i + 4, j] != "." && board[i + 2, j + 2] != "." && board[i + 4, j + 2] != "." && board[i + 2, j + 4] != "." && board[i, j + 2] != "." && board[i, j + 4] != "." && board[i + 4, j + 4] != ".")
                            {
                                //row coordinates for 3*3 squares 
                                for (int m = i; m < i + 6; m = m + 2)
                                {
                                    //column coordinates for 3*3 squares
                                    for (int n = j; n < j + 6; n = n + 2)
                                    {
                                        delete_array[m, n] = ".";
                                    }
                                }
                            }
                        }
                    }

                    for (int i = 2; i < delete_array.GetLength(0) - 1; i = i + 2)
                    {
                        for (int j = 2; j < delete_array.GetLength(1) - 1; j = j + 2)
                        {
                            if (delete_array[i, j] == ".")
                            {
                                board[i, j] = ".";
                            }
                        }
                    }

                } //end of outer while loop which controls our game

                Console.ForegroundColor = ConsoleColor.Red;     //sets the foreground color to red
                Console.SetCursorPosition(3, 22);
                Console.WriteLine("Game Over!");
                Console.SetCursorPosition(3, 23);
                Console.WriteLine("Your score:  {0}!", score);  //display the score

                Console.SetCursorPosition(2, 27);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("DO YOU WANT TO PLAY AGAIN?");    //ask user to whether he/she wants to play again
                Console.WriteLine("Type y for yes OR type n for no");
                keepGaming = Console.ReadLine();                    //take input from user

                if (keepGaming != "y" && keepGaming != "n") //if user enters unknown answer, ask him/her again to enter again
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUnknown answer please type again!");
                    Console.WriteLine("Type y for yes OR type n for no");
                    keepGaming = Console.ReadLine();
                    while (keepGaming != "y" && keepGaming != "n") //while user enters wrong input, take input until he/she enters the input in the correct way
                    {
                        Console.WriteLine("\nUnknown answer please type again!");
                        Console.WriteLine("Type y for yes OR type n for no");
                        keepGaming = Console.ReadLine();
                    }
                }
                Console.Clear();        //clear the console screen to prepare it for the next game
                Console.ResetColor();   //resets the console’s foreground and background colors

            } //end of the while(keepGaming =="y")
            Console.ForegroundColor = ConsoleColor.Yellow;  //sets the foreground color to yellow
            Console.WriteLine("You dont want to play game :(");
            Console.ReadLine();
        }
    }
}