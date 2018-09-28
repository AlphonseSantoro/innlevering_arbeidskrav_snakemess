using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    class SnakePart : Item {

        public SnakePart(int x, int y, Marker marker=Marker.PART) : base(x, y, marker){}
    }
}
