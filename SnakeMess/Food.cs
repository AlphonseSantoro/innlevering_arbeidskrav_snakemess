﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    class Food : Item {

        public Food(int x, int y, Marker marker=Marker.FOOD) : base(x, y, marker) { }
    }


}
