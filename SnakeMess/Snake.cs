using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    class Snake {
        List<SnakePart> snakeParts = new List<SnakePart>();
        public SnakePart head{ get; private set; }
        public SnakePart tail{ get; private set; }

        public Snake(int startX = 10, int startY = 10, int length = 4){

        }

        public List<SnakePart> getSnakeParts(){
            return snakeParts;
        }

        public void addPart(){
            return new SnakePart();
        }




    }
}
