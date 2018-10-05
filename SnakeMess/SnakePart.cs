namespace SnakeMess {
    public class SnakePart : Item {

        public SnakePart(int x, int y, char marker) : base(x, y, marker){}
	    public SnakePart(SnakePart sp) : base(sp.Coord.X, sp.Coord.Y, sp.Icon) { }
	    public SnakePart(SnakePart sp, char marker) : base(sp.Coord.X, sp.Coord.Y, marker) { }

    }
}
