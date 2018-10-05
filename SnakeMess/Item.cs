namespace SnakeMess{
	public class Item{
		public Coordinate Coord{ get; set; }
		public char icon{ get; set; }

		public Item(int x, int y, char icon){
			this.icon = icon;
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
	}
}
