namespace SnakeMess {

	public enum Marker {
		HEAD,
		BODY,
		TAIL,
		FOOD
	}

	public class Markers {

		public static readonly char HEAD = '@';
		public static readonly char BODY = '0';
		public static readonly char TAIL = ' ';
		public static readonly char FOOD = '$';

		public static char GetMarker(Marker marker) {
			switch(marker) {
			case Marker.HEAD:
				return HEAD;
			case Marker.BODY:
				return BODY;
			case Marker.TAIL:
				return TAIL;
			case Marker.FOOD:
				return FOOD;
			}
			return '-';
		}
	}
}
