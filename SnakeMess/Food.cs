using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    public class Food : Item {

	    private static Random rand = new Random();

	    public Food() : base(randInt(true), randInt(false), Markers.GetMarker(Marker.FOOD)) { }
	    public Food(int x, int y) : base(x, y, Markers.GetMarker(Marker.FOOD)) { }

	    private static int randInt(bool isWidth) {
		    if(isWidth)
			    return rand.Next(0, GameController.windowWidth);
		    else
			    return rand.Next(0, GameController.windowHeight);
		}

	    public void Draw() {
		    Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(Coord.X, Coord.Y);
			Console.Write(icon);
	    }

    }


}
