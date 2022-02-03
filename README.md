# Binary-Sudoku-Console-Game-With-C#

Me and my friend Mustafa Efe developed sudoku like game called Binary sudoku <br />

This game is coded in C# programming language. Have fun! <br />

## What is Binary Sudoku?

- The game is played on a 9x9 board. The board will be filled with 10 different game elements by the player. <br />
- The aim of the game is to fill a row, a column or a 3*3 block with the game elements and reaching the highest score. <br />
- There are ten game elements. Each has a 1/10 probability of occurrence. (Each X represents 0 or 1, randomly generated) <br />

![image](https://user-images.githubusercontent.com/73299618/152333967-f8a34b18-0cd3-404a-99bd-65eb82f8f72e.png)

***Game Playing Rules***

•	The game starts with a 9*9 empty board. <br />
•	A new piece is generated randomly and displayed on the right of the board. <br />
•	The user can place the game element in an empty part of the board without overlaying. Game elements cannot be rotated. Placement operation does not have a time limit. <br />
- Move pieces by using ***arrow keys*** and place the piece by using ***ENTER key*** on keyboard <br />
•	If the located element:  <br />
-	fills a full row(s) (and/or) <br />
-	fills a column(s) completely (and/or) <br />
-	fully fills a 3*3 block(s), <br />

The fully filled row(s)/column(s)/block(s) are treated as a binary number. The decimal equivalent of  binary numbers are calculated. <br />

•	If the currently placed game element fills more than one row(s)/column(s)/block(s), the decimal equivalent of binary numbers are added and this sum is multiplied by the number completed parts (row(s)/column(s)/block(s)). This result is added to the score. <br />
•	Completed parts are removed from the board. <br />

***Game Ending***

If there is no suitable space left to place the new piece on the board, a notice appears saying "Game over!".  <br />
