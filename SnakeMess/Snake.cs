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

        public void move(GameController.MoveDirection direction){
            
            switch (direction){
                case GameController.MoveDirection.UP:
                    moveHead(0, -1);
                    break;
                case GameController.MoveDirection.DOWN:
                    moveHead(0, 1);
                    break;
                case GameController.MoveDirection.LEFT:
                    moveHead(-1, 0);
                    break;
                case GameController.MoveDirection.RIGHT:
                    moveHead(1, 0);
                    break;
            }

        }

        private void moveHead(int x, int y){
            tail = snakeParts.First();
            head = snakeParts.Last();
            newHead = new SnakePart(head.getX() + x, head.getY() + y, Marker.HEAD);
            head.marker = Marker.BODY;
        }

        public List<SnakePart> getSnakeParts(){
            return snakeParts;
        }

        public void addPart(int x, int y, Marker marker){
            snakeParts.Add(new SnakePart(x,y, marker));
        }
        
        public bool IsFoodInSnake(Food food){
            foreach(SnakePart part in snakeParts){
                if(part == food) return true;
            }
            return false;
        }
        
        private bool IsItemInSnake(Item item) {
            for(int i = 0; i < snakeParts.Count-2; i++){
                if(snakeParts[i] == item) return true;
            }
            return false;
        }

        public bool Collide(){
            if (IsItemInSnake(snakeParts.Last())) return true;
            if (snakeParts.Last().getX() < 0 || snakeParts.Last().getY() < 0 ||
                snakeParts.Last().getX() > GameController.windowWidth ||
                snakeParts.Last().getY() > GameController.windowHeight){
                return true;
            }
            return false;
        }
    }
}
