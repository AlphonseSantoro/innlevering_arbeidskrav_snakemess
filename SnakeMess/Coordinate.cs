using System;

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

		public override bool Equals(object obj) {
			var coordinate = obj as Coordinate;
			return coordinate != null &&
				   X == coordinate.X &&
				   Y == coordinate.Y;
		}

		public override int GetHashCode() {
			var hashCode = 1861411795;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			return hashCode;
		}
	}
}
