using System;
using System.Diagnostics;

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
			Output.CursorVisible(false);
			Output.Title("Høyskolen Kristiania - SNAKE");
			GameLoop();
		}
		
		

		private void GameLoop() {
			_t.Start();

			//Game loops that loops untill its game over
			while(!gameOver) {
				//Check for player input
				CheckKeyPress();

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
				}

			}
		}

		
		private void CheckKeyPress() {
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
		}


	}
}
