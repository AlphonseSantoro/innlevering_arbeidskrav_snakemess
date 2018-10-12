using System;

namespace SnakeMess {
	class Output {


		public static void CursorVisible(bool input) {
			Console.CursorVisible = input;
		}

		public static void Title(string title) {
			Console.Title = title;
		}

		public static void Draw(int x, int y, char icon) {
			Console.SetCursorPosition(x, y);
			Console.Write(icon);
		}

		public static void SetColor(ConsoleColor color) {
			Console.ForegroundColor = color;
		}


	}
}
