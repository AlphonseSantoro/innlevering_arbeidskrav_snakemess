using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
	public class Coordinate {
		
		public int X { get; set; }
		public int Y { get; set; }

		public Coordinate() {
			Random rand = new Random();
			X = rand.Next(0, GameController.windowWidth);
			Y = rand.Next(0, GameController.windowHeight);
		}

		public Coordinate(int x, int y) {
			X = x;
			Y = y;
		}

		public static bool operator ==(Coordinate coord1, Coordinate coord2) {
			if(coord1.X == coord2.X && coord1.Y == coord2.Y) {
				return true;
			}
			return false;
		}

		public static bool operator !=(Coordinate coord1, Coordinate coord2) {
			if(coord1.X != coord2.X || coord1.Y != coord2.Y) {
				return true;
			}
			return false;
		}

	}
}
