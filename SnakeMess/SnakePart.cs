namespace SnakeMess {
    public class SnakePart : Item {

        public SnakePart(int x, int y, Marker marker) : base(x, y, marker){}
	    public SnakePart(SnakePart sp) : base(sp.Coord.X, sp.Coord.Y, sp.Icon) { }
	    public SnakePart(SnakePart sp, Marker marker) : base(sp.Coord.X, sp.Coord.Y, marker) { }

    }
}
