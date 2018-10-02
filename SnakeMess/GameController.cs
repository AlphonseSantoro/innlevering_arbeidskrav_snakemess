using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SnakeMess {

	public enum MoveDirection {
		LEFT, RIGHT, UP, DOWN
	}

	public class GameController {


		public static readonly int windowWidth = Console.WindowWidth;
		public static readonly int windowHeight = Console.WindowHeight;
		public static bool gameOver = false;
		public static bool gamePaused = false;

		private MoveDirection _newDir = MoveDirection.RIGHT;
		private MoveDirection _lastDir;
		private Snake _snake;
		private Food _food;
		private Stopwatch _t;

		public GameController() {
			_snake = new Snake();
			_food = new Food(14, 10);
			_t = new Stopwatch();
			Console.CursorVisible = false;
			Console.Title = "Høyskolen Kristiania - SNAKE";
			GameLoop();
		}

		

		private void GameLoop() {
			_t.Start();

			//Game loops that loops untill its game over
			while(!gameOver) {

				if(Console.KeyAvailable) {
					ConsoleKeyInfo consoleKeyinfo = Console.ReadKey(true);
					//Detect diffrent key presses
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
					//Game speed delay
					if(_t.ElapsedMilliseconds < 100)
						continue;
					_t.Restart();
					_lastDir = _newDir;

					//Draw food
					_food.Draw();

					//Move snake
					_snake.Move(_newDir);

					//Check for death
					if(_snake.Collide()) {
						gameOver = true;
						break;
					}

					//Draw snake
					_snake.DrawSnake();
					

					//If snake is on top of food, eat it
					if(_snake.IsFoodInSnake(_food)) {
						_snake.Eat();
						_food = new Food();
					}
					//While food is inside snake, respawn it
					while(true) {
						if(_snake.IsFoodInSnake(_food)) {
							_food = new Food();
						} else {
							break;
						}
					}
					

					/*

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
					*/
				}

			}
		}







	}
}
