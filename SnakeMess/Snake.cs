using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    class Snake {
        List<SnakePart> snakeParts = new List<SnakePart>();
        public SnakePart head{ get; private set; }
        public SnakePart newHead { get; private set; }
        public SnakePart tail{ get; private set; }
        

        public Snake(int startX = 10, int startY = 10, int length = 4){
            for (int i = 0; i < length-1; i++){
                addPart(startX, startY-i, Marker.BODY);
            }
            addPart(startX, startY, Marker.HEAD);
        }

        //FIX NEW VALUE FOR NEW HEAD X and Y
        public void move(GameController.MoveDirection direction){
            tail = snakeParts.First();
            head = snakeParts.Last();
            newHead = new SnakePart(head.getX(), head.getY(), Marker.HEAD);
            head.marker = Marker.BODY;
            switch (direction){
                case GameController.MoveDirection.UP:
                    break;
                case GameController.MoveDirection.DOWN:
                    break;
                case GameController.MoveDirection.LEFT:
                    break;
                case GameController.MoveDirection.RIGHT:
                    break;
            }

        }


        

        public List<SnakePart> getSnakeParts(){
            return snakeParts;
        }

        public void addPart(int x, int y, Marker marker){
            snakeParts.Add(new SnakePart(x,y, marker));
        }
        
        private bool IsFoodInSnake(Food food) {
            foreach(SnakePart part in snakeParts){
                if(part == food) return true;
            }
            return false;
        }
    }
}
