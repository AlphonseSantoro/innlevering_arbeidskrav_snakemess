using System.Collections.Generic;

namespace SnakeMess{
	public class Item{

		public Coordinate Coord{ get; set; }
		public char Icon{ get; set; }

		public Item(int x, int y, Marker marker){
			this.Icon = Markers.GetMarker(marker);
			Coord = new Coordinate(x, y);
		}
		
		public Item(int x, int y, char icon) {
			this.Icon = icon;
			Coord = new Coordinate(x, y);
		}
		

		public static bool operator ==(Item item1, Item item2){
			if (item1.Coord == item2.Coord)
				return true;
			return false;
		}

		public static bool operator !=(Item item1, Item item2){
			if (item1.Coord != item2.Coord)
				return true;
			return false;
		}

		public override bool Equals(object obj) {
			var item = obj as Item;
			return item != null &&
				   EqualityComparer<Coordinate>.Default.Equals(Coord, item.Coord) &&
				   Icon == item.Icon;
		}

		public override int GetHashCode() {
			var hashCode = 138354766;
			hashCode = hashCode * -1521134295 + EqualityComparer<Coordinate>.Default.GetHashCode(Coord);
			hashCode = hashCode * -1521134295 + Icon.GetHashCode();
			return hashCode;
		}
	}
}
