using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    class Food : Item {

	    private static Random rand = new Random();

	    public Food() : base(randInt(true), randInt(false), Marker.FOOD) { }

	    private static int randInt(bool isWidth) {
		    if(isWidth)
			    return rand.Next(0, GameController.windowWidth);
		    else
			    return rand.Next(0, GameController.windowHeight);
		}

    }


}
