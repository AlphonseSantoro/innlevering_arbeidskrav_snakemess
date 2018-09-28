using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// WARNING: DO NOT code like this. Please. EVER! 
//          "Aaaargh!" 
//          "My eyes bleed!" 
//          "I facepalmed my facepalm." 
//          Etc.
//          I had a lot of fun obfuscating this code! And I can now (proudly?) say that this is the uggliest short piece of code I've ever written!
//          (It could maybe have been even ugglier? But the idea wasn't to make it fuggly-uggly, just funny-uggly or sweet-uggly. ;-)
//
//          -Tomas
//
namespace SnakeMess
{
	class Point
	{
		public const string Ok = "Ok";

		public int X; public int Y;

	    public Point(int x = 0, int y = 0)
	    {
	        X = x; Y = y;
	    }
		public Point(Point input) { X = input.X; Y = input.Y; }
	}

	class SnakeMess
	{
		public static void Main(string[] arguments)
		{
			bool gameOver = false, pause = false, inUse = false; // gg -> has lost or not
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDir;
			int boardWidth = Console.WindowWidth, boardHeight = Console.WindowHeight; // Sets the size of board -> Height and Width
			Random rand = new Random(); // generates random number -> used for placement of "$"
			Point snakeFood = new Point(); // Snake food -> "$"
			List<Point> snake = new List<Point>(); //snake List containing snake itmens
			snake.Add(new Point(10, 10)); snake.Add(new Point(10, 10)); snake.Add(new Point(10, 10)); snake.Add(new Point(10, 10)); //init snakeLength
			Console.CursorVisible = false;
			Console.Title = "Høyskolen Kristiania - SNAKE";
			//Console.ForegroundColor = ConsoleColor.Green; 
		    //Console.SetCursorPosition(10, 10); 
		    //Console.Write("@");
			while (true) {
				snakeFood.X = rand.Next(0, boardWidth); snakeFood.Y = rand.Next(0, boardHeight);
				bool spot = true;
				foreach (Point i in snake) // for each part in snake
					if (i.X == snakeFood.X && i.Y == snakeFood.Y) { // check snake part coordinates
						spot = false;
						break; // 
					}
				if (spot) {
					Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(snakeFood.X, snakeFood.Y); Console.Write("$");
					break;
				}
			}
			Stopwatch t = new Stopwatch();
			t.Start();
			while (!gameOver) {
				if (Console.KeyAvailable) {
					ConsoleKeyInfo consoleKeyinfo = Console.ReadKey(true);
					if (consoleKeyinfo.Key == ConsoleKey.Escape)
						gameOver = true;
					else if (consoleKeyinfo.Key == ConsoleKey.Spacebar)
						pause = !pause;
					else if (consoleKeyinfo.Key == ConsoleKey.UpArrow && last != 2)
						newDir = 0;
					else if (consoleKeyinfo.Key == ConsoleKey.RightArrow && last != 3)
						newDir = 1;
					else if (consoleKeyinfo.Key == ConsoleKey.DownArrow && last != 0)
						newDir = 2;
					else if (consoleKeyinfo.Key == ConsoleKey.LeftArrow && last != 1)
						newDir = 3;
				}
				if (!pause) {
					if (t.ElapsedMilliseconds < 100)
						continue;
					t.Restart();
					Point tail = new Point(snake.First());
					Point head = new Point(snake.Last());
					Point newHead = new Point(head); // the new head position
					switch (newDir) {
						case 0:
							newHead.Y -= 1;
							break;
						case 1:
							newHead.X += 1;
							break;
						case 2:
							newHead.Y += 1;
							break;
						default:
							newHead.X -= 1;
							break;
					}
					if (newHead.X < 0 || newHead.X >= boardWidth)
						gameOver = true;
					else if (newHead.Y < 0 || newHead.Y >= boardHeight)
						gameOver = true;
					if (newHead.X == snakeFood.X && newHead.Y == snakeFood.Y) {
						if (snake.Count + 1 >= boardWidth * boardHeight)
							// No more room to place apples - game over.
							gameOver = true;
						else {
							while (true) {
								snakeFood.X = rand.Next(0, boardWidth); snakeFood.Y = rand.Next(0, boardHeight);
								bool found = true;
								foreach (Point i in snake)
									if (i.X == snakeFood.X && i.Y == snakeFood.Y) {
										found = false;
										break;
									}
								if (found) {
									inUse = true;
									break;
								}
							}
						}
					}
					if (!inUse) {
						snake.RemoveAt(0);
						foreach (Point x in snake)
							if (x.X == newHead.X && x.Y == newHead.Y) {
								// Death by accidental self-cannibalism.
								gameOver = true;
								break;
							}
					}
					if (!gameOver) {
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(head.X, head.Y); Console.Write("0");
						if (!inUse) {
							Console.SetCursorPosition(tail.X, tail.Y); Console.Write(" ");
						} else {
							Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(snakeFood.X, snakeFood.Y); Console.Write("$");
							inUse = false;
						}
						snake.Add(newHead);
						Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(newHead.X, newHead.Y); Console.Write("@");
						last = newDir;
					}
				}
			}
		}
	}
}