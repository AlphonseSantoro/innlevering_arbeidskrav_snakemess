using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SnakeMess {
	class GameController {

		public enum MoveDirection {
			LEFT, RIGHT, UP, DOWN
		}

		public static readonly int windowWidth = Console.WindowWidth;
		public static readonly int windowHeight = Console.WindowHeight;
		public static bool gameOver = false;
		public static bool gamePaused = false;

		private MoveDirection _newDir;
		private MoveDirection _lastDir;
		private Snake _snake;
		private Food _food;
		private Stopwatch _t = new Stopwatch();

		GameController() {

		}

		private void GameLoop() {
			_t.Start();

			while(!gameOver) {
				if(Console.KeyAvailable) {
					ConsoleKeyInfo consoleKeyinfo = Console.ReadKey(true);
					if(consoleKeyinfo.Key == ConsoleKey.Escape)
						gameOver = true;
					else if(consoleKeyinfo.Key == ConsoleKey.Spacebar)
						gamePaused = !gamePaused;
					else if(consoleKeyinfo.Key == ConsoleKey.UpArrow && _lastDir != MoveDirection.DOWN)
						_newDir = MoveDirection.UP;
					else if(consoleKeyinfo.Key == ConsoleKey.RightArrow && _lastDir != MoveDirection.LEFT)
						_newDir = MoveDirection.RIGHT;
					else if(consoleKeyinfo.Key == ConsoleKey.DownArrow && _lastDir != MoveDirection.UP)
						_newDir = MoveDirection.DOWN;
					else if(consoleKeyinfo.Key == ConsoleKey.LeftArrow && _lastDir != MoveDirection.RIGHT)
						_newDir = MoveDirection.LEFT;
					
				}
				if(!gamePaused) {
					if(_t.ElapsedMilliseconds < 100)
						continue;
					_t.Restart();
					Point tail = new Point(snake.First());
					Point head = new Point(snake.Last());
					Point newHead = new Point(head); // the new head position
					switch(_newDir) {
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
					if(newHead.X < 0 || newHead.X >= boardWidth)
						gameOver = true;
					else if(newHead.Y < 0 || newHead.Y >= boardHeight)
						gameOver = true;
					if(newHead.X == snakeFood.X && newHead.Y == snakeFood.Y) {
						if(snake.Count + 1 >= boardWidth * boardHeight)
							// No more room to place apples - game over.
							gameOver = true;
						else {
							while(true) {
								snakeFood.X = rand.Next(0, boardWidth); snakeFood.Y = rand.Next(0, boardHeight);
								bool found = true;
								foreach(Point i in snake)
									if(i.X == snakeFood.X && i.Y == snakeFood.Y) {
										found = false;
										break;
									}
								if(found) {
									inUse = true;
									break;
								}
							}
						}
					}
					if(!inUse) {
						snake.RemoveAt(0);
						foreach(Point x in snake)
							if(x.X == newHead.X && x.Y == newHead.Y) {
								// Death by accidental self-cannibalism.
								gameOver = true;
								break;
							}
					}
					if(!gameOver) {
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(head.X, head.Y); Console.Write("0");
						if(!inUse) {
							Console.SetCursorPosition(tail.X, tail.Y); Console.Write(" ");
						} else {
							Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(snakeFood.X, snakeFood.Y); Console.Write("$");
							inUse = false;
						}
						snake.Add(newHead);
						Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(newHead.X, newHead.Y); Console.Write("@");
						last = _newDir;
					}
				}

			}
		}


		private bool IsFoodInSnake() {

		}

	}
}
