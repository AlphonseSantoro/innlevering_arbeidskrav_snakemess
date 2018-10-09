using System;

namespace SnakeMess {
    public class Food : Item {

	    private static Random _rand = new Random();

	    public Food() : base(RandInt(true), RandInt(false), Marker.FOOD) { }
	    public Food(int x, int y) : base(x, y, Marker.FOOD) { }

		//Generate a random number, used to pick a random spawn point for the food
	    private static int RandInt(bool isWidth) {
		    if(isWidth)
			    return _rand.Next(0, GameController.windowWidth);
		    else
			    return _rand.Next(0, GameController.windowHeight);
		}

	    public void Draw() {
			Output.SetColor(ConsoleColor.Green);
			Output.Draw(Coord.X, Coord.Y, Icon);
	    }

    }


}
