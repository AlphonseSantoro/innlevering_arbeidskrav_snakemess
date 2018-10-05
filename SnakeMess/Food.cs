using System;

namespace SnakeMess {
    public class Food : Item {

	    private static Random _rand = new Random();

	    public Food() : base(RandInt(true), RandInt(false), Markers.GetMarker(Marker.FOOD)) { }
	    public Food(int x, int y) : base(x, y, Markers.GetMarker(Marker.FOOD)) { }

	    private static int RandInt(bool isWidth) {
		    if(isWidth)
			    return _rand.Next(0, GameController.windowWidth);
		    else
			    return _rand.Next(0, GameController.windowHeight);
		}

	    public void Draw() {
		    Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(Coord.X, Coord.Y);
			Console.Write(Icon);
	    }

    }


}
